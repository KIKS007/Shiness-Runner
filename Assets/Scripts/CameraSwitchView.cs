using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraSwitchView : MonoBehaviour 
{
	public bool isMovingAlongPath = false;
	public Transform waypointsParent;
	public Ease pathEase = Ease.OutQuad;

	[Header ("Side To Top Path")]
	public Vector3[] toTopPath = new Vector3[0];
	public float toTopDuration;
	public int topTopPathResolution;

	[Header ("Top To Side Path")]
	public Vector3[] toSidePath = new Vector3[0];
	public float toSideDuration;
	public int topSidePathResolution;

	[Header ("Debug Test")]
	public bool toTop = false;
	public bool toSide = false;

	//private GameObject player;
	private CameraFollow cameraFollowScript;

	void Start () 
	{
		//player = GameObject.FindGameObjectWithTag ("Player");
		cameraFollowScript = GetComponent <CameraFollow> ();

		for(int i = 0; i < waypointsParent.childCount; i++)
		{
			toTopPath [i] = waypointsParent.GetChild (i).transform.position;
			toSidePath [i] = waypointsParent.GetChild (waypointsParent.childCount - 1 - i).transform.position;
		}

		SetPathEndAndBeginPostition ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.gameState == GameState.Playing)
		{
			waypointsParent.position = new Vector3 (transform.position.x, waypointsParent.position.y, waypointsParent.position.z);
			
			SetPathEndAndBeginPostition ();
			
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
			
		}

	}

	void SetPathEndAndBeginPostition ()
	{
		if(toTopPath[toTopPath.Length - 1] != cameraFollowScript.topPosition)
		{
			toTopPath [toTopPath.Length - 1] = cameraFollowScript.topPosition;
			toSidePath [0] = cameraFollowScript.topPosition;
		}

		if(toTopPath[0] != cameraFollowScript.sidePosition)
		{
			toTopPath [0] = cameraFollowScript.sidePosition;
			toSidePath [toTopPath.Length - 1] = cameraFollowScript.sidePosition;
		}
	}

	public void ToTop ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Top;

		transform.DOLocalPath (toTopPath, toTopDuration, PathType.CatmullRom, PathMode.Ignore, topTopPathResolution, Color.red).OnComplete (()=> isMovingAlongPath = false).SetEase (pathEase);
		transform.DOLocalMoveX (cameraFollowScript.topPosition.x, toTopDuration).SetEase (pathEase);
	}

	public void TopSide ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Side;

		transform.DOLocalPath (toSidePath, toSideDuration, PathType.CatmullRom, PathMode.Ignore, topSidePathResolution, Color.green).OnComplete (()=> isMovingAlongPath = false).SetEase (pathEase);
		transform.DOLocalMoveX (cameraFollowScript.sidePosition.x, toSideDuration).SetEase (pathEase);
	}
}
