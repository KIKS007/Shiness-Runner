using UnityEngine;
using System.Collections;

public class ProjectileSpawn : MonoBehaviour 
{
	public int projectileId;
	public float projectileSpeed = -1;

	void Start ()
	{
		GetComponent <Renderer> ().enabled = false;
	}
}
