using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Highscore : MonoBehaviour {

	[SerializeField] private Score _highscore;

	private Text _highscoreTextField;

	private void Start() 
	{
		_highscoreTextField = GetComponent<Text>();
		_highscoreTextField.text = _highscore._score.ToString();
	}
}
