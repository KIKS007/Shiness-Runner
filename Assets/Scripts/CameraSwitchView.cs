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

	private GameObject player;
	private CameraFollow cameraFollowScript;

	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		cameraFollowScript = GetComponent <CameraFollow> ();;
	}
	
	// Update is called once per frame
	void Update () 
	{
		waypointsParent.position = new Vector3 (transform.position.x, waypointsParent.position.y, waypointsParent.position.z);

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
