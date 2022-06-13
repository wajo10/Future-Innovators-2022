package com.example.mycure

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button

class MainActivity : AppCompatActivity() {
    @SuppressLint("WrongViewCast")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        supportActionBar?.hide()

        val logInButton = findViewById<Button>(R.id.logInButton)
        logInButton.setOnClickListener (View.OnClickListener {
            val intent = Intent(this, LogIn::class.java)
            startActivity(intent)
        })

        val signUpButton = findViewById<Button>(R.id.signUpButton)
        signUpButton.setOnClickListener(View.OnClickListener {
            val intent = Intent(this, SignUp::class.java)
            startActivity(intent)
        })
    }

}