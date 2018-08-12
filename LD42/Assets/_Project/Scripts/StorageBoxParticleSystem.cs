using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBoxParticleSystem : MonoBehaviour {

	private void Start() 
	{
		ParticleSystem particleSystem = GetComponent<ParticleSystem>();
		particleSystem.Play();
		StartCoroutine(WaitForKill(particleSystem));
	}

	private IEnumerator WaitForKill(ParticleSystem particleSystem) 
	{
		yield return new WaitForSeconds(1f);
		Destroy(this.gameObject);
	}
}
