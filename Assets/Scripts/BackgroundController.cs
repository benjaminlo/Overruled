using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour {

	private static Material backgroundMaterial;
	private static Texture2D forestBackground;
	private static Texture2D iceBackground;
	private static int numBackgrounds;

	void Start () {
		numBackgrounds = 2;
		backgroundMaterial = GameObject.Find ("Background").GetComponent<Renderer> ().material;

		backgroundMaterial.shader = Shader.Find ("Sprites/Default");

		forestBackground = Resources.Load ("ForestBackground") as Texture2D;
		iceBackground = Resources.Load ("IceBackground") as Texture2D;
	}

	public static void updateBackground() {
		switch (Random.Range (0, numBackgrounds)) {
		case 0:
			backgroundMaterial.mainTexture = forestBackground;
			break;
		case 1:
			backgroundMaterial.mainTexture = iceBackground;
			break;
		}
	}
}