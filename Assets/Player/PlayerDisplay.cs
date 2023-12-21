using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerDisplay: MonoBehaviour {

  public Player player;

  // private SpriteRenderer spriteRenderer;

  void Start() {
    // this.spriteRenderer = this.GetComponent<SpriteRenderer>();

    Assert.IsNotNull(this.player);
    // Assert.IsNotNull(this.spriteRenderer);

    // this.spriteRenderer.color = this.player.color;
  }

  void OnDrawGizmosSelected() {
    Gizmos.DrawWireSphere(this.transform.position, this.player.interactRadius);
  }
}
