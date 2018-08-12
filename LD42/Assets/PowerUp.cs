using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour {

	[SerializeField] private ActivePowerUp _activePowerUp;

	[SerializeField] private GameObject _forceField;
	[SerializeField] private GameObject _waterHose;
	[SerializeField] private GameObject _shield;

	[SerializeField] private UnityEvent _onForceField;

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
			case (PowerUpItemEnum.WaterHose):
			break;
			case (PowerUpItemEnum.Shield):
			_shield.SetActive(true);
			break;
			default:
			break;
		}
		_activePowerUp._powerUpItem = PowerUpItemEnum.None;
	}
}
