using UnityEngine;
using System.Collections;

public class CameraCheckDeath : MonoBehaviour 
{
	[Header ("Top View")]
	public float topXDeathPosition;

	[Header ("Side View")]
	public float sideXDeathPosition;

	private Camera cam;
	private Transform player;

	// Use this for initialization
	void Start ()
	{
		cam = GetComponent <Camera> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		Vector3 screenPos = cam.WorldToScreenPoint (player.position);

		if(GameManager.Instance.gameState == GameState.Playing)
		{
			if(GameManager.Instance.viewState == ViewState.Top && screenPos.x < topXDeathPosition)
			{
				GameManager.Instance.Death ();
			}

			if(GameManager.Instance.viewState == ViewState.Side && screenPos.x < sideXDeathPosition)
			{
				GameManager.Instance.Death ();
			}
		}
	}
}
