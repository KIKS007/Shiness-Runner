using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {
	public GameObject projectile;
	public Vector3 projectileRelativePosition;
	public int projectileCount;
	public float spawnRate;
	public bool randomPosition;

	public void Start()
	{
		StartCoroutine (SpawnProjectile ());
	}

	IEnumerator SpawnProjectile()
	{
		for (int i = 0; i < projectileCount; i++) {
			Vector3 projectilePosition = new Vector3 (projectileRelativePosition.x + gameObject.transform.position.x, projectileRelativePosition.y, projectileRelativePosition.z);
			Instantiate (projectile, projectilePosition, projectile.transform.rotation);
			yield return new WaitForSeconds (spawnRate);
		}
	}
}
