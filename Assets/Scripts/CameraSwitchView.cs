using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraSwitchView : MonoBehaviour 
{
	public bool isMovingAlongPath = false;
	public Transform sideWaypointsParent;
	public Transform topWaypointsParent;
	public Ease pathEase = Ease.OutQuad;

	[Header ("Side To Top Path")]
	public Vector3[] toTopPath = new Vector3[0];
	public float toTopDuration;
	public int topTopPathResolution;
	public float toPathRotationDuration;

	[Header ("Top To Side Path")]
	public Vector3[] toSidePath = new Vector3[0];
	public float toSideDuration;
	public int topSidePathResolution;
	public float toSideRotationDuration;

	[Header ("Debug Test")]
	public bool toTop = false;
	public bool toSide = false;

	//private GameObject player;
	private CameraFollow cameraFollowScript;

	void Start () 
	{
		//player = GameObject.FindGameObjectWithTag ("Player");
		cameraFollowScript = GetComponent <CameraFollow> ();

		toTopPath = new Vector3[3];
		toSidePath = new Vector3[3];

		SetPathEndAndBeginPostition ();

		/*for(int i = 0; i < topWaypointsParent.childCount; i++)
		{
			toTopPath [i] = topWaypointsParent.GetChild (i).transform.position;
			toTopPath [i].x = 0;
			topWaypointsParent.GetChild (i).gameObject.SetActive (false);
		}

		for(int i = 0; i < sideWaypointsParent.childCount; i++)
		{
			toSidePath [i] = sideWaypointsParent.GetChild (sideWaypointsParent.childCount - 1 - i).transform.position;
			toSidePath [i].x = 0;
			sideWaypointsParent.GetChild (i).gameObject.SetActive (false);
		}*/
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.gameState == GameState.Playing)
		{
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
		toTopPath [2] = cameraFollowScript.topPosition;
		toTopPath [1] = topWaypointsParent.GetChild (0).transform.position;
		toTopPath [0] = cameraFollowScript.sidePosition;
		


		toSidePath [2] = cameraFollowScript.sidePosition;
		toSidePath [1] = sideWaypointsParent.GetChild (0).transform.position;		
		toSidePath [0] = cameraFollowScript.topPosition;

		topWaypointsParent.GetChild (0).gameObject.SetActive (false);
		sideWaypointsParent.GetChild (0).gameObject.SetActive (false);
	}

	public void ToTop ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Top;

		transform.DOLocalMoveX (cameraFollowScript.topPosition.x, toTopDuration).SetEase (pathEase);
		transform.DOLocalRotate (new Vector3(65.3f, 0, 0), toTopDuration).SetEase (pathEase);
		transform.DOLocalPath (toTopPath, toTopDuration, PathType.CatmullRom, PathMode.Ignore, topTopPathResolution, Color.red).OnComplete (()=> isMovingAlongPath = false).SetEase (pathEase);
	}

	public void TopSide ()
	{
		isMovingAlongPath = true;
		GameManager.Instance.viewState = ViewState.Side;

		transform.DOLocalMoveX (cameraFollowScript.sidePosition.x, toSideDuration).SetEase (pathEase);
		transform.DOLocalRotate (new Vector3(0, 0, 0), toTopDuration).SetEase (pathEase);
		transform.DOLocalPath (toSidePath, toSideDuration, PathType.CatmullRom, PathMode.Ignore, topSidePathResolution, Color.green).OnComplete (()=> isMovingAlongPath = false).SetEase (pathEase);
	}
}
