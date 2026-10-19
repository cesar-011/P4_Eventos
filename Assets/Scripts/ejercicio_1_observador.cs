using UnityEngine;

public class ejercicio_1_observador : MonoBehaviour
{
  public Transform objetivoTipo2;
  public Transform cilindro;
  public float velocidad = 2f;
    
  private bool moverse = false;

  private void Start() {
    // Nos suscribimos al evento del cilindro
    ejercicio_1_notificador.OnCuboChoca += IniciarMovimiento;
  }

  private void OnDestroy() {
    // Nos desuscribimos si la esfera se destruye para evitar errores
    ejercicio_1_notificador.OnCuboChoca -= IniciarMovimiento;
  }

  // Función de respuesta (Callback)
  private void IniciarMovimiento() {
    moverse = true;
  }

  private void Update() {
    if (moverse) {
      // Lógica para las esferas Tipo 1 (Rojas)
      if (gameObject.CompareTag("Tipo1") && objetivoTipo2 != null) {
        transform.position = Vector3.MoveTowards(transform.position, objetivoTipo2.position, velocidad * Time.deltaTime);
      }
      // Lógica para las esferas Tipo 2 (Verdes)
      else if (gameObject.CompareTag("Tipo2") && cilindro != null) {
        transform.position = Vector3.MoveTowards(transform.position, cilindro.position, velocidad * Time.deltaTime);
      }
    }
  }
}
