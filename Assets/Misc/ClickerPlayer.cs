using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Clicker Player")]
public class ClickerPlayer: ScriptableObject {

  public int clicks;

  public int hits;

  public Timer timer;

  public float GetAccuracy() {
    if (this.clicks == 0) return 1;

    return ((float) this.hits / this.clicks);
  }

  public string GetFormattedAccuracy() {
    return Mathf.Round(this.GetAccuracy() * 100).ToString();
  }

  public float GetScore() {
    return Mathf.Round(
      (((float) this.hits) * 100 * this.GetAccuracy()) / this.timer.elapsedTime
    );
  }
}
