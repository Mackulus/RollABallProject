using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//I don't have my textbook with me so I can't verify that this is the code from there or if it's all your own, but there may be a simpler solution
//check out this link for more details, otherwise if you can make this work then awesome! https://answers.unity.com/questions/20773/how-do-i-make-a-highscores-board.html


public class HighScoreController : MonoBehaviour {
	private static List<string> HighScoreNames = new List<string>(10);
	private static List<int> HighScores = new List<int>(10);

	void Start () {
		GetHighScoreList();
        SetHighScoreList();
    }
	
	public static void NewScore(string name, int score) {
		for (int ix = 0; ix < HighScores.Capacity; ix++) {
			if (ix >= HighScores.Count) {
				HighScoreNames.Add(name);
				HighScores.Add(score);
			}
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
			HighScoreNames[ix] = PlayerPrefs.GetString("HighScoreName" + ix, "");
			HighScores[ix] = PlayerPrefs.GetInt("HighScore" + ix, 0);
		}
	}

	public static void SetHighScoreList() {
		for (int ix = 0; ix < HighScores.Count; ix++) {
			PlayerPrefs.SetString("HighScore" + ix, HighScoreNames[ix]);
			PlayerPrefs.SetInt("HighScore" + ix, HighScores[ix]);
		}
	}
}