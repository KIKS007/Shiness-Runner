using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Follow Settings")]
	public float movementLerp = 0.1f;
	public bool followOnY = true;

	[Header ("Profile View")]
	public Vector3 profilePosition;
	public bool profileLookAtPlayer = true;
	public float profileLookAtLerp = 0.1f;
	public Vector2 profileLookAtOffset;

	[Header ("Top View")]
	public Vector3 topPosition;
	public bool topLookAtPlayer = true;
	public float topLookAtLerp = 0.1f;
	public Vector2 topLookAtOffset;

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
		
	void FixedUpdate ()
	{
		LookAtPlayer ();

		FollowPlayerPosition ();
	}

	void FollowPlayerPosition ()
	{
		Vector3 target = new Vector3 ();

		if(GameManager.Instance.viewState == ViewState.Profile)
		{
			if (followOnY)
				target = player.transform.position + profilePosition; 

			else
				target = new Vector3(player.transform.position.x + profilePosition.x, 0, player.transform.position.z + profilePosition.z);			
		}

		else
		{
			if (followOnY)
				target = player.transform.position + topPosition; 

			else
				target = new Vector3(player.transform.position.x + topPosition.x, 0, player.transform.position.z + topPosition.z);
		}


		transform.position = Vector3.Lerp (transform.position, target, movementLerp);
	}

	void LookAtPlayer ()
	{
		if(GameManager.Instance.viewState == ViewState.Profile && profileLookAtPlayer)
		{
			Vector3 targetPos = new Vector3 (player.transform.position.x + profileLookAtOffset.x, player.transform.position.y + profileLookAtOffset.y, player.transform.position.z);
			targetPos -= transform.position;

			Quaternion rotation = Quaternion.LookRotation (targetPos, Vector3.up);

			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, profileLookAtLerp);
		}

		else if(topLookAtPlayer)
		{
			Vector3 targetPos = new Vector3 (player.transform.position.x + topLookAtOffset.x, player.transform.position.y + topLookAtOffset.y, player.transform.position.z);
			targetPos -= transform.position;

			Quaternion rotation = Quaternion.LookRotation (targetPos, Vector3.up);

			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, topLookAtLerp);
		}
	}
}
