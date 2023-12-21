using System;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(menuName = "ScriptableObjects/Events/PickUp")]
public class PickUpEvent: ScriptableObject {

  [NonSerialized]
  public UnityEvent e;

  void OnEnable() {
    if (this.e == null) this.e = new UnityEvent();
  }
}
