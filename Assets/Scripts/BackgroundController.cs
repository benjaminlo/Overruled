using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {
	Texture2D forestBackground;
	Texture2D iceBackground;

	// Use this for initialization
	void Start () {

		forestBackground = Resources.Load ("forestBackground") as Texture2D;
		iceBackground = Resources.Load ("iceBackground") as Texture2D;

		switch (GameController.rules [0]) {
		case 0:
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = forestBackground;
			break;
		case 1:
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
			break;
		}
	}
}
