using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Enemy")]
public class Enemy: ScriptableObject {

  [Range(0, 25)]
  [Tooltip("Max velocity")]
  public float maxVelocity;

  [Range(0, 10)]
  [Tooltip("Max direction duration")]
  public float maxDirectionDuration;

  [Range(0, 1)]
  [Tooltip("Stop probability")]
  public float stopProbability;
}
