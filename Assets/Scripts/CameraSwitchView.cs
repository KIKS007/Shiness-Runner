using UnityEngine;
using System.Collections;
using DG.Tweening;

//[ExecuteInEditMode]
public class CameraSwitchView : MonoBehaviour 
{
	public bool isMovingAlongPath = false;
	public float playerMovementXOffset = 1;

	[Header ("Side To Top Path")]
	public Vector3[] toTopPath = new Vector3[0];
	public Vector3[] toTopPathTemp = new Vector3[0];
	public float toTopDuration;
	public int topTopPathResolution;

	[Header ("Top To Side Path")]
	public Vector3[] toSidePath = new Vector3[0];
	public Vector3[] toSidePathTemp = new Vector3[0];
	public float toSideDuration;
	public int topSidePathResolution;

	[Header ("Debug Test")]
	public bool toTop = false;
	public bool toSide = false;

	private GameObject player;
	private CameraFollow cameraFollowScript;

	void OnEnable ()
	{
		cameraFollowScript = GetComponent <CameraFollow> ();
		//SetEndPathPosition ();
	}

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		cameraFollowScript = GetComponent <CameraFollow> ();
		toTopPathTemp = new Vector3[toTopPath.Length];
		toSidePathTemp = new Vector3[toSidePath.Length];
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Application.isPlaying)
		{
			//SetEndPathPosition ();
			
			if(toTop)
			{
				toTop = false;
				ToTop ();
			}
			
			if(toSide)
			{
				toSide = false;
				TopSide ();
			}

			float playerMovementXOffset = player.GetComponent <PlayerMovement> ().movementSpeed * Time.deltaTime;

			for (int i = 0; i < toTopPath.Length; i++)
				toTopPathTemp [i] = new Vector3 (toTopPath[i].x + player.transform.position.x + playerMovementXOffset, toTopPath[i].y, toTopPath[i].z);

			for (int i = 0; i < toSidePath.Length; i++)
				toSidePathTemp [i] = new Vector3 (toSidePath[i].x + player.transform.position.x, toSidePath[i].y, toSidePath[i].z);
		}
	}

	void SetEndPathPosition ()
	{
		if (toTopPath [toTopPath.Length - 1] != cameraFollowScript.topPosition)
			toTopPath [toTopPath.Length - 1] = cameraFollowScript.topPosition;

		if (toSidePath [toSidePath.Length - 1] != cameraFollowScript.sidePosition)
			toSidePath [toSidePath.Length - 1] = cameraFollowScript.sidePosition;

		if (toTopPath [0] != cameraFollowScript.sidePosition)
			toTopPath [0] = cameraFollowScript.sidePosition;

		if (toSidePath [0] != cameraFollowScript.topPosition)
			toSidePath [0] = cameraFollowScript.topPosition;
	}

	public void ToTop ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Top;

		transform.DOPath (toTopPathTemp, toTopDuration, PathType.CatmullRom, PathMode.Ignore, topTopPathResolution, Color.red).OnComplete (()=> isMovingAlongPath = false);
	}

	public void TopSide ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Side;

		transform.DOPath (toSidePathTemp, toSideDuration, PathType.CatmullRom, PathMode.Ignore, topSidePathResolution, Color.green).OnComplete (()=> isMovingAlongPath = false);
	}
}
