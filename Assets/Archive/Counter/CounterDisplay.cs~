using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CounterDisplay: MonoBehaviour {
  // public static event System.Action onGameWon;

  [SerializeField]
  private Counter counter;

  TextMeshProUGUI tmp;

  void Start() {
    this.tmp = this.GetComponent<TextMeshProUGUI>();
  }

  void Update() {
    this.tmp.SetText($"{this.counter.count} / {this.counter.maxCount}");
  }
}
