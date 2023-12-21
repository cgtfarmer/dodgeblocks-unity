using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class CounterDisplay: MonoBehaviour {
  // public static event System.Action onGameWon;

  [SerializeField]
  private Counter counter;

  TextMeshProUGUI tmp;

  void Start() {
    this.tmp = this.GetComponent<TextMeshProUGUI>();

    Assert.IsNotNull(this.counter);
    Assert.IsNotNull(this.tmp);
  }

  void Update() {
    this.tmp.SetText($"{this.counter.count} / {this.counter.maxCount}");
  }
}
