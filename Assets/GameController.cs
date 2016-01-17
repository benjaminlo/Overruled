using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public static int [] rules = new int [7];
	GameObject moat;
	//[3]			[5]			[4]		[2]		[2]		[3]			[3]
	//environment, abilities, controls, trail, speed, attributes, goal
	//refer to document to see the lookups
	
	// Use this for initialization
	void Start () {
		for (int i = 0; i < rules.Length; i++)
			rules [i] = 0;
		moat = GameObject.Find ("Moat");
		moat.SetActive (false);

		rules [1] = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (rules [0] == 1)
			moat.SetActive (true);
		//if (rules [1] == 2)
		//show ice
	}
}
