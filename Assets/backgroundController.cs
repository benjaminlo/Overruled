using UnityEngine;
using System.Collections;

public class backgroundController : MonoBehaviour {
	GameObject background;
	Texture2D iceBackground;
	Texture2D forestBackground;
	GameObject controller;

	int [] rules;

	// Use this for initialization
	void Start () {



		switch (GameController.rules [0]) {
		case 0:
			forestBackground = Resources.Load("ForestBackground") as Texture2D;
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
