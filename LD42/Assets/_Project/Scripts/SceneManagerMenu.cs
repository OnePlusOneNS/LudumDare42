using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerMenu : MonoBehaviour {
	public void SwitchScene(string scene) 
	{
		StartCoroutine(InitiateScene(scene));
	}

	private IEnumerator InitiateScene(string scene) 
	{
		yield return new WaitForSeconds(2f);
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}
}
