using UnityEngine;

public class ejercicio_3_observador_2 : MonoBehaviour {
  public Transform escudoGrupo2;
  public float velocidad = 2f;
  private bool moverse = false;

  private void Start() {
    // Se suscribe al evento del notificador
    ejercicio_3_notificador.OnTocaHumanoide1 += ActivarMovimiento;
  }

  private void OnDestroy() {
    ejercicio_3_notificador.OnTocaHumanoide1 -= ActivarMovimiento;
  }

  private void ActivarMovimiento() {
    moverse = true;
  }

  private void Update() {
    if (moverse && escudoGrupo2 != null) {
      transform.position = Vector3.MoveTowards(transform.position, escudoGrupo2.position, velocidad * Time.deltaTime);
    }
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Escudo1") || collision.gameObject.CompareTag("Escudo2")) {
      Renderer renderizador = GetComponentInChildren<Renderer>();
      if (renderizador != null) {
        renderizador.material.color = Color.red;
      }
    }
  }
}
