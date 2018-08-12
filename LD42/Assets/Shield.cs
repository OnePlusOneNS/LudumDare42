using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour {

	[SerializeField] private UnityEvent _onFallDownWithShield;
	[SerializeField] private float _shieldTimer;

	private void OnEnable() 
	{
		StartCoroutine(SelfDestructTimer());
	}

	private void OnTriggerEnter(Collider c) 
	{
		if(c.gameObject.tag == "Ground") 
		{
			_onFallDownWithShield.Invoke();
			StopAllCoroutines();
			gameObject.SetActive(false);
		}
	}

	private IEnumerator SelfDestructTimer() 
	{
		float timer = _shieldTimer;
		while (timer>0) 
		{
			timer -= Time.deltaTime;
			yield return null;
		}
		gameObject.SetActive(false);
	}
}
