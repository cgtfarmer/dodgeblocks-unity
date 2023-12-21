using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class ClicksDisplay: MonoBehaviour {
  // public static event System.Action onGameWon;

  [SerializeField]
  private ClickerPlayer clickerPlayer;

  TextMeshProUGUI tmp;

  void Start() {
    this.tmp = this.GetComponent<TextMeshProUGUI>();

    Assert.IsNotNull(this.clickerPlayer);
    Assert.IsNotNull(this.tmp);
  }

  void Update() {
    this.tmp.SetText($"Clicks: {this.clickerPlayer.clicks.ToString()}");
  }
}
