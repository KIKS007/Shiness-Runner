using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraSwitchView : MonoBehaviour 
{
	public bool isMovingAlongPath = false;
	
	[Header ("Profile To Top Path")]
	public Vector3[] toTopPath = new Vector3[0];
	public float toTopDuration;
	public PathMode toTopPathMode;
	public int topTopPathResolution;

	[Header ("Top To Profile Path")]
	public Vector3[] toProfilePath = new Vector3[0];
	public float topProfileDuration;
	public PathMode toProfilePathMode;
	public int topProfilePathResolution;

	[Header ("Debug Test")]
	public bool toTop = false;
	public bool toProfile = false;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
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
	}

	public void ToTop ()
	{
		isMovingAlongPath = true;
		transform.DOPath (toTopPath, toTopDuration, PathType.CatmullRom, toTopPathMode, topTopPathResolution, Color.red).OnComplete (()=> isMovingAlongPath = false);
	}

	public void TopProfile ()
	{
		isMovingAlongPath = true;
		transform.DOPath (toTopPath, toTopDuration, PathType.CatmullRom, toProfilePathMode, topProfilePathResolution, Color.green).OnComplete (()=> isMovingAlongPath = false);
	}
}
