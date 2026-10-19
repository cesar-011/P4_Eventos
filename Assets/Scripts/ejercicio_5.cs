using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ejercicio_5 : MonoBehaviour {
  public float velocidad = 1.0f;
  private Rigidbody rb;
  private Vector3 movimiento;

  public int puntuacion = 0;
  private int proximaRecompensa = 100; // Marcamos la primera meta en 100 puntos
  
  public Text textoPuntuacion;
  public TextMeshProUGUI textoRecompensa;


  void Start() {
    rb = GetComponent<Rigidbody>();
    ActualizarMarcador();
    if (textoRecompensa != null) {
      textoRecompensa.text = ""; 
    }
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
    //Comprobamos si chocamos con un escudo de tipo 1
    if (collision.gameObject.CompareTag("Escudo1")) {
      puntuacion += 5;
      ActualizarMarcador();
      ComprobarRecompensa();
      Destroy(collision.gameObject); // Destruye el escudo recolectado
    }
    //Comprobamos si chocamos con un escudo de tipo 2
    else if (collision.gameObject.CompareTag("Escudo2")) {
      puntuacion += 10;
      ActualizarMarcador();
      ComprobarRecompensa();
      Destroy(collision.gameObject); // Destruye el escudo recolectado
    }
  }

  private void ActualizarMarcador() {
    if (textoPuntuacion != null) {
      textoPuntuacion.text = "Puntuación: " + puntuacion;
    }
  }

  private void ComprobarRecompensa() {
    if (puntuacion >= proximaRecompensa) {
      if (textoRecompensa != null) {
        textoRecompensa.text = "¡Recompensa obtenida por " + proximaRecompensa + " puntos!";
      }
      // Subimos la meta a los siguientes 100 puntos
      proximaRecompensa += 100; 
    }
  }
    
}
