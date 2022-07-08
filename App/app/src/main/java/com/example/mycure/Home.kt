package com.example.mycure

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button

class Home : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home)
        supportActionBar?.hide()

        val backButton = findViewById<Button>(R.id.backButtonHome)

        backButton.setOnClickListener((View.OnClickListener {
            val intent = Intent(this, MainActivity::class.java)
            startActivity(intent)
        }))

    }
}