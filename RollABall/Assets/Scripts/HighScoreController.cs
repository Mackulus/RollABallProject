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
		return scoreData.name.Length == 0 && scoreData.time <= 0f && scoreData.score <= 0;
	}

	public string name;
	public int score;
	public float time;
}

public class HighScoreController : MonoBehaviour {
	public GameObject[] Data = new GameObject[10];
	public Text curPlayerName;

	private ScoreData[] HighScoreArr = new ScoreData[10];
	//private ScoreData[] LowTimeArr = new ScoreData[10];

	void Awake() {
		if (!ScoreData.IsEmpty(HighScoreRecorder.curScore)) {
			Debug.Log("Detected a Score!");
			Debug.Log("Reported values: " + HighScoreRecorder.curScore.score + " and " + HighScoreRecorder.curScore.time);
			NewScore(HighScoreRecorder.curScore);
		}
		else {
			Debug.Log("No Detected Score. :(");
		}
	}

	void Start () {
		PrintHighScoreList(HighScoreArr);
	}
	
	void GameStart() {
		HighScoreRecorder.curScore = new ScoreData(curPlayerName.text, 0, 0f);
	}

	bool NewScore(ScoreData highScore) {
		Debug.Log("New Score Detected");
		Debug.Log("Length of Array: " + HighScoreArr.Length);
		int ix;
		for (ix = 0; ix < HighScoreArr.Length; ix++) {
			Debug.Log("Position: " + ix);
			if (highScore.score > HighScoreArr[ix].score || (highScore.score == HighScoreArr[ix].score && highScore.time < HighScoreArr[ix].time)) {
				Debug.Log("Spot found at " + ix);
				ScoreData[] tempArr = new ScoreData[10];
				tempArr[ix] = highScore;
				for (int iy = 0; iy < tempArr.Length && iy + 1 < HighScoreArr.Length; iy++) {
					if (iy > ix) {
						tempArr[iy] = HighScoreArr[iy + 1];
					}
					else if(iy < ix){
						tempArr[iy] = HighScoreArr[iy];
					}
				}
				return true;
			}
		}
		if (ix < HighScoreArr.Length && ScoreData.IsEmpty(HighScoreArr[ix])) {
			HighScoreArr[ix] = highScore;
		}
		return false;
	}

	void GetHighScoreLists() {

	}

	void PrintHighScoreList(ScoreData[] hsArr) {
		Debug.Log("Begin printing High Scores");
		Debug.Log("Length of Array: " + HighScoreArr.Length);
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
	}
}