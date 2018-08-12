using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {

	[SerializeField] private float _playerHorizontalSpeed;
	[SerializeField] private float _playerJumpForce;
	[SerializeField] private UnityEvent _onPlayerFallDown;
	[SerializeField] private UnityEvent _onPickUpPowerUp;
	[SerializeField] private UnityEvent _onCollision;
	[SerializeField] private PowerUp _powerUp;
	[SerializeField] private ActivePowerUp _activePowerUp;

	private Rigidbody _rigidbody;
	private bool _inTheAir;
	private Vector3 _starPos;

	private void Start() 
	{
		_starPos = transform.position;
		_rigidbody = GetComponent<Rigidbody>();
	}

	private void FixedUpdate () 
	{
		_rigidbody.AddForce(new Vector3(0,0,Input.GetAxis("Horizontal")*Time.deltaTime*_playerHorizontalSpeed),ForceMode.Acceleration);
	
		if(Input.GetButton("Jump") && !_inTheAir) 
		{
			_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0, _rigidbody.velocity.z);
			_inTheAir = true;
			//transform.Translate(Vector3.up * _playerJumpForce * Time.deltaTime, Space.World);
			_rigidbody.AddForce(Vector3.up * _playerJumpForce * Time.deltaTime, ForceMode.Impulse);
			StartCoroutine(JumpTimeOutRoutine());
		}
	}

	private void Update()
	{
		if(Input.GetButtonDown("PowerUp")) 
		{
			_powerUp.ActivatePowerUp();
		}
	}

	private void OnTriggerEnter(Collider c) 
	{
		if(c.gameObject.tag == "PowerUp") 
		{
			_activePowerUp._powerUpItem = c.GetComponent<PowerUpItem>()._powerUpItem;
			_onPickUpPowerUp.Invoke();
			Destroy(c.gameObject);
		}
	}

	private void OnCollisionEnter(Collision c) {
		_inTheAir = false;
		if(c.gameObject.tag == "Ground") 
		{
			_onPlayerFallDown.Invoke();
		}
		_onCollision.Invoke();
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

	public void PlayerReset() 
	{
		transform.position = _starPos;
	}
}
