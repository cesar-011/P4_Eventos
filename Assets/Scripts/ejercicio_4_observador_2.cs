using UnityEngine;

public class ejercicio_4_observador_2 : MonoBehaviour {
  public Transform escudoGrupo2;
  public Transform objetoOrientacion; // Nuevo hueco para el objeto que van a mirar
  public float velocidad = 2f;
  private bool moverse = false;

  private void Start() {
    ejercicio_4_notificador.OnAproximaReferencia += Orientar; // Nueva suscripción
  }

  private void OnDestroy() {
    ejercicio_4_notificador.OnAproximaReferencia -= Orientar; // Desuscripción
  }

  private void ActivarMovimiento() {
    moverse = true;
  }

  // 4. Callback de la orientación
  private void Orientar() {
    if (objetoOrientacion != null) {
      transform.LookAt(objetoOrientacion);
    }
  }

  private void Update() {
    if (moverse && escudoGrupo2 != null) {
      transform.position = Vector3.MoveTowards(transform.position, escudoGrupo2.position, velocidad * Time.deltaTime);
    }
  }
}
