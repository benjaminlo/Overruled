using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour {

	public Boundary boundary;

	public string horizontalAxis, verticalAxis;
	public string firstAction;
	public string secondAction;
	public string thirdAction;

	private Vector3 startingPosition;
	private float activeDuration;
	private float cooldown;
	private float nextAction;
	private float activeTimer;

	// Abilities and attributes
	private float speed;
	private Vector3 size;

	void Awake () {
		gameObject.tag = "Player";
		startingPosition = gameObject.transform.position;
		nextAction = 0.0f;
		activeTimer = 0.0f;

		// Set default attributes
		speed = 5f;
		size = Vector3.one;
	}

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

	void Update () {
		if (Input.GetButton (firstAction) && Time.time > nextAction) {
			nextAction = Time.time + cooldown;
			activeTimer = activeDuration;
			transform.localScale = size; // Perform action
		}
		if (activeTimer < 0) { 
			transform.localScale = Vector3.one; // Reset active ability
		} else
			activeTimer -= Time.deltaTime;
	}

	public void updatePlayer(int[] rules) {
		resetPlayerPosition ();

		switch (rules [1]) { // Passive ability
		case 0:
			speed = 5f;
			break;
		case 1:
			speed = 0.5f;
			break;
		case 2:
			speed = 10f;
			break;
		default:
			speed = 5f;
			break;
		}
		switch (rules [2]) { // Active ability
		case 0:
			size = Vector3.one;
			break;
		case 1:
			size = new Vector3 (0.5f, 0.5f, 0);
			cooldown = 3f;
			activeDuration = 3f;
			break;
		case 2:
			size = new Vector3 (5f, 5f, 0);
			cooldown = 3f;
			activeDuration = 3f;
			break;
		default:
			size = Vector3.one;
			break;
		}
	}

	public void resetPlayerPosition() {
		this.transform.position = startingPosition;
	}
}