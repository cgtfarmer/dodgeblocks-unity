using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class OrthographicPositionClamper: MonoBehaviour {

  public Camera cam;
  // private Vector2 screenBounds;
  // private SpriteRenderer spriteRenderer;
  // private Vector2 spriteExtents;

  private Vector3 clampMaxValues;

  void Start() {
    SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();

    Assert.IsNotNull(this.cam);

    Vector2 screenBounds = this.cam.ScreenToWorldPoint(
      new Vector3(Screen.width, Screen.height, this.cam.transform.position.z)
    );

    Vector2 spriteExtents = spriteRenderer.bounds.extents;

    Vector2 difference = (screenBounds - spriteExtents);

    this.clampMaxValues = new Vector3(difference.x, difference.y, 0);
  }

  void LateUpdate() {
    this.transform.position = this.ClampVectorSymmetric(
      this.transform.position,
      this.clampMaxValues
    );
  }

  private Vector3 ClampVectorSymmetric(Vector3 values, Vector3 clampValues) {
    return new Vector3(
      Mathf.Clamp(values.x, (clampValues.x * -1), clampValues.x),
      Mathf.Clamp(values.y, (clampValues.y * -1), clampValues.y),
      Mathf.Clamp(values.z, (clampValues.z * -1), clampValues.z)
    );
  }
}
