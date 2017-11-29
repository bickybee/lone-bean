using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour {

    public Canvas bubble;
    public float visibilityTime;
    public string text;
	
	void OnTriggerEnter2D () {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Canvas theBubble = Instantiate(bubble, player.transform.position, player.transform.rotation) as Canvas;
        theBubble.GetComponentInChildren<Text>().text = text;
        theBubble.transform.SetParent(player.transform);
        Destroy(gameObject.GetComponent<BoxCollider2D>());
        Destroy(theBubble.GetComponentInChildren<Text>(), visibilityTime);
    }
}
