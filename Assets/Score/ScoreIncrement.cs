using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class ScoreIncrement: MonoBehaviour {

  [SerializeField]
  private Score score;

  [SerializeField]
  private Timer timer;

  private int pointsPerSecond;

  void Start() {
    this.pointsPerSecond = 100;

    Assert.IsNotNull(this.timer);

    this.score.value = 0;
  }

  void Update() {
    this.score.value = Mathf.RoundToInt(this.timer.elapsedTime * this.pointsPerSecond);
  }
}
