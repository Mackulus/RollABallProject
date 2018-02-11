using UnityEngine;
using UnityEngine.UI;

public class NameUpdate : MonoBehaviour {
	private static Text Input;

    private void Start() {
        Input = GetComponent<Text>();
    }

    public void PassName () {
		Debug.Log(Input.text);
		GameController.playerName = Input.text;
	}
}
