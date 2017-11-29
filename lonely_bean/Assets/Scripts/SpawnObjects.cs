using UnityEngine;
using System.Collections;

public class SpawnObjects : MonoBehaviour {

	public float timer;
	public float frequency = 100f;
	public GameObject spawn;
	public Transform spawnPoint;
	public bool turnedOn = true;
	
	// Update is called once per frame
	void Update () {
        if (gameObject.GetComponentInParent<Renderer>().isVisible)
        {
            if (turnedOn)
            {
                timer += Time.deltaTime;
                if (timer >= frequency)
                {
                    GameObject newObj = Instantiate(spawn, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
                    newObj.transform.localScale = gameObject.transform.localScale;
                    timer = 0;
                }
            }
        }
	}

	public void TurnSpawnOff() {
		if (turnedOn)
			turnedOn = false;
	}
}
