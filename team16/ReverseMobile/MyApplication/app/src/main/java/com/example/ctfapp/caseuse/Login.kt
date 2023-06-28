package com.example.ctfapp.caseuse

import com.example.ctfapp.network.OurSuperCoolApi
import com.example.ctfapp.network.stuff.CredsDto

class Login(private val api: OurSuperCoolApi) {
    suspend operator fun invoke(dto: CredsDto) {
        api.login(dto)
    }
}