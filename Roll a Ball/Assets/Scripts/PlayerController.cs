using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;
	public Text timeText;

	private Rigidbody rb;
	private int count;
	private float timeLeft;
	private bool timeExpired;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
		count = 0;
		timeLeft = 30.0f;
		timeExpired = false;
		SetCountText ();
		SetTimeText ();
		winText.text = "";
	}

	void Update ()
	{
		if(!timeExpired)
		{
			SetTimeText();
		}

		if (Input.GetKeyDown(KeyCode.N))
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}

	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(!timeExpired)
		{
			if (other.gameObject.CompareTag ("Pick Up")) 
			{
				count = count + 1;
			}
			else if (other.gameObject.CompareTag ("Bonus Pick Up"))
			{
				count = count + 5;
				GetComponent<AudioSource>().Play();
			}
			other.gameObject.SetActive (false);
			SetCountText ();
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 16) 
		{
			winText.text = "You Win!";
			timeExpired = true;
		}
	}

	void SetTimeText ()
	{
		timeLeft -= Time.deltaTime;
		timeText.text = "Time left: " + Mathf.Round(timeLeft);
		if (timeLeft <= 0)
		{
			timeExpired = true;
			winText.text = "You Lose...";
		}
	}
}
