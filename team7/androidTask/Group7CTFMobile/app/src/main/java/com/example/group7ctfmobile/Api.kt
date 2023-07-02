package com.example.group7ctfmobile

import retrofit2.http.Body
import retrofit2.http.POST

interface Api {
    @POST("api/web")
    suspend fun signIn(@Body body: SignInDto): TokenDto
}