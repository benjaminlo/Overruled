using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	
	public Transform goalPrefab;

	private GUIStyle buttonStyle;
	private Canvas p1RuleSelectionUi;
	private Canvas p2RuleSelectionUi;
	private Text p1ScoreText;
	private Text p2ScoreText;
	private Text winnerText;
	public Button playAgainButton;

	private int p1Score;
	private int p2Score;

	private string[,] ruleDescriptions;
	private int[] p1Rules;
	private int[] p2Rules;
	private int numRules;
	private int numChosenRules;
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
		p1RuleSelectionUi = GameObject.Find ("P1 Rule Selection").GetComponent<Canvas>();
		p2RuleSelectionUi = GameObject.Find ("P2 Rule Selection").GetComponent<Canvas>();
		playAgainButton = GameObject.Find ("Play Again Button").GetComponent<Button>();
		p1ScoreText = GameObject.Find ("Player 1 Score").GetComponent<Text> ();
		p2ScoreText = GameObject.Find ("Player 2 Score").GetComponent<Text> ();
		winnerText = GameObject.Find ("Winner Text").GetComponent<Text> ();

		p1Score = 0;
		p2Score = 0;

		numRules = 3;
		numChosenRules = 0;
		ruleDescriptions = new string [3, 3] {
			{ "EMPTY", "", "" }, 
			{ "Player Speed", "1/2x", "2x" },
			{ "Player Size", "1/2x", "2x" }
		};
		p1Rules = new int[numRules];
		p2Rules = new int[numRules];
	}

	void Start() {
		p1RuleSelectionUi.gameObject.SetActive (false);
		p2RuleSelectionUi.gameObject.SetActive (false);
		playAgainButton.gameObject.SetActive (false);
		instantiateGoals ();
		p1ScoreText.text = "P1 Score: " + p1Score;
		p2ScoreText.text = "P2 Score: " + p2Score;
		winnerText.text = "";
	}

	private void instantiateGoals() {
		Transform p1Goal = Instantiate (goalPrefab, GameObject.Find ("Player 1").transform.position + new Vector3 (-1, 0, 0), GameObject.Find ("Player 1").transform.rotation) as Transform;
		Transform p2Goal = Instantiate (goalPrefab, GameObject.Find ("Player 2").transform.position + new Vector3 (1, 0, 0), GameObject.Find ("Player 2").transform.rotation) as Transform;
		p1Goal.GetComponent<GoalController> ().setPlayer (GameObject.Find ("Player 1").transform);
		p2Goal.GetComponent<GoalController> ().setPlayer (GameObject.Find ("Player 2").transform);
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

		p1RuleSelectionUi.gameObject.SetActive (true);
		GameObject.Find ("P1 Top Button").GetComponentInChildren<Text> ().text = ruleDescriptions [p1SelectionRule1, 0] + "\n" + ruleDescriptions [p1SelectionRule1, p1SelectionChoice1];
		GameObject.Find ("P1 Middle Button").GetComponentInChildren<Text> ().text = ruleDescriptions [p1SelectionRule2, 0] + "\n" + ruleDescriptions [p1SelectionRule2, p1SelectionChoice2];
		GameObject.Find ("P1 Bottom Button").GetComponentInChildren<Text> ().text = ruleDescriptions [p1SelectionRule3, 0] + "\n" + ruleDescriptions [p1SelectionRule3, p1SelectionChoice3];

		p2RuleSelectionUi.gameObject.SetActive (true);
		GameObject.Find ("P2 Top Button").GetComponentInChildren<Text> ().text = ruleDescriptions [p2SelectionRule1, 0] + "\n" + ruleDescriptions [p2SelectionRule1, p2SelectionChoice1];
		GameObject.Find ("P2 Middle Button").GetComponentInChildren<Text> ().text = ruleDescriptions [p2SelectionRule2, 0] + "\n" + ruleDescriptions [p2SelectionRule2, p2SelectionChoice2];
		GameObject.Find ("P2 Bottom Button").GetComponentInChildren<Text> ().text = ruleDescriptions [p2SelectionRule3, 0] + "\n" + ruleDescriptions [p2SelectionRule3, p2SelectionChoice3];
	}

	public void onP1RuleSelection(int buttonPosition) {
		switch (buttonPosition) {
		case 1:
			setRule (p1Rules, p1SelectionRule1, p1SelectionChoice1);
			break;
		case 2:
			setRule (p1Rules, p1SelectionRule2, p1SelectionChoice2);
			break;
		case 3:
			setRule (p1Rules, p1SelectionRule3, p1SelectionChoice3);
			break;
		}
		p1RuleSelectionUi.gameObject.SetActive (false);
		if (!p1RuleSelectionUi.isActiveAndEnabled && !p2RuleSelectionUi.isActiveAndEnabled)
			updateGame ();
	}

	public void onP2RuleSelection(int buttonPosition) {
		switch (buttonPosition) {
		case 1:
			setRule (p2Rules, p2SelectionRule1, p2SelectionChoice1);
			break;
		case 2:
			setRule (p2Rules, p2SelectionRule2, p2SelectionChoice2);
			break;
		case 3:
			setRule (p2Rules, p2SelectionRule3, p2SelectionChoice3);
			break;
		}
		p2RuleSelectionUi.gameObject.SetActive (false);
		if (!p1RuleSelectionUi.isActiveAndEnabled && !p2RuleSelectionUi.isActiveAndEnabled)
			updateGame ();
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
		} else {
			playAgainButton.gameObject.SetActive (true);
			if (p1Score > p2Score)
				winnerText.text = "PLAYER 1 WINS!";
			else
				winnerText.text = "PLAYER 2 WINS!";
		}
			
		printRulesInfo ();
	}

	public void playAgain() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}
}