using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public Transform goalPrefab;

	private GUIStyle buttonStyle;
	public Button playAgainButton;
	public GUIText p1ScoreText;
	public GUIText p2ScoreText;

	private int p1Score;
	private int p2Score;

	private int[] p1Rules;
	private int[] p2Rules;
	private int numRules;
	private int numChosenRules;
	private bool displayP1RuleSelection;
	private bool displayP2RuleSelection;
	private int p1SelectionRule1;
	private int p1SelectionRule2;
	private int p1SelectionRule3;
	private int p1SelectionChoice1;
	private int p1SelectionChoice2;
	private int p1SelectionChoice3;
	private int p2SelectionRule1;
	private int p2SelectionRule2;
	private int p2SelectionRule3;
	private int p2SelectionChoice1;
	private int p2SelectionChoice2;
	private int p2SelectionChoice3;

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
		setButtonStyle ();
		playAgainButton.gameObject.SetActive(false);

		p1Score = 0;
		p2Score = 0;

		numRules = 3;
		numChosenRules = 0;
		p1Rules = new int[numRules];
		p2Rules = new int[numRules];
		displayP1RuleSelection = false;
		displayP2RuleSelection = false;
	}

	void Start() {
		instantiateGoals ();
		p1ScoreText.text = "P1 Score: " + p1Score;
		p2ScoreText.text = "P2 Score: " + p2Score;
	}

	private void instantiateGoals() {
		Transform p1Goal = Instantiate (goalPrefab, GameObject.Find ("Player 1").transform.position + new Vector3 (-1, 0, 0), GameObject.Find ("Player 1").transform.rotation) as Transform;
		Transform p2Goal = Instantiate (goalPrefab, GameObject.Find ("Player 2").transform.position + new Vector3 (1, 0, 0), GameObject.Find ("Player 2").transform.rotation) as Transform;
		p1Goal.GetComponent<GoalController> ().setPlayer (GameObject.Find ("Player 1").transform);
		p2Goal.GetComponent<GoalController> ().setPlayer (GameObject.Find ("Player 2").transform);
	}

	void setButtonStyle(){
		Font buttonFont = Resources.Load ("ButtonFont") as Font;
		buttonStyle = new GUIStyle();
		buttonStyle.font = buttonFont;
		buttonStyle.alignment = TextAnchor.MiddleCenter;
		buttonStyle.normal.background = Resources.Load ("buttonImage") as Texture2D;
		buttonStyle.active.background = Resources.Load ("buttonPressedImage") as Texture2D;
	}

	void OnGUI() {
		if (displayP1RuleSelection) {
			if (GUI.Button (new Rect (Screen.width/16, Screen.height/16, Screen.width/4, Screen.height/4),
				"Rule: " + p1SelectionRule1 + "\nChoice: " + p1SelectionChoice1, buttonStyle)) {
				setRule (p1Rules, p1SelectionRule1, p1SelectionChoice1);
				displayP1RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updateGame ();
			}
			if (GUI.Button (new Rect (Screen.width/16, Screen.height*6/16, Screen.width/4, Screen.height/4),
				"Rule: " + p1SelectionRule2 + "\nChoice: " + p1SelectionChoice2, buttonStyle)) {
				setRule (p1Rules, p1SelectionRule2, p1SelectionChoice2);
				displayP1RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updateGame ();
			}
			if (GUI.Button (new Rect (Screen.width/16, Screen.height*11/16, Screen.width/4, Screen.height/4),
				"Rule: " + p1SelectionRule3 + "\nChoice: " + p1SelectionChoice3, buttonStyle)) {
				setRule (p1Rules, p1SelectionRule3, p1SelectionChoice3);
				displayP1RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updateGame ();
			}
		}

		if (displayP2RuleSelection) {
			if (GUI.Button (new Rect (Screen.width*11/16, Screen.height/16, Screen.width/4, Screen.height/4),
				"Rule: " + p2SelectionRule1 + "\nChoice: " + p2SelectionChoice1, buttonStyle)) {
				setRule (p2Rules, p2SelectionRule1, p2SelectionChoice1);
				displayP2RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updateGame ();
			}
			if (GUI.Button (new Rect (Screen.width*11/16, Screen.height*6/16, Screen.width/4, Screen.height/4),
				"Rule: " + p2SelectionRule3 + "\nChoice: " + p2SelectionChoice2, buttonStyle)) {
				setRule (p2Rules, p2SelectionRule2, p2SelectionChoice2);
				displayP2RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updateGame ();
			}
			if (GUI.Button (new Rect (Screen.width*11/16, Screen.height*11/16, Screen.width/4, Screen.height/4),
				"Rule: " + p2SelectionRule3 + "\nChoice: " + p2SelectionChoice3, buttonStyle)) {
				setRule (p2Rules, p2SelectionRule3, p2SelectionChoice3);
				displayP2RuleSelection = false;
				if (displayP1RuleSelection == false && displayP2RuleSelection == false)
					updateGame ();
			}
		}
	}

	private int getRule(int[] rules) {
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

	private void setRule(int[] rules, int rule, int choice) {
		rules [rule] = choice;
	}

	public void runRuleSelection() {
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

	public void printRulesInfo() {
		print (
			"Number of chosen rules = " + numChosenRules + "\n" +
			"Number of unchosen rules = " + (numRules - numChosenRules)
		);
		print ("p1Rules Array: " + p1Rules [0] + p1Rules [1] + p1Rules [2]);
		print ("p2Rules Array: " + p2Rules [0] + p2Rules [1] + p2Rules [2]);
	}

	public void incrementScore(string scorer) {
		switch (scorer) {
		case "Player 1":
			p1Score += 10;
			break;
		case "Player 2":
			p2Score += 10;
			break;
		}
		p1ScoreText.text = "P1 Score: " + p1Score;
		p2ScoreText.text = "P2 Score: " + p2Score;
	}

	private void updateGame() {
		numChosenRules++;
		BackgroundController.updateBackground ();
		GameObject.Find ("Player 1").GetComponent<PlayerController>().updatePlayer (p1Rules);
		GameObject.Find ("Player 2").GetComponent<PlayerController>().updatePlayer (p2Rules);
		if (numChosenRules < numRules) {
			instantiateGoals ();
		} else
			playAgainButton.gameObject.SetActive(true);
			
		printRulesInfo ();
	}

	public void playAgain() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}