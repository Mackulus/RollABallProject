using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreRecorder : MonoBehaviour {
	//public HighScoreController highScoreController;

	public static ScoreData curScore = new ScoreData();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Record(int score, float time) {
		Debug.Log("Recorded: " + score + " and " + time);
		if (score > 0 && time > 0) {
			curScore.score += (int)score;
			curScore.time += (float)time;
		}
		Debug.Log("New values: " + curScore.score + " and " + curScore.time);
	}
}