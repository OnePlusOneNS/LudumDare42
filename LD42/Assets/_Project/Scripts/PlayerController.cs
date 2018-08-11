using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float _playerHorizontalSpeed;
	[SerializeField] private float _playerJumpForce;
	[SerializeField] private UnityEvent _onPlayerFallDown;

	private Rigidbody _rigidbody;
	private bool _inTheAir;

	private void Start() 
	{
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void Update () 
	{
		_rigidbody.AddForce(new Vector3(0,0,Input.GetAxis("Horizontal")*Time.deltaTime*_playerHorizontalSpeed),ForceMode.Acceleration);
	
		if(Input.GetButton("Jump") && !_inTheAir) 
		{
			_inTheAir = true;
			_rigidbody.AddForce(Vector3.up * _playerJumpForce * Time.deltaTime, ForceMode.Impulse);
		}
	}

	private void OnCollisionEnter(Collision c) {
		_inTheAir = false;
		if(c.gameObject.tag == "Ground") 
		{
			_onPlayerFallDown.Invoke();
		}
	}
}
