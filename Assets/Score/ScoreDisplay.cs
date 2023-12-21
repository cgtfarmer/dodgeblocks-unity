using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class ScoreDisplay: MonoBehaviour {

  [SerializeField]
  private Score score;

  private TextMeshProUGUI tmp;

  void Start() {
    this.tmp = this.GetComponent<TextMeshProUGUI>();

    Assert.IsNotNull(this.tmp);
  }

  void Update() {
    this.tmp.SetText($"Score: {this.score.value.ToString()}");
  }
}
