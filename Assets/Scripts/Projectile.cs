using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
	public float speed;

	private Rigidbody rigidBody;
	private Transform player;
	private CameraFollow cameraFollowScript;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag (("Player")).transform;
		rigidBody = GetComponent <Rigidbody> ();
		cameraFollowScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <CameraFollow> ();
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

		transform.LookAt (target);

		rigidBody.MovePosition (transform.position + transform.forward * speed * Time.fixedDeltaTime);
	}

	void OnTriggerEnter (Collider other)
	{
		if(GameManager.Instance.viewState == ViewState.Side)
		{

			if(other.gameObject.tag == "Player")
			{
				Debug.Log (other);
				Debug.Log ("player hit");
				cameraFollowScript.ScrollingHit ();
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
