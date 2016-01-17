using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class playerController : NetworkBehaviour {

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

	public bool endGame = false;

	// Use this for initialization
	void Start () { 
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % spritesF.Length;

		if (Input.GetKey (moveUp)) {
			transform.position += Vector3.up * speed * Time.deltaTime;
			spriteRenderer.sprite = spritesB [index];
		}
		if (Input.GetKey (moveDown)) {
			transform.position += Vector3.down * speed * Time.deltaTime;
			spriteRenderer.sprite = spritesF [index];
		}
		if (Input.GetKey (moveLeft)) {
			transform.position += Vector3.left * speed * Time.deltaTime;
			spriteRenderer.sprite = spritesL [index];
		}
		if (Input.GetKey (moveRight)) {
			transform.position += Vector3.right * speed * Time.deltaTime;
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
		//if(endGame) {
			print ("ENDING GAME!");
			//SceneManager.LoadScene("scene");
			SceneManager.LoadScene("end");
		}
	}
}
