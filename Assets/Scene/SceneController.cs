using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class SceneController: MonoBehaviour {

  public GameWonEvent gameWonEvent;

  void Start() {
    Assert.IsNotNull(this.gameWonEvent);
  }

  void OnEnable() {
    this.gameWonEvent.e.AddListener(this.LoadGameOverScene);
  }

  void OnDisable() {
    this.gameWonEvent.e.RemoveListener(this.LoadGameOverScene);
  }

  public void LoadMainMenuScene() {
    print($"[GameSceneManager#LoadGameWonScene]");

    SceneManager.LoadScene("MainMenu");
  }

  public void LoadGameScene() {
    print($"[GameSceneManager#LoadGameScene]");

    SceneManager.LoadScene("Game");
  }

  public void LoadGameOverScene() {
    print($"[GameSceneManager#LoadGameOverScene]");

    SceneManager.LoadScene("GameOver");
  }

  public void QuitGame() {
    print($"[GameSceneManager#QuitGame]");

    Application.Quit();
  }
}

