using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Timer")]
public class Timer: ScriptableObject {

  public bool running;

  public float elapsedTime;

  private void OnEnable() {
    this.running = false;
    this.elapsedTime = 0f;
  }

  public void Start() {
    this.running = true;
  }

  public void Stop() {
    this.running = false;
  }

  public void Reset() {
    this.elapsedTime = 0f;
  }

  public void IncrementElapsedTime(float amount) {
    this.elapsedTime += amount;
  }
}
