using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public Slider slider;

	public void Decrease (int amount) {
		slider.value--;
	}
}
