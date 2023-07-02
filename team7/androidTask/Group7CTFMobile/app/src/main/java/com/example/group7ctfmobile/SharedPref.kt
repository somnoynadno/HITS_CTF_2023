package com.example.group7ctfmobile

import android.content.Context

class SharedPref(context: Context) {
    private val preferences = context.getSharedPreferences(PREFERENCE_NAME, Context.MODE_PRIVATE)

    fun getString(key: String): String? {
        return preferences.getString(key, "")
    }

    fun setString(key: String, value: String) {
        val editor = preferences.edit()
        editor.putString(key, value)
        editor.apply()
    }

    companion object {
        const val PREFERENCE_NAME = "pref"
        const val ACCESS_TOKEN = "token"
    }

}