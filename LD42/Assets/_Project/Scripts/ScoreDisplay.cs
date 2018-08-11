using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	[SerializeField] private Score _gameScore;

	private Text _scoreTextField;

	private void Start() 
	{
		_scoreTextField = GetComponent<Text>();
		_scoreTextField.text = "Score: " + 0.ToString();
	}

	public void UpdateScore() 
	{
		_scoreTextField.text = "Score: " + _gameScore._score.ToString();
	}
}
