using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxLineChecker : MonoBehaviour {

	[SerializeField] private UnityEvent _onTimerChange;
	[SerializeField] private UnityEvent _onTimerReset;
	[SerializeField] private UnityEvent _onTimerZero;
	[SerializeField] private Timer _gameTimer;

	[SerializeField] private Color _colorInactive;
	[SerializeField] private Color _colorActive;

	private float _originalTimer;
	private int _amountInsideBarrier;
	private Material _mat;

	private void Start() 
	{
		_originalTimer = _gameTimer._timer;
		_mat = GetComponent<Renderer>().sharedMaterial;
		_mat.SetColor("_BarrierColor", _colorInactive);
	}

	private void OnTriggerEnter(Collider other) 
	{
		if(other.GetComponent<StorageBox>() != null) 
		{
			_amountInsideBarrier++;
			_mat.SetColor("_BarrierColor", _colorActive);
			StartCoroutine(StartCounter());
		}
	}

	private void OnTriggerExit(Collider other) 
	{
		if(other.GetComponent<StorageBox>() != null) 
		{
			_amountInsideBarrier--;
			if(_amountInsideBarrier == 0) 
			{
				_mat.SetColor("_BarrierColor", _colorInactive);
				StopAllCoroutines();
				_gameTimer._timer = _originalTimer;
				_onTimerReset.Invoke();
			}
			
		}
	}

	private IEnumerator StartCounter() 
	{
		while(_gameTimer._timer > 0) 
		{
			_gameTimer._timer -= Time.deltaTime;
			_onTimerChange.Invoke();
			yield return null;
		}
		_gameTimer._timer = _originalTimer;
		_onTimerZero.Invoke();
		Debug.Log("GameOver");
	}

}
