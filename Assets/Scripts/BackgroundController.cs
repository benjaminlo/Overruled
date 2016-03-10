using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	Texture2D forestBackground;
	Texture2D iceBackground;
	GameObject controller;

	int [] rules;

	// Use this for initialization
	void Start () {


		switch (GameController.rules [0]) {
		case 0:
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = forestBackground;
			break;
		case 1:
			iceBackground = Resources.Load ("IceBackground") as Texture2D;
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
			break;
		case 2:
			iceBackground = Resources.Load ("IceBackground") as Texture2D;
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
			break;
		}
	}
}
