using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ResourceController: MonoBehaviour {

  public InteractEvent interactEvent;

  public PickUpEvent pickUpEvent;

  public ResourceDisplay resourceDisplay;

  void Start() {
    this.resourceDisplay = this.GetComponent<ResourceDisplay>();

    Assert.IsNotNull(this.interactEvent);
    Assert.IsNotNull(this.pickUpEvent);
    Assert.IsNotNull(this.resourceDisplay);
  }

  void OnEnable() {
    this.interactEvent.e.AddListener(this.HandleInteract);
  }

  void OnDisable() {
    this.interactEvent.e.RemoveListener(this.HandleInteract);
  }

  public void HandleInteract(string name) {
    string goName = this.resourceDisplay.gameObject.name;

    if (name != goName) return;

    Debug.Log($"[ResourceController#HandlePickUp] {goName}");
    this.pickUpEvent.e.Invoke();
    this.resourceDisplay.Die();
  }
}

