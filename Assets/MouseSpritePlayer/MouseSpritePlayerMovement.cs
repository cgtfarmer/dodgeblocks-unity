using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseSpritePlayerMovement: MonoBehaviour {

  public Camera cam;

  public GameWonEvent gameWonEvent;

  private Vector2 mousePosition;

  void Start() {
    Assert.IsNotNull(this.cam);
    Assert.IsNotNull(this.gameWonEvent);
  }

  void Update() {
    this.mousePosition = this.cam.ScreenToWorldPoint(Input.mousePosition);
    this.transform.position = this.mousePosition;
  }

  void OnTriggerEnter2D(Collider2D collider) {
    this.gameWonEvent.e.Invoke();
  }
}
