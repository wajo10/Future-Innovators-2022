package com.example.mycure

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton
import android.widget.Toast
import androidx.appcompat.content.res.AppCompatResources
import com.android.volley.Request
import com.android.volley.Response
import com.android.volley.toolbox.JsonObjectRequest
import com.android.volley.toolbox.Volley
import com.example.mycure.classes.Doctor
import com.example.mycure.classes.Patient
import com.google.android.material.chip.Chip
import com.google.android.material.chip.ChipGroup

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
        val chipGroup = findViewById<ChipGroup>(R.id.chipgroup_login)
        val chipPatient = findViewById<Chip>(R.id.chippatient_login)
        val chipDoctor = findViewById<Chip>(R.id.chipdoctor_login)
        var selectPatient = true

        // back button go to start up page
        backButton.setOnClickListener {
            // create intent to go to start up page
            val intent = Intent(this, StartUp::class.java)
            startActivity(intent)
        }

        chipGroup.isSingleSelection = true
        chipGroup.isSingleLine = true
        chipGroup.isSelectionRequired = true

        chipPatient.isCheckable = true
        chipPatient.isClickable = true
        chipPatient.setChipBackgroundColorResource(R.color.pressed_chip)

        chipDoctor.isCheckable = true
        chipDoctor.isClickable = true
        chipDoctor.setChipBackgroundColorResource(R.color.normal_chip)

        chipGroup.check(chipPatient.id)
        chipPatient.setOnCheckedChangeListener() { _, isChecked ->
            if (isChecked) {
                Toast.makeText(this, "Patient", Toast.LENGTH_SHORT).show()
                selectPatient = true
                chipPatient.setChipBackgroundColorResource(R.color.pressed_chip)


            } else {
                selectPatient = false
                chipPatient.setChipBackgroundColorResource(R.color.normal_chip)
            }
        }

        chipDoctor.setOnCheckedChangeListener() { _, isChecked ->
            if (isChecked) {
                Toast.makeText(this, "Doctor", Toast.LENGTH_SHORT).show()
                selectPatient = false
                chipDoctor.setChipBackgroundColorResource(R.color.pressed_chip)

            } else {
                selectPatient = true
                chipDoctor.setChipBackgroundColorResource(R.color.normal_chip)
            }
        }


        // log in button go to home page
        logInButton.setOnClickListener {
            val email = emailEntry.text.toString()
            val password = passwordEntry.text.toString()


            // connect to data base function
            //Check if the selected chip is patient or doctor
            if (selectPatient) {
                val request = com.android.volley.toolbox.JsonObjectRequest(
                    com.android.volley.Request.Method.GET,
                    url + "/Patient/LogInPatient?idPatient=${email}&password=${password}",
                    null,
                    { response ->
                        run {
                            val idPatient = response.getString("idpatient")
                            if (idPatient != "") {
                                val intent = android.content.Intent(
                                    this,
                                    com.example.mycure.HomePatient::class.java
                                )
                                intent.putExtra("Patient", response.toString())
                                startActivity(intent)
                            } else {
                                android.widget.Toast.makeText(
                                    this,
                                    "Invalid email or password",
                                    android.widget.Toast.LENGTH_LONG
                                ).show()
                            }
                        }
                    },
                    { error ->
                        // TODO: Handle error
                    }
                )
                queue.add(request)
            } else {
                // connect to data base function
                val request = JsonObjectRequest(
                    Request.Method.GET,
                    url + "/Doctor/LogInDoctor?idDoctor=${email}&password=${password}",
                    null,
                    { response ->
                        run {
                            val idDoctor = response.getString("iddoctor")
                            if (idDoctor != "") {
                                val doctor = Doctor(response)
                                val intent = Intent(this, HomeDoctor::class.java)
                                intent.putExtra("Doctor", doctor)
                                startActivity(intent)
                            } else {
                                Toast.makeText(this, "Invalid email or password", Toast.LENGTH_LONG)
                                    .show()
                            }
                        }
                    },
                    { error ->
                        // TODO: Handle error
                    }
                )
                queue.add(request)

            }

        }

        // sign up button go to sign up page
        signUpButton.setOnClickListener {
            val intent = Intent(this, SignUp::class.java)
            startActivity(intent)
        }


    }
}

