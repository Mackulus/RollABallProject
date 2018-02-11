using UnityEngine;

public class FocusController : MonoBehaviour {
	public GameObject focus;

	void LateUpdate() {
		//https://answers.unity.com/questions/132592/lookat-in-opposite-direction.html
		transform.LookAt(2 * transform.position - focus.transform.position);
	}
}
