using UnityEngine;
using System.Collections;

public class PauseScript : MonoBehaviour {

	public GameObject pausePanel;

	void Start(){
		pausePanel.SetActive (false);
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
			togglePause();
	}

	bool togglePause()
	{
		if(Time.timeScale == 0f)
		{
			Time.timeScale = 1f;
			pausePanel.SetActive (false);
			return(false);
		}
		else
		{
			Time.timeScale = 0f;
			pausePanel.SetActive (true);
			return(true);    
		}
	}
}
