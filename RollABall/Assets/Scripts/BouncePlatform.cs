using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePlatform : MonoBehaviour {


	#region Code from answers.unity.com/questions/773960/trying-to-make-a-bounce-platform-that-tosses-the-p.html
	public float bounciness; // Determines jump height

	void OnCollisionEnter(Collision other)
	{
		other.rigidbody.AddForce(Vector3.up * bounciness, ForceMode.Impulse);
	}

	#endregion
}
