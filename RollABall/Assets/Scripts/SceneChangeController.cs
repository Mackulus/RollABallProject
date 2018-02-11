using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeController : MonoBehaviour {
	public string sceneToLoad;
	
	void LoadScene() {
		SceneManager.LoadScene(sceneToLoad);
	}
}
