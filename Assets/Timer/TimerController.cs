using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class TimerController: MonoBehaviour {

  public GameWonEvent gameWonEvent;

  public Timer timer;

  public bool autoStartTimer;

  void Start() {
    Assert.IsNotNull(this.gameWonEvent);
    Assert.IsNotNull(this.timer);

    if (this.autoStartTimer) {
      this.timer.Start();
    }
  }

  void OnEnable() {
    this.gameWonEvent.e.AddListener(this.StopTimer);
  }

  void OnDisable() {
    this.gameWonEvent.e.RemoveListener(this.StopTimer);
  }

  void Update() {
    if (!this.timer.running) return;

    this.timer.IncrementElapsedTime(Time.deltaTime);
  }

  public void StartTimer() {
    print($"[TimerController#StartTimer]");

    this.timer.Start();
  }

  public void StopTimer() {
    print($"[TimerController#StopTimer]");

    this.timer.Stop();
  }

  public void ResetTimer() {
    print($"[TimerController#ResetTimer]");

    this.timer.Reset();
  }
}

