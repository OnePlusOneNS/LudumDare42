using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	[SerializeField] private AudioClip[] _boxDrop;
	[SerializeField] private AudioClip[] _boxRoll;

	private AudioSource _audioSource;

	private void Start() 
	{
		_audioSource = GetComponent<AudioSource>();
	}

	public void BoxDropped() 
	{
		_audioSource.PlayOneShot(_boxDrop[Random.Range(0,_boxDrop.Length)]);
	}

	public void BoxRoll() 
	{
		_audioSource.PlayOneShot(_boxRoll[Random.Range(0,_boxRoll.Length)]);
	}
}
