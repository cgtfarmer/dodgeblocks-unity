using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy Sprite")]
public class EnemySprite: ScriptableObject {

  [Tooltip("Sprite")]
  public Sprite sprite;
}
