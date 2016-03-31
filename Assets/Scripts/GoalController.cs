using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {

	private Transform player;
	private string playerLastTouched;

	void Awake(){
		gameObject.tag = "Goal";
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.name == "Background") {
			GameObject []goals = GameObject.FindGameObjectsWithTag("Goal");
			for(int i = 0; i< goals.Length; i++)
				Destroy(goals[i]);
			GameController.incrementScore (playerLastTouched);
			GameController.runRuleSelection();
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Equals ("Border") && playerLastTouched.Equals (player.name)) {
			if (other.name == "Top Border" || other.name == "Bottom Border") {
				Rigidbody2D body = GetComponent<Rigidbody2D> ();
				body.velocity = new Vector2 (body.velocity.x, body.velocity.y * (-1));
			}
			if (other.name == "Right Border" || other.name == "Left Border") {
				Rigidbody2D body = GetComponent<Rigidbody2D> ();
				body.velocity = new Vector2 (body.velocity.x * (-1), body.velocity.y);
			}
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