using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Side Scrolling Settings")]
	public Ease hitEase;
	public float movementLerp = 0.1f;
	public float lookAtSmooth = 10f;
	public float followZTweenDuration = 0.1f;

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

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		sideScrollingParent = transform.parent;
		sideInitialXpos = sidePosition.x;
		cameraSwitchScript = GetComponent <CameraSwitchView> ();

		GameManager.Instance.OnSideView += ResetSideScroll;
		GameManager.Instance.OnSideView += SideViewScrolling;
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

	void LateUpdate ()
	{
		/*if(GameManager.Instance.gameState == GameState.Playing && !cameraSwitchScript.isMovingAlongPath)
			LookAt ();*/
	}

	void SideViewScrolling ()
	{
		if(DOTween.IsTweening ("SideScrollZ"))
			DOTween.Kill ("SideScrollZ");
		
		sideScrollingParent.DOLocalMoveZ (0, 0.5f).SetId ("SideScrollZ");
	}

	void SideScrolling ()
	{
		if(!cameraSwitchScript.isMovingAlongPath)
		{
			if (GameManager.Instance.viewState == ViewState.Top)
				sideScrollingParent.DOLocalMoveZ (player.transform.position.z, followZTweenDuration).SetLoops (-1).SetId ("SideScrollZ");

		}


		if (GameManager.Instance.viewState == ViewState.Top)
			sideScrollingParent.DOLocalMoveX (topViewScrollSpeed, 0.1f).SetLoops (-1).SetRelative (true).SetId ("SideScroll").OnComplete (()=> DOTween.Kill ("SideScroll"));
		else
			sideScrollingParent.DOLocalMoveX (sideViewScrollSpeed, 0.1f).SetLoops (-1).SetRelative (true).SetId ("SideScroll").OnComplete (()=> DOTween.Kill ("SideScroll"));

	}

	void LookAt ()
	{
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			Vector3 targetPos = new Vector3 (transform.position.x, topLookAtYOffset, player.transform.position.z);

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, lookAtSmooth * Time.deltaTime);
		}
		else
		{
			Vector3 targetPos = new Vector3 (transform.position.x, transform.position.y + sideLookAtYOffset, transform.position.z);
			targetPos.z += 1;

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, lookAtSmooth * Time.deltaTime);
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
