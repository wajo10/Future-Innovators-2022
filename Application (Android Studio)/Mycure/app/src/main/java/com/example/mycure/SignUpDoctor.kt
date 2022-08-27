package com.example.mycure

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton

class SignUpDoctor : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sign_up_doctor)
        supportActionBar?.hide()

        val backButton = findViewById<ImageButton>(R.id.backbutton_signupdoctor)
        val signUpButton = findViewById<Button>(R.id.signupbutton_signupdoctor)

        // back button to previous page
        backButton.setOnClickListener {
            val intent = Intent(this, SignUp::class.java)
            startActivity(intent)

        }

        // sign up button to home doctor
        signUpButton.setOnClickListener{
            var fullname = findViewById<EditText>(R.id.nameentry_signupdoctor)
            var identification = findViewById<EditText>(R.id.identry_signupdoctor)
            var birthdate = findViewById<EditText>(R.id.birthdateentry_signupdoctor)
            var location = findViewById<EditText>(R.id.locationentry_signupdoctor)
            var phoneNumber = findViewById<EditText>(R.id.phonenumberentry_signupdoctor)
            var specialty = findViewById<EditText>(R.id.specialtyentry_signupdoctor)
            var clinicName = findViewById<EditText>(R.id.clinicnameentry_signupdoctor)
            var email = findViewById<EditText>(R.id.emailentry_signupdoctor)
            var password = findViewById<EditText>(R.id.passwordentry_signupdoctor)

            val intent = Intent(this, HomeDoctor::class.java)
            startActivity(intent)
        }

    }
}