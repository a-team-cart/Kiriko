using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPosition : MonoBehaviour {

	public float m_spawnRange = 50f;

	void start(){
	}

	void OnTriggetEnter(Collider other){
		float xRange = Random.Range(-m_spawnRange,m_spawnRange);
		float yRange = Random.Range(-m_spawnRange,m_spawnRange);
		float zRange = Random.Range(-m_spawnRange,m_spawnRange);
		other.gameObject.transform.position = new Vector3(m_spawnRange,100,m_spawnRange);
	}
}
