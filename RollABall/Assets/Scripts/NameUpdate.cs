using UnityEngine;
using UnityEngine.UI;

public class NameUpdate : MonoBehaviour {
	public Text Input;

	private string cachedInput = "";

	void Update () {
		if (cachedInput != GameController.playerName) {
			GameController.playerName = Input.text;
			cachedInput = GameController.playerName;
		}
	}
}
