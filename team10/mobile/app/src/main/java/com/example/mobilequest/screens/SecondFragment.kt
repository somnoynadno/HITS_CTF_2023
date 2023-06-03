package com.example.mobilequest.screens

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import androidx.fragment.app.Fragment
import androidx.navigation.fragment.findNavController
import com.example.mobilequest.R
import com.example.mobilequest.databinding.FragmentFirstBinding

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
private const val ARG_PARAM1 = "param1"
private const val ARG_PARAM2 = "param2"


private lateinit var binding: FragmentFirstBinding

/**
 * A simple [Fragment] subclass.
 * Use the [SecondFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class SecondFragment : Fragment() {
    // TODO: Rename and change types of parameters
    private var param1: String? = null
    private var param2: String? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        arguments?.let {
            param1 = it.getString(ARG_PARAM1)
            param2 = it.getString(ARG_PARAM2)
        }
    }

    override fun onCreateView(
        inflater: LayoutInflater, container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View {
        val mainView = inflater.inflate(R.layout.fragment_first, container, false)
        binding = FragmentFirstBinding.bind(mainView)

        setOnSendButtonClickListener()
        setOnClueButtonClickListener()

        return binding.root
    }

    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment SecondFragment.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance(param1: String, param2: String) =
            SecondFragment().apply {
                arguments = Bundle().apply {
                    putString(ARG_PARAM1, param1)
                    putString(ARG_PARAM2, param2)
                }
            }
    }

    private fun setOnSendButtonClickListener() {
        binding.button.setOnClickListener {
            if (binding.editTextTextPersonName.text.toString() == getString(R.string.you_were_not_supposed_to_see_me_i_am_password)) {
                findNavController().navigate(R.id.action_secondFragment_to_firstFragment)
            }
            else {
                val text = "Попробуй поискать усерднее"
                val duration = Toast.LENGTH_SHORT

                val toast = Toast.makeText(context, text, duration)
                toast.show()
                binding.editTextTextPersonName.setText("")
            }
        }
    }

    private fun setOnClueButtonClickListener() {
        binding.button2.setOnClickListener {
            val text = "Может стоит заглянуть в ресурсы?"
            val duration = Toast.LENGTH_SHORT

            val toast = Toast.makeText(context, text, duration)
            toast.show()
        }
    }
}