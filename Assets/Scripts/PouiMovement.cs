using UnityEngine;
using System.Collections;
using Rewired;

public class PouiMovement : MonoBehaviour 
{
	[Header ("Top View")]
	public float topYOffset;

	[Header ("Side View")]
	public float sideLerp = 1;
	public float sideZOffset;

	private Camera mainCamera;

	private Rigidbody rigidBody;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <Camera> ();
		rigidBody = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			MovementTop ();
		}
		else
		{
			MovementSide ();
		}
	}

	void MovementTop ()
	{

	}

	void MovementSide ()
	{
		Vector3 newPos = Input.mousePosition;
		newPos.z = 0;
		newPos.z = sideZOffset - mainCamera.transform.position.z;
		newPos = mainCamera.ScreenToWorldPoint (newPos);

		Vector3 target = Vector3.Lerp (transform.position, newPos, sideLerp);
		rigidBody.MovePosition (target);
	}

	void CheckIfCanMove (Vector3 newPos)
	{
		
	}
}
