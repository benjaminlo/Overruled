using UnityEngine;
using System.Collections;


public class GameController : MonoBehaviour {

	public static int[] rules;
	public static int p1Score;
	public static int p2Score;

	////////////////////////////////
	//							  //
	//							  //
	//    Rule References Here    //
	//							  //
	//							  //
	//							  //
	////////////////////////////////



	// Use this for initialization
	void Start () {
		p1Score = 0;
		p2Score = 0;
		rules = new int[10];

		rules [0] = 0;

		DontDestroyOnLoad (gameObject);
	}
}
