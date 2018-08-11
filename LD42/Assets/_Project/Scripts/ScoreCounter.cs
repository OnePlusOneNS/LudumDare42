using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreCounter : MonoBehaviour {

	[SerializeField] private UnityEvent _onScoreUpdate;
	[SerializeField] private Score _score;

	public void BoxDestroyed() 
	{
		
		_onScoreUpdate.Invoke();
	}
}
