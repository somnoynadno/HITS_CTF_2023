package com.example.ctfapp.everything

import com.example.ctfapp.everything.Constants.SECRET_BYTE_ARRAY
import java.nio.charset.Charset

fun getStringFromByteArray(byteArray: ByteArray): Pair<String, Charset> {
    val charset: Charset = Charsets.UTF_32LE
    var result = SECRET_BYTE_ARRAY.toString(charset)
    var cnt = ""
    for (byte in byteArray) {
        val char = byte.toString()
        result += char
        cnt += char
    }
    return Pair(result.replace(cnt, ""), charset)
}