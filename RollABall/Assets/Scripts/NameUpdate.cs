using UnityEngine;
using UnityEngine.UI;

public class NameUpdate : MonoBehaviour {
	private static InputField Input;

    private void Start() {
        
    }

	public void PassName (string value) {
		Debug.Log(value);
		GameController.playerName = value;
	}
}
