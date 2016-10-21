using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Rewired;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using DG.Tweening;

public enum GameState {Menu, Playing, Paused, GameOver};
public enum ViewState {Side, Top};

public delegate void EventHandler();

public class GameManager :  Singleton<GameManager> 
{
	public event EventHandler OnSideView;
	public event EventHandler OnTopView;

	public GameState gameState = GameState.Playing;
	public ViewState viewState = ViewState.Side;

	[Header ("Score")]
	public int score = 0;
	public int preciousScoreTemp = 0;

	[Header ("Collectibles")]
	public int simplesCount = 0;
	public int preciousCount = 0;
	public int preciousCountTemp = 0;
	public List<GameObject> simpleCollectibles = new List<GameObject> ();
	public List<GameObject> preciousCollectibles = new List<GameObject> ();
	public List<GameObject> preciousCollectiblesTemp = new List<GameObject> ();

	[Header ("Checkpoints")]
	public List<Transform> checkpointsList = new List<Transform> ();

	[Header ("Load Checkpoint")]
	public float delayBeforeResume = 3;

	[Header ("Transition")]
	public float speedSubstrated = 2;
	public float speedSubstractionWaitTime = 2;
	public float speedSubstractionTweenDuration = 2;

	private GameObject player;
	private GameObject mainCamera;
	private CameraSwitchView cameraSwitchScript;
	private CameraFollow cameraFollowScript;
	private PlayerMovement playerMovementScript;

	// Use this for initialization
	void Start () 
	{
		//DontDestroyOnLoad (GameManager.Instance);

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		StartCoroutine (OnTopViewEvent ());
		StartCoroutine (OnSideViewEvent ());

		player = GameObject.FindGameObjectWithTag ("Player");
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		cameraSwitchScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <CameraSwitchView>();
		cameraFollowScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <CameraFollow>();
		playerMovementScript = player.GetComponent <PlayerMovement> ();
	}

	void ClearEvents ()
	{
		OnTopView = null;
		OnSideView = null;
		cameraSwitchScript.topPathClass.Kill ();
		cameraSwitchScript.sidePathClass.Kill ();
		DOTween.Clear ();
	}

	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AddToScore (CollectibleType collectibleType, int scoreToAdd, GameObject collectibleObject)
	{
		if(collectibleType == CollectibleType.Simple)
		{
			simplesCount += 1;
			score += scoreToAdd;
			simpleCollectibles.Add (collectibleObject);
		}
		else
		{
			preciousCount += 1;
			preciousCountTemp += 1;
			preciousScoreTemp += scoreToAdd;
			preciousCollectiblesTemp.Add (collectibleObject);

		}
	}

	public void CheckpointPassed (Transform checkpoint)
	{
		if (!checkpointsList.Contains (checkpoint))
			checkpointsList.Add (checkpoint);

		score += preciousScoreTemp;

		preciousCountTemp = 0;
		preciousScoreTemp = 0;

		for (int i = 0; i < preciousCollectiblesTemp.Count; i++)
			preciousCollectibles.Add (preciousCollectiblesTemp [i]);

		Debug.Log ("Checkpoint Passed : " + checkpointsList[checkpointsList.Count - 1].ToString ());
		Debug.Log ("Score = " + GameManager.Instance.score);
	}

	public void LoadPreviousCheckpoint ()
	{
		StartCoroutine (LoadPreviousCheckpointCoroutine ());
	}

