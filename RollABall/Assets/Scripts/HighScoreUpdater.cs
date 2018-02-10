using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreUpdater : MonoBehaviour {
	public string playerPref;
	public Text playerName;
	public Text score;
	public Text time;

	// Use this for initialization
	void Awake() {
		//The playerPref value is not set inside of HighScoreController. The keys below it (playerPref + n, etc.) are, but never just the playerPref that is here)
		if (PlayerPrefs.HasKey(playerPref)) {
			playerName.text = PlayerPrefs.GetString(playerPref + "n");
			score.text = PlayerPrefs.GetInt(playerPref + "s").ToString();
			time.text = PlayerPrefs.GetFloat(playerPref + "t").ToString();
		}
	}

	// Update is called once per frame
	void Update () {
		
	}
}
