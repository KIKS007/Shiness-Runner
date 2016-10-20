using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Rewired;

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

	// Use this for initialization
	void Start () 
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;

		StartCoroutine (OnTopViewEvent ());
		StartCoroutine (OnSideViewEvent ());
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void AddToScore (int scoreToAdd = 1)
	{
		score += scoreToAdd;
	}

	public void GameOver ()
	{
		gameState = GameState.GameOver;
		Debug.Log ("Gameover");
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
