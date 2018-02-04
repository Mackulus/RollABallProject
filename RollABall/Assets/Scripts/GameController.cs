using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public Text countText;
	public Text winText;
	public Text timeText;
	public PlayerController player;

	private int count;
	private float timeLeft;
	private bool timeExpired;

	void Start()
	{
		count = 0;
		timeLeft = 30.0f;
		timeExpired = false;
		SetCountText ();
		SetTimeText ();
		winText.text = "";
	}

	void Update()
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

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
		//if (count >= 16) 
		//{
		//	winText.text = "You Win!";
		//	timeExpired = true;
		//}
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

	public void AddPoints(Collider other)
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
			else if (other.gameObject.CompareTag ("Level Win Pick Up"))
			{
				count = count + 10;
				winText.text = "You Win!";
				timeExpired = true;
			}
			other.gameObject.SetActive (false);
			SetCountText ();
		}
	}
}
