using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static int p1Score;
	public static int p2Score;
	public static int[] p1Rules;
	public static int[] p2Rules;

	public Transform goal;

	public static int numRules;
	public static int numChosenRules;
	public static bool displayP1RuleSelection;
	public static bool displayP2RuleSelection;
	private static int p1SelectionRule1;
	private static int p1SelectionRule2;
	private static int p1SelectionRule3;
	private static int p1SelectionChoice1;
	private static int p1SelectionChoice2;
	private static int p1SelectionChoice3;
	private static int p2SelectionRule1;
	private static int p2SelectionRule2;
	private static int p2SelectionRule3;
	private static int p2SelectionChoice1;
	private static int p2SelectionChoice2;
	private static int p2SelectionChoice3;

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
	rules [0]	EMPTY FOR NOW
	rules [1]	Player speed (passive)
	rules [2]	Player size (active)
	*/

	void Awake () {
		p1Score = 0;
		p2Score = 0;

		numRules = 3;
		numChosenRules = 0;
		p1Rules = new int[numRules];
		p2Rules = new int[numRules];
		displayP1RuleSelection = false;
		displayP2RuleSelection = false;

		buttonStyle = new GUIStyle();
		buttonFont = Resources.Load ("ButtonFont") as Font;
		setupButtonStyle ();

		DontDestroyOnLoad (gameObject);
	}

	void Start() {
		Instantiate (goal);
	}

	void OnGUI() {
		if (displayP1RuleSelection) {
			if (GUI.Button (new Rect (Screen.width/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3),
				"Rule: " + p1SelectionRule1 + "\nChoice: " + p1SelectionChoice1, buttonStyle)) {
				setRule (p1Rules, p1SelectionRule1, p1SelectionChoice1);
				displayP1RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updatePlayersAndBackground ();
			}
			if (GUI.Button (new Rect (Screen.width*3/8, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3),
				"Rule: " + p1SelectionRule2 + "\nChoice: " + p1SelectionChoice2, buttonStyle)) {
				setRule (p1Rules, p1SelectionRule2, p1SelectionChoice2);
				displayP1RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updatePlayersAndBackground ();
			}
			if (GUI.Button (new Rect (Screen.width*11/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3),
				"Rule: " + p1SelectionRule3 + "\nChoice: " + p1SelectionChoice3, buttonStyle)) {
				setRule (p1Rules, p1SelectionRule3, p1SelectionChoice3);
				displayP1RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updatePlayersAndBackground ();
			}
		}

		if (displayP2RuleSelection) {
			if (GUI.Button (new Rect (Screen.width/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3),
				"Rule: " + p2SelectionRule1 + "\nChoice: " + p2SelectionChoice1, buttonStyle)) {
				setRule (p2Rules, p2SelectionRule1, p2SelectionChoice1);
				displayP2RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updatePlayersAndBackground ();
			}
			if (GUI.Button (new Rect (Screen.width*3/8, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3),
				"Rule: " + p2SelectionRule3 + "\nChoice: " + p2SelectionChoice2, buttonStyle)) {
				setRule (p2Rules, p2SelectionRule2, p2SelectionChoice2);
				displayP2RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updatePlayersAndBackground ();
			}
			if (GUI.Button (new Rect (Screen.width*11/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3),
				"Rule: " + p2SelectionRule3 + "\nChoice: " + p2SelectionChoice3, buttonStyle)) {
				setRule (p2Rules, p2SelectionRule3, p2SelectionChoice3);
				displayP2RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updatePlayersAndBackground ();
			}
		}
	}

	void setupButtonStyle(){
		buttonStyle.font = buttonFont;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		//buttonStyle.normal.background = Resources.Load ("buttonImage") as Texture2D;
		//buttonStyle.active.background = Resources.Load ("buttonPressedImage") as Texture2D;
	}

	private static int getRule(int[] rules) {
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

	public static void runRuleSelection() {
		p1SelectionRule1 = getRule (p1Rules);
		p1SelectionRule2 = getRule (p1Rules);
		p1SelectionRule3 = getRule (p1Rules);
		p1SelectionChoice1 = Random.Range (1,3);
		p1SelectionChoice2 = Random.Range (1,3);
		p1SelectionChoice3 = Random.Range (1,3);

		p2SelectionRule1 = getRule (p2Rules);
		p2SelectionRule2 = getRule (p2Rules);
		p2SelectionRule3 = getRule (p2Rules);
		p2SelectionChoice1 = Random.Range (1,3);
		p2SelectionChoice2 = Random.Range (1,3);
		p2SelectionChoice3 = Random.Range (1,3);

		displayP1RuleSelection = true;
		displayP2RuleSelection = true;
	}

	private static void setRule(int[] rules, int rule, int choice) {
		rules [rule] = choice;
	}

	public static void printRulesInfo() {
		print (
			"Number of chosen rules = " + numChosenRules + "\n" +
			"Number of unchosen rules = " + (numRules - numChosenRules)
		);
		print ("p1Rules Array: " + p1Rules [0] + p1Rules [1] + p1Rules [2]);
		print ("p2Rules Array: " + p2Rules [0] + p2Rules [1] + p2Rules [2]);
	}

	private void updatePlayersAndBackground() {
		numChosenRules++;
		BackgroundController.updateBackground ();
		GameObject.Find ("Player1").GetComponent<PlayerController>().updatePlayer (p1Rules);
		GameObject.Find ("Player2").GetComponent<PlayerController>().updatePlayer (p2Rules);
		if(numChosenRules < numRules) {
			Instantiate (goal);
		}
		printRulesInfo ();
	}
}