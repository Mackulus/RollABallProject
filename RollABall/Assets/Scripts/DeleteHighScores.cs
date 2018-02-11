using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteHighScores : MonoBehaviour {
	void DeleteAllScores() {
		PlayerPrefs.DeleteAll();
	}
}