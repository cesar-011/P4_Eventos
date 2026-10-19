using UnityEngine;
using TMPro; // Usamos TextMeshPro para la interfaz

public class VidaCubo : MonoBehaviour {
  public int vida = 50;
  public TextMeshProUGUI textoMuerte;

  public float velocidad = 1.0f;
  private Rigidbody rb;
  private Vector3 movimiento;


  private void Start() {
    // Al empezar el juego, nos aseguramos de que el texto de muerte esté oculto o vacío
    if (textoMuerte != null) {
      textoMuerte.text = ""; 
    }
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
  // Comprobamos si nos ha tocado un humanoide
    if (collision.gameObject.CompareTag("Humanoide1")) {
      vida -= 20; // Restamos 20 de vida
      Debug.Log("Me han atacado. Vida restante: " + vida);

      // Si la vida baja de 1, mostramos el mensaje de muerte
      if (vida < 1) {
        Morir();
        }
      }
    }

  private void Morir() {
    Debug.Log("El cubo ha muerto.");
    if (textoMuerte != null) {
      textoMuerte.text = "¡HAS MUERTO!";
      textoMuerte.color = Color.red;
    }
    Destroy(gameObject);
  }
}