using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		//GameController.runRuleSelection = true;

		int rule = GameController.getRule ();
		int choice = Random.Range (1,3);
		GameController.setRule (rule, choice);

		BackgroundController.updateBackground ();

		GameObject.Find ("Player1").GetComponent<PlayerController>().updatePlayer ();
		GameObject.Find ("Player2").GetComponent<PlayerController>().updatePlayer ();

		GameController.getRulesInfo ();

		//Destroy (gameObject);
	}
}