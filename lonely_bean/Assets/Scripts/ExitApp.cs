using UnityEngine;
using System.Collections;

public class ExitApp : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if (Input.inputString=="e"|| Input.inputString == "E") { 
            Application.Quit();
        }
    }
}

