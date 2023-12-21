using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotion: MonoBehaviour {

  public GameObject target;

  void Start() {
    this.SetPositionToTarget();
  }

  void Update() {
    // this.transform.position = this.player.transform.position;
    this.SetPositionToTarget();
  }

  private void SetPositionToTarget() {
    this.transform.position = new Vector3(
      this.target.transform.position.x,
      this.target.transform.position.y,
      this.transform.position.z
    );
  }
}
