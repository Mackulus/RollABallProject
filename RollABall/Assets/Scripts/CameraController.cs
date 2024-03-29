﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject focus;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - focus.transform.position;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey("escape")) {
            Application.Quit();
        }
    }

    void LateUpdate () {
		transform.position = focus.transform.position + offset;
	}
}