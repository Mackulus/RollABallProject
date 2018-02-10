using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {
	private static List<string> HighScoreNames = new List<string>(10);
	private static List<int> HighScores = new List<int>(10);

	void Start () {
		GetHighScoreList();
        SetHighScoreList();
    }
	
	public static void NewScore(string name, int score) {
		for (int ix = 0; ix < HighScores.Count; ix++) {
			if (score > HighScores[ix]) {
				HighScoreNames.Insert(ix, name);
				HighScores.Insert(ix, score);

				HighScoreNames.TrimExcess();
				HighScores.TrimExcess();

				SetHighScoreList();
				break;
			}
		}
	}

	public static void GetHighScoreList() {
		for (int ix = 0; ix < HighScores.Capacity && PlayerPrefs.HasKey("HighScoreName" + ix); ix++) {
			HighScoreNames[ix] = PlayerPrefs.GetString("HighScoreName" + ix);
			HighScores[ix] = PlayerPrefs.GetInt("HighScore" + ix);
		}
	}

	public static void SetHighScoreList() {
		for (int ix = 0; ix < HighScores.Count; ix++) {
            Debug.Log(HighScores[ix].ToString());
			PlayerPrefs.SetString("HighScore" + ix, HighScoreNames[ix]);
			PlayerPrefs.SetInt("HighScore" + ix, HighScores[ix]);
		}
	}
}