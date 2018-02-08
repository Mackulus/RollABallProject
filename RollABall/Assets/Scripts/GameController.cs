using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public Text countText;
	public Text winText;
	public Text timeText;
	//public PlayerController player;
	
	private static int count = 0;
	private static int level = 1;
	private float timeMax = 30.0f;
	private float timeLeft;
	private bool timeExpired;
	private bool win;

	void Start()
	{
		timeLeft = timeMax;
		timeExpired = false;
		SetCountText ();
		SetTimeText ();
		winText.text = "";
		win = false;
	}

	void Update()
	{
		if(!timeExpired)
		{
			SetTimeText();
		}

		if (Input.GetKeyDown(KeyCode.N))
		{
			PlayerController.Record(count, timeMax - timeLeft);
			//HighScoreRecorder.curScore.score += count;
			//HighScoreRecorder.curScore.time += timeMax - timeLeft;
			count = 0;
			level = 1;
			SceneManager.LoadScene("Menu");
		}

		if (timeExpired)
		{
			StartCoroutine(WinLevelOrBackToMainMenu());
		}
	}

	IEnumerator WinLevelOrBackToMainMenu()
	{
		yield return new WaitForSecondsRealtime(5);
		level++;
		if (level < 5 && win)
		{
			PlayerController.Record(count, timeMax - timeLeft);
			SceneManager.LoadScene("Level" + level);
		}
		else
		{
			PlayerController.Record(count, timeMax - timeLeft);
			count = 0;
			level = 1;
			SceneManager.LoadScene("Menu");
		}
	}

	void SetCountText ()
	{
		countText.text = "Count: " + count.ToString ();
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
				//audio component array code found here https://answers.unity.com/questions/52017/2-audio-sources-on-a-game-object-how-use-script-to.html
				count = count + 1;
				GetComponents<AudioSource>()[0].Play();
			}
			else if (other.gameObject.CompareTag ("Bonus Pick Up"))
			{
				count = count + 5;
				GetComponents<AudioSource>()[1].Play();
			}
			else if (other.gameObject.CompareTag ("Level Win Pick Up"))
			{
				count = count + 10;
				winText.text = "You Win!";
				//GetComponents<AudioSource>()[2].Play();
				win = true;
				timeExpired = true;
			}
			other.gameObject.SetActive (false);
			SetCountText ();
		}
	}
}
