package com.example.mycure.classes

import org.json.JSONObject
import java.io.Serializable

data class Doctor(
    val fullName: String, val identification: String, val location: String,
    val phoneNumber: String, val specialty: String, val clinicName: String
) : Serializable {
    constructor(json: JSONObject) : this(
        json.getString("name"),
        json.getString("iddoctor"),
        json.getString("location"),
        json.getString("phonenumber"),
        json.getString("specialty"),
        json.getString("clinic"),
    )
}
