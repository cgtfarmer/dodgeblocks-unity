using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class OrthographicPositionWrapper: MonoBehaviour {

  private Camera cam;
  // private Vector2 screenBounds;
  // private SpriteRenderer spriteRenderer;
  // private Vector2 spriteExtents;

  private Vector2 wrapMaxValues;

  private Vector2 wrapOffset;

  // private Bounds cameraBounds;

  void Start() {
    SpriteRenderer spriteRenderer = this.GetComponent<SpriteRenderer>();
    this.cam = Camera.main;

    Assert.IsNotNull(this.cam);
    // this.cameraBounds = this.cam.Bounds


    Vector2 screenBounds = this.cam.ScreenToWorldPoint(
      new Vector3(Screen.width, Screen.height, this.cam.transform.position.z)
    );

    this.wrapOffset = (spriteRenderer.bounds.extents * 0.75f);

    // this.wrapMaxValues = (screenBounds + spriteExtents);
    this.wrapMaxValues = screenBounds;
  }

  // void Update() {
  //   this.transform.position = this.WrapVectorSymmetric(
  //     this.transform.position,
  //     this.wrapMaxValues
  //   );
  // }

  void LateUpdate() {
    this.transform.position = this.WrapVectorSymmetric(
      this.transform.position,
      this.wrapMaxValues
    );
  }

  private Vector3 WrapVectorSymmetric(Vector3 values, Vector2 wrapValues) {
    return new Vector3(
      this.Wrap(values.x, (wrapValues.x * -1), wrapValues.x),
      this.Wrap(values.y, (wrapValues.y * -1), wrapValues.y),
      values.z
    );
  }

  private float Wrap(float value, float start, float end) {
    if (value < start) return end;

    if (value > end) return start;

    return value;
  }

  // void LateUpdate() {
  //   if (Mathf.Abs(this.transform.position.x) <= this.wrapMaxValues.x) return;

  //   if (Mathf.Abs(this.transform.position.y) <= this.wrapMaxValues.y) return;

  //   this.transform.position = this.WrapVectorSymmetric(
  //     this.transform.position,
  //     this.wrapMaxValues
  //   );
  // }

  // void FixedUpdate() {
  //   if (Mathf.Abs(this.transform.position.x) <= this.wrapMaxValues.x) return;

  //   if (Mathf.Abs(this.transform.position.y) <= this.wrapMaxValues.y) return;

  //   this.transform.position = this.WrapVectorSymmetric(
  //     this.transform.position,
  //     this.wrapMaxValues
  //   );
  // }

  // private Vector3 WrapVectorSymmetric(Vector3 values, Vector2 wrapValues) {

  //   if (Mathf.Abs(values.x) > wrapValues.x) {
  //     values.x *= -1;
  //     values.x += this.wrapOffset.x;
  //   }

  //   if (Mathf.Abs(values.y) > wrapValues.y) {
  //     values.y *= -1;
  //     values.y -= this.wrapOffset.y;
  //   }

  //   return values;
  // }

  // private void WrapPosition() {
  //   Vector2 position = new Vector2();

  //   for (int i = 0; i < 2; i++) {
  //     if (sr.bounds.max[i] < Global.GameBounds.min[i]) {
  //       position[i] = Global.GameBounds.max[i];
  //     } else if (sr.bounds.min[i] > Global.GameBounds.max[i]) {
  //       position[i] = Global.GameBounds.min[i];
  //     } else {
  //       position[i] = transform.position[i];
  //     }
  //   }

  //   transform.position = position;
  // }
}
