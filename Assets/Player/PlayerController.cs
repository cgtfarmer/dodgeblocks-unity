using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController: MonoBehaviour {

  // public static event System.Action<string> onInteract;

  public InteractEvent interactEvent;

  public Player player;

  // private Animator animator;

  // public LayerMask interactableLayers;

  // new Camera camera;
  // private PlayerMovement playerMovement;

  private PlayerAbilityManager playerAbilityManager;

  void Start() {
    // this.camera = Camera.main;
    // this.player = this.GetComponent<Player>();
    // this.playerMovement = this.GetComponent<PlayerMovement>();
    this.playerAbilityManager = this.GetComponent<PlayerAbilityManager>();
    // this.animator = this.GetComponent<Animator>();

    Assert.IsNotNull(this.interactEvent);
    Assert.IsNotNull(this.player);
    // Assert.IsNotNull(this.playerMovement);
    Assert.IsNotNull(this.playerAbilityManager);
    // Assert.IsNotNull(this.animator);
  }

  void Update() {
    // this.playerMovement.SetMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    this.player.SetMovement(
      Input.GetAxisRaw("Horizontal"),
      Input.GetAxisRaw("Vertical")
    );

    // this.animator.SetFloat("Horizontal", this.player.movement.x);
    // this.animator.SetFloat("Vertical", this.player.movement.y);
    // this.animator.SetFloat("Speed", this.player.movement.sqrMagnitude);

    // if (this.player.movement.sqrMagnitude > 0.01f) {
    //   this.animator.SetFloat("LastMoveHorizontal", this.player.movement.x);
    //   this.animator.SetFloat("LastMoveVertical", this.player.movement.y);
    // }

    // this.player.SetMovement(
    //   Input.GetAxisRaw("Horizontal"),
    //   Input.GetAxisRaw("Vertical")
    // );

    if (Input.GetKeyDown(KeyCode.Space)) {
      this.Interact();
    }
  }

  private void Interact() {
    Debug.Log("[PlayerController#Interact]");

    this.playerAbilityManager.Interact();
  }
}
