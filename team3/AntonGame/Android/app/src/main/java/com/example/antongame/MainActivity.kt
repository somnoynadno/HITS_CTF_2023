package com.example.antongame

import android.os.Bundle
import android.webkit.WebResourceRequest
import android.webkit.WebView
import android.webkit.WebViewClient
import androidx.appcompat.app.AppCompatActivity
import com.example.antongame.databinding.ActivityMainBinding


class MainActivity : AppCompatActivity() {
    private lateinit var binding: ActivityMainBinding

    private val url = "http://158.160.62.132:7004/"
    private val FERNET_KEY = "gNVoRkn46rMECawSZcbEvLeypU1EDsQE_9Z_ahzNYt8="
    val rsaPrivateKey = "MIICdwIBADANBgkqhkiG9w0BAQEFAASCAmEwggJdAgEAAoGBAM+EWjeK8+JnJfR/vQBCCx2bVi5x504stm12DUDk9hCl+EnTQ9HzRmk527iX+6EARDBesBbtzz9kSLFSmPGyrb+UOW3BEwU9caUWRjGl1sYHVZGbZ5aRSyDWsZEJ3JGjFFxU7Pt3TekI1jlYqSit9037w7tkRPtj23hZuHS2XAZjAgMBAAECgYEAyNHudJ3V0p27j1cm0l8XXrl6t0unanG+wUNjJA/vSME0/Eyk70KcOyyww3zhGDenxZ98jVPqIhCsgF3MgOpHVMRsbeI7p5TS00KPNgRw9rG3l4uXFw8B9tMXg4kw3T5PJoKj39dg4dXbv7Znzy095S53j2opHcAbui3x9qfoGcECQQD/V8YmpeIHLMi5qbVLUKA88zWnWs1LtQltFDXhMoyTELkN0NrIuEvY8WUtVylQKm9cKlGygPgTqyL3Q5nVxgkzAkEA0A0RzsfvLh8tFdN78XvC4vkfrRxZIXKk3J61tbZenE/LWC65x5VTmXsqCkWRInnpJBa+yLLbvjNPr7rSCbjuEQJACEyAAi2OBRGtjGs5mzMJojF9Yu0OkxFVNxhbD/CmpPj8KrjJA5EJ1gkycqDMlPBsIiC1+wk6BtmfD05BJ7OCBQJBAIJmvrOhwztgVQzqGjR4guVqij0hmIgLaGPTokb7wH8u0GA8ITuET/rSJL59bgNy7/srunbnDC5B0P9vFDj9zVECQHr1KU5HmOR7VcopCOE7BdFIPSS/R8fJipm1PdqKOTLHTvbm80gCBL2FQmfNY1thaDSvWptFg6hB9irOjXdQZVU="

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        binding = ActivityMainBinding.inflate(layoutInflater)
        setContentView(binding.root)

        binding.webView.webViewClient = object : WebViewClient(){
            override fun shouldOverrideUrlLoading(
                view: WebView?,
                request: WebResourceRequest
            ): Boolean {
                val headerMap = HashMap<String, String>()
                headerMap["User-Agent"] = "Android"
                if (request.url.toString() == url + "") { // rsa task todo(need to finish)
                    TODO("Not Implemented")
                }

                if (request.url.toString() == url + "") { // fernet task todo(need to finish)
                    TODO("Not Implemented")
                }
                return false
            }
        }

        binding.webView.loadUrl(url)
    }
}