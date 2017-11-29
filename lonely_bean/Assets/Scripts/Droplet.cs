using UnityEngine;
using System.Collections;

public class Droplet : MonoBehaviour {

	public float damageAmount = 5f;
    public AudioClip clip;

	void OnTriggerEnter2D(Collider2D col){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (col.CompareTag ("Player")) {
            GetComponent<BoxCollider2D>().isTrigger = false;
            player.SendMessage ("ApplyDamage", damageAmount);
            Destroy(gameObject);
		}
        else
        {
            GetComponent<BoxCollider2D>().isTrigger = false;
            GetComponent<AudioSource>().PlayOneShot(clip);
            GetComponent<Renderer>().enabled = false;
            Destroy(gameObject, clip.length/2); //waits till audio is finished playing before destroying.
        }
	}
}