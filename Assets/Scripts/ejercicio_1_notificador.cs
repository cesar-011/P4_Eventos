using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ejercicio_1_notificador : MonoBehaviour
{
  // Definimos el delegado y el evento
  public delegate void AccionChoque();
  public static event AccionChoque OnCuboChoca;
  
  // Detectamos la colision y llamamos al evento
  private void OnCollisionEnter(Collision collision) {
    // Comprobamos si lo que ha chocado tiene la etiqueta "Cubo"
    if (collision.gameObject.CompareTag("Cubo")) {
      Debug.Log("El cubo ha chocado con el cilindro");
      // Disparamos el evento si hay alguien suscrito
      if (OnCuboChoca != null) {
        OnCuboChoca();
      }
    }
  }
}
