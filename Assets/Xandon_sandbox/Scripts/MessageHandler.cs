using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class MessageData{};
public enum MessageTurret{DAMAGED, HEALTHCHANGED, DIED};
public delegate void MessageDelegate(MessageTurret msgType, GameObject go, MessageData msgData);

public class MessageHandler : MonoBehaviour {
	public List<MessageTurret> messages;

	List<MessageDelegate> m_messageDelegates = new List<MessageDelegate>();

	public void RegisterDelegate(MessageDelegate msgDele)
	{
		m_messageDelegates.Add(msgDele);
	}

	public bool GiveMessage(MessageTurret msgType, GameObject go, MessageData msgData)
	{
		bool approved = false;

		for(int i = 0; i < messages.Count; i++)
		{
			if(messages[i] == msgType)
			{
				approved = true;
				break;
			}
		}

		if(!approved)
			return false;

		for(int i = 0; i < m_messageDelegates.Count; i++)
		{
			m_messageDelegates[i](msgType, go, msgData);
		}

		return true;
	}
}

public class DamageData : MessageData{
	public int damage;
}

public class DeathData : MessageData{
	public GameObject attacker;
	public GameObject attacked;
}

public class HealthData : MessageData{
	public int maxHealth;
	public int curHealth;
}