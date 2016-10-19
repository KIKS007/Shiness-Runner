using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public enum ViewState {Side, Top};

public delegate void EventHandler();

public class GameManager :  Singleton<GameManager> 
{
	public ViewState viewState = ViewState.Side;

	public event EventHandler OnTopView;
	public event EventHandler OnSideView;

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
		if(viewState == ViewState.Side)
			Cursor.lockState = CursorLockMode.Confined;
		else
			Cursor.lockState = CursorLockMode.None;
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
