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
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
