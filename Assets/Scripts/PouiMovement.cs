using UnityEngine;
using System.Collections;
using Rewired;
using DG.Tweening;

public class PouiMovement : MonoBehaviour 
{
	public LayerMask wallMask;
	public float transitionLerp = 0.5f;
	public float tweenDuration = 0.5f;

	[Header ("Top View")]
	public LayerMask floorLayer;
	public float topLerp = 1;
	public float topYOffset;
	public float topUpLimit = 0.95f;
	public float topDownLimit = 0.95f;
	public float topRightLimit = 0.95f;
	public float topleftLimit = 0.95f;

	[Header ("Side View")]
	public float sideLerp = 1;
	public float sideZOffset;

	private Camera mainCamera;

	private Rigidbody rigidBody;

	private float raycastDistance;

	private CameraSwitchView cameraSwitchViewScript;

	public bool inTransition = false;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <Camera> ();
		cameraSwitchViewScript = mainCamera.GetComponent<CameraSwitchView> ();
		rigidBody = GetComponent<Rigidbody> ();
		raycastDistance = GetComponent <Collider> ().bounds.extents.y + 0.05f;

		GameManager.Instance.OnTopView += ()=> StartCoroutine (PouiToTopPosition ());
		GameManager.Instance.OnSideView += ()=> StartCoroutine (PouiToSidePosition ());
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(inTransition == false && GameManager.Instance.gameState == GameState.Playing)
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
	}

	IEnumerator PouiToTopPosition ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		inTransition = true;

		while(cameraSwitchViewScript.isMovingAlongPath)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (mainCamera.transform.position.x, topYOffset, 0), transitionLerp);

			yield return new WaitForFixedUpdate ();
		}

		inTransition = false;
		Cursor.lockState = CursorLockMode.None;

		yield return new WaitForSeconds (0.001f);

		Cursor.lockState = CursorLockMode.Confined;
	}

	IEnumerator PouiToSidePosition ()
	{
		Cursor.lockState = CursorLockMode.Locked;
		inTransition = true;

		while(cameraSwitchViewScript.isMovingAlongPath)
		{
			transform.position = Vector3.Lerp (transform.position, new Vector3 (mainCamera.transform.position.x, 3.5f, sideZOffset), transitionLerp);

			yield return new WaitForFixedUpdate	 ();
		}

		inTransition = false;
		Cursor.lockState = CursorLockMode.None;

		yield return new WaitForSeconds (0.001f);

		Cursor.lockState = CursorLockMode.Confined;
	}

	void MovementTop ()
	{
		Vector3 rayCastDirection = Input.mousePosition;
		rayCastDirection.z -= mainCamera.transform.position.z;

		rayCastDirection = mainCamera.ScreenToWorldPoint (rayCastDirection);
			
		RaycastHit hit = new RaycastHit();
		Physics.Raycast (mainCamera.transform.position, rayCastDirection - mainCamera.transform.position, out hit, Mathf.Infinity, floorLayer, QueryTriggerInteraction.Collide);

		Vector3 newPos = hit.point;

		//newPos = TopCheckLimits (mainCamera.WorldToScreenPoint(newPos));
		newPos = CheckIfCanMove (newPos);
		newPos.y = topYOffset;

		Vector3 target = Vector3.Lerp (transform.position, newPos, topLerp);

		rigidBody.MovePosition (target);
	}

	Vector3 TopCheckLimits (Vector3 mousePos)
	{
		if (mousePos.x > topRightLimit * mainCamera.pixelWidth)
			mousePos.x = topRightLimit * mainCamera.pixelWidth;

		if(mousePos.x < (1 - topleftLimit) * mainCamera.pixelWidth)
			mousePos.x = (1 - topleftLimit) * mainCamera.pixelWidth;

		if (mousePos.y > topUpLimit * mainCamera.pixelHeight)
			mousePos.y = topUpLimit * mainCamera.pixelHeight;

		if(mousePos.y < (1 - topDownLimit) * mainCamera.pixelHeight)
			mousePos.y = (1 - topDownLimit) * mainCamera.pixelHeight;

		return mousePos;
	}

	void MovementSide ()
	{
		Vector3 newPos = Input.mousePosition;
		newPos.z = sideZOffset - mainCamera.transform.position.z;

		newPos = mainCamera.ScreenToWorldPoint (newPos);
		newPos.z = sideZOffset;

		newPos = CheckIfCanMove (newPos);

		Vector3 target = Vector3.Lerp (transform.position, newPos, sideLerp);

		rigidBody.MovePosition (target);
	}

	Vector3 CheckIfCanMove (Vector3 newPos)
	{
		if (Physics.Raycast (transform.position, -Vector3.up, raycastDistance, wallMask) && newPos.y < transform.position.y)
			newPos.y = transform.position.y;

		if (Physics.Raycast (transform.position, Vector3.up, raycastDistance, wallMask) && newPos.y > transform.position.y)
			newPos.y = transform.position.y;

		if (Physics.Raycast (transform.position, Vector3.right, raycastDistance, wallMask) && newPos.x > transform.position.x)
			newPos.x = transform.position.x;

		if (Physics.Raycast (transform.position, -Vector3.right, raycastDistance, wallMask) && newPos.x < transform.position.x)
			newPos.x = transform.position.x;

		return newPos;
	}
}
