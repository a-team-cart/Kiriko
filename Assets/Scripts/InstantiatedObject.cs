using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatedObject
{
	public int mass;
	public float size;

	public Vector3 spawnPosition;
	public Rigidbody objectBody;

	public MeshRenderer objectRender;

	public InstantiatedObject(int newMass, float newSize, Vector3 NewSpawnPosition, Rigidbody newObjectBody){
		mass = newMass;
		size = newSize;
		spawnPosition = NewSpawnPosition;
		objectBody = newObjectBody;

	}



}
