using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public float backlashX;
    public float backlashY;
	public float damageAmount;

	void OnTriggerEnter2D(Collider2D col){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (col.CompareTag ("Player")) {
			player.SendMessage ("ApplyDamage", damageAmount);
			player.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (backlashX, backlashY), ForceMode2D.Impulse);
		}
	}

	void OnTriggerStay2D(Collider2D col){
		OnTriggerEnter2D (col);
	}
}