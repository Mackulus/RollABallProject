using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController : MonoBehaviour {
	public string sceneToLoad;

	// Use this for initialization
	void Start () {
		
	}

	void LoadScene() {
		SceneManager.LoadScene(sceneToLoad);
	}
}
