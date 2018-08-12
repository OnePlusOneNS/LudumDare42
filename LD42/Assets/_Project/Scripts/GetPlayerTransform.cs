using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPlayerTransform : MonoBehaviour {

	[SerializeField] private Transform _player;

	private void FixedUpdate() 
	{
		transform.position = _player.position;
	}
}
