using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageBox : MonoBehaviour 
{

	[SerializeField] private ParticleSystem _boxDestroyParticleSystem;
	[SerializeField] private UnityEvent _onDestroy;

	[SerializeField] private Material[] _cardboardMaterials;
	[SerializeField] private int _stompSpeed;

	private SkinnedMeshRenderer _skinnedMeshRenderer;

	private void Start() 
	{
		GetComponent<Renderer>().material = _cardboardMaterials[Random.Range(0,_cardboardMaterials.Length)];
		_skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
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

	private void OnTriggerEnter(Collider c) 
	{	
		if(c.gameObject.tag == "TopPlank") 
		{
			_skinnedMeshRenderer.SetBlendShapeWeight(0,50f);
			
			//StartCoroutine(StompBox());
		}
	}

	private void OnTriggerExit(Collider c) 
	{
		if(c.gameObject.tag == "TopPlank") 
		{
			_onDestroy.Invoke();
			Destroy(this.gameObject);
		}
	}

	private IEnumerator StompBox() 
	{
		float counter = 0f;
		while(counter < 100f) 
		{
			counter += Time.deltaTime * _stompSpeed;
			_skinnedMeshRenderer.SetBlendShapeWeight(0, counter);
			yield return null;
		}
	}

}