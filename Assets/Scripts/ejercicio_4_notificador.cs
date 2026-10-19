using UnityEngine;

public class ejercicio_4_notificador : MonoBehaviour {

  // para la aproximación
  public delegate void MensajeAproximacion();
  public static event MensajeAproximacion OnAproximaReferencia;
  
  public float velocidad = 1.0f;
  private Rigidbody rb;
  private Vector3 movimiento;


  void Start() {
    rb = GetComponent<Rigidbody>();
  }

  void Update() {
    float ejeX = Input.GetAxis("Horizontal");
    float ejeZ = Input.GetAxis("Vertical");

    movimiento = new Vector3(ejeX, 0, ejeZ).normalized;
  }

  void FixedUpdate() {
    Vector3 nueva_posicion = rb.position + movimiento * velocidad * Time.fixedDeltaTime;
    rb.MovePosition(nueva_posicion);
  }


  // Detectamos si el cubo se aproxima al objeto de referencia (Trigger)
  private void OnTriggerEnter(Collider other) {
    if (other.CompareTag("Referencia")) {
      if (OnAproximaReferencia != null) OnAproximaReferencia();
    }
  }
    
}
