package com.example.mobilequest.screens

import android.os.Bundle
import android.util.Log
import androidx.fragment.app.Fragment
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.Toast
import com.example.mobilequest.R
import com.example.mobilequest.databinding.FragmentSecondBinding

// TODO: Rename parameter arguments, choose names that match
// the fragment initialization parameters, e.g. ARG_ITEM_NUMBER
private const val ARG_PARAM1 = "param1"
private const val ARG_PARAM2 = "param2"

private const val PRIVATE_KEY = "MIICWwIBAAKBgHwRH0+O1KvsscDEs8EC73LPg5RlEFPPirasOvL39iCjgOTgAbLDn4ETy7DKkaAYMBk1p8HTC6loREZC5Zd6NP4nYWeB5PiVmZQVFRaWXr5N4ZjzmPWTJvVxYjcd93ja0Kzq+MxP81ZX1p6y28mKk1fIp3afKgRYzWxYKnW1k3fPAgMBAAECgYBr9mJu0vYSniiYfROHVEyWdiokSkYJCMPG7t1lbY3LHT0e7ifMLhtxMY7BS6Wp0SKZ7W0MZ+DwDIHNOo2cYYYWnA0E7t67zLp1ARAF7UgOr/44pOBoi6tEy9AtKu5MYFX3HBQFlklprCWyRgF/BHagBfBozCUUJxbkdAfswPkMkQJBAObDMi5P4/DyyuTw0I8hCOIeXy9YDPFgQevcFEk3y6hq6AEUZe69pd8tXm88WBVH8YN92KXpZOrnpUqmWov+Kv0CQQCJorOkx0f2WQNUepuiUovPFpAlOe04HjtnViL/JNvTCNfbQN8+2z9z4PufK3banmoVSpbHrY6mLumF7HWwmaW7AkAdECx7xLgSmqGPH/1EaYay49xdHBvVMqhaykcLyakutvgtWqJT5TLE3vPr0o/NblgulWT50GFTbIVW14jD5OkJAkAnxaZXxWZcH5jAvrVekK/p5cE9oKGWB9ZupAt04zfKodGOgA6C4WRSnf7YHf04a3KIOIedp9+C0ieVFaFkqOGlAkEAvZ4e7Klk7rMSAIgT1nu1jNSQqMsH6915b3ZmezFox9jRECL0TyBxdob4Xi+ldaxl1cx7YKfp3uIaw5VsbH1dcg=="

private lateinit var binding: FragmentSecondBinding
/**
 * A simple [Fragment] subclass.
 * Use the [FirstFragment.newInstance] factory method to
 * create an instance of this fragment.
 */
class FirstFragment : Fragment() {
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
        val mainView = inflater.inflate(R.layout.fragment_second, container, false)
        binding = FragmentSecondBinding.bind(mainView)

        setOnClueButtonClickListener()
        Log.d("PrivateKey", PRIVATE_KEY)
        Log.d("Message", binding.textView2.text.toString())

        return binding.root
    }

    companion object {
        /**
         * Use this factory method to create a new instance of
         * this fragment using the provided parameters.
         *
         * @param param1 Parameter 1.
         * @param param2 Parameter 2.
         * @return A new instance of fragment FirstFragment.
         */
        // TODO: Rename and change types and number of parameters
        @JvmStatic
        fun newInstance(param1: String, param2: String) =
            FirstFragment().apply {
                arguments = Bundle().apply {
                    putString(ARG_PARAM1, param1)
                    putString(ARG_PARAM2, param2)
                }
            }
    }

    private fun setOnClueButtonClickListener() {
        binding.button3.setOnClickListener {
            val text = "Logs?"
            val duration = Toast.LENGTH_SHORT

            val toast = Toast.makeText(context, text, duration)
            toast.show()
        }
    }

}