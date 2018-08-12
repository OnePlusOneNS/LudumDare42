using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableSetterOnStart : MonoBehaviour {

	[SerializeField] private Timer _gameTimer;

	private void Start() 
	{
		_gameTimer._timer = 10f;
	}
}
