using UnityEngine;
using System.Collections;

public enum ViewState {Side, Top};

public class GameManager :  Singleton<GameManager> 
{
	public ViewState viewState = ViewState.Side;

	// Use this for initialization
	void Start () 
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Confined;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(viewState == ViewState.Side)
			Cursor.lockState = CursorLockMode.Confined;
		else
			Cursor.lockState = CursorLockMode.None;
	}
}
