using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;


public class PlayerHealth : MonoBehaviour {

	public int playerHealth;
	public int startingHealth = 100;
	public Slider HealthBar;
	public bool isRed = false;
	public float timer;
	public float rednessTime = 1f;
    public AudioClip clip;

	// Use this for initialization
	void Awake () {
		playerHealth = startingHealth;
	}

	void Update () {
		if (isRed) {
			timer += Time.deltaTime;
			if (timer >= rednessTime) {
				gameObject.GetComponent<Renderer>().material.color = new Color(1f,1f,1f,1f);
				isRed = false;
				timer = 0;
			}
		}
	}

	public void ApplyDamage (int amount) {
        GetComponent<AudioSource>().PlayOneShot(clip);
        playerHealth -= amount;
		HealthBar.value = playerHealth;
		gameObject.GetComponent<Renderer>().material.color = new Color(1f,0f,0f);
		isRed = true;

		if (playerHealth <= 0) {
			Death ();
		}
	}

    public void Heal(int amount)
    {
        if ((playerHealth + amount) <= startingHealth)
        {
            playerHealth += amount;
            HealthBar.value = playerHealth;
        }
    }

	public void Death(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
		
}
