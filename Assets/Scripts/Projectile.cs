using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed;
	public static float xPositionOffset = 0.4f;
	public float distanceFromCamera;

	private Rigidbody rigidBody;
	private Transform player;
	private CameraFollow cameraFollowScript;


	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag (("Player")).transform;
		rigidBody = GetComponent <Rigidbody> ();
		cameraFollowScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <CameraFollow> ();

		distanceFromCamera = GameObject.FindGameObjectWithTag ("MainCamera").transform.position.x - transform.position.x;

		if(distanceFromCamera > 0)
		{
			speed = (speed + distanceFromCamera * xPositionOffset);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		GetToPlayer ();
	}

	void GetToPlayer ()
	{
		Vector3 target = player.position;
		target.z = transform.position.z;
		target.y += 1.2f;

		transform.LookAt (target);


		rigidBody.MovePosition (transform.position + transform.forward * speed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if(GameManager.Instance.viewState == ViewState.Side)
		{

			if(other.gameObject.tag == "Player")
			{
				Debug.Log ("player hit");
				player.GetComponent <PlayerMovement> ().Hit ();
				Destroy ();
			}

			if(other.gameObject.tag == "Poui")
			{
				Debug.Log ("projectile destroyed");
				Destroy ();
			}
		}
	}

	void Destroy ()
	{
		Destroy (gameObject);
	}
}
