using UnityEngine;
using System.Collections;
using Rewired;

public class PouiMovement : MonoBehaviour 
{
	[Header ("Top View")]
	public float topYOffset;

	[Header ("Profile View")]
	public float profileZOffset;

	private Camera mainCamera;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <Camera> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			MovementTop ();
		}
		else
		{
			MovementProfile ();
		}
	}

	void MovementTop ()
	{

	}

	void MovementProfile ()
	{
		Vector3 newPos = Input.mousePosition;
		newPos.z = profileZOffset - mainCamera.transform.position.z;
		newPos = mainCamera.ScreenToWorldPoint (newPos);

		transform.position = newPos;
	}
}
