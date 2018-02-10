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

	public static string playerName = "";
	public static int playerCount = 0;
	public static float playerTime = 0.0f;

	//private static int count = 0;
	private static int level = 1;
	private float timeMax = 30.0f;
	private float timeLeft;
	private bool timeExpired;
	private bool win;
	private bool startedCoRoutine;

	void Start()
	{
		timeLeft = timeMax;
		timeExpired = false;
		Debug.Log("starting timeExpired: " + timeExpired);
		SetCountText ();
		SetTimeText ();
		winText.text = "";
		win = false;
		startedCoRoutine = false;
	}

	void Update()
	{
		if(!timeExpired)
		{
			SetTimeText();
		}

		if (Input.GetKeyDown(KeyCode.N))
		{
			HighScoreController.NewScore(playerName, playerCount, playerTime);
			playerTime = 0f;
			playerCount = 0;
			level = 1;
			SceneManager.LoadScene("Menu");
		}

		if (timeExpired && !startedCoRoutine)
		{
			Debug.Log("Calling Win Level");
			StartCoroutine(WinLevelOrBackToMainMenu());
		}
	}

	IEnumerator WinLevelOrBackToMainMenu()
	{
		startedCoRoutine = true;
		yield return new WaitForSecondsRealtime(5);
		level++;
		Debug.Log(level);
		Debug.Log(timeExpired);
		if (level < 5 && win)
		{
			playerTime += timeMax - timeLeft;
			SceneManager.LoadScene("Level" + level);
			StopCoroutine(WinLevelOrBackToMainMenu());
		}
		else
		{
			HighScoreController.NewScore(playerName, playerCount, playerTime);
			level = 1;
			playerTime += timeMax - timeLeft;
			playerCount = 0;
			SceneManager.LoadScene("Menu");
			StopCoroutine(WinLevelOrBackToMainMenu());
		}
		StopCoroutine(WinLevelOrBackToMainMenu());
	}

	void SetCountText ()
	{
		countText.text = "Count: " + playerCount.ToString ();
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
				playerCount += 1;
				GetComponents<AudioSource>()[0].Play();
			}
			else if (other.gameObject.CompareTag ("Bonus Pick Up"))
			{
				playerCount += 5;
				GetComponents<AudioSource>()[1].Play();
			}
			else if (other.gameObject.CompareTag ("Level Win Pick Up"))
			{
				playerCount += 10;
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
