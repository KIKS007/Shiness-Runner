using UnityEngine;
using System.Collections;

public class ProjectileMovement : MonoBehaviour
{
	private Rigidbody ProjectileBody;
	public float movementSpeed;

	void Start()
	{
		ProjectileBody = GetComponent <Rigidbody> ();
		//ProjectileBody.velocity = transform.forward * movementSpeed;
		ProjectileBody.MovePosition (transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0));
	}
}
