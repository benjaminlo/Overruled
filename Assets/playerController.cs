using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	public Sprite[] spritesF;
	public Sprite[] spritesB;
	public Sprite[] spritesR;
	public Sprite[] spritesL;

	public float framesPerSecond;
	public float speed;
	private SpriteRenderer spriteRenderer;
	private float deltaTime;
	private float dashTime = 0;
	private bool dashUsed = false;
	private bool dashing = false;

	public bool endGame = false;

	// Use this for initialization
	void Start () { 
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}

	void runStateMachine(){
		//Terrain
		switch (GameController.rules [0]) {
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		};

		//Abilities
		switch (GameController.rules [1]) {
		case 0:
			break;
		case 1:
			print(dashTime);
			if (Input.GetKeyDown("space") & !dashUsed & !dashing){
				speed += 15f;
				dashUsed = true;
				dashing = true;
			}

			if (dashUsed){
				dashTime += deltaTime;

				if (dashTime > 3){
					dashUsed = false;
					dashTime = 0f;
				}
			}
			if (dashing){
				speed -= 1f;
				if (speed <= 5f){
					speed = 5f;
					dashing = false;
				}
			}

			break;
		case 2:
			break;
		};
	}

	// Update is called once per frame
	void Update () {
		deltaTime = Time.deltaTime;

		runStateMachine ();

		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % spritesF.Length;

		if (Input.GetKey (moveUp)) {
			transform.position += Vector3.up * speed * deltaTime;
			spriteRenderer.sprite = spritesB [index];
		}
		if (Input.GetKey (moveDown)) {
			transform.position += Vector3.down * speed * deltaTime;
			spriteRenderer.sprite = spritesF [index];
		}
		if (Input.GetKey (moveLeft)) {
			transform.position += Vector3.left * speed * deltaTime;
			spriteRenderer.sprite = spritesL [index];
		}
		if (Input.GetKey (moveRight)) {
			transform.position += Vector3.right * speed * deltaTime;
			spriteRenderer.sprite = spritesR [index];
		}
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		print("Their relative velocity is " + collisionInfo.relativeVelocity);
		if(collisionInfo.collider.name == "goal") {
			endGame = true;
			GameController.rules[0] = 1;
			//Application.LoadLevel("end");
		}
		if (collisionInfo.collider.name == "BoxLeft" || collisionInfo.collider.name == "BoxBottom" || collisionInfo.collider.name == "BoxTop" || collisionInfo.collider.name == "BoxRight") {
			print ("Collided with water");
		}
	}
}
