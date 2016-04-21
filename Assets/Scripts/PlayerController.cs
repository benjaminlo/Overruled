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

	private int[] rules;
	private float activeDuration;
	private float cooldown;
	private float nextAction;
	private float activeTimer;
	private Vector3 startingPosition;
	private Vector2 direction;
	private Vector2 factor;
	private ButtonCycle shootCycle;
	private Rigidbody2D body;

	// Abilities and attributes
	private float speed;
	private Vector3 size;

	void Awake () {
		gameObject.tag = "Player";

		startingPosition = gameObject.transform.position;

		nextAction = 0.0f;
		activeTimer = 0.0f;

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
		switch (shootCycle) {
		case ButtonCycle.open:
			if(Input.GetButton (firstAction))
				shootCycle = ButtonCycle.pressed;
			break;
		case ButtonCycle.pressed:
			if(!Input.GetButton (firstAction))
				shootCycle = ButtonCycle.released;
			break;
		case ButtonCycle.released:
			Transform bullet = Instantiate (bulletPrefab, gameObject.transform.position + new Vector3 (factor.x/Mathf.Abs(factor.x), 0, 0), gameObject.transform.rotation) as Transform;
			bullet.GetComponent<BulletController>().setDirection(direction);
			shootCycle = ButtonCycle.open;
			break;
		}

		if (Input.GetButton (secondAction) && Time.time > nextAction) {
			nextAction = Time.time + cooldown;
			activeTimer = activeDuration;
			grow ();
		}

		if (Input.GetButton (thirdAction) && Time.time > nextAction) {
			nextAction = Time.time + cooldown;
			activeTimer = activeDuration;
			shrink ();
		}

		if (activeTimer < 0) { 
			transform.localScale = Vector3.one; // Reset active ability
		} else
			activeTimer -= Time.deltaTime;
	}

	public void updatePlayer(int[] rules) {
		this.rules = rules;
		resetPlayerPosition ();
		updatePassiveAttributes ();
	}

	public void resetPlayerPosition() {
		this.transform.position = startingPosition;
	}
		
	private void updatePassiveAttributes (){
		switch (rules [0]) {
		case 0:
			speed = 5f;
			break;
		case 1:
			speed = 7.5f;
			break;
		case 2:
			speed = 10f;
			break;
		}
	}

	private void grow() {
		switch (rules [1]) {
		case 0:
			size = Vector3.one;
			break;
		case 1:
			size = new Vector3 (2f, 2f, 0);
			break;
		case 2:
			size = new Vector3 (3f, 3f, 0);
			break;
		}
		cooldown = 3f;
		activeDuration = 3f;
		this.transform.localScale = size;
	}

	private void shrink() {
		switch (rules [2]) {
		case 0:
			size = Vector3.one;
			break;
		case 1:
			size = new Vector3 (0.5f, 0.5f, 0);
			break;
		case 2:
			size = new Vector3 (0.33f, 0.33f, 0);
			break;
		}
		cooldown = 3f;
		activeDuration = 3f;
		this.transform.localScale = size;
	}
}