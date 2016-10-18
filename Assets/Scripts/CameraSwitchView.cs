using UnityEngine;
using System.Collections;
using DG.Tweening;

//[ExecuteInEditMode]
public class CameraSwitchView : MonoBehaviour 
{
	public bool isMovingAlongPath = false;
	public float playerMovementXOffset = 1;

	[Header ("Profile To Top Path")]
	public Vector3[] toTopPath = new Vector3[0];
	public Vector3[] toTopPathTemp = new Vector3[0];
	public float toTopDuration;
	public int topTopPathResolution;

	[Header ("Top To Profile Path")]
	public Vector3[] toProfilePath = new Vector3[0];
	public Vector3[] toProfilePathTemp = new Vector3[0];
	public float toProfileDuration;
	public int topProfilePathResolution;

	[Header ("Debug Test")]
	public bool toTop = false;
	public bool toProfile = false;

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
		toProfilePathTemp = new Vector3[toProfilePath.Length];
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
			
			if(toProfile)
			{
				toProfile = false;
				TopProfile ();
			}

			float playerMovementXOffset = player.GetComponent <PlayerMovement> ().movementSpeed * Time.deltaTime;

			for (int i = 0; i < toTopPath.Length; i++)
				toTopPathTemp [i] = new Vector3 (toTopPath[i].x + player.transform.position.x + playerMovementXOffset, toTopPath[i].y, toTopPath[i].z);

			for (int i = 0; i < toProfilePath.Length; i++)
				toProfilePathTemp [i] = new Vector3 (toProfilePath[i].x + player.transform.position.x, toProfilePath[i].y, toProfilePath[i].z);
		}
	}

	void SetEndPathPosition ()
	{
		if (toTopPath [toTopPath.Length - 1] != cameraFollowScript.topPosition)
			toTopPath [toTopPath.Length - 1] = cameraFollowScript.topPosition;

		if (toProfilePath [toProfilePath.Length - 1] != cameraFollowScript.profilePosition)
			toProfilePath [toProfilePath.Length - 1] = cameraFollowScript.profilePosition;

		if (toTopPath [0] != cameraFollowScript.profilePosition)
			toTopPath [0] = cameraFollowScript.profilePosition;

		if (toProfilePath [0] != cameraFollowScript.topPosition)
			toProfilePath [0] = cameraFollowScript.topPosition;
	}

	public void ToTop ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Top;

		transform.DOPath (toTopPathTemp, toTopDuration, PathType.CatmullRom, PathMode.Ignore, topTopPathResolution, Color.red).OnComplete (()=> isMovingAlongPath = false);
	}

	public void TopProfile ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Profile;

		transform.DOPath (toProfilePathTemp, toProfileDuration, PathType.CatmullRom, PathMode.Ignore, topProfilePathResolution, Color.green).OnComplete (()=> isMovingAlongPath = false);
	}
}
