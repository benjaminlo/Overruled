using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	private static Texture2D forestBackground;
	private static Texture2D iceBackground;

	// Use this for initialization
	void Start () {
		forestBackground = Resources.Load ("ForestBackground") as Texture2D;
		iceBackground = Resources.Load ("IceBackground") as Texture2D;
	}

	public static void updateBackground() {
		switch (GameController.rules [0]) {
		case 0:
			break;
		case 1:
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = forestBackground;
			break;
		case 2:
			GameObject.Find ("Background").GetComponent<Renderer> ().material.mainTexture = iceBackground;
			break;
		}
	}
}