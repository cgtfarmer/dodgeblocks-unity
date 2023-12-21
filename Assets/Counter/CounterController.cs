using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class CounterController: MonoBehaviour {

  // public UnityEvent<int> catchCountChangeEvent;
  public PickUpEvent pickUpEvent;

  public GameWonEvent gameWonEvent;

  public Counter counter;

  // public UnityEvent<bool> gameWonEvent;

  void Start() {
    Assert.IsNotNull(this.pickUpEvent);
    Assert.IsNotNull(this.gameWonEvent);
    Assert.IsNotNull(this.counter);
  }

  void OnEnable() {
    this.pickUpEvent.e.AddListener(this.IncrementCounter);
  }

  void OnDisable() {
    this.pickUpEvent.e.RemoveListener(this.IncrementCounter);
  }

  public void IncrementCounter() {
    print($"[CounterController#IncrementCounter]");

    this.counter.Increment();

    if (!this.counter.IsMax()) return;

    print($"[CounterController#IncrementCounter] Counter is maxed");
    this.gameWonEvent.e.Invoke();
  }
}

