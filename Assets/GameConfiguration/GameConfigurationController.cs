using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class GameConfigurationController: MonoBehaviour {

  public Counter counter;

  public EnemySpawner enemySpawner;

  public Enemy enemy;

  void Start() {
    Assert.IsNotNull(this.counter);
    Assert.IsNotNull(this.enemySpawner);
    Assert.IsNotNull(this.enemy);
  }

  public void SetEasyConfiguration() {
    print($"[GameConfigurationController#SetEasyConfiguration]");

    this.enemySpawner.quantity = 10;
    this.counter.count = 0;
    this.counter.maxCount = 10;
    this.enemy.maxVelocity = 3;
    this.enemy.maxDirectionDuration = 5;
    this.enemy.stopProbability = 0.3f;
  }

  public void SetMediumConfiguration() {
    print($"[GameConfigurationController#SetMediumConfiguration]");

    this.enemySpawner.quantity = 25;
    this.counter.count = 0;
    this.counter.maxCount = 25;
    this.enemy.maxVelocity = 10;
    this.enemy.maxDirectionDuration = 5;
    this.enemy.stopProbability = 0.2f;
  }

  public void SetHardConfiguration() {
    print($"[GameConfigurationController#SetHardConfiguration]");

    this.enemySpawner.quantity = 50;
    this.counter.count = 0;
    this.counter.maxCount = 50;
    this.enemy.maxVelocity = 30;
    this.enemy.maxDirectionDuration = 5;
    this.enemy.stopProbability = 0.1f;
  }

  public void SetImpossibleConfiguration() {
    print($"[GameConfigurationController#SetImpossibleConfiguration]");

    this.enemySpawner.quantity = 100;
    this.counter.count = 0;
    this.counter.maxCount = 100;
    this.enemy.maxVelocity = 100;
    this.enemy.maxDirectionDuration = 1;
    this.enemy.stopProbability = 0.01f;
  }
}
