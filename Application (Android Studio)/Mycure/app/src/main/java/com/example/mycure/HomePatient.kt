package com.example.mycure

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.ImageButton

class HomePatient : AppCompatActivity() {
    @SuppressLint("WrongViewCast")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home_patient)
        supportActionBar?.hide()

        val profileButton = findViewById<ImageButton>(R.id.profilebutton_homepatient)

        profileButton.setOnClickListener {
            val intent = Intent(this, ProfilePatient::class.java)
            startActivity(intent)
        }


    }
}