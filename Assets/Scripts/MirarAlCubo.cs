using UnityEngine;

public class MirarAlCubo : MonoBehaviour {
  public Transform cubo;

  private void Update() {
    // En cada frame, el humanoide rotará para mirar directamente al cubo
    if (cubo != null) {
      transform.LookAt(cubo);
    }
  }
}