	IEnumerator LoadPreviousCheckpointCoroutine ()
	{
		ClearEvents ();

		SceneManager.UnloadScene (1);

		yield return SceneManager.LoadSceneAsync (1, LoadSceneMode.Additive);

		Cursor.lockState = CursorLockMode.None;

		yield return new WaitForSeconds (0.001f);

		Cursor.lockState = CursorLockMode.Confined;

		ProjectilesSpawnManager.Instance.StopProjectileRandom ();
		ProjectilesSpawnManager.Instance.DestroyProjectiles ();

		for (int i = 0; i < simpleCollectibles.Count; i++)
			simpleCollectibles [i].SetActive (false);

		for (int i = 0; i < preciousCollectibles.Count; i++)
			preciousCollectibles [i].SetActive (false);
			
		preciousCollectiblesTemp.Clear ();

		preciousCount -= preciousCountTemp;
		preciousCountTemp = 0;
		preciousScoreTemp = 0;

		Vector3 position = new Vector3 (checkpointsList [checkpointsList.Count - 1].position.x, checkpointsList [checkpointsList.Count - 1].position.y + 4, checkpointsList [checkpointsList.Count - 1].position.z);

		Debug.Log ("Checkpoint Loaded : " + checkpointsList[checkpointsList.Count - 1].ToString ());

		player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = position;
		player.SetActive (true);

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera.transform.parent.transform.position = new Vector3 (position.x, 0, 0);

		cameraFollowScript.SubscribeEvents ();

		cameraSwitchScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <CameraSwitchView>();

		if (checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn == ViewState.Top && GameManager.Instance.viewState != checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn)
		{
			mainCamera.transform.position = cameraFollowScript.sidePosition;
			mainCamera.transform.rotation = Quaternion.Euler(new Vector3 (0, 0, 0));
			ToTop ();
			GameObject.FindGameObjectWithTag ("Poui").GetComponent <PouiMovement> ().StartCoroutine ("PouiToTopPosition");
		}

		if (checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn == ViewState.Side && GameManager.Instance.viewState != checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn)
		{
			mainCamera.transform.position = cameraFollowScript.topPosition;
			mainCamera.transform.rotation = Quaternion.Euler(new Vector3 (65, 0, 0));
			ToSide ();
			GameObject.FindGameObjectWithTag ("Poui").GetComponent <PouiMovement> ().StartCoroutine ("PouiToSidePosition");
		}

		Cursor.lockState = CursorLockMode.None;

		yield return new WaitForSeconds (0.001f);

		Cursor.lockState = CursorLockMode.Confined;

		yield return new WaitForSeconds (delayBeforeResume);

		gameState = GameState.Playing;
	}

	public void ToTop ()
	{
		StartCoroutine (ToTopCoroutine ());
	}

	IEnumerator ToTopCoroutine ()
	{

		float speed = playerMovementScript.topMovementSpeed;
		float cameraSpeed = cameraFollowScript.topViewScrollSpeed;

		DOTween.To (()=> playerMovementScript.topMovementSpeed, x => playerMovementScript.topMovementSpeed = x, playerMovementScript.topMovementSpeed - speedSubstrated, speedSubstractionTweenDuration);
		DOTween.To (()=> cameraFollowScript.topViewScrollSpeed, x => cameraFollowScript.topViewScrollSpeed = x, cameraFollowScript.topViewScrollSpeed - speedSubstrated, speedSubstractionTweenDuration);

		yield return new WaitForSeconds (speedSubstractionWaitTime);

		DOTween.To (()=> playerMovementScript.topMovementSpeed, x => playerMovementScript.topMovementSpeed = x, speed, speedSubstractionTweenDuration);
		DOTween.To (()=> cameraFollowScript.topViewScrollSpeed, x => cameraFollowScript.topViewScrollSpeed = x, cameraSpeed, speedSubstractionTweenDuration);

		cameraSwitchScript.ToTop ();
	}

	public void ToSide ()
	{
		StartCoroutine (ToSideCoroutine ());
	}

	IEnumerator ToSideCoroutine ()
	{

		float speed = playerMovementScript.sideMovementSpeed;
		float cameraSpeed = cameraFollowScript.sideViewScrollSpeed;

		DOTween.To (()=> playerMovementScript.sideMovementSpeed, x => playerMovementScript.sideMovementSpeed = x, playerMovementScript.sideMovementSpeed - speedSubstrated, speedSubstractionTweenDuration);
		DOTween.To (()=> cameraFollowScript.sideViewScrollSpeed, x => cameraFollowScript.sideViewScrollSpeed = x, cameraFollowScript.sideViewScrollSpeed - speedSubstrated, speedSubstractionTweenDuration);

		yield return new WaitForSeconds (speedSubstractionWaitTime);
	
		DOTween.To (()=> playerMovementScript.sideMovementSpeed, x => playerMovementScript.sideMovementSpeed = x, speed, speedSubstractionTweenDuration);
		DOTween.To (()=> cameraFollowScript.sideViewScrollSpeed, x => cameraFollowScript.sideViewScrollSpeed = x, cameraSpeed, speedSubstractionTweenDuration);
	
		cameraSwitchScript.ToSide ();
	}

	public void Death ()
	{
		gameState = GameState.GameOver;
		Debug.Log ("Gameover");

		LoadPreviousCheckpoint ();
	}

	IEnumerator OnTopViewEvent ()
	{
		yield return new WaitUntil (() => viewState == ViewState.Side);

		yield return new WaitUntil (() => viewState == ViewState.Top);

		if (OnTopView != null)
			OnTopView ();

		StartCoroutine (OnTopViewEvent ());
	}

	IEnumerator OnSideViewEvent ()
	{
		yield return new WaitUntil (() => viewState == ViewState.Top);

		yield return new WaitUntil (() => viewState == ViewState.Side);

		if (OnSideView != null)
			OnSideView ();

		StartCoroutine (OnSideViewEvent ());
	}
}
