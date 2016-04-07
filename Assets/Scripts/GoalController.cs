using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	private Transform player;
	private string playerLastTouched;
	private GameController gameController;

	void Awake(){
		gameObject.tag = "Goal";
		gameController = GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController>();
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Background") {
			GameObject []goals = GameObject.FindGameObjectsWithTag("Goal");
			for(int i = 0; i< goals.Length; i++)
				Destroy(goals[i]);
			gameController.incrementScore (playerLastTouched);
			gameController.runRuleSelection();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals ("Player") && !coll.gameObject.name.Equals(player.name)) {
			playerLastTouched = coll.gameObject.name;
			gameObject.layer = LayerMask.NameToLayer ("Destroy");
		} else
			gameObject.layer = LayerMask.NameToLayer ("Safe");
	}

	public void setPlayer(Transform player) {
		this.player = player;
	}
}