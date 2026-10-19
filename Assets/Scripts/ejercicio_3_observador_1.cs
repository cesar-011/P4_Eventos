using UnityEngine;

public class ejercicio_3_observador_1 : MonoBehaviour {
  public Transform escudoSeleccionado;
  public float velocidad = 2f;
  private bool moverse = false;

  private void Start() {
    // Se suscribe al evento del notificador
    ejercicio_3_notificador.OnTocaHumanoide2 += ActivarMovimiento;
  }

  private void OnDestroy() {
    ejercicio_3_notificador.OnTocaHumanoide2 -= ActivarMovimiento;
  }

  private void ActivarMovimiento() {
    moverse = true;
  }

  private void Update() {
    if (moverse && escudoSeleccionado != null) {
      transform.position = Vector3.MoveTowards(transform.position, escudoSeleccionado.position, velocidad * Time.deltaTime);
    }
  }

  private void OnCollisionEnter(Collision collision) {
    if (collision.gameObject.CompareTag("Escudo1") || collision.gameObject.CompareTag("Escudo2")) {
      Renderer renderizador = GetComponentInChildren<Renderer>();
      if (renderizador != null) {
        renderizador.material.color = Color.blue;
      }
    }
  }
}
