using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour 
{
	public GameObject projectile;
	public Vector2 spawnValues;
	public int projectileCount;
	public float spawnWait;

	void Start ()
	{
		StartCoroutine(SpawnProjectile ());
	}

	IEnumerator SpawnProjectile ()
	{
		for (int i = 0; i < projectileCount; i++) {
			Vector3 spawnPosition = new Vector3 (spawnValues.x, spawnValues.y, 0);
			Quaternion spawnRotation = Quaternion.identity;
			Instantiate (projectile, spawnPosition, spawnRotation);
			yield return new WaitForSeconds (spawnWait);
		}
	}
}
