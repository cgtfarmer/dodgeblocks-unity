using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/EnemySpawner")]
public class EnemySpawner: ScriptableObject {

  [Range(1, 1000)]
  [Tooltip("The quantity of resources to spawn")]
  public int quantity;
}
