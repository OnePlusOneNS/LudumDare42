using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BoxLineChecker : MonoBehaviour {

	[SerializeField] private UnityEvent _onTimerChange;
	[SerializeField] private UnityEvent _onTimerReset;
	[SerializeField] private UnityEvent _onTimerZero;
	[SerializeField] private Timer _gameTimer;
	[SerializeField] private AudioClip _crossedBarrier;

	[SerializeField] private Color _colorInactive;
	[SerializeField] private Color _colorActive;

	private bool _halfTimeReached;
	private bool _bVirgin = false;
	private AudioSource _audioSource;
	private float _originalTimer;
	private int _amountInsideBarrier;
	private Material _mat;

	private void Start() 
	{
		_halfTimeReached = false;
		_audioSource = GetComponent<AudioSource>();
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

	public void StompFinish() 
	{
		_amountInsideBarrier = 0;
		StopAllCoroutines();
		_mat.SetColor("_BarrierColor", _colorInactive);
		_gameTimer._timer = _originalTimer;
		_onTimerReset.Invoke();
		_bVirgin = false;
		_audioSource.Stop();
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
				_bVirgin = false;
				_audioSource.Stop();
			}
		}
	}

	private IEnumerator StartCounter() 
	{
		while(_gameTimer._timer > 0) 
		{
			_gameTimer._timer -= Time.deltaTime;
			_onTimerChange.Invoke();
			if(_gameTimer._timer < _originalTimer-3)  
			{
				_halfTimeReached = true;
				if(!_bVirgin && _halfTimeReached) 
				{
					_bVirgin = true;
					_audioSource.clip = _crossedBarrier;
					_audioSource.Play();
				}
			}
			yield return null;
		}
		_onTimerZero.Invoke();
		_gameTimer._timer = _originalTimer;
		_audioSource.Stop();
	}

}
