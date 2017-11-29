using UnityEngine;
using System.Collections;

public class KeepPlayerOn : MonoBehaviour {

    private GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

	// Use this for initialization
	void OnCollision2D (BoxCollider2D col) {
	    if (col == player.GetComponent<BoxCollider2D>())
        {
            player.transform.position += gameObject.transform.position;
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
