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

	void Start () {
		GetHighScoreList();

		if (!ScoreData.IsEmpty(PlayerController.playerScore)) {
			//Debug.Log("Detected a Score!");
			//Debug.Log("Reported values: " + HighScoreRecorder.curScore.score + " and " + HighScoreRecorder.curScore.time);
			NewScore(PlayerController.playerScore);
		}
	}
	
	//Probably Works
	bool NewScore(ScoreData highScore) {
		//Debug.Log("New Score Detected");
		//Debug.Log("Length of Array: " + HighScores.Length);
		// Loops thru HighScores 0 to 10
		for (int ix = 0; ix < HighScores.Length; ix++) {
			//Debug.Log("Position: " + ix);
			// if the Score at this position is empty place the score here
			if (ScoreData.IsEmpty(HighScores[ix])) {
				Debug.Log("Empty Spot found at " + ix);
				HighScores[ix] = highScore;
				SetHighScoreList();
				Debug.Log(HighScores.ToString());
				return true;
			}
			// else if the curScore has a greater score or the same score and a better time
			else if (highScore.score > HighScores[ix].score || (highScore.score == HighScores[ix].score && highScore.time < HighScores[ix].time)) {
				//Debug.Log("Spot found at " + ix);
				//move everything over one
				for (int iy = HighScores.Length - 1; iy > ix; iy--) {
					HighScores[iy] = HighScores[iy - 1];
				}
				HighScores[ix] = highScore;
				SetHighScoreList();
				Debug.Log(HighScores.ToString());
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
			PlayerPrefs.SetString("HighScore" + ix + "n", HighScores[ix].name);
			PlayerPrefs.GetInt("HighScore" + ix + "s", HighScores[ix].score);
			PlayerPrefs.GetFloat("HighScore" + ix + "t", HighScores[ix].time);
		}
	}

	/*Definitely Doesn't Work
	void PrintHighScoreList(ScoreData[] hsArr) {
		Debug.Log("Begin printing High Scores");
		for (int ix = 0; ix < Data.Length && ix < hsArr.Length && (!ScoreData.IsEmpty(hsArr[ix])); ix++) {
			Text[] textArr = Data[ix].GetComponents<Text>();
			foreach (Text t in textArr) {
				if(t.CompareTag("Name")) {
					t.text = hsArr[ix].name;
				}
				else if (t.CompareTag("Score")) {
					t.text = hsArr[ix].score.ToString();
				}
				else if (t.CompareTag("Time")) {
					t.text = hsArr[ix].time.ToString();
				}
			}
		}
	}*/
}