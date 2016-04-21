using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

	private Rigidbody2D body;
	private Vector2 direction;


	void Awake(){
		body = gameObject.GetComponent<Rigidbody2D> ();
		direction = new Vector2 (5, 0);
	}
	
	// Update is called once per frame
	void Update () {
		body.velocity = direction;
	}
	public void setDirection(Vector2 direction){
		this.direction = direction;
		body.MoveRotation (Mathf.Atan ((float)direction.y/direction.x)*180/Mathf.PI);
	}
}
