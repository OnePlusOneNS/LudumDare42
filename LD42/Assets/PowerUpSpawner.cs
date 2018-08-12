using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

	[SerializeField] private Transform _leftBarrier;
	[SerializeField] private Transform _rightBarrier;
	[SerializeField] private int _powerUpAmount;

	[SerializeField] private int _minPowerUpTime;
	[SerializeField] private int _maxPowerUpTime;
	[SerializeField] private GameObject _powerUpPrefab;
	
	private List<Vector3> _calculatedSpawnLocations = new List<Vector3>();

	private void Start() 
	{
		CalculateSpawnSegments();
		StartCoroutine(PowerUpSpawnTimer());
		Debug.Log("Start Coroutine für spawn");
	}

	private IEnumerator PowerUpSpawnTimer() 
	{
		yield return new WaitForSeconds(Random.Range(_minPowerUpTime, _maxPowerUpTime));
		Debug.Log("Timer fertig, spawne PowerUp");
		SpawnPowerUp();
	}

	private void SpawnPowerUp() 
	{
		Instantiate(_powerUpPrefab, _calculatedSpawnLocations[Random.Range(0,_calculatedSpawnLocations.Count)], Quaternion.identity);
		StartCoroutine(PowerUpSpawnTimer());
	}


	private void CalculateSpawnSegments() 
	{
		float distance = Vector3.Distance(_leftBarrier.position, _rightBarrier.position);
		float segmentSize = distance/_powerUpAmount;
		float segmentStart = (_leftBarrier.position.z+(segmentSize/2));
		for(int i = 0; i<_powerUpAmount; i++) 
		{
			_calculatedSpawnLocations.Add(new Vector3(0f, 1.8f, segmentStart));
			segmentStart += segmentSize;
		}
	}
}
