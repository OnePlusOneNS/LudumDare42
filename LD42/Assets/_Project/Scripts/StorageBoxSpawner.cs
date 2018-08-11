using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageBoxSpawner : MonoBehaviour 
{
	[SerializeField] private GameObject _storageBoxPrefab;
	[SerializeField] private Transform _leftBarrier;
	[SerializeField] private Transform _rightBarrier;
	[SerializeField] private int _storageBoxAmountPerLevel;
	[SerializeField] private float _startTimeBetweenBoxSpawns;
	[SerializeField] private float _timerBetweenLevels;

	private int _storageBoxesToSpawn;
	private List<Vector3> _spawnLocations = new List<Vector3>();
	private List<Vector3> _calculatedSpawnLocations = new List<Vector3>();

	private void Start() 
	{
		_storageBoxesToSpawn = _storageBoxAmountPerLevel;
		CalculateSpawnSegments();
		SpawnBoxes();
	}

	private void SpawnBoxes() 
	{
		/*for(int i = 0; i<_storageBoxAmountPerLevel; i++) 
		{
			Instantiate(_storageBoxPrefab, _spawnLocations[i], Quaternion.identity);
		}*/
		foreach(Vector3 position in _calculatedSpawnLocations)
		{
			_spawnLocations.Add(position);
		}
		StartCoroutine(SpawnBoxesRoutine());

	}

	private IEnumerator SpawnBoxesRoutine() 
	{
		while(_storageBoxesToSpawn > 0) {
			yield return new WaitForSeconds(_startTimeBetweenBoxSpawns);
			int randomValue = GetRandomLocationFromStorageBoxes();
			Instantiate(_storageBoxPrefab, _spawnLocations[randomValue], Quaternion.identity);
			_spawnLocations.RemoveAt(randomValue);
		}
		yield return new WaitForSeconds(_timerBetweenLevels);
		ProgressToNextLevel();
	}

	private void ProgressToNextLevel() 
	{
		_storageBoxesToSpawn = _storageBoxAmountPerLevel;
		if(_startTimeBetweenBoxSpawns >= 1.6f) 
		{
			_startTimeBetweenBoxSpawns = _startTimeBetweenBoxSpawns - 0.2f;
		} else 
		{
			Debug.Log("Final Level Reached Increase Score To The Max");
		}
		SpawnBoxes();
	}

	private int GetRandomLocationFromStorageBoxes() 
	{	
		int randomValue = Random.Range(0, _storageBoxesToSpawn);
		_storageBoxesToSpawn--;
		return randomValue;
	}

	private void CalculateSpawnSegments() 
	{
		float distance = Vector3.Distance(_leftBarrier.position, _rightBarrier.position);
		float segmentSize = distance/_storageBoxAmountPerLevel;
		float segmentStart = (_leftBarrier.position.z+(segmentSize/2));
		for(int i = 0; i<_storageBoxAmountPerLevel; i++) 
		{
			_calculatedSpawnLocations.Add(new Vector3(0f, 4f, segmentStart));
			segmentStart += segmentSize;
		}
	}
}

