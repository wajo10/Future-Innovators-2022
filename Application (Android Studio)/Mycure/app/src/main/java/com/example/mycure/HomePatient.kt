package com.example.mycure

import android.annotation.SuppressLint
import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.ImageButton
import android.widget.TextView
import com.example.mycure.classes.Patient
import org.json.JSONObject

class HomePatient : AppCompatActivity() {
    lateinit var json:JSONObject
    @SuppressLint("WrongViewCast", "SetTextI18n")
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_home_patient)
        supportActionBar?.hide()
        val intentValues = intent.getStringExtra("Patient")
        if (intentValues != null){
            json = JSONObject(intentValues)

        }
        val patient = Patient(json)
        val profileButton = findViewById<ImageButton>(R.id.profilebutton_homepatient)

        val titlePatient = findViewById<TextView>(R.id.title_homepatient)
        titlePatient.text = "Hello, ${patient.fullName.split(" ")[0]}"

        profileButton.setOnClickListener {
            val intent = Intent(this, ProfilePatient::class.java)
            startActivity(intent)
        }


    }
}