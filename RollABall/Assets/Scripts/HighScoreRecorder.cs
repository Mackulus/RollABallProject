using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScoreRecorder : MonoBehaviour {
	public HighScoreController highScoreController;
	static int Score;
	static float Time;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void Finish() {

	}

	public static bool Record(int score, float time) {

		return true;
	}
}