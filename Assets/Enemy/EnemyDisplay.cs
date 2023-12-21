using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyDisplay : MonoBehaviour {

  public Enemy enemy;

  // public EnemySprite enemySprite;

  private SpriteRenderer spriteRenderer;

  void Start() {
    this.spriteRenderer = this.GetComponent<SpriteRenderer>();

    Assert.IsNotNull(this.enemy);
    // Assert.IsNotNull(this.enemySprite);
    Assert.IsNotNull(this.spriteRenderer);
  }

  public void Die() {
    this.gameObject.SetActive(false);
  }
}
