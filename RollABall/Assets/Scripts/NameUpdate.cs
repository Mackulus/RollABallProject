using UnityEngine;
using UnityEngine.UI;

public class NameUpdate : MonoBehaviour {
	public Text Input;

	private string cachedInput = "";

	void Update () {
		if (cachedInput != PlayerController.playerScore.name) {
			PlayerController.playerScore.name = Input.text;
			cachedInput = PlayerController.playerScore.name;
		}
	}
}
