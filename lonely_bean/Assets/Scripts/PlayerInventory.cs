using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour {

    public Dictionary<string, int> items;
    public Text txt;

	// Use this for initialization
	void Start () {
        items = new Dictionary<string, int>();
        items.Add("bean", 0);
        items.Add("key", 0);
	}

    //update HUD counters
    void Update()
    {

    }
	
	// pick up an item
	public void Increment (string item) {
        int numItems = ++items[item];
        txt.text = numItems.ToString();
	}

    // drop/use an item
    public void Decrement (string item)
    {
        int numItems = --items[item];
        txt.text = numItems.ToString();
    }

    public int GetNumberOf(string item)
    {
        return items[item];
    }
}
