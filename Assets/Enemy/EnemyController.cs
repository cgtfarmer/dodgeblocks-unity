using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyController: MonoBehaviour {

  public InteractEvent interactEvent;

  public PickUpEvent pickUpEvent;

  private EnemyDisplay enemyDisplay;

  private EnemyMovement enemyMovement;

  private Animator animator;

  private float dyingTime;

  public bool isDying;

  void Start() {
    this.isDying = false;
    this.dyingTime = 0.6f;
    this.enemyDisplay = this.GetComponent<EnemyDisplay>();
    this.enemyMovement = this.GetComponent<EnemyMovement>();
    this.animator = this.GetComponent<Animator>();

    Assert.IsNotNull(this.interactEvent);
    Assert.IsNotNull(this.pickUpEvent);
    Assert.IsNotNull(this.enemyDisplay);
    Assert.IsNotNull(this.enemyMovement);
    Assert.IsNotNull(this.animator);
  }

  void OnEnable() {
    this.interactEvent.e.AddListener(this.HandleInteract);
  }

  void OnDisable() {
    this.interactEvent.e.RemoveListener(this.HandleInteract);
  }

  void OnTriggerEnter2D(Collider2D collider) {
    this.transform.localScale = new Vector3(0.35f, 0.35f, 1);
    this.isDying = true;
    this.animator.SetBool("IsDying", this.isDying);

    this.GetComponent<CircleCollider2D>().enabled = false;

    Debug.Log($"[EnemyController#OnTriggerEnter2D] {this.gameObject.name}");
    this.pickUpEvent.e.Invoke();

    Destroy(this.gameObject, this.dyingTime);
  }

  public void HandleInteract(string name) {
    if (name != this.gameObject.name) return;

    Debug.Log($"[EnemyController#HandleInteract] {this.gameObject.name}");
    this.pickUpEvent.e.Invoke();

    this.enemyDisplay.Die();
  }
}

