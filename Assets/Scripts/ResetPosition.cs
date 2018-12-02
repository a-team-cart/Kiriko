using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

	private float m_spawnRange = 150f;

	private void OnTriggerEnter(Collider other){
		// Debug.Log(other);
		float xRange = Random.Range(-m_spawnRange,m_spawnRange);
		float yRange = Random.Range(-m_spawnRange,m_spawnRange);
		float zRange = Random.Range(-m_spawnRange,m_spawnRange);
		other.gameObject.transform.position = new Vector3(xRange,100,zRange);
	}
}
