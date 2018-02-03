using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndGrow : MonoBehaviour {

	private float xDimension, yDimension, zDimension, halfX, halfY, halfZ;

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
		Debug.Log("Here");
		if (transform.localScale.x >= xDimension && transform.localScale.y >= yDimension && transform.localScale.z >= zDimension)
		{
			transform.localScale -= Vector3(transform.localScale.x / 3, transform.localScale.y / 3, transform.localScale.z / 3) * Time.deltaTime;
		}
		else if (transform.localScale.x <= halfX && transform.localScale.y <= halfY && transform.localScale.z <= halfZ)
		{
			transform.localScale += Vector3(transform.localScale.x / 3, transform.localScale.y / 3, transform.localScale.z / 3) * Time.deltaTime;
		}

	}
}
