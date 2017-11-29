using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FloatingPickUp : MonoBehaviour {

	public float amplitude;
	public float speed;
    public string itemType;
    public AudioClip audioClip;

	// floating animation
	void FixedUpdate () {
		Vector3 tempY = gameObject.GetComponent<Transform>().position;
		tempY.y += amplitude*Mathf.Sin (speed * Time.time);
		gameObject.GetComponent<Transform>().position = tempY;
	}

	void OnTriggerEnter2D(Collider2D col){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (col == player.GetComponent<BoxCollider2D>())
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(audioClip);
            if (itemType != "heart") player.SendMessage("Increment", itemType);//increment item in inventory
            else player.SendMessage("Heal", 10);//or, healing item is immediately used and does not go to inventory
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            gameObject.GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, audioClip.length);
        }
	}
}
