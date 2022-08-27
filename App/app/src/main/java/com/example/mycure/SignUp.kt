package com.example.mycure

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText

class SignUp : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sign_up)
        supportActionBar?.hide()

        val userType = 0
        val backButton = findViewById<Button>(R.id.backButtonSignUp)
        val signUpButton = findViewById<Button>(R.id.signupButtonSignUp)
        val fullnameEntry = findViewById<EditText>(R.id.fullnameEntrySignUp)
        val phoneNumberEntry = findViewById<EditText>(R.id.phoneNumberEntrySignUp)
        val birthdateEntry = findViewById<EditText>(R.id.birthdateEntrySignUp)
        val locationEntry = findViewById<EditText>(R.id.locationEntrySignUp)
        val passwordEntry = findViewById<EditText>(R.id.passwordEntrySignUp)

        backButton.setOnClickListener((View.OnClickListener {
            val intent = Intent(this, MainActivity::class.java)
            startActivity(intent)
        }))

        signUpButton.setOnClickListener((View.OnClickListener {
            // get string values from entries
            var fullnameString = fullnameEntry.text.toString()
            var phoneNumberString = phoneNumberEntry.text.toString()
            var birthdateString = birthdateEntry.text.toString()
            var locationString = locationEntry.text.toString()
            var passwordString = passwordEntry.text.toString()

            // go to home
            if(userType==1){
                val intent = Intent(this, HomePatient::class.java)
                startActivity(intent)
            }

            if(userType==2){
                val intent = Intent(this, HomeDoctor::class.java)
                startActivity(intent)
            }

        }))


    }
}