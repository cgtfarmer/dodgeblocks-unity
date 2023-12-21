using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Assertions;

public class OrthographicCameraPositionClamper: MonoBehaviour {

  public Tilemap tilemap;

  private Bounds tilemapWorldBounds;

  private Vector2 clampMaxValues;

  private Vector2 cameraExtents;

  private Camera cam;

  void Start() {
    this.cam = this.GetComponent<Camera>();

    Bounds tilemapLocalBounds = this.tilemap.localBounds;

    this.tilemapWorldBounds = new Bounds();
    this.tilemapWorldBounds.SetMinMax(
      this.tilemap.transform.TransformPoint(tilemapLocalBounds.min),
      this.tilemap.transform.TransformPoint(tilemapLocalBounds.max)
    );

    this.cameraExtents = new Vector2(
      this.cam.orthographicSize * this.cam.aspect,
      this.cam.orthographicSize
    );

    Assert.IsNotNull(this.cam);
    Assert.IsNotNull(this.tilemap);

    // this.clampMaxValues = this.tilemapWorldBounds.max;
  }

  // void LateUpdate() {
  //   // Random.Range(this.tilemapWorldBounds.min.x, this.tilemapWorldBounds.max.x),

  //   this.transform.position = this.ClampVectorSymmetric(
  //     this.transform.position,
  //     // this.clampMaxValues
  //   );
  // }

  void LateUpdate() {
    // Random.Range(this.tilemapWorldBounds.min.x, this.tilemapWorldBounds.max.x),

    this.transform.position = this.ClampWithBounds(
      this.transform.position,
      this.tilemapWorldBounds
    );
  }

  private Vector3 ClampWithBounds(Vector3 values, Bounds bounds) {
    return new Vector3(
      Mathf.Clamp(values.x, (bounds.min.x + this.cameraExtents.x), (bounds.max.x - this.cameraExtents.x)),
      Mathf.Clamp(values.y, (bounds.min.y + this.cameraExtents.y), (bounds.max.y - this.cameraExtents.y)),
      values.z
    );
  }

  // private Vector3 ClampVectorSymmetric(Vector3 values, Vector3 clampValues) {
  //   return new Vector3(
  //     Mathf.Clamp(values.x, (clampValues.x * -1), clampValues.x),
  //     Mathf.Clamp(values.y, (clampValues.y * -1), clampValues.y),
  //     Mathf.Clamp(values.z, (clampValues.z * -1), clampValues.z)
  //   );
  // }
}
