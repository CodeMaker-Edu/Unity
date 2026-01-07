### 3. Interacción del Jugador (JugadorColisiones.cs)

Maneja qué pasa cuando el jugador toca cosas (monedas o enemigos).

```csharp
using UnityEngine;

public class JugadorColisiones : MonoBehaviour
{
    public int vidas = 3;

    void Start()
    {
        // Inicializar la UI al empezar
        GameManager.Instance.ActualizarVidas(vidas);
        GameManager.Instance.ActualizarPuntos(0);
    }

    // Se ejecuta cuando entramos en un Trigger (Monedas)
    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Puntos"))
        {
            GameManager.Instance.ActualizarPuntos(10); // Sumar 10 puntos
            Destroy(otro.gameObject); // Destruir la moneda
        }
    }

    // Se ejecuta cuando chocamos con un colisionador sólido (Enemigos/Obstáculos)
    void OnCollisionEnter2D(Collision2D colision)
    {
        if (colision.gameObject.CompareTag("Enemigo"))
        {
            vidas--;
            GameManager.Instance.ActualizarVidas(vidas);
            
            // Opcional: Empuje hacia atrás al chocar (Feedback)
            Debug.Log("¡Auch! Colisión con un enemigo.");
            
            if (vidas <= 0)
            {
                gameObject.SetActive(false); // Ocultar al jugador en lugar de destruirlo para evitar errores
            }
        }
    }
}
```
