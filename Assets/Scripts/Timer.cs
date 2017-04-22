using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public float health = 100f;
    public float damage;
	public Text timerText;
	public GameObject GameOver;
	public GameObject restartButton;
	public Camera cam1;
	public Camera cam2;
	public Camera cam3;



	void Update () {
		health -= damage;
		timerText.text = timer.ToString ("00.0");
		if (health <= 0) {
			GameOver.SetActive (true);
			restartButton.SetActive (true);
			
			timer = 0;
			cam1.enabled = false;
			cam2.enabled = true;
			cam3.enabled = false;

		}

	}
}
