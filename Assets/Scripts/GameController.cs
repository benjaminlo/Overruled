using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static int p1Score;
	public static int p2Score;

	public static int[] rules;
	private static int numRules;
	private static int numChosenRules;
	public static bool runRuleSelection;

	public Texture btnTexture;
	private GUIStyle buttonStyle;
	private Font buttonFont;

	////////////////////////////////
	//							  //
	//       Rule Reference		  //
	//							  //
	////////////////////////////////

	/*
	A rule's default value is 0 (i.e. rule has not been chosen)
	rules [0]	Background
	rules [1]	Player speed (passive)
	rules [2]	Player size (active)
	*/

	// Use this for initialization
	void Start () {
		p1Score = 0;
		p2Score = 0;

		numRules = 3;
		numChosenRules = 0;
		rules = new int[numRules];
		runRuleSelection = false;

		buttonStyle = new GUIStyle();
		buttonFont = Resources.Load ("ButtonFont") as Font;
		setupButtonStyle ();

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

	public static int getRule() {
		int[] unchosenRules = new int[numRules];
		int unchosenRulesArrayLength = 0;

		for (int i = 0; i < rules.Length; i++) {
			if (rules [i] == 0) {
				unchosenRules [unchosenRulesArrayLength] = i;
				unchosenRulesArrayLength++;
			}
		}
		return unchosenRules[Random.Range (0,unchosenRulesArrayLength)];
	}

	public static void setRule(int rule, int choice) {
		if (numChosenRules < numRules) {
			rules [rule] = choice;
			numChosenRules++;
		}
	}

	public static void getRulesInfo() {
		print (
			"Number of chosen rules = " + numChosenRules + "\n" +
			"Number of unchosen rules = " + (numRules - numChosenRules)
		);
		print ("Rules Array: " + rules [0] + rules [1] + rules [2]);
	}
}