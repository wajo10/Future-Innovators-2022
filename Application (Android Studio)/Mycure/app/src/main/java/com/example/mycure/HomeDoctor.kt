package com.example.mycure

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle

class HomeDoctor : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home_doctor)
        supportActionBar?.hide()


    }
}