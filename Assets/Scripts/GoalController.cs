using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		GameController.runRuleSelection();
		Destroy (gameObject);
	}
}