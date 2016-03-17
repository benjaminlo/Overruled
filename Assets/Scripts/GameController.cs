using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static int p1Score;
	public static int p2Score;

	public Transform goal;

	public static int[] rules;
	public static int numRules;
	public static int numChosenRules;
	public static bool displayRuleSelection;
	private static int selectionRule1;
	private static int selectionRule2;
	private static int selectionRule3;
	private static int selectionChoice1;
	private static int selectionChoice2;
	private static int selectionChoice3;
	private static string selection1;
	private static string selection2;
	private static string selection3;

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

	void Awake () {
		p1Score = 0;
		p2Score = 0;

		numRules = 3;
		numChosenRules = 0;
		rules = new int[numRules];
		displayRuleSelection = false;

		buttonStyle = new GUIStyle();
		buttonFont = Resources.Load ("ButtonFont") as Font;
		setupButtonStyle ();

		DontDestroyOnLoad (gameObject);
	}

	void Start() {
		Instantiate (goal);
	}

	void OnGUI() {
		if (displayRuleSelection) {
			if (GUI.Button (new Rect (Screen.width/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3), selection1, buttonStyle)) {
				setRule (selectionRule1, selectionChoice1);
				updatePlayersAndBackground ();
				displayRuleSelection = false;
				if (numChosenRules < numRules) 
					Instantiate (goal);
				
				printRulesInfo ();
			}
			if (GUI.Button (new Rect (Screen.width*3/8, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3), selection2, buttonStyle)) {
				setRule (selectionRule2, selectionChoice2);
				updatePlayersAndBackground ();
				displayRuleSelection = false;
				if (numChosenRules < numRules) 
					Instantiate (goal);
				
				printRulesInfo ();
			}
			if (GUI.Button (new Rect (Screen.width*11/16, Screen.height*19/20 - Screen.height*2/3, Screen.width/4, Screen.height*2/3), selection3, buttonStyle)) {
				setRule (selectionRule3, selectionChoice3);
				updatePlayersAndBackground ();
				displayRuleSelection = false;
				if (numChosenRules < numRules) 
					Instantiate (goal);

				printRulesInfo ();
			}
		}
	}

	void setupButtonStyle(){
		buttonStyle.font = buttonFont;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonStyle.normal.background = Resources.Load ("buttonImage") as Texture2D;
		buttonStyle.active.background = Resources.Load ("buttonPressedImage") as Texture2D;
	}

	private static int getRule() {
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
		selectionRule1 = getRule ();
		selectionRule2 = getRule ();
		selectionRule3 = getRule ();
		selectionChoice1 = Random.Range (1,3);
		selectionChoice2 = Random.Range (1,3);
		selectionChoice3 = Random.Range (1,3);

		selection1 = "Rule: " + selectionRule1 + "\nChoice: " + selectionChoice1;
		selection2 = "Rule: " + selectionRule1 + "\nChoice: " + selectionChoice2;
		selection3 = "Rule: " + selectionRule3 + "\nChoice: " + selectionChoice3;

		displayRuleSelection = true;
	}

	private static void setRule(int rule, int choice) {
		if (numChosenRules < numRules) {
			rules [rule] = choice;
			numChosenRules++;
		}
	}

	public static void printRulesInfo() {
		print (
			"Number of chosen rules = " + numChosenRules + "\n" +
			"Number of unchosen rules = " + (numRules - numChosenRules)
		);
		print ("Rules Array: " + rules [0] + rules [1] + rules [2]);
	}

	private void updatePlayersAndBackground() {
		BackgroundController.updateBackground ();
		GameObject.Find ("Player1").GetComponent<PlayerController>().updatePlayer ();
		GameObject.Find ("Player2").GetComponent<PlayerController>().updatePlayer ();
	}
}