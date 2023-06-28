package com.example.ctfapp.fragments

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.navigation.fragment.findNavController
import com.example.ctfapp.R
import com.example.ctfapp.databinding.FragmentMainBinding

class MainFragment : Fragment() {

    private lateinit var binding: FragmentMainBinding

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        val view = inflater.inflate(R.layout.fragment_main, container, false)
        binding = FragmentMainBinding.bind(view)

        setOnButtonClickListeners()

        return binding.root
    }

    private fun setOnButtonClickListeners() {
        setOnFirstButtonClickListener()
        setOnSecondButtonClickListener()
        setOnThirdButtonClickListener()
    }

    private fun setOnFirstButtonClickListener() {
        binding.btFirst.setOnClickListener {
            val action = MainFragmentDirections.actionMainFragmentToFirstFragment()
            findNavController().navigate(action)
        }
    }

    private fun setOnSecondButtonClickListener() {
        binding.btSecond.setOnClickListener {
            val action = MainFragmentDirections.actionMainFragmentToThirdFragment()
            findNavController().navigate(action)
        }
    }

    private fun setOnThirdButtonClickListener() {
        binding.btThird.setOnClickListener {
            val action = MainFragmentDirections.actionMainFragmentToSecondFragment()
            findNavController().navigate(action)
        }
    }

}