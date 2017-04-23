using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBeam : ProjectileBase {
	public float beamLength = 10.0f;
	GameObject m_launcher;
	GameObject m_target;
	int m_damage;
	float m_attackSpeed;
	float m_attackTimer;

	//Update is called once per frame
	void Update () {
		m_attackTimer += Time.deltaTime;

		if(m_launcher){
			GetComponent<LineRenderer>().SetPosition(0, m_launcher.transform.position);
			GetComponent<LineRenderer>().SetPosition(1, m_launcher.transform.position + (m_launcher.transform.forward * beamLength));
			RaycastHit hit;

			if(Physics.Raycast(m_launcher.transform.position, m_launcher.transform.forward, out hit, beamLength))
			{
				if(hit.transform.gameObject == m_target)
				{
					if(m_attackTimer >= m_attackSpeed)
					{
						DamageData dmgData = new DamageData();
						dmgData.damage = m_damage;

						MessageHandler msgHandler = m_target.GetComponent<MessageHandler>();

						if(msgHandler)
						{
							msgHandler.GiveMessage(MessageTurret.DAMAGED, m_launcher, dmgData);
						}

						m_attackTimer = 0.0f;
					}
				}
			}
		}
	}

	public override void FireProjectile(GameObject launcher, GameObject target, int damage, float attackSpeed){
		if(launcher){
			m_launcher = launcher;
			m_target = target;
			m_damage = damage;
			m_attackSpeed = attackSpeed;
			m_attackTimer = 0.0f;
		}
	}
}
