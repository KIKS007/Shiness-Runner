using UnityEngine;
using System.Collections;
using DG.Tweening;
using System.Xml.Linq;

public class CameraFollow : MonoBehaviour 
{
	[Header ("Side Scrolling Settings")]
	public float topViewScrollSpeed;
	public float sideViewScrollSpeed;
	public float movementZLerp = 0.1f;
	public float movementYLerp = 0.1f;
	public Ease hitEase;

	[Header ("Top View")]
	public Vector3 topPosition;
	public float topLookAtSmooth = 10f;
	public float topLookAtYOffset;

	[Header ("Side View")]
	public Vector3 sidePosition;

	[Header ("Top Hit")]
	public float topScrollHitDistance;
	public float topScrollHitDuration;
	public float topScrollHitDelay = 2;
	public float topDurationToNormal;

	[Header ("Side Hit")]
	public float sideScrollHitDistance;
	public float sideScrollHitDuration;
	public float sideScrollHitDelay = 2;
	public float sideDurationToNormal;

	public bool hittest = false;

	private GameObject player;
	//private CameraSwitchView cameraSwitchViewScript;
	private Transform sideScrollingParent;

	private float topInitialXpos;
	private float sideInitialXpos;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		//cameraSwitchViewScript = GetComponent <CameraSwitchView> ();
		sideScrollingParent = transform.parent;

		topInitialXpos = topPosition.x;
		sideInitialXpos = sidePosition.x;

		GameManager.Instance.OnTopView += ResetTopScroll;
		GameManager.Instance.OnSideView += ResetSideScroll;
	}
	
	// Update is called once per frame
	void Update () 
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
		
	void FixedUpdate ()
	{
		SideScrolling ();
	}

	void LateUpdate ()
	{
		LookAtFloor ();
	}

	void LookAtFloor ()
	{
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			Vector3 targetPos = new Vector3 (transform.position.x, topLookAtYOffset, player.transform.position.z);

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, topLookAtSmooth * Time.deltaTime);
		}
		else
		{
			Vector3 targetPos = transform.position;
			targetPos.z += 1;

			Quaternion rotation = Quaternion.LookRotation (targetPos - transform.position);

			transform.rotation = Quaternion.Slerp (transform.rotation, rotation, topLookAtSmooth * Time.deltaTime);
		}
	}

	void SideScrolling ()
	{
		if(GameManager.Instance.viewState == ViewState.Top)
			sideScrollingParent.transform.Translate (Vector3.right * topViewScrollSpeed * Time.fixedDeltaTime);

		else
			sideScrollingParent.transform.Translate (Vector3.right * sideViewScrollSpeed * Time.fixedDeltaTime);

		Vector3 target = new Vector3 ();

		target = new Vector3 (sideScrollingParent.position.x, player.transform.position.y, sideScrollingParent.position.z);
		sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, movementYLerp);

		if(GameManager.Instance.viewState == ViewState.Top)
		{
			target = new Vector3 (sideScrollingParent.position.x, sideScrollingParent.position.y, player.transform.position.z + topPosition.z);
			sideScrollingParent.position = Vector3.Lerp (sideScrollingParent.position, target, movementZLerp);
		}

	}

	public void ScrollingHit ()
	{
		DOTween.Kill ("ScrollHit");
		DOTween.Kill ("ScrollReset");

		if(GameManager.Instance.viewState == ViewState.Top)
		{
			DOTween.To(()=> topPosition, x=> topPosition = x, new Vector3(topPosition.x + topScrollHitDistance, topPosition.y, topPosition.z), topScrollHitDuration).SetEase (hitEase).SetId ("ScrollHit").OnComplete (ResetScrolling);
		}
		else
		{
			DOTween.To(()=> sidePosition, x=> sidePosition = x, new Vector3(sidePosition.x + sideScrollHitDistance, sidePosition.y, sidePosition.z), sideScrollHitDuration).SetEase (hitEase).SetId ("ScrollHit").OnComplete (ResetScrolling);
		}

	}

	void ResetScrolling ()
	{
		if(GameManager.Instance.viewState == ViewState.Top)
		{
			float duration = -(topInitialXpos - topPosition.x) / topDurationToNormal;

			DOTween.To(()=> topPosition, x=> topPosition = x, new Vector3(topInitialXpos, topPosition.y, topPosition.z), duration).SetEase (hitEase).SetId ("ScrollReset").SetDelay (topScrollHitDelay);
		}
		else
		{
			float duration = -(sideInitialXpos - sidePosition.x) / sideDurationToNormal;

			DOTween.To(()=> sidePosition, x=> sidePosition = x, new Vector3(sideInitialXpos, sidePosition.y, sidePosition.z), duration).SetEase (hitEase).SetId ("ScrollReset").SetDelay (sideScrollHitDelay);
		}

	}

	void ResetTopScroll ()
	{
		DOTween.To(()=> topPosition, x=> topPosition = x, new Vector3(topInitialXpos, topPosition.y, topPosition.z), 2).SetEase (hitEase).SetId ("ScrollReset");
	}

	void ResetSideScroll ()
	{
		DOTween.To(()=> sidePosition, x=> sidePosition = x, new Vector3(sideInitialXpos, sidePosition.y, sidePosition.z), 2).SetEase (hitEase).SetId ("ScrollReset");
	}

}
