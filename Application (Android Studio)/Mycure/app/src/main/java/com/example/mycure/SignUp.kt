package com.example.mycure

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.ImageButton
import android.widget.ImageView

class SignUp : AppCompatActivity() {
    @SuppressLint("WrongViewCast")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sign_up)
        supportActionBar?.hide()

        val backButton = findViewById<ImageButton>(R.id.backbutton_signup)
        val patientButton = findViewById<Button>(R.id.patientbutton_signup)
        val doctorButton = findViewById<Button>(R.id.doctorbutton_signup)

        // back button to log in page
        backButton.setOnClickListener {
            val intent = Intent(this, LogIn::class.java)
            startActivity(intent)
        }

        // patient button to patient sign up page
        patientButton.setOnClickListener {
            val intent = Intent(this, SignUpPatient::class.java)
            startActivity(intent)
        }

        // doctor button to doctor sign up page
        doctorButton.setOnClickListener {
            val intent = Intent(this, SignUpDoctor::class.java)
            startActivity(intent)
        }


    }
}