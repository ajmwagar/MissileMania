using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RangeChecker : MonoBehaviour {
	public List<string> tags;

	List<GameObject> m_targets = new List<GameObject>();

	void OnTriggerEnter(Collider other)
	{
		bool invalid = true;

		for(int i = 0; i < tags.Count; i++)
		{
			if(other.CompareTag(tags[i]))
			{
				invalid = false;
				break;
			}
		}

		if(invalid)
			return;

		m_targets.Add(other.gameObject);
	}

	void OnTriggerExit(Collider other)
	{
		for(int i = 0; i < m_targets.Count; i++)
		{
			if(other.gameObject == m_targets[i])
			{
				m_targets.Remove(other.gameObject);
				return;
			}
		}
	}

	public List<GameObject> GetValidTargets()
	{
		return m_targets;
	}

	public bool InRange(GameObject go)
	{
		for(int i = 0; i < m_targets.Count; i++)
		{
			if(go == m_targets[i])
				return true;
		}

		return false;
	}
}