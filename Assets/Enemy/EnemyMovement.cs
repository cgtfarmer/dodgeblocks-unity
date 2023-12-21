using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement: MonoBehaviour {

  public Enemy enemy;

  public Vector2 movement;

  public float velocity;

  private Rigidbody2D rb;

  private Animator animator;

  private float directionDuration;

  private EnemyController enemyController;

  void Start() {
    this.enemyController = this.GetComponent<EnemyController>();
    this.rb = this.GetComponent<Rigidbody2D>();
    this.animator = this.GetComponent<Animator>();
    this.directionDuration = 0f;
    this.velocity = 0f;

    Assert.IsNotNull(this.enemyController);
    Assert.IsNotNull(this.enemy);
    Assert.IsNotNull(this.animator);
    Assert.IsNotNull(this.rb);

    this.GetNewVelocity();
  }

  void FixedUpdate() {
    if (this.enemyController.isDying) return;

    if (this.directionDuration <= 0) this.GetNewVelocity();

    this.Move();
    this.directionDuration -= Time.fixedDeltaTime;
  }

  private void GetNewVelocity() {
    this.directionDuration = Random.Range(0.0f, this.enemy.maxDirectionDuration);

    this.velocity = Random.Range(0.0f, this.enemy.maxVelocity);

    this.movement = this.GetNewMovement();
    // this.animator.SetFloat("Horizontal", this.movement.x);
    // this.animator.SetFloat("Vertical", this.movement.y);
    // this.animator.SetFloat("Speed", this.movement.sqrMagnitude);

    if (this.movement.sqrMagnitude > 0.01f) {
      this.animator.SetFloat("LastHorizontal", this.movement.x);
      // this.animator.SetFloat("LastVertical", this.movement.y);
    }
  }

  private Vector2 GetNewMovement() {
    if (this.ShouldStop()) return new Vector2(0, 0);

    return new Vector2(
      Random.Range(-1.0f, 1.0f),
      Random.Range(-1.0f, 1.0f)
    );
  }

  private bool ShouldStop() {
    return (Random.Range(0.0f, 1.0f) <= this.enemy.stopProbability);
  }

  private void Move() {
    this.rb.MovePosition(this.rb.position + (
      this.movement.normalized * this.velocity * Time.fixedDeltaTime
    ));
  }
}
