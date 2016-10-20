using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Rewired;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
	private CameraSwitchView cameraSwitchScript;

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad (GameManager.Instance);

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		StartCoroutine (OnTopViewEvent ());
		StartCoroutine (OnSideViewEvent ());

		player = GameObject.FindGameObjectWithTag ("Player");
		cameraSwitchScript = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent <CameraSwitchView>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Debug.Log (Cursor.lockState);
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
		SceneManager.LoadScene (0);

		for (int i = 0; i < simpleCollectibles.Count; i++)
			simpleCollectibles [i].SetActive (false);

		preciousCount -= preciousCountTemp;
		preciousCountTemp = 0;
		preciousScoreTemp = 0;

		Vector3 position = new Vector3 (checkpointsList [checkpointsList.Count - 1].position.x, checkpointsList [checkpointsList.Count - 1].position.y + 2, checkpointsList [checkpointsList.Count - 1].position.z);

		player.transform.position = position;
		player.SetActive (true);

		if (checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn == ViewState.Top && GameManager.Instance.viewState != checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn)
			ToTop ();

		if (checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn == ViewState.Side && GameManager.Instance.viewState != checkpointsList [checkpointsList.Count - 1].GetComponent <Checkpoint> ().viewStateOnSpawn)
			ToSide ();

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
