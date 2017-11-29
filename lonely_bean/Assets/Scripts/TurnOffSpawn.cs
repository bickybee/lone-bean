using UnityEngine;
using System.Collections;

public class TurnOffSpawn : MonoBehaviour {

	public GameObject FoamSpawner;
	public bool buttonHasBeenPressed = false;

	void OnCollisionEnter2D(Collision2D col){
		if (!buttonHasBeenPressed) {
			FoamSpawner.SendMessage ("TurnSpawnOff");
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (0.4f,0.4f,0.4f);
			buttonHasBeenPressed = true;
		}

	}
}
