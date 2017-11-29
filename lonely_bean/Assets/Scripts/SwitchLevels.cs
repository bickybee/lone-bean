using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SwitchLevels : MonoBehaviour {

    public string nextLevel;

	// Use this for initialization
	void OnTriggerEnter2D()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
