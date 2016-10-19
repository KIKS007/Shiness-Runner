using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Side Scrolling Settings")]
	public float movementLerp = 0.1f;
	public bool followOnY = true;

	[Header ("Top View")]
	public Vector3 topPosition;
	public bool topLookAtPlayer = true;
	public float topLookAtLerp = 0.1f;
	public Vector2 topLookAtOffset;

	[Header ("Side View")]
	public Vector3 sidePosition;
	public bool sideLookAtPlayer = true;
	public float sideLookAtLerp = 0.1f;
	public Vector2 sideLookAtOffset;

	[Header ("Along Path")]
	public bool pathLookAtPlayer = true;
	public float pathLookAtPlayerLerp = 0.1f;

	private GameObject player;
	private CameraSwitchView cameraSwitchViewScript;
	private Transform sideScrollingParent;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		cameraSwitchViewScript = GetComponent <CameraSwitchView> ();
		sideScrollingParent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () 
	{
	}
		
	void FixedUpdate ()
	{
		SideScrolling ();
	}

	void LateUpdate ()
	{
		LookAtPlayer ();
	}

	void SideScrolling ()
	{
		Vector3 target = new Vector3 ();

		if(followOnY)
			target = new Vector3 (player.transform.position.x + sidePosition.x, player.transform.position.y, sideScrollingParent.position.z);
		else
			target = new Vector3 (player.transform.position.x + sidePosition.x, sideScrollingParent.position.y, sideScrollingParent.position.z);

		sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, movementLerp);
	}

	void LookAtPlayer ()
	{
		if(GameManager.Instance.viewState == ViewState.Side && sideLookAtPlayer)
		{
			Vector3 targetPos = new Vector3 (player.transform.position.x + sideLookAtOffset.x, player.transform.position.y + sideLookAtOffset.y, player.transform.position.z);

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, sideLookAtLerp * Time.deltaTime);

			/*Vector3 targetPos = new Vector3 (player.transform.position.x + sideLookAtOffset.x, player.transform.position.y + sideLookAtOffset.y, player.transform.position.z);
			transform.LookAt (targetPos);*/
		}

		else if(topLookAtPlayer)
		{
			Vector3 targetPos = new Vector3 (player.transform.position.x + topLookAtOffset.x, player.transform.position.y + topLookAtOffset.y, player.transform.position.z);

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, topLookAtLerp * Time.deltaTime);

			/*Vector3 targetPos = new Vector3 (player.transform.position.x + topLookAtOffset.x, player.transform.position.y + topLookAtOffset.y, player.transform.position.z);
			transform.LookAt (targetPos);*/
		}
	}

	void LookAtDuringPath ()
	{
		/*Vector3 targetPos = new Vector3 (player.transform.position.x, player.transform.position.y, player.transform.position.z);
		targetPos -= transform.position;

		Quaternion rotation = Quaternion.LookRotation (targetPos, Vector3.up);

		if(Quaternion.Angle (transform.rotation, rotation) > rotationAngleLimit)
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, pathLookAtPlayerLerp);*/

		Vector3 targetPos = new Vector3 (player.transform.position.x + topLookAtOffset.x, player.transform.position.y + topLookAtOffset.y, player.transform.position.z);
		Vector3 direction = targetPos - transform.position;
		Quaternion toRotation = Quaternion.FromToRotation(transform.forward, direction);
		transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, topLookAtLerp * Time.fixedDeltaTime);
	}
}
