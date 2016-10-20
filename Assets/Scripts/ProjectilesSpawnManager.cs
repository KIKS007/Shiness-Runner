using UnityEngine;
using System.Collections;

public class ProjectilesSpawnManager : Singleton<ProjectilesSpawnManager>
{
	public GameObject projectilePrefab;

	[Header ("Random")]
	public bool randomPosition;
	public float randomValue = 1;

	[Header ("Projectiles Test")]
	public bool projectileTest = false;
	public float spawnIntervalle = 2;
	public float spawnIntervalleRandom = 0.2f;

	[HideInInspector]
	public ProjectileSpawn[] spawns = new ProjectileSpawn[0];

	// Use this for initialization
	void Start () 
	{
		Transform spawnParent = GameObject.FindGameObjectWithTag ("ProjectilesSpawns").transform;

		spawns = new ProjectileSpawn[spawnParent.childCount];

		for(int i = 0; i < spawnParent.childCount; i++)
		{
			spawns [i] = spawnParent.GetChild (i).GetComponent <ProjectileSpawn> ();
		}

		if(projectileTest)
		{
			StartCoroutine (SpawnProjectilesTest ());
		}
	}

	IEnumerator SpawnProjectilesTest ()
	{
		int randomSpawnId = Random.Range (0, spawns.Length);
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
			position = new Vector3 (Random.Range (position.x - randomValue, position.x + randomValue), Random.Range (position.y - randomValue, position.y + randomValue), position.z);

		GameObject clone = Instantiate (projectilePrefab, position, projectilePrefab.transform.rotation) as GameObject;

		if(speed != -1)
			clone.GetComponent <Projectile> ().speed = speed;
	}
}
