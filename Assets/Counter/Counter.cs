using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Counter")]
public class Counter: ScriptableObject {

  [Range(1, 1000)]
  [Tooltip("Max count")]
  public int maxCount;

  [Range(0, 1000)]
  public int count;

  private void OnEnable() {
    this.count = 0;
  }

  public void Increment() {
    this.count += 1;
  }

  public bool IsMax() {
    return (this.count >= this.maxCount);
  }
}
