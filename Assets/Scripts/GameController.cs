using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameController : MonoBehaviour {

	public static int[] rules;
	public static int p1Score;
	public static int p2Score;
	public static bool runRuleSelection;
	GUIStyle buttonStyle;
	Font buttonFont;

	////////////////////////////////
	//							  //
	//							  //
	//    Rule References Here    //
	//							  //
	//							  //
	//							  //
	////////////////////////////////


	public Texture btnTexture;

	// Use this for initialization
	void Start () {

		buttonStyle = new GUIStyle();
		buttonFont = Resources.Load ("ButtonFont") as Font;

		setupButtonStyle ();

		p1Score = 0;
		p2Score = 0;
		runRuleSelection = false;

		rules = new int[10];

		rules [0] = 0; // Background
		rules [1] = 2; // Player speed
		rules [2] = 2; // Player size

		DontDestroyOnLoad (gameObject);

	}

	void OnGUI() {
		if (runRuleSelection) {
			if (GUI.Button (new Rect (Screen.width/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3), "Rule 1", buttonStyle)) {
				Debug.Log ("1");
			}
			if (GUI.Button (new Rect (Screen.width*3/8, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3), "Rule 2", buttonStyle)) {
				Debug.Log ("2");
			}
			if (GUI.Button (new Rect (Screen.width*11/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3), "Rule 3", buttonStyle)) {
				Debug.Log ("3");
			}
		}
	}

	void setupButtonStyle(){
		buttonStyle.font = buttonFont;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonStyle.normal.background = Resources.Load ("buttonImage") as Texture2D;
		buttonStyle.active.background = Resources.Load ("buttonPressedImage") as Texture2D;
	}
}
