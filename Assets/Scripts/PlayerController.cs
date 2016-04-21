using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary{
	public float xMin, xMax, yMin, yMax;
}

enum ButtonCycle{
	open,
	pressed,
	released
}

public class PlayerController : MonoBehaviour {

	public Transform bulletPrefab;
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
	private Vector2 direction;
	private Vector2 factor;
	private ButtonCycle shootCycle;

	// Abilities and attributes
	private float speed;
	private Vector3 size;
	private Rigidbody2D body;

	void Awake () {
		gameObject.tag = "Player";
		startingPosition = gameObject.transform.position;
		nextAction = 0.0f;
		activeTimer = 0.0f;

		// Set default attributes
		speed = 5f;
		size = Vector3.one;

		shootCycle = ButtonCycle.open;
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis (horizontalAxis);
		float moveVertical = Input.GetAxis (verticalAxis);

		body = GetComponent<Rigidbody2D> ();
		factor = new Vector2 (0, 0);


		if (body.velocity.x > 0)
			factor.x = 3;
		if (body.velocity.x < 0)
			factor.x = -3;

		if (body.velocity.y > 0)
			factor.y = 3;
		if (body.velocity.y < 0)
			factor.y = -3;

		if (factor.x == 0) {
			if (direction.x >= 0) {
				factor.x = -3;
			} else {
				factor.x = 3;
			}
		}

		direction = new Vector2 (body.velocity.x + factor.x, body.velocity.y + factor.y);

		if (direction == new Vector2(0, 0)){
			direction = new Vector2(body.position.x / Mathf.Abs(body.position.x) * (-3), 0);
		}

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


		switch (shootCycle) {
		case ButtonCycle.open:
			if(Input.GetButton (secondAction))
				shootCycle = ButtonCycle.pressed;
			break;
		
		case ButtonCycle.pressed:
			if(!Input.GetButton (secondAction))
				shootCycle = ButtonCycle.released;
			break;

		case ButtonCycle.released:
			Transform bullet = Instantiate (bulletPrefab, gameObject.transform.position + new Vector3 (factor.x/Mathf.Abs(factor.x), 0, 0), gameObject.transform.rotation) as Transform;
			bullet.GetComponent<BulletController>().setDirection(direction);
			shootCycle = ButtonCycle.open;
			break;
		
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
			speed = 2.5f;
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
			size = new Vector3 (2.0f, 2.0f, 0);
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