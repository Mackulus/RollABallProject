using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreController : MonoBehaviour {
	//private static ScoreData[] HighScores = new ScoreData[10];
	private static List<string> HighScoreNames = new List<string>(10);
	private static List<int> HighScores = new List<int>(10);
	private static List<float> HighScoreTimes = new List<float>(10);

	static void Start () {
		GetHighScoreList();
    }
	
	public static void NewScore(string name, int score, float time) {
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