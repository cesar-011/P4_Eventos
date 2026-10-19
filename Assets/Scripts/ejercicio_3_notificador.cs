using UnityEngine;

public class ejercicio_3_notificador : MonoBehaviour {
  public float velocidad = 1.0f;
  private Rigidbody rb;
  private Vector3 movimiento;
  // Creamos dos eventos diferentes
  public delegate void MensajeChoque1();
  public delegate void MensajeChoque2();

  public static event MensajeChoque1 OnTocaHumanoide1;
  public static event MensajeChoque2 OnTocaHumanoide2;

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

  private void OnCollisionEnter(Collision collision) {
    // Si choca con el grupo 1, lanza la alarma 1
    if (collision.gameObject.CompareTag("Humanoide1")) {
      if (OnTocaHumanoide1 != null) OnTocaHumanoide1();
    }
    // Si choca con el grupo 2, lanza la alarma 2
    else if (collision.gameObject.CompareTag("Humanoide2")) {
      if (OnTocaHumanoide2 != null) OnTocaHumanoide2();
    }
  }
}
