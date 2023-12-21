using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ClickerPlayerController: MonoBehaviour {

  public InteractEvent interactEvent;

  public Camera cam;

  public ClickerPlayer clickerPlayer;

  void Start() {
    Assert.IsNotNull(this.interactEvent);
    Assert.IsNotNull(this.cam);
    Assert.IsNotNull(this.clickerPlayer);

    this.clickerPlayer.clicks = 0;
    this.clickerPlayer.hits = 0;
  }

  void Update() {
    if (!Input.GetMouseButtonDown(0)) return;

    Interact();
  }
  private void Interact() {
    print("[MousePlayerController#Interact]");

    this.clickerPlayer.clicks += 1;

    Vector3 mousePos = this.cam.ScreenToWorldPoint(Input.mousePosition);

    RaycastHit2D hit = Physics2D.Raycast((Vector2) mousePos, Vector2.zero);

    string intersectionName = hit ? hit.collider?.gameObject?.name : "NONE";

    print($"[MousePlayerController#Interact] {intersectionName}");

    if (hit.collider == null) return;

    this.clickerPlayer.hits += 1;

    this.interactEvent.e.Invoke(intersectionName);
  }
}
