using UnityEngine;
using System.Collections;
using DG.Tweening;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Side Scrolling Settings")]
	public Ease hitEase;
	public float topViewScrollSpeed;
	public float topViewScrollLerp = 0.1f;
	public float movementYLerp = 0.1f;
	public float lookAtSmooth = 10f;

	[Header ("Top View")]
	public Vector3 topPosition;
	public float topLookAtYOffset;

	[Header ("Side View")]
	public Vector3 sidePosition;
	public float sideLookAtYOffset;

	[Header ("Side Hit")]
	public float sideScrollHitDistance;
	public float sideScrollHitDuration;
	public float sideScrollHitDelay = 2;
	public float sideDurationToNormal;

	public bool hittest = false;

	private GameObject player;
	//private CameraSwitchView cameraSwitchViewScript;
	private Transform sideScrollingParent;
	private Rigidbody parentRigidBody;

	private float topInitialXpos;
	private float sideInitialXpos;

	public float dist;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		//cameraSwitchViewScript = GetComponent <CameraSwitchView> ();
		sideScrollingParent = transform.parent;
		parentRigidBody = transform.parent.GetComponent <Rigidbody> ();

		topInitialXpos = topPosition.x;
		sideInitialXpos = sidePosition.x;

		GameManager.Instance.OnSideView += ResetSideScroll;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(GameManager.Instance.gameState == GameState.Playing)
		{
			if(GameManager.Instance.viewState == ViewState.Top)
			{
				transform.localPosition = Vector3.Lerp (transform.localPosition, topPosition, movementYLerp);
			}
			else
			{
				transform.localPosition = Vector3.Lerp (transform.localPosition, sidePosition, movementYLerp);
			}
			
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
			FollowPlayerPosition ();
			
			SideScrolling ();
			
		}
	}

	void LateUpdate ()
	{
		if(GameManager.Instance.gameState == GameState.Playing)
			LookAt ();
	}

	void SideScrolling ()
	{
		if (GameManager.Instance.viewState == ViewState.Top)
		{
			Vector3 target = new Vector3 ();
			
			target = new Vector3 (sideScrollingParent.position.x + topViewScrollSpeed * Time.fixedDeltaTime, sideScrollingParent.position.y, player.transform.position.z - sideScrollingParent.position.z);
			sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, topViewScrollLerp);
		}
	}

	void FollowPlayerPosition ()
	{
		Vector3 target = new Vector3 ();

		if(GameManager.Instance.viewState == ViewState.Side)
		{
			target = new Vector3 (player.transform.position.x, player.transform.position.y, 0);
			sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, movementYLerp);
		}
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
