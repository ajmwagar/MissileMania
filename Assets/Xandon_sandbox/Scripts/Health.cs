using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public int maxHealth = 100;

	int m_curHealth;
	MessageHandler m_messageHandler;

	// Use this for initialization
	void Start () {
		m_curHealth = maxHealth;
		m_messageHandler = GetComponent<MessageHandler>();

		if(m_messageHandler)
		{
			m_messageHandler.RegisterDelegate(RecieveMessage);
		}
	}

	void RecieveMessage(MessageTurret msgType, GameObject go, MessageData msgData)
	{
		switch(msgType)
		{
		case MessageTurret.DAMAGED:
			DamageData dmgData = msgData as DamageData;

			if(dmgData != null)
			{
				DoDamage(dmgData.damage, go);
			}
			break;
		}
	}

	void DoDamage(int dmg, GameObject go)
	{
		m_curHealth -= dmg;

		if(m_curHealth <= 0)
		{
			m_curHealth = 0;

			if(m_messageHandler)
			{
				DeathData deathData = new DeathData();
				deathData.attacker = go;
				deathData.attacked = gameObject;

				m_messageHandler.GiveMessage(MessageTurret.DIED, gameObject, deathData);
			}
		}

		if(m_messageHandler)
		{
			HealthData hpData = new HealthData();

			hpData.maxHealth = maxHealth;
			hpData.curHealth = m_curHealth;

			m_messageHandler.GiveMessage(MessageTurret.HEALTHCHANGED, gameObject, hpData);
		}
	}
}
