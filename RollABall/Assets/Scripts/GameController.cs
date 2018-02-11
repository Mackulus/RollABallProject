using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	public Text countText;
	public Text winText;
	public Text timeText;

	public static string playerName = "";
	public static int playerCount = 0;
    
	private static int level = 1;
	public float timeMax = 30.0f;
	private float timeLeft;
	private bool timeExpired;
	private bool win;
	private bool startedCoRoutine;

	void Start() {
		timeLeft = timeMax;
		timeExpired = false;
		SetCountText ();
		SetTimeText ();
		winText.text = "";
		win = false;
		startedCoRoutine = false;
	}

	void Update() {
		if(!timeExpired) {
			SetTimeText();
		}

		if (Input.GetKeyDown(KeyCode.N)) {
			HighScoreController.NewScore(playerName, playerCount);
			playerCount = 0;
			level = 1;
			SceneManager.LoadScene("Menu");
		}

		if (timeExpired && !startedCoRoutine) {
            level++;
            string scene;

            if (level < 5 && win) {
                scene = "Level" + level;
            }
            else {
			    HighScoreController.NewScore(playerName, playerCount);
			    level = 1;
			    playerCount = 0;
                scene = "Menu";
		    }
            StartCoroutine(RedirectToNewScene(scene));
        }
	}

	IEnumerator RedirectToNewScene(string scene, int delay = 5) {
		startedCoRoutine = true;
		yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(scene);
    }

	void SetCountText () {
		countText.text = "Count: " + playerCount.ToString ();
	}

	void SetTimeText () {
		timeLeft -= Time.deltaTime;
		timeText.text = "Time left: " + Mathf.Round(timeLeft);
		if (timeLeft <= 0) {
			timeExpired = true;
			winText.text = "You Lose...";
		}
	}

	public void ColliderHandler(Collider other) {
		if(!timeExpired) {
			if(other.gameObject.CompareTag("Game Over")) {
				timeExpired = true;
				winText.text = "You Lose...";
			}
			else if (other.gameObject.CompareTag ("Pick Up")) {
				//audio component array code found here https://answers.unity.com/questions/52017/2-audio-sources-on-a-game-object-how-use-script-to.html
				playerCount += 1;
				GetComponents<AudioSource>()[0].Play();
			}
			else if (other.gameObject.CompareTag ("Bonus Pick Up")) {
				playerCount += 5;
				GetComponents<AudioSource>()[1].Play();
			}
			else if (other.gameObject.CompareTag ("Level Win Pick Up")) {
				playerCount += 10;
				if (level < 4)
				{
					winText.text = "You beat Level " + level;
				}
				else
				{
					winText.text = "You win!";
				}
				GetComponents<AudioSource>()[2].Play();
				win = true;
				timeExpired = true;
			}
			if (!other.gameObject.CompareTag("Game Over")){
				other.gameObject.SetActive (false);
			}
			SetCountText ();
		}
	}
}
