using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Resource")]
public class Resource: ScriptableObject {

  [ColorUsage(true)]
  [Tooltip("The color")]
  public Color color;

  // ENCAPSULATION EXAMPLE
  // [SerializeField]
  // public int maxHealth { get; private set; } = 100;
}
