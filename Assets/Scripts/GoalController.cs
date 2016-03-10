using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	Texture2D iceBackground;

	void OnTriggerEnter2D(Collider2D other) {
		iceBackground = Resources.Load ("IceBackground") as Texture2D;
		GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
		GameController.runRuleSelection = true;
		Destroy (gameObject);

	}
}
