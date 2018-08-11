using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Score : ScriptableObject {

	[SerializeField] private int _score {get {return _score;} set {_score = value;}}

}
