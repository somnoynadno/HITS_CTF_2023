package com.example.group7ctfmobile

import android.content.Context
import android.util.Patterns
import androidx.lifecycle.LiveData
import androidx.lifecycle.MutableLiveData
import androidx.lifecycle.ViewModel
import androidx.lifecycle.viewModelScope
import com.jakewharton.retrofit2.converter.kotlinx.serialization.asConverterFactory
import kotlinx.coroutines.launch
import kotlinx.serialization.json.Json
import okhttp3.MediaType.Companion.toMediaType
import okhttp3.OkHttpClient
import okhttp3.logging.HttpLoggingInterceptor
import retrofit2.Retrofit
import java.lang.Exception

class SignInViewModel : ViewModel() {

    private val _isEnter = MutableLiveData(false)
    val isEnter: LiveData<Boolean> = _isEnter

    private val _error = MutableLiveData(Pair<Boolean, String?>(false, null))
    val error: LiveData<Pair<Boolean, String?>> = _error

    fun signIn(email: String, url: String, context: Context) {
        if (email.isEmpty() || url.isEmpty()) {
            _error.value = Pair(true, "Заполните все поля")
        }
        if (!Patterns.EMAIL_ADDRESS.matcher(email).matches()) {
            _error.value = Pair(true, "Неверный формат почты")
        }
        var baseUrl = url
        if (url.last() != '/') {
            baseUrl = "$url/"
        }
        viewModelScope.launch {
            val sharedPref = SharedPref(context)
            val client = OkHttpClient.Builder().apply {
                val logLevel = HttpLoggingInterceptor.Level.BODY
                addInterceptor(HttpLoggingInterceptor().setLevel(logLevel))
                addInterceptor(AuthInterceptor(sharedPref))
            }.build()
            val api = Retrofit.Builder()
                .baseUrl(baseUrl)
                .addConverterFactory(Json.asConverterFactory("application/json".toMediaType()))
                .client(client)
                .build()
                .create(Api::class.java)

            try {
                val token = api.signIn(SignInDto(email))

                sharedPref.setString(SharedPref.ACCESS_TOKEN, token.token)

                _isEnter.value = true
            } catch (e: Exception) {
                _error.value = Pair(true, e.message)
            }
        }
    }

    fun setDefault() {
        _isEnter.value = false
        _error.value = Pair(false, null)
    }
}