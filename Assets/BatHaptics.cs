using NullSpace.SDK;
	﻿using UnityEngine;

public class BatHaptics : MonoBehaviour {
	public bool Lefty;
	public bool Righty;
	HapticSequence BatHaptic = new HapticSequence();
	public GameObject HandPicker;


// Use this for initialization
void Start () {
	BatHaptic.LoadFromAsset("Haptic/buzz");
	HandPicker.SetActive(true);
}


	// Update is called once per frame
	public void SelLeft () {
		Lefty = true;
		Righty = false;
		HandPicker.SetActive(false);

	}
public void SelRight ()
  {
		Lefty = false;
		Righty = true;
		HandPicker.SetActive(true);
	}
public void OnCollisionEnter ()
{
	if (Lefty)
	{
		BatHaptic.CreateHandle(AreaFlag.Forearm_Left).Play();
        }
  if (Righty)
	{
			BatHaptic.CreateHandle(AreaFlag.Forearm_Right).Play();
				}

}
}
