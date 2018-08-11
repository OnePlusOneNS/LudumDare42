using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageBox : MonoBehaviour 
{

	[SerializeField] private ParticleSystem _boxDestroyParticleSystem;
	[SerializeField] private UnityEvent _onDestroy;

	[SerializeField] private Material[] _cardboardMaterials;
	private void Start() 
	{
		GetComponent<Renderer>().material = _cardboardMaterials[Random.Range(0,_cardboardMaterials.Length)];
	}

	private void OnCollisionEnter(Collision c) 
	{
		if(c.gameObject.tag == "Ground") 
		{
			Instantiate(_boxDestroyParticleSystem, transform.position, transform.rotation);
			_onDestroy.Invoke();
			Destroy(this.gameObject);
		}
	}

}