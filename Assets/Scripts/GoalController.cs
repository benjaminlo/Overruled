using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		if (GameController.numChosenRules < GameController.numRules)
			GameController.runRuleSelection();
		Destroy (gameObject);
	}
}