using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Tilemaps;

public class EnemySpawnerController: MonoBehaviour {

  public GameObject prefabToSpawn;

  public Enemy enemyObject;

  public Transform parentTransform;

  public EnemySpawner enemySpawner;

  private Camera cam;

  private Bounds cameraBounds;

  private float spawnInterval = 1f;

  private float timer = 0f;

  private float minVelocity = 1f;

  private float maxVelocity = 10f;

  private int spawnCounter;

  private float velocityIncreaseInterval;

  private float velocityIncreaseIntervalCounter;

  private float velocityIncreaseAmount;

  private float spawnIntervalDecreaseAmount;

  void Start() {
    this.spawnCounter = 0;

    this.velocityIncreaseInterval = 20f;
    this.velocityIncreaseIntervalCounter = 0f;
    this.velocityIncreaseAmount = 2f;

    this.spawnIntervalDecreaseAmount = 0.60f;

    this.cam = Camera.main;

    this.cameraBounds = new Bounds(
      new Vector3(0, 0, 0),
      new Vector3(
        this.cam.orthographicSize * 2 * this.cam.aspect,
        this.cam.orthographicSize * 2,
        0
      )
    );

    Assert.IsNotNull(this.prefabToSpawn);
    Assert.IsNotNull(this.parentTransform);
    Assert.IsNotNull(this.cam);
    Assert.AreNotEqual(this.cameraBounds, default(Bounds));
  }

  void Update() {
    this.timer += Time.deltaTime;
    this.velocityIncreaseIntervalCounter += Time.deltaTime;

    if (this.velocityIncreaseIntervalCounter >= this.velocityIncreaseInterval) {
      this.velocityIncreaseIntervalCounter = 0f;
      this.minVelocity += this.velocityIncreaseAmount;
      this.maxVelocity += this.velocityIncreaseAmount;
      this.spawnInterval *= this.spawnIntervalDecreaseAmount;
    }

    if (this.timer < this.spawnInterval) return;

    this.timer = 0;

    this.SpawnGameObject();
    this.spawnCounter += 1;
  }

  private void SpawnGameObject() {
    GameObject go = Instantiate(
      this.prefabToSpawn,
      this.GetRandomPosition(),
      Quaternion.identity,
      this.parentTransform
    );

    go.name = $"Block-{this.spawnCounter}";
    go.GetComponent<BlockMovement>().velocity = Random.Range(this.minVelocity, this.maxVelocity);
  }

  // private void SpawnGameObjects() {
  //   for (int i = 0; i < this.enemySpawner.quantity; i++) {
  //     GameObject go = Instantiate(
  //       this.prefabToSpawn,
  //       this.GetRandomPosition(),
  //       Quaternion.identity,
  //       this.parentTransform
  //     );

  //     go.name = $"Enemy-{i}";
  //     go.GetComponent<OrthographicTilemapPositionClamper>().tilemap = this.tilemap;
  //     // go.GetComponent<ResourceDisplay>().resource = this.GetRandomResourceObject();
  //   }
  // }

  private Vector3 GetRandomPosition() {
    return new Vector3(
      Random.Range(this.cameraBounds.min.x, this.cameraBounds.max.x),
      (this.cameraBounds.max.y + this.prefabToSpawn.GetComponent<SpriteRenderer>().bounds.extents.y),
      0
    );
  }
}
