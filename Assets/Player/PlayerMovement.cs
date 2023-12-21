using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement: MonoBehaviour {

  public Camera cam;

  public Player player;

  private Rigidbody2D rb;

  // private Vector2 movement;

  private Vector2 mousePosition;

  void Start() {
    this.rb = gameObject.GetComponent<Rigidbody2D>();

    // Assert.IsNotNull(this.cam);
    Assert.IsNotNull(this.player);
    Assert.IsNotNull(this.rb);
  }

  // void Update() {
  //   this.rb.MovePosition(this.rb.position + (
  //     this.player.movement.normalized * this.player.moveSpeed * Time.fixedDeltaTime
  //   ));
  // }

  void Update() {
    this.mousePosition = this.cam.ScreenToWorldPoint(Input.mousePosition);
  }

  void FixedUpdate() {
    this.rb.MovePosition(this.rb.position + (
      this.player.movement.normalized * this.player.moveSpeed * Time.fixedDeltaTime
    ));

    Vector2 lookDir = (this.mousePosition - this.rb.position);
    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
    this.rb.rotation = angle;
  }

  // public void SetMovement(float horizontal, float vertical) {
  //   this.player.movement = new Vector2(horizontal, vertical);
  // }
}
