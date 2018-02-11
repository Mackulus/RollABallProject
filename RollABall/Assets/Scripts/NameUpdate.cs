using UnityEngine;
using UnityEngine.UI;

public class NameUpdate : MonoBehaviour {

	//This code and dynamic string update found here
	//https://doc.photonengine.com/en-us/pun/current/demos-and-tutorials/pun-basics-tutorial/lobby-ui

	public void PassName (string value) {
		GameController.playerName = value;
	}
}
