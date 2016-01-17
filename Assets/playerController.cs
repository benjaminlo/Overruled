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

	void CmdMoveUp () {
		transform.position += Vector3.up * speed * Time.deltaTime;
	}

	void CmdMoveDown () {
		transform.position += Vector3.down * speed * Time.deltaTime;
	}

	void CmdMoveLeft () {
		transform.position += Vector3.left * speed * Time.deltaTime;
	}

	void CmdMoveRight () {
		transform.position += Vector3.right * speed * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % spritesF.Length;

		if (Input.GetKey (moveUp)) {
			CmdMoveUp ();
			spriteRenderer.sprite = spritesB [index];
		}
		if (Input.GetKey (moveDown)) {
			CmdMoveDown ();
			spriteRenderer.sprite = spritesF [index];
		}
		if (Input.GetKey (moveLeft)) {
			CmdMoveLeft ();
			spriteRenderer.sprite = spritesL [index];
		}
		if (Input.GetKey (moveRight)) {
			CmdMoveRight ();
			spriteRenderer.sprite = spritesR [index];
		}
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)	{
		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		print("Their relative velocity is " + collisionInfo.relativeVelocity);
		if(collisionInfo.collider.name == "goal")
			endGame = true;
		if(endGame) {
			print ("ENDING GAME!");
			//SceneManager.LoadScene("scene");
			SceneManager.LoadScene("end");
		}
	}
}