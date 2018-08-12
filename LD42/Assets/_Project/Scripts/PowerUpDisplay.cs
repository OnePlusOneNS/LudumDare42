using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerUpDisplay : MonoBehaviour {

	[SerializeField] private ActivePowerUp _activePowerUp;

	[SerializeField] private Sprite[] _powerUpImages;

	private Image _powerUpImage;

	private void Start() 
	{
		_powerUpImage = GetComponent<Image>();
		UpdatePowerUp();
	}

	public void UpdatePowerUp() 
	{
		_powerUpImage.overrideSprite = _powerUpImages[(int)_activePowerUp._powerUpItem];
	}

}
