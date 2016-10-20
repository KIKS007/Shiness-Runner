﻿using UnityEngine;
using System.Collections;

public class ProjectileTrigger : MonoBehaviour 
{
	public int whichSpawnId = 0;
	public bool randomSpawn = false;

	void Start ()
	{
		GetComponent <Renderer> ().enabled = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if(GameManager.Instance.viewState == ViewState.Side)
		{
			if(other.gameObject.tag == "Player")
			{
				if(!randomSpawn)
					ProjectilesSpawnManager.Instance.SpawnProjectile (whichSpawnId);

				else
				{
					int randomSpawnId = Random.Range (0, ProjectilesSpawnManager.Instance.spawns.Length);
					ProjectilesSpawnManager.Instance.SpawnProjectile (randomSpawnId);
					Debug.Log (randomSpawnId);
				}
			}
		}
	}
}
