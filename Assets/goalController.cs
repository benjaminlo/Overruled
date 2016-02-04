using UnityEngine;
using System.Collections;

public class goalController : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other) {
		Destroy (this.gameObject);
	}
}
