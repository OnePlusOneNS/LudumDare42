using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour {

	[SerializeField] private UnityEvent _onScoreUpdate;
	[SerializeField] private Score _gameScore;
	[SerializeField] private Score _highscore;

	private void Start() 
	{
		_gameScore._score = 0;
	}

	public void BoxDestroyed() 
	{
		_gameScore._score++;
		_onScoreUpdate.Invoke();
	}

	public void PlayerDestroyed() 
	{
		if(_gameScore._score > _highscore._score) 
		{
			_highscore._score = _gameScore._score;
		}
	}
}
