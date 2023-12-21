using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting: MonoBehaviour {

  public Transform firePoint;

  public GameObject projectilePrefab;

  private float projectileForce;

  void Start() {
    this.projectileForce = 20f;
  }

  void Update() {
    if (!Input.GetMouseButtonDown(0)) return;

    this.Shoot();
  }

  private void Shoot() {
    GameObject projectile = Instantiate(projectilePrefab, this.firePoint.position, firePoint.rotation);

    Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

    rb.AddForce((firePoint.up) * this.projectileForce, ForceMode2D.Impulse);
  }
}
