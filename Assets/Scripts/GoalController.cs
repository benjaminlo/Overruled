using UnityEngine;
using System.Collections;

public class GoalController : MonoBehaviour {
	
	Rigidbody2D body;
	public Boundary boundary;

	void Start(){
		body = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerExit2D(Collider2D other){
		Debug.Log (other.name);
		if (other.name == "Background") {
			GameController.runRuleSelection();
			Destroy (this);
			Debug.Log ("Hello");
		}
	}
}