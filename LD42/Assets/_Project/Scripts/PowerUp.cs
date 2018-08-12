using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour {

	[SerializeField] private ActivePowerUp _activePowerUp;

	[SerializeField] private GameObject _forceField;
	[SerializeField] private GameObject _stomp;
	[SerializeField] private GameObject _shield;

	[SerializeField] private UnityEvent _onForceField;
	[SerializeField] private UnityEvent _onStomp;
	[SerializeField] private UnityEvent _onShield;
	[SerializeField] private UnityEvent _onPowerUpUsed;

	private void Start() 
	{
		_activePowerUp._powerUpItem = PowerUpItemEnum.None;
	}

	public void ActivatePowerUp() 
	{
		switch (_activePowerUp._powerUpItem) 
		{
			case (PowerUpItemEnum.ForceField):
			_onForceField.Invoke();
			break;
			case (PowerUpItemEnum.Stomp):
			_onStomp.Invoke();
			break;
			case (PowerUpItemEnum.Shield):
			_onShield.Invoke();
			_shield.SetActive(true);
			break;
			default:
			break;
		}
		_activePowerUp._powerUpItem = PowerUpItemEnum.None;
		_onPowerUpUsed.Invoke();
	}
}
