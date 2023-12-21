using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ResourceSpawnerController: MonoBehaviour {

  public GameObject prefabToSpawn;

  public Resource[] resourceObjects;

  public Transform parentTransform;

  public ResourceSpawner resourceSpawner;

  private Camera cam;

  private Bounds cameraBounds;

  // public Vector3 minPosition;
  // public Vector3 maxPosition;

  void Start() {
    // this.camera = this.GetComponent<Camera>();
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
    Assert.IsNotNull(this.resourceObjects);
    Assert.IsNotNull(this.parentTransform);
    Assert.IsNotNull(this.resourceSpawner);
    Assert.IsNotNull(this.cam);
    Assert.AreNotEqual(this.cameraBounds, default(Bounds));

    this.SpawnGameObjects();
  }

  private void SpawnGameObjects() {
    for (int i = 0; i < this.resourceSpawner.quantity; i++) {
      GameObject go = Instantiate(
        this.prefabToSpawn,
        this.GetRandomPosition(),
        Quaternion.identity,
        this.parentTransform
      );

      go.name = $"Resource-{i}";
      go.GetComponent<ResourceDisplay>().resource = this.GetRandomResourceObject();
    }
  }

  private Vector3 GetRandomPosition() {
    return new Vector3(
      Random.Range(this.cameraBounds.min.x, this.cameraBounds.max.x),
      Random.Range(this.cameraBounds.min.y, this.cameraBounds.max.y),
      Random.Range(this.cameraBounds.min.z, this.cameraBounds.max.z)
    );
  }

  private Resource GetRandomResourceObject() {
    int randomIndex = Random.Range(0, this.resourceObjects.Length);

    return this.resourceObjects[randomIndex];
  }
}
