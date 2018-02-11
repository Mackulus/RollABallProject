using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour {

	//Projectile shooting code
	//https://unity3d.com/learn/tutorials/temas/multiplayer-networking/shooting-single-player

	public GameObject cubePrefab;
	public Transform cubeSpawn;
	public float spawnTime = 4f;
	public float destroyTime = 4f;
	public int cubeSpeed;

	// Use this for initialization
	void Start () {
		InvokeRepeating ("SpawnCube", spawnTime, spawnTime);
	}
	
	// Update is called once per frame
	void Update () {
	}

	void SpawnCube()
	{
		var cube = (GameObject)Instantiate (
			cubePrefab,
			cubeSpawn.position,
			cubeSpawn.rotation);

		cube.GetComponent<Rigidbody>().velocity = cube.transform.forward * cubeSpeed;

		Destroy(cube, destroyTime);
	}
}
