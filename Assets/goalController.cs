using UnityEngine;
using System.Collections;

public class goalController : MonoBehaviour {

	Texture2D iceBackground;

	void OnTriggerEnter2D(Collider2D other) {
		iceBackground = Resources.Load ("IceBackground") as Texture2D;
		GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
		Destroy (gameObject);
	}
}
