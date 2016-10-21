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
	public int normalsCount = 0;
	public int preciousCount = 0;
	public int preciousCountTemp = 0;
	public List<GameObject> simpleCollectibles = new List<GameObject> ();

	[Header ("Checkpoints")]
	public List<Transform> checkpointsList = new List<Transform> ();

	[Header ("Load Checkpoint")]
	public float delayBeforeResume = 3;

	private GameObject player;
	private GameObject mainCamera;
	private CameraSwitchView cameraSwitchScript;
	private CameraFollow cameraFollowScript;

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

	public void AddToScore (CollectibleType collectibleType, int scoreToAdd)
	{
		if(collectibleType == CollectibleType.Simple)
		{
			normalsCount += 1;
			score += scoreToAdd;
		}
		else
		{
			preciousCount += 1;
			preciousCountTemp += 1;
			preciousScoreTemp += scoreToAdd;
		}
	}

	public void CheckpointPassed (Transform checkpoint)
	{
		if (!checkpointsList.Contains (checkpoint))
			checkpointsList.Add (checkpoint);

		score += preciousScoreTemp;

		preciousCountTemp = 0;
		preciousScoreTemp = 0;
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

		for (int i = 0; i < simpleCollectibles.Count; i++)
			simpleCollectibles [i].SetActive (false);

		preciousCount -= preciousCountTemp;
		preciousCountTemp = 0;
		preciousScoreTemp = 0;

		Vector3 position = new Vector3 (checkpointsList [checkpointsList.Count - 1].position.x, checkpointsList [checkpointsList.Count - 1].position.y + 4, checkpointsList [checkpointsList.Count - 1].position.z);

		player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = position;
		player.SetActive (true);

		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera");
		mainCamera.transform.parent.transform.position = new Vector3 (position.x, 0, 0);

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
		cameraSwitchScript.ToTop ();
	}

	public void ToSide ()
	{
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
