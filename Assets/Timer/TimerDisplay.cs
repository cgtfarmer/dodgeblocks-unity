using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class TimerDisplay: MonoBehaviour {

  [SerializeField]
  private Timer timer;

  private TextMeshProUGUI tmp;

  private string displayFormat;

  void Start() {
    this.tmp = this.GetComponent<TextMeshProUGUI>();
    this.displayFormat = "{0:00}:{1:00}:{2:00}";

    Assert.IsNotNull(this.timer);
    Assert.IsNotNull(this.tmp);
  }

  void Update() {
    float minutes = Mathf.FloorToInt(this.timer.elapsedTime / 60);
    float seconds = Mathf.FloorToInt(this.timer.elapsedTime % 60);
    float milliseconds = Mathf.FloorToInt((this.timer.elapsedTime * 100) % 100);

    this.tmp.SetText(string.Format(this.displayFormat, minutes, seconds, milliseconds));
  }
}
