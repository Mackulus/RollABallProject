using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefUpdater : MonoBehaviour {
	private Text textBox;

    public string playerPref;

    private void Start() {
        textBox = GetComponent<Text>();
    }

    void OnEnable() {
        if (playerPref != "" && PlayerPrefs.HasKey(playerPref)) {
            textBox.text = PlayerPrefs.GetString(playerPref);
        }
    }
}