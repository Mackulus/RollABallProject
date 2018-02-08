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
	void Start() {
	}

	// Update is called once per frame
	void Update () {
		if (PlayerPrefs.HasKey(playerPref)) {
			playerName.text = PlayerPrefs.GetString(playerPref + "n");
			score.text = PlayerPrefs.GetInt(playerPref + "s").ToString();
			time.text = PlayerPrefs.GetFloat(playerPref + "t").ToString();
		}
	}
}
