using UnityEngine;
using System.Collections;
using DG.Tweening;
using Rewired;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Side Scrolling Settings")]
	public Ease hitEase;
	public float movementLerp = 0.1f;
	public float followZTweenDuration = 0.1f;
	public float resetScrollTransitionSpeed = 20;
	public float resetScrollPlayerSpeed = 10;

	[Header ("Top View")]
	public Vector3 topPosition;
	public float topLookAtYOffset;
	public float topViewScrollSpeed;

	[Header ("Side View")]
	public Vector3 sidePosition;
	public float sideLookAtYOffset;
	public float sideViewScrollSpeed;

	[Header ("Side Hit")]
	public float sideScrollHitDelay = 2;
	public float sideScrollHitForce = 2;

	[Header ("Dbug Hit")]
	public bool hittest = false;

	private GameObject player;
	private Transform sideScrollingParent;

	private CameraSwitchView cameraSwitchScript;

	private Rigidbody rigiBodyParent;

	private bool reseting = false;

	public float distX;
	public float speed;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		sideScrollingParent = transform.parent;
		cameraSwitchScript = GetComponent <CameraSwitchView> ();

		rigiBodyParent = sideScrollingParent.GetComponent <Rigidbody> ();

		SubscribeEvents ();
	}

	public void SubscribeEvents ()
	{
		GameManager.Instance.OnSideView += SideViewScrolling;
		GameManager.Instance.OnTopView += DebugMovement;

		GameManager.Instance.OnTopView += ()=> StartCoroutine (ResetScroll());
		GameManager.Instance.OnSideView += ()=> StartCoroutine (ResetScroll());
	}

	void DebugMovement ()
	{
		enabled = false;
		enabled = true;
	}
		
	// Update is called once per frame
	void Update () 
	{
		if(player == null && GameObject.FindGameObjectWithTag ("Player") != null)
			player = GameObject.FindGameObjectWithTag ("Player");
			
		if(player != null)
			distX = player.transform.position.x - sideScrollingParent.transform.position.x;

		speed = rigiBodyParent.velocity.x;
	}
		
	void FixedUpdate ()
	{
		if(GameManager.Instance.gameState == GameState.Playing)
		{
			//FollowPlayerPosition ();
			SideScrolling ();
			
		}
		else
		{
			if(DOTween.IsTweening ("SideScroll"))
				DOTween.Kill ("SideScroll");
		}
	}

	void SideViewScrolling ()
	{
		if(DOTween.IsTweening ("SideScrollZ"))
			DOTween.Kill ("SideScrollZ");

		sideScrollingParent.DOLocalMoveZ (0, 1f).SetId ("SideScrollZ");
	}

	void SideScrolling ()
	{
		if(!cameraSwitchScript.isMovingAlongPath)
		{
			if (GameManager.Instance.viewState == ViewState.Top)
				sideScrollingParent.DOLocalMoveZ (player.transform.position.z, followZTweenDuration).SetLoops (-1).SetId ("SideScrollZ");

		}		

		if(!reseting)
		{
			if (GameManager.Instance.viewState == ViewState.Top)
				rigiBodyParent.MovePosition (sideScrollingParent.transform.position + new Vector3(topViewScrollSpeed * Time.fixedDeltaTime, 0, 0));
			else
				rigiBodyParent.MovePosition (sideScrollingParent.transform.position + new Vector3(sideViewScrollSpeed * Time.fixedDeltaTime, 0, 0));	
		}
		else
		{
			Vector3 target = new Vector3(player.transform.position.x - sideScrollingParent.transform.position.x, 0, 0);
			target.Normalize ();
			rigiBodyParent.MovePosition (sideScrollingParent.transform.position + target * resetScrollTransitionSpeed * Time.fixedDeltaTime);
		}
	}

	IEnumerator ResetScroll ()
	{
		reseting = true;

		yield return new WaitWhile (()=> Mathf.Abs (player.transform.position.x - sideScrollingParent.transform.position.x) > 0.3f);

		reseting = false;
	}
}
