using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ProjectilesSpawnManager : Singleton<ProjectilesSpawnManager>
{
	public GameObject projectilePrefab;

	[Header ("Random")]
	public bool randomPosition;
	public float randomValueAdded = 1;

	[Header ("Projectiles Test")]
	public bool projectileTest = false;
	public float spawnIntervalle = 2;
	public float spawnIntervalleRandom = 0.2f;

	public List<int> idList = new List<int> ();

	[HideInInspector]
	public ProjectileSpawn[] spawns = new ProjectileSpawn[0];

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (ProjectilesSpawnManager.Instance);

		Transform spawnParent = GameObject.FindGameObjectWithTag ("ProjectilesSpawns").transform;

		spawns = new ProjectileSpawn[spawnParent.childCount];

		for(int i = 0; i < spawnParent.childCount; i++)
		{
			spawns [i] = spawnParent.GetChild (i).GetComponent <ProjectileSpawn> ();

			if (!idList.Contains (spawns [i].projectileId))
				idList.Add (spawns [i].projectileId);
		}

		if(projectileTest)
		{
			StartCoroutine (SpawnProjectilesTest ());
		}
	}

	IEnumerator SpawnProjectilesTest ()
	{
		int randomSpawnId = idList[Random.Range (0, idList.Count)];
		SpawnProjectile (randomSpawnId);

		yield return new WaitForSeconds (Random.Range (spawnIntervalle - spawnIntervalleRandom, spawnIntervalle + spawnIntervalleRandom));

		StartCoroutine (SpawnProjectilesTest ());
	}
	
	public void SpawnProjectile (int id)
	{
		Vector3 position = new Vector3 ();
		float speed = -1;

		for(int i =0; i < spawns.Length; i++)
		{
			if (spawns [i].projectileId == id)
			{
				position = spawns [i].transform.position;
				speed = spawns [i].projectileSpeed;
			}
		}

		if(randomPosition)
			position = new Vector3 (Random.Range (position.x - randomValueAdded, position.x + randomValueAdded), Random.Range (position.y - randomValueAdded, position.y + randomValueAdded), position.z);

		GameObject clone = Instantiate (projectilePrefab, position, projectilePrefab.transform.rotation) as GameObject;

		if(speed != -1)
			clone.GetComponent <Projectile> ().speed = speed;
	}
}
