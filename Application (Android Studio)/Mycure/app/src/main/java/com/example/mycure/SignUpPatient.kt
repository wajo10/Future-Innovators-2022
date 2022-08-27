package com.example.mycure

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton

class SignUpPatient : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_sign_up_patient)
        supportActionBar?.hide()

        val backButton = findViewById<ImageButton>(R.id.backbutton_signuppatient)
        val signUpButton = findViewById<Button>(R.id.signupbutton_signuppatient)

        // back button to go back to the previous page
        backButton.setOnClickListener {
            val intent = Intent(this, SignUp::class.java)
            startActivity(intent)
        }

        // sign up button, get values from edit texts and go to home patient
        signUpButton.setOnClickListener {
            var fullname = findViewById<EditText>(R.id.nameentry_signuppatient).text.toString()
            var identification = findViewById<EditText>(R.id.identry_signuppatient).text.toString()
            var birthdate = findViewById<EditText>(R.id.birthdateentry_signuppatient).text.toString()
            var location = findViewById<EditText>(R.id.locationentry_signuppatient).text.toString()
            var phonenumber = findViewById<EditText>(R.id.phonenumberentry_signuppatient).text.toString()
            var email = findViewById<EditText>(R.id.emailentry_signuppatient).text.toString()
            var password = findViewById<EditText>(R.id.passwordentry_signuppatient).text.toString()


            val intent = Intent(this, HomePatient::class.java)
            startActivity(intent)
        }
    }
}