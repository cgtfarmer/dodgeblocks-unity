using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerAbilityManager: MonoBehaviour {

  public InteractEvent interactEvent;

  public Player player;

  public LayerMask interactableLayers;

  void Start() {
    Assert.IsNotNull(this.interactEvent);
    Assert.IsNotNull(this.player);

    // Reference types can be null, Value types cannot - they default to a value (0?)
    // LayerMask is a struct, which is a value type
    // Assert.IsNotNull(this.interactableLayers);

    Assert.AreNotEqual(this.interactableLayers, default(LayerMask));
  }

  public void Interact() {
    Collider2D intersection = Physics2D.OverlapCircle(
      this.transform.position, this.player.interactRadius, this.interactableLayers
    );

    string intersectionName = intersection ? intersection?.gameObject?.name : "NONE";
    print($"[PlayerAbilityManager#Interact] {intersectionName}");

    if (intersection == null) return;

    this.interactEvent.e.Invoke(intersectionName);
  }
}

