using UnityEngine;
using UnityEngine.UI;

public class PrefIntUpdater : MonoBehaviour {
    private Text textBox;

    public string playerPref;

    private void Start() {
        textBox = GetComponent<Text>();
    }

    void LateUpdate() {
        if (playerPref != "" && PlayerPrefs.HasKey(playerPref)) {
            textBox.text = PlayerPrefs.GetInt(playerPref).ToString();
        }
    }
}