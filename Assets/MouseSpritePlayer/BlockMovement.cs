using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class BlockMovement: MonoBehaviour {

  public Vector2 movement;

  public float velocity;

  private Rigidbody2D rb;

  private float destroyTime;

  void Start() {
    this.destroyTime = 10f;
    this.rb = this.GetComponent<Rigidbody2D>();
    this.movement = new Vector2(0, -1);

    Assert.IsNotNull(this.rb);

    Destroy(this.gameObject, this.destroyTime);
  }

  void FixedUpdate() {
    this.Move();
  }

  private void Move() {
    this.rb.MovePosition(this.rb.position + (
      this.movement.normalized * this.velocity * Time.fixedDeltaTime
    ));
  }
}
