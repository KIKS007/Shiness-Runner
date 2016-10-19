using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Side Scrolling Settings")]
	public bool followZ = true;
	public float movementZLerp = 0.1f;
	public float movementYLerp = 0.1f;

	[Header ("Top View")]
	public Vector3 topPosition;
	public float topLookAtSmooth = 10f;
	public float topLookAtYOffset;
	//public bool topLookAtPlayer = true;

	[Header ("Side View")]
	public Vector3 sidePosition;
	/*public bool sideLookAtPlayer = true;
	public float sideLookAtSmooth = 10f;
	public float sideLookAtYOffset;*/

	private GameObject player;
	//private CameraSwitchView cameraSwitchViewScript;
	private Transform sideScrollingParent;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		//cameraSwitchViewScript = GetComponent <CameraSwitchView> ();
		sideScrollingParent = transform.parent;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			transform.localPosition = Vector3.Lerp (transform.localPosition, topPosition, movementYLerp);
		}
		else
		{
			transform.localPosition = Vector3.Lerp (transform.localPosition, sidePosition, movementYLerp);
		}
	}
		
	void FixedUpdate ()
	{
		SideScrolling ();
	}

	void LateUpdate ()
	{
		LookAtFloor ();
	}

	void LookAtFloor ()
	{
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			Vector3 targetPos = new Vector3 (transform.position.x, topLookAtYOffset, player.transform.position.z);

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, topLookAtSmooth * Time.deltaTime);
		}
		else
		{
			Vector3 targetPos = transform.position;
			targetPos.z += 1;

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, topLookAtSmooth * Time.deltaTime);
		}
	}

	void SideScrolling ()
	{
		Vector3 target = new Vector3 ();

		target = new Vector3 (player.transform.position.x + sidePosition.x, player.transform.position.y, sideScrollingParent.position.z);
		sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, movementYLerp);

		if(followZ && GameManager.Instance.viewState == ViewState.Top)
		{
			target = new Vector3 (sideScrollingParent.position.x, sideScrollingParent.position.y, player.transform.position.z + topPosition.z);
			sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, movementZLerp);
		}
		else
		{
			target = new Vector3 (sideScrollingParent.position.x, sideScrollingParent.position.y, 0);
			sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, movementZLerp);
		}
	}

	/*void LookAtPlayer ()
	{
		if(GameManager.Instance.viewState == ViewState.Top && topLookAtPlayer)
		{
			Vector3 targetPos = new Vector3 (transform.position.x, player.transform.position.y + topLookAtYOffset, player.transform.position.z);

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, topLookAtSmooth * Time.deltaTime);
		}

		else if(sideLookAtPlayer)
		{
			Vector3 targetPos = new Vector3 (transform.position.x, player.transform.position.y + sideLookAtYOffset, player.transform.position.z);

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, sideLookAtSmooth * Time.deltaTime);
		}
	}*/
}
