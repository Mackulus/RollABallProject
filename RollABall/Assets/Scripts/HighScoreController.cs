using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreData {
	public ScoreData() {
		name = "";
		score = 0;
		time = 0f;
	}

	public ScoreData(string n, int s, float t) {
		name = n;
		score = s;
		time = t;
	}

	public static bool IsEmpty(ScoreData scoreData) {
		if (scoreData != null) {
			return scoreData.name.Length == 0 && scoreData.time <= 0f && scoreData.score <= 0;
		}
		else return false;
	}

	public override string ToString() {
		return name + ": " + score.ToString() + " : " + time.ToString();
	}

	public string name;
	public int score;
	public float time;
}

public class HighScoreController : MonoBehaviour {
	private static ScoreData[] HighScores = new ScoreData[10];

	static void Start () {
		GetHighScoreList();
    }
	
	//Somewhat Works
	public static bool NewScore(ScoreData highScore) {
		//Find a place to insert or place the New High Score
		for (int ix = 0; ix < HighScores.Length && (!ScoreData.IsEmpty(highScore)); ix++) {
			// if the Score at this position is empty place the score here
			if (ScoreData.IsEmpty(HighScores[ix])) {
				HighScores[ix] = highScore;
                return true;
			}
			// else if the curScore has a greater score or the same score and a better time
            // NullReference Exception somewhere in this line
			else if (highScore.score > HighScores[ix].score || (highScore.score == HighScores[ix].score && highScore.time < HighScores[ix].time)) {
				//move everything over one
				for (int iy = HighScores.Length - 1; iy > ix; iy--) {
					HighScores[iy] = HighScores[iy - 1];
				}
				HighScores[ix] = highScore;
				return true;
			}
		}
		return false;
	}

	public static void GetHighScoreList() {
		for (int ix = 0; ix < 10 && PlayerPrefs.HasKey("HighScore" + ix + "n"); ix++) {
			HighScores[ix].name = PlayerPrefs.GetString("HighScore" + ix + "n");
			HighScores[ix].score = PlayerPrefs.GetInt("HighScore" + ix + "s");
			HighScores[ix].time = PlayerPrefs.GetFloat("HighScore" + ix + "t");
		}
	}

	public static void SetHighScoreList() {
		for (int ix = 0; ix < 10 && (!ScoreData.IsEmpty(HighScores[ix])); ix++) {
            Debug.Log(HighScores[ix].ToString());
			PlayerPrefs.SetString("HighScore" + ix + "n", HighScores[ix].name);
			PlayerPrefs.GetInt("HighScore" + ix + "s", HighScores[ix].score);
			PlayerPrefs.GetFloat("HighScore" + ix + "t", HighScores[ix].time);
		}
	}
}