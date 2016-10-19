using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour {

	public float movementSpeed;
	private Rigidbody projectileBody;

	public void Start() 
	{
		projectileBody = GetComponent<Rigidbody>();
		projectileBody.velocity = -transform.forward * movementSpeed;
	}

}
