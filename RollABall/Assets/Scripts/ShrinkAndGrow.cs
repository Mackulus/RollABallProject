﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndGrow : MonoBehaviour {

	private float xDimension, yDimension, zDimension, halfX, halfY, halfZ;
	private bool grow = false;

	void Start ()
	{
		xDimension = transform.localScale.x;
		yDimension = transform.localScale.y;
		zDimension = transform.localScale.z;
		halfX = xDimension/2;
		halfY = yDimension/2;
		halfZ = zDimension/2;
	}

	// Update is called once per frame
	void Update () 
	{
		if (!grow)
		{
			transform.localScale -=  new Vector3(transform.localScale.x / 50, transform.localScale.y / 50, transform.localScale.z / 50);
			if (transform.localScale.x <= halfX && transform.localScale.y <= halfY && transform.localScale.z <= halfZ)
			{
				grow = true;
			}
		}
		else if (grow)
		{
			//code snippet found https://docs.unity3d.com/ScriptReference/Transform-localScale.html
			transform.localScale += new Vector3(transform.localScale.x / 50, transform.localScale.y / 50, transform.localScale.z / 50);
			if (transform.localScale.x >= xDimension && transform.localScale.y >= yDimension && transform.localScale.z >= zDimension)
			{
				grow = false;
			}
		}

	}
}
