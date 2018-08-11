using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StorageBox : MonoBehaviour 
{

	[SerializeField] private UnityEvent _onDestroy;

	private void OnCollisionEnter(Collision c) 
	{
		if(c.gameObject.tag == "Ground") 
		{
			_onDestroy.Invoke();
			Destroy(this);
		}
	}

}