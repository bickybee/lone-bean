using UnityEngine;
using System.Collections;

public class Door: MonoBehaviour {

    GameObject player;
    PlayerInventory inventory;
    public int numRequired;
    bool isRed;
    public float timer;
    float rednessTime = 0.2f;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        inventory = player.GetComponent<PlayerInventory>();
        Color transparent = new Color(1, 0, 0, 0);
        gameObject.GetComponent<SpriteRenderer>().color = transparent;
    }

    void Update()
    {
        if (isRed)
        {
            timer += Time.deltaTime;
            if (timer >= rednessTime)
            {
                gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0, 0);
                isRed = false;
                timer = 0;
            }
        }
    }

    void OnCollisionEnter2D () {
	    if (inventory.GetNumberOf("bean") == numRequired)
        {
            Destroy(gameObject);
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1,0,0,0.5f);
            isRed = true;
        }
	}
}
