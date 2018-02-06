using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct HighScoreData {
	public string name;
	public int score;
	public float time;
}

public class HighScoreController : MonoBehaviour {
	public GameObject[] Data = new GameObject[10];

	private HighScoreData[] HighScoreArr = new HighScoreData[10];
	private HighScoreData[] LowTimeArr = new HighScoreData[10];

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	bool NewHighScore(HighScoreData highScore) {
		for(int ix = 0; ix < HighScoreArr.Length; ix++) {
			if (highScore.score > HighScoreArr[ix].score) {
				HighScoreData[] tempArr = new HighScoreData[10];
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

		return false;
	}

	void GetHighScoreLists() {

	}

	void PrintHighScoreList(HighScoreData[] hsArr) {
		for(int ix = 0; ix < Data.Length && ix < hsArr.Length; ix++) {
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