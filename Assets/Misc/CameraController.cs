using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController: MonoBehaviour {

  public Transform target;

  public Vector3 offset;

  public float minZoom;
  public float maxZoom;
  public float currentZoom;

  void Start() {
    this.target = null;

    this.minZoom = 5f;
    this.maxZoom = 15f;
    this.currentZoom = 10f;
  }

  void LateUpdate() {
    gameObject.transform.position = (target.position - offset) * currentZoom;
    // gameObject.transform.lookAt(target.position);
  }
}
