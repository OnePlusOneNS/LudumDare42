using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {

	public PowerUpItemEnum _powerUpItem {get; set;}

	private void OnEnable() 
	{
		gameObject.SetActive(true);
		_powerUpItem = (PowerUpItemEnum) Random.Range(1,4);
		StartCoroutine(SelfDestructTimer());
	}

	private IEnumerator SelfDestructTimer() 
	{
		float timer = 5f;
		while (timer>0) 
		{
			timer -= Time.deltaTime;
			yield return null;
		}
		Destroy(gameObject);
	}
}
