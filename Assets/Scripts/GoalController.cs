using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	private Transform player;
	private string playerLastTouched;

	void Awake(){
		gameObject.tag = "Goal";
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Background" && !playerLastTouched.Equals(player.name)) {
			GameObject []goals = GameObject.FindGameObjectsWithTag("Goal");
			for(int i = 0; i< goals.Length; i++)
				Destroy(goals[i]);
			GameController.runRuleSelection();
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag.Equals("Player"))
			playerLastTouched = coll.gameObject.name;
	}

	public void setPlayer(Transform player) {
		this.player = player;
	}
}