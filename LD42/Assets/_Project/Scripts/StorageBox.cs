using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBox : MonoBehaviour 
{
	private int _id;
	public void SetID(int value) 
	{
		_id = value;
	}
	public int GetID() 
	{
		return _id;
	}
}