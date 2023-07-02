package com.example.group7ctfmobile

import okhttp3.Interceptor
import okhttp3.Response

class AuthInterceptor(
    private val sharedPref: SharedPref
) : Interceptor {
    override fun intercept(chain: Interceptor.Chain): Response {

        val token = sharedPref.getString(SharedPref.ACCESS_TOKEN)

        val request = chain.request().newBuilder().apply {
            token?.let {
                addHeader("Authorization", "Bearer $it")
            }
        }.build()
        return chain.proceed(request)
    }
}
