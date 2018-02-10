using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//I don't have my textbook with me so I can't verify that this is the code from there or if it's all your own, but there may be a simpler solution
//check out this link for more details, otherwise if you can make this work then awesome! https://answers.unity.com/questions/20773/how-do-i-make-a-highscores-board.html


public class HighScoreController : MonoBehaviour {
	//private static ScoreData[] HighScores = new ScoreData[10];
	private static List<string> HighScoreNames = new List<string>(10);
	private static List<int> HighScores = new List<int>(10);
	private static List<float> HighScoreTimes = new List<float>(10);

	static void Start () {
		//Start is not called when a function is called directly from another script, this will not get called
		GetHighScoreList();
    }
	
	public static void NewScore(string name, int score, float time) {
		//When HighScores is empty, this loop will never be entered because it has no values in it. Count checks for occupied spaces rather than potential length
		for (int ix = 0; ix < HighScores.Count; ix++) {
			if (score > HighScores[ix] || (score == HighScores[ix] && time < HighScoreTimes[ix])) {
				HighScoreNames.Insert(ix, name);
				HighScores.Insert(ix, score);
				HighScoreTimes.Insert(ix, time);

				HighScoreNames.TrimExcess();
				HighScores.TrimExcess();
				HighScoreTimes.TrimExcess();

				SetHighScoreList();
				break;
			}
		}
	}

	public static void GetHighScoreList() {
		//This will fail if the high score list is not populated with values. Accessing a slot in the list that has no value will cause an out of range exception
		for (int ix = 0; ix < HighScores.Capacity && PlayerPrefs.HasKey("HighScore" + ix + "n"); ix++) {
			HighScoreNames[ix] = PlayerPrefs.GetString("HighScore" + ix + "n");
			HighScores[ix] = PlayerPrefs.GetInt("HighScore" + ix + "s");
			HighScoreTimes[ix] = PlayerPrefs.GetFloat("HighScore" + ix + "t");
		}
	}

	public static void SetHighScoreList() {
		for (int ix = 0; ix < HighScores.Count; ix++) {
            Debug.Log(HighScores[ix].ToString());
			PlayerPrefs.SetString("HighScore" + ix + "n", HighScoreNames[ix]);
			PlayerPrefs.GetInt("HighScore" + ix + "s", HighScores[ix]);
			PlayerPrefs.GetFloat("HighScore" + ix + "t", HighScoreTimes[ix]);
		}
	}
}