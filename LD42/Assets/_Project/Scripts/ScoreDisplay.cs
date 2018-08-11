using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	private Text _scoreTextField;

	private void Start() 
	{
		_scoreTextField = GetComponent<Text>();
	}

	public void UpdateScore() 
	{
		
	}
}
