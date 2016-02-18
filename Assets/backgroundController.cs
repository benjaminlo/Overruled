using UnityEngine;
using System.Collections;

public class backgroundController : MonoBehaviour {
	GameObject background;
	Texture2D iceBackground;
	GameObject controller;

	int [] rules;

	// Use this for initialization
	void Start () {

		iceBackground = Resources.Load ("IceBackground") as Texture2D;

		switch (GameController.rules [0]) {
		case 0:
			break;
		case 1:
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
			break;
		case 2:
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
			break;
		}
	}
}
