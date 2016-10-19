using UnityEngine;
using System.Collections;
using Rewired;

public class PouiMovement : MonoBehaviour 
{
	public LayerMask wallMask;

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
	[Range (0, 1)]
	public float sideXLimit = 0.95f;
	[Range (0, 1)]
	public float sideYLimit = 0.95f;


	private Camera mainCamera;

	private Rigidbody rigidBody;

	private float raycastDistance;

	// Use this for initialization
	void Start () 
	{
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <Camera> ();
		rigidBody = GetComponent<Rigidbody> ();
		raycastDistance = GetComponent <Collider> ().bounds.extents.y + 0.05f;
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
		Vector3 rayCastDirection = Input.mousePosition;
		rayCastDirection.z -= mainCamera.transform.position.z;


		rayCastDirection = mainCamera.ScreenToWorldPoint (rayCastDirection);

		RaycastHit hit = new RaycastHit();
		Physics.Raycast (mainCamera.transform.position, rayCastDirection - mainCamera.transform.position, out hit, Mathf.Infinity, floorLayer, QueryTriggerInteraction.UseGlobal);


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
		//newPos = SideCheckLimits (newPos);

		newPos = mainCamera.ScreenToWorldPoint (newPos);
		newPos.z = sideZOffset;

		newPos = CheckIfCanMove (newPos);

		Vector3 target = Vector3.Lerp (transform.position, newPos, sideLerp);

		rigidBody.MovePosition (target);
	}

	Vector3 SideCheckLimits (Vector3 mousePos)
	{
		if (mousePos.x > sideXLimit * mainCamera.pixelWidth)
			mousePos.x = sideXLimit * mainCamera.pixelWidth;

		if(mousePos.x < (1 - sideXLimit) * mainCamera.pixelWidth)
			mousePos.x = (1 - sideXLimit) * mainCamera.pixelWidth;

		if (mousePos.y > sideYLimit * mainCamera.pixelHeight)
			mousePos.y = sideYLimit * mainCamera.pixelHeight;

		if(mousePos.y < (1 - sideYLimit) * mainCamera.pixelHeight)
			mousePos.y = (1 - sideYLimit) * mainCamera.pixelHeight;

		return mousePos;
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
