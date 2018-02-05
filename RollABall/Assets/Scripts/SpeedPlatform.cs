using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPlatform : MonoBehaviour {

	public float speedGain; // Determines speed

	void OnCollisionEnter(Collision other)
	{
		//transform.forward found here https://answers.unity.com/questions/1149895/unity-speedpad-boost-pad.html
		other.rigidbody.AddForce(transform.forward * speedGain, ForceMode.Impulse);
	}
}
