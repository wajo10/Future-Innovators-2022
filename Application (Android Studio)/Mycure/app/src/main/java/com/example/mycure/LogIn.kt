package com.example.mycure

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton
import android.widget.Toast
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.google.android.material.chip.Chip

class LogIn : AppCompatActivity() {
    @SuppressLint("CutPasteId")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_log_in)
        supportActionBar?.hide()

        val queue = Volley.newRequestQueue(this)
        val url = "https://mycureserver.azurewebsites.net/API"

        val backButton = findViewById<ImageButton>(R.id.backbutton_login)
        val logInButton = findViewById<Button>(R.id.loginbutton_login)
        val signUpButton = findViewById<Button>(R.id.signupbutton_login)
        val emailEntry = findViewById<EditText>(R.id.emailentry_login)
        val passwordEntry = findViewById<EditText>(R.id.passwordentry_login)

        // back button go to start up page
        backButton.setOnClickListener {
            // create intent to go to start up page
            val intent = Intent(this, StartUp::class.java)
            startActivity(intent)
        }

        // log in button go to home page
        logInButton.setOnClickListener{
            var email = emailEntry.text.toString()
            var password = passwordEntry.text.toString()

            // connect to data base function
            val request = JsonObjectRequest(
                Request.Method.GET, url+"/Patient/LogInPatient?idPatient=${email}&password=${password}", null,
                { response ->
                    run {
                        val idPatient = response.getString("idpatient")
                        if (idPatient != "") {
                            val intent = Intent(this, HomePatient::class.java)
                            intent.putExtra("Patient", response.toString())
                            startActivity(intent)
                        }
                        else{
                            Toast.makeText(this, "Invalid email or password", Toast.LENGTH_LONG).show()
                        }
                    }
                },
                { error ->
                    // TODO: Handle error
                }
            )
            queue.add(request)

        }

        // sign up button go to sign up page
        signUpButton.setOnClickListener {
            val intent = Intent(this, SignUp::class.java)
            startActivity(intent)
        }


    }
}

