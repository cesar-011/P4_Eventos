using UnityEngine;

public class ejercicio_4_observador_1 : MonoBehaviour {
  public Transform escudoSeleccionado;
  public Transform escudoTeletransporte; // Nuevo hueco para el escudo del teletransporte
  public float velocidad = 2f;
  private bool moverse = false;

  private void Start() {
    ejercicio_4_notificador.OnAproximaReferencia += Teletransportar; // Nueva suscripción
  }

  private void OnDestroy() {
    ejercicio_4_notificador.OnAproximaReferencia -= Teletransportar; // Desuscripción
  }

  private void ActivarMovimiento() {
    moverse = true;
  }

  // 3. Callback del teletransporte
  private void Teletransportar() {
    if (escudoTeletransporte != null) {
      transform.position = escudoTeletransporte.position;
    }
  }

  private void Update() {
    if (moverse && escudoSeleccionado != null) {
      transform.position = Vector3.MoveTowards(transform.position, escudoSeleccionado.position, velocidad * Time.deltaTime);
    }
  }
}
