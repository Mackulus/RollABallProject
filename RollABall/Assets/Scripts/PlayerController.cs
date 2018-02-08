using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public static ScoreData playerScore = new ScoreData();

	public float speed;
	public GameController game;

	private Rigidbody rb;


	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		game.AddPoints(other);
	}

	public static void Record(int score, float time) {
		//Debug.Log("Recorded: " + score + " and " + time);
		if (score > 0 && time > 0) {
			playerScore.score += (int)score;
			playerScore.time += (float)time;
		}
		//Debug.Log("New values: " + curScore.score + " and " + curScore.time);
	}
}
