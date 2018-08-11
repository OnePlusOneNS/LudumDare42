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

	private List<StorageBox> _storageBoxesToSpawn = new List<StorageBox>();
	private List<Vector3> _spawnLocations = new List<Vector3>();

	private void Start() 
	{
		CalculateSpawnSegments();

		for(int i = 0; i<_storageBoxAmountPerLevel; i++) 
		{
			StorageBox newStorageBox = new StorageBox();
			_storageBoxesToSpawn.Add(newStorageBox);
		}
		SpawnBoxes();
	}

	private void SpawnBoxes() 
	{
		/*for(int i = 0; i<_storageBoxAmountPerLevel; i++) 
		{
			Instantiate(_storageBoxPrefab, _spawnLocations[i], Quaternion.identity);
		}*/

		StartCoroutine(SpawnBoxesRoutine());

	}

	private IEnumerator SpawnBoxesRoutine() 
	{
		while(_storageBoxesToSpawn.Count > 0) {
			yield return new WaitForSeconds(_startTimeBetweenBoxSpawns);
			int randomValue = GetRandomLocationFromStorageBoxes();
			Instantiate(_storageBoxPrefab, _spawnLocations[randomValue], Quaternion.identity);
			_spawnLocations.RemoveAt(randomValue);
		}
		ProgressToNextLevel();
	}

	private void ProgressToNextLevel() 
	{
		Debug.Log("progresse weiter");
	}

	private int GetRandomLocationFromStorageBoxes() 
	{
		int randomValue = Random.Range(0, _storageBoxesToSpawn.Count);
		_storageBoxesToSpawn.RemoveAt(randomValue);
		return randomValue;
	}

	private void CalculateSpawnSegments() 
	{
		float distance = Vector3.Distance(_leftBarrier.position, _rightBarrier.position);
		float segmentSize = distance/_storageBoxAmountPerLevel;
		float segmentStart = (_leftBarrier.position.z+(segmentSize/2));
		for(int i = 0; i<_storageBoxAmountPerLevel; i++) 
		{
			_spawnLocations.Add(new Vector3(0f, 2f, segmentStart));
			segmentStart += segmentSize;
		}
	}
}

