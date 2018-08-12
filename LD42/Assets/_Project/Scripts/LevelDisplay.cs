using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {
	[SerializeField] private Score _gameLevel;

	private Text _levelTextField;

	private void Awake() 
	{
		_gameLevel._score = 0;
		_levelTextField = GetComponent<Text>();
		_levelTextField.text = "Level: " + 0.ToString();
	}

	public void UpdateLevel() 
	{
		_gameLevel._score++;
		_levelTextField.text = "Level: " + _gameLevel._score.ToString();
	}
}
