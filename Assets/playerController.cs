using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	public float speed = 1.5f;
	public KeyCode moveUp;
	public KeyCode moveDown;
	public KeyCode moveLeft;
	public KeyCode moveRight;

	// Use this for initialization
	void Start () { 
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(moveUp))
			transform.position += Vector3.up * speed * Time.deltaTime;
		if (Input.GetKey(moveDown))
			transform.position += Vector3.down * speed * Time.deltaTime;
		if (Input.GetKey(moveLeft))
			transform.position += Vector3.left * speed * Time.deltaTime;
		if (Input.GetKey(moveRight))
			transform.position += Vector3.right * speed * Time.deltaTime;
	}

	void OnCollisionEnter2D(Collision2D collisionInfo)
	{
		print("Detected collision between " + gameObject.name + " and " + collisionInfo.collider.name);
		print("There are " + collisionInfo.contacts.Length + " point(s) of contacts");
		print("Their relative velocity is " + collisionInfo.relativeVelocity);
	}
}
