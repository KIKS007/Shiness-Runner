using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour 
{
	public ViewState viewStateOnSpawn;

	void Start ()
	{
		GetComponent <Renderer> ().enabled = false;
	}

	void OnTriggerEnter (Collider other)
	{
		if(other.gameObject.tag == "Player")
		{
			viewStateOnSpawn = GameManager.Instance.viewState;
			GameManager.Instance.CheckpointPassed (transform);
		}
	}
}
