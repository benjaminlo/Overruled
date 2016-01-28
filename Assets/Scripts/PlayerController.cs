using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public float speed;
	public Boundary boundary;
	public string horizontalAxis, verticalAxis;

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis (horizontalAxis);
		float moveVertical = Input.GetAxis (verticalAxis);

		Rigidbody2D body = GetComponent<Rigidbody2D> ();

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
		body.velocity = movement * speed;

		body.position = new Vector2(
			Mathf.Clamp (body.position.x, boundary.xMin, boundary.xMax),
			Mathf.Clamp (body.position.y, boundary.yMin, boundary.yMax)
		);
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
