using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ResourceDisplay : MonoBehaviour {

  public Resource resource;

  private SpriteRenderer spriteRenderer;

  void Start() {
    this.spriteRenderer = this.GetComponent<SpriteRenderer>();

    Assert.IsNotNull(this.resource);
    Assert.IsNotNull(this.spriteRenderer);

    this.spriteRenderer.color = this.resource.color;
  }

  public void Die() {
    this.gameObject.SetActive(false);
  }
}
