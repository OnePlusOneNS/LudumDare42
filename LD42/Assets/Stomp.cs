using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Stomp : MonoBehaviour {

	[SerializeField] private Transform _targetPosition;
	[SerializeField] private float _timeDown;
	[SerializeField] private float _timeUp;

	[SerializeField] private UnityEvent _onStompFinish;

	private Vector3 _startPos;

	private void Start() 
	{
		_startPos = transform.position;
	}

	public void StompDown() 
	{
		StartCoroutine(MoveDown());
	}

	private IEnumerator MoveDown() 
	{
		float timer = _timeDown;
		while(timer>0) 
		{
			timer -= Time.deltaTime;
			transform.position = Vector3.Lerp(_startPos, _targetPosition.position, 1-timer);
			yield return null;
		}
		transform.position = _targetPosition.position;
		StartCoroutine(MoveUp());
	}

	private IEnumerator MoveUp() 
	{
		float timer = 0f;
		while(timer<1)
		{
			timer += Time.deltaTime*_timeUp;
			transform.position = Vector3.Lerp(_targetPosition.position, _startPos, timer);
			yield return null;
		}
		transform.position = _startPos;
		_onStompFinish.Invoke();
	}
}
