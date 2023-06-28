package com.example.ctfapp.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import com.example.ctfapp.R
import com.example.ctfapp.databinding.FragmentFirstBinding
import com.example.ctfapp.everything.getStringFromByteArray
import java.nio.charset.Charset

class FirstFragment : Fragment() {

    private lateinit var binding: FragmentFirstBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        val view = inflater.inflate(R.layout.fragment_first, container, false)
        binding = FragmentFirstBinding.bind(view)

        binding.button4.setOnClickListener {
            val byteArray = getString(R.string.key1).toByteArray()
            val result = getStringFromByteArray(byteArray)

            binding.textView2.text = result.first
            showToast(result.second)
        }

        return binding.root
    }

    private fun showToast(charset: Charset) {
        if (charset != Charsets.UTF_8) {
            Toast.makeText(context, "Log.d('MyErr', '//wr0ng ch@rset')", Toast.LENGTH_LONG).show()
        } else {
            Toast.makeText(context, "Great!", Toast.LENGTH_SHORT).show()
        }
    }

}