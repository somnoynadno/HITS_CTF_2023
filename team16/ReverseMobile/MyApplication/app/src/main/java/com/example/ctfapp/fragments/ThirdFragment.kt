package com.example.ctfapp.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import com.example.ctfapp.R
import com.example.ctfapp.caseuse.Login
import com.example.ctfapp.databinding.FragmentThirdBinding
import com.example.ctfapp.everything.Constants.BASE_URL
import com.example.ctfapp.network.OurSuperCoolApi
import com.example.ctfapp.network.stuff.CredsDto
import kotlinx.coroutines.GlobalScope
import kotlinx.coroutines.MainScope
import kotlinx.coroutines.launch
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory

class ThirdFragment : Fragment() {

    private val retrofit: OurSuperCoolApi = Retrofit.Builder()
        .baseUrl(BASE_URL)
        .addConverterFactory(GsonConverterFactory.create())
        .build()
        .create(OurSuperCoolApi::class.java)

    private val doLogin: Login = Login(retrofit)
    private lateinit var binding: FragmentThirdBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_third, container, false)
        binding = FragmentThirdBinding.bind(view)

        binding.button.setOnClickListener {
            val login = binding.editTextTextPersonName.text.toString()
            val password = binding.editTextTextPassword.text.toString()
            if (login != getString(R.string.secret_login) || password != getString(R.string.secret_password)) {
                login(login, password)
            } else {
                getFlag(login, password)
            }
        }

        return binding.root
    }

    private fun login(login: String, password: String) {
        try {
            GlobalScope.launch {
                doLogin(
                    CredsDto(login, password)
                )
            }
        } catch (ex: Exception) {
            Toast.makeText(context, "oh no, wrong creds :-(", Toast.LENGTH_SHORT).show()
        }
    }

    private fun getFlag(login: String, password: String) {
        // need to implement this later
        // but still you can get this flag by another way
        // ;-)
    }

}