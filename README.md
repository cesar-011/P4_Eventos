# Práctica 4: Interfaces Inteligentes - Patrón Observador y Eventos

Este repositorio contiene la implementación de los distintos ejercicios de la Práctica 4, centrados en la comunicación entre *GameObjects* mediante el Patrón Observador, el uso de delegados, eventos y la gestión de la interfaz de usuario (UI) en Unity3D.

A continuación se detallan los hitos conseguidos y la explicación técnica de su implementación:

## Hito 1: Mecánica básica de notificación con primitivas
Se implementó el **Patrón Observador**. Se creó un script Notificador en el Cilindro que define un `delegate` y un `event`. Utilizando la función `OnCollisionEnter`, el cilindro detecta la colisión del Cubo y dispara el evento. Por otro lado, las Esferas (observadores) se suscriben a este evento en su método `Start()` mediante el operador `+=`. Al recibir la notificación, actualizan su posición usando `Vector3.MoveTowards` en el método `Update()`.

<img width="718" height="374" alt="ej1 (1)" src="https://github.com/user-attachments/assets/d16741f0-2959-408f-9cc1-0fb22f7641fa" />


## Hito 2: Sustitución por modelos complejos
Se reemplazaron las primitivas 3D por *assets* complejos (Humanoides tipo Footman y Lich). Se convirtieron en **Prefabs** para facilitar su instanciación y se les asignaron componentes `CapsuleCollider` adaptados a sus mallas. Además, se utilizó la herramienta *Render Pipeline Converter* para actualizar sus materiales al estándar del proyecto y solucionar errores de renderizado (texturas fucsias).

<img width="706" height="380" alt="ej2 (1)" src="https://github.com/user-attachments/assets/c857998c-cf9a-44eb-bdd2-06bb8efb87af" />


## Hito 3: Eventos múltiples y cambio de estado
Se trasladó el rol de Notificador al Cubo, creando delegados y eventos independientes para cada grupo de humanoides. Usando `CompareTag()` dentro de `OnCollisionEnter`, el cubo notifica a un grupo o a otro. Los humanoides, al chocar con los escudos físicos, cambian de color accediendo a su malla mediante `GetComponentInChildren<Renderer>().material.color`. Para que las físicas funcionaran correctamente, se les añadió un `Rigidbody` con las rotaciones congeladas (Freeze Rotation).

<img width="716" height="374" alt="ej3 (1)" src="https://github.com/user-attachments/assets/1052ebf8-ff03-4115-8606-c0328315d947" />


## Hito 4: Uso de Triggers espaciales y transformaciones
Se configuró un objeto invisible como área de detección marcando la casilla **Is Trigger** en su Collider. El Cubo utiliza el método `OnTriggerEnter` para detectar cuando entra en esta zona y lanzar un nuevo evento. En respuesta, los humanoides del grupo 1 utilizan la asignación directa de `transform.position` para un efecto de **teletransporte** instantáneo, mientras que el grupo 2 utiliza la función `transform.LookAt()` para orientar su rotación permanentemente hacia un objetivo.

<img width="716" height="374" alt="ej4 (1)" src="https://github.com/user-attachments/assets/c0a3e446-846a-44a7-bb87-e8c546364366" />


## Hito 5: Recolección y registro por consola
Se centralizó la recolección en el script del Cubo. Mediante la detección de colisiones y la comprobación de etiquetas (`CompareTag("Escudo1")`), se actualiza una variable de tipo `int` para la puntuación. Para simular que el objeto es recogido, se llama a la función `Destroy(gameObject)` sobre el escudo impactado, mostrando simultáneamente la puntuación acumulada mediante `Debug.Log` en la consola.

<img width="746" height="360" alt="ej5 (1)" src="https://github.com/user-attachments/assets/f32f7df3-d600-43db-96f1-fa45c037e280" />


## Hito 6: Integración con la Interfaz de Usuario (UI)
Se implementó la librería `TMPro` (`using TMPro;`) para conectar la lógica del juego con la interfaz. Se creó un `Canvas` en la escena con un elemento `TextMeshProUGUI`. A través del Inspector de Unity, se referenció este elemento de texto en el script del cubo, permitiendo actualizar la propiedad `.text` en tiempo real cada vez que la puntuación varía.

<img width="716" height="376" alt="ej6 (1)" src="https://github.com/user-attachments/assets/af1e48db-7cda-488d-a83e-9b1bc2b45a49" />


## Hito 7: Sistema de Recompensas UI
Se añadió lógica condicional matemática en el gestor de puntuaciones para comprobar si se superan múltiplos de 100 puntos. Al alcanzar este umbral, se activa y actualiza un segundo elemento de texto `TextMeshProUGUI` en el Canvas principal para mostrar un mensaje dinámico de recompensa ("¡Recompensa obtenida!").

<img width="716" height="376" alt="ej7" src="https://github.com/user-attachments/assets/d8f44453-cbc6-4569-906f-6855aeac1e5c" />


## Hito 8: Combate, seguimiento constante y Game Over
Se creó un script de seguimiento continuo usando `transform.LookAt()` en el método `Update()` para que los humanoides miren al jugador en cada fotograma. El script del Cubo se modificó para incluir una variable de `vida`. Al colisionar con las etiquetas de los enemigos, la vida se reduce y, mediante una estructura condicional (`if vida < 1`), se actualiza un texto `TextMeshProUGUI` en pantalla cambiando su propiedad `color` a `Color.red` para indicar el Game Over.

<img width="716" height="376" alt="ej8" src="https://github.com/user-attachments/assets/2a1e5da5-0231-4582-870b-20efb147fc6e" />
