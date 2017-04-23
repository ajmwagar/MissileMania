using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthUi : MonoBehaviour {
	public Slider slider;

	// Use this for initialization
	void Start () {
		MessageHandler msgHandler = GetComponent<MessageHandler>();

		if(msgHandler)
		{
			msgHandler.RegisterDelegate(RecieveMessage);
		}
	}


	void RecieveMessage(MessageTurret msgType, GameObject go, MessageData msgData)
	{
		switch(msgType)
		{
		case MessageTurret.HEALTHCHANGED:
			HealthData hpData = msgData as HealthData;

			if(hpData != null)
			{
				UpdateUi(hpData.maxHealth, hpData.curHealth);
			}
			break;
		}
	}

	void UpdateUi(int maxHealth, int curHealth)
	{
		slider.value = (1.0f/maxHealth) * curHealth;
	}
}