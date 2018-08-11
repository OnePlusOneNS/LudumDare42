using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour {
	
	[SerializeField] private Timer _gameTimer;

	private Text _timerTextField;

	private void Start() 
	{
		_timerTextField = GetComponent<Text>();
		_timerTextField.text = "Barrier Inactive";
	}

	public void UpdateTimer() 
	{
		_timerTextField.text = "Barrier Active:" + _gameTimer._timer.ToString();
	}

	public void ResetTimer() 
	{
		_timerTextField.text = "Barrier Inactive";
	}
}