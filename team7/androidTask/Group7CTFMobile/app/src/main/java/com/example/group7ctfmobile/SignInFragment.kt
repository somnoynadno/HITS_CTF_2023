package com.example.group7ctfmobile

import android.os.Bundle
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.viewModels
import androidx.navigation.fragment.findNavController
import com.example.group7ctfmobile.databinding.FragmentSignInBinding

class SignInFragment : Fragment() {

    private var _binding: FragmentSignInBinding? = null
    private val binding get() = _binding!!

    private val viewModel: SignInViewModel by viewModels()

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        _binding = FragmentSignInBinding.inflate(inflater, container, false)
        return binding.root
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        binding.enter.setOnClickListener {
            viewModel.signIn(
                binding.emailInput.text.toString(),
                binding.baseURL.text.toString(),
                requireContext()
            )
        }

        viewModel.isEnter.observe(viewLifecycleOwner) {
            if (it == true) {
                Toast.makeText(
                    requireContext(), "Запрос на вход успешен, вы получили...", Toast.LENGTH_SHORT
                ).show()
                findNavController().navigate(R.id.action_signInFragment_to_mainFragment)
                viewModel.setDefault()
            }
        }
        viewModel.error.observe(viewLifecycleOwner) {
            if (it.first) {
                Toast.makeText(requireContext(), it.second, Toast.LENGTH_SHORT).show()
                viewModel.setDefault()
            }
        }
    }
}