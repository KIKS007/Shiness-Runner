using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Side Scrolling Settings")]
	public Ease hitEase;
	public float movementLerp = 0.1f;
	public float followZTweenDuration = 0.1f;
	public float resetXScrollSpeed = 0.1f;

	[Header ("Top View")]
	public Vector3 topPosition;
	public float topLookAtYOffset;
	public float topViewScrollSpeed;

	[Header ("Side View")]
	public Vector3 sidePosition;
	public float sideLookAtYOffset;
	public float sideViewScrollSpeed;

	[Header ("Side Hit")]
	public float sideScrollHitDistance;
	public float sideScrollHitDuration;
	public float sideScrollHitDelay = 2;
	public float sideDurationToNormal;

	[Header ("Dbug Hit")]
	public bool hittest = false;

	private GameObject player;
	private Transform sideScrollingParent;

	private float sideInitialXpos;
	private CameraSwitchView cameraSwitchScript;

	private Rigidbody rigiBodyParent;

	private bool reseting = false;

	public float distX;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		sideScrollingParent = transform.parent;
		sideInitialXpos = sidePosition.x;
		cameraSwitchScript = GetComponent <CameraSwitchView> ();

		rigiBodyParent = sideScrollingParent.GetComponent <Rigidbody> ();

		GameManager.Instance.OnSideView += ResetSideScroll;
		GameManager.Instance.OnSideView += SideViewScrolling;
		GameManager.Instance.OnTopView += DebugMovement;


		GameManager.Instance.OnTopView += ()=> StartCoroutine (ResetXScroll ());
		GameManager.Instance.OnSideView += ()=> StartCoroutine (ResetXScroll ());
	}

	void DebugMovement ()
	{
		enabled = false;
		enabled = true;
	}

	IEnumerator ResetXScroll ()
	{
		reseting = true;

		do 
		{
			Vector3 target = new Vector3(player.transform.position.x - sideScrollingParent.position.x, 0, 0);
			target.Normalize ();
			/*//sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, resetXScrollSpeed);

			Debug.Log (Mathf.Abs (sideScrollingParent.position.x - player.transform.position.x));

			rigiBodyParent.DOMoveX (player.transform.position.x, resetXScrollSpeed).SetLoops (-1).SetId ("Reset");*/			 

			rigiBodyParent.MovePosition(sideScrollingParent.position + target * Time.fixedDeltaTime * resetXScrollSpeed);
			yield return new WaitForFixedUpdate ();	
		} 
		while(Mathf.Abs (sideScrollingParent.position.x - player.transform.position.x) > 0.3f);

		DOTween.Kill ("Reset");

		reseting = false;

		Debug.Log ("resting false");
	}

	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.gameState == GameState.Playing)
		{
			/*if(GameManager.Instance.viewState == ViewState.Top)
			{
				transform.localPosition = Vector3.Lerp (transform.localPosition, topPosition, movementLerp);
			}
			else
			{
				transform.localPosition = Vector3.Lerp (transform.localPosition, sidePosition, movementLerp);
			}*/
			
			if(hittest)
			{
				hittest = false;
				
				ScrollingHit ();
			}	
		}
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
	}

	public void ScrollingHit ()
	{
		DOTween.Kill ("ScrollHit");
		DOTween.Kill ("ScrollReset");

		if(GameManager.Instance.viewState == ViewState.Side)
		{
			DOTween.To(()=> sidePosition, x=> sidePosition = x, new Vector3(sidePosition.x + sideScrollHitDistance, sidePosition.y, sidePosition.z), sideScrollHitDuration).SetEase (hitEase).SetId ("ScrollHit").OnComplete (ResetScrolling);
		}

	}

	void ResetScrolling ()
	{
		if(GameManager.Instance.viewState == ViewState.Side)
		{
			float duration = -(sideInitialXpos - sidePosition.x) / sideDurationToNormal;

			DOTween.To(()=> sidePosition, x=> sidePosition = x, new Vector3(sideInitialXpos, sidePosition.y, sidePosition.z), duration).SetEase (hitEase).SetId ("ScrollReset").SetDelay (sideScrollHitDelay);
		}
	}

	void ResetSideScroll ()
	{
		DOTween.To(()=> sidePosition, x=> sidePosition = x, new Vector3(sideInitialXpos, sidePosition.y, sidePosition.z), 2).SetEase (hitEase).SetId ("ScrollReset");
	}

}
