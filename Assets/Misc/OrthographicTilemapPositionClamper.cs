using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.Assertions;

public class OrthographicTilemapPositionClamper: MonoBehaviour {

  public Tilemap tilemap;

  private Bounds tilemapWorldBounds;

  private Vector2 clampMaxValues;

  private Vector3 spriteExtents;

  void Start() {
    SpriteRenderer spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    this.spriteExtents = spriteRenderer.bounds.extents;

    Bounds tilemapLocalBounds = this.tilemap.localBounds;

    this.tilemapWorldBounds = new Bounds();
    this.tilemapWorldBounds.SetMinMax(
      this.tilemap.transform.TransformPoint(tilemapLocalBounds.min),
      this.tilemap.transform.TransformPoint(tilemapLocalBounds.max)
    );

    Assert.IsNotNull(this.tilemap);
    // Assert.IsNotNull(this.spriteExtents);
    Assert.AreNotEqual(this.spriteExtents, default(Vector3));
  }

  void LateUpdate() {
    this.transform.position = this.ClampWithBounds(
      this.transform.position,
      this.tilemapWorldBounds
    );
  }

  private Vector3 ClampWithBounds(Vector3 values, Bounds bounds) {
    return new Vector3(
      Mathf.Clamp(values.x, (bounds.min.x + this.spriteExtents.x), (bounds.max.x - this.spriteExtents.x)),
      Mathf.Clamp(values.y, (bounds.min.y + this.spriteExtents.y), (bounds.max.y - this.spriteExtents.y)),
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
