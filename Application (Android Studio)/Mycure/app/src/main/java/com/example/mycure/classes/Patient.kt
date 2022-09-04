package com.example.mycure.classes

import org.json.JSONObject
import java.io.Serializable

data class Patient(val fullName: String, val identification:String, val birthdate:String,
val location:String, val phoneNumber:String, val email:String, val height:String, val weight:String)
    :Serializable{
    constructor(json:JSONObject):this(
        json.getString("name"),
        json.getString("idpatient"),
        json.getString("birthdate"),
        json.getString("location"),
        json.getString("phonenumber"),
        json.getString("email"),
        json.getString("height"),
        json.getString("weight")
    )
}