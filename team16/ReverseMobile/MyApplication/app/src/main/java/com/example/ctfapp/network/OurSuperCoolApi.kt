package com.example.ctfapp.network

import com.example.ctfapp.network.stuff.CredsDto
import com.example.ctfapp.network.stuff.FlagDto
import com.example.ctfapp.network.stuff.TokenDto
import retrofit2.http.Body
import retrofit2.http.GET
import retrofit2.http.Header
import retrofit2.http.POST

interface OurSuperCoolApi {
    @POST("login")
    suspend fun login(
        @Body body: CredsDto
    ): TokenDto

    @GET("flag")
    suspend fun getFlag(
        @Header("Authorization") token: String,
    ): FlagDto
}