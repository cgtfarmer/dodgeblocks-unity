using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile: MonoBehaviour {

  private float destroyTime;

  void Start() {
    this.destroyTime = 5f;

    Destroy(this.gameObject, this.destroyTime);
  }

  void OnTriggerEnter2D(Collider2D collider) {
    Destroy(this.gameObject);
  }
}
