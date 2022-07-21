package com.example.mycure

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import android.widget.EditText

class LogIn : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_log_in)
        supportActionBar?.hide()

        val backButton = findViewById<Button>(R.id.backButtonLogIn)
        val logInButton = findViewById<Button>(R.id.loginButtonLogIn)
        val emailEntry = findViewById<EditText>(R.id.emailEntryLogIn)
        val passwordEntry = findViewById<EditText>(R.id.passwordEntryLogIn)

        // back button (goes back to main)
        backButton.setOnClickListener ((View.OnClickListener {
            val intent = Intent(this, MainActivity::class.java)
            startActivity(intent)
        }))

        // log in button (goes to home page and gets info)
        logInButton.setOnClickListener((View.OnClickListener {
            // get string values from entries
            var emailString = emailEntry.text.toString()
            var passwordString = passwordEntry.text.toString()

            // go to home page
            val intent = Intent(this, HomePatient::class.java)
            startActivity(intent)
        }))

    }
}