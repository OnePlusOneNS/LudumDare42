using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerMenu : MonoBehaviour {
	
	[SerializeField] private float _playerJumpForce;

	private Rigidbody _rigidbody;
	private bool _inTheAir;

	private void Start() 
	{
		_rigidbody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown("Jump") && !_inTheAir) 
		{
			_inTheAir = true;
			_rigidbody.AddForce(Vector3.up * _playerJumpForce * Time.deltaTime, ForceMode.Impulse);
			StartCoroutine(JumpTimeOutRoutine());
		}
	}

	private void OnCollisionEnter(Collision c) {
		_inTheAir = false;
	}

	private IEnumerator JumpTimeOutRoutine() 
	{
		float jumpForceTimer = 3f;
		while(_inTheAir) 
		{
			if(jumpForceTimer<=0) 
			{
				_inTheAir = false;
			} else 
			{
				jumpForceTimer -= Time.deltaTime;
			}
			yield return null;
		}
	}
}
