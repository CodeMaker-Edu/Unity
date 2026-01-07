### 2. Movimiento del Jugador (MovimientoJugador.cs)

Script que mueve al personaje usando las flechas o WASD.

Este script deberá de asociarse al personaje que controla el jugador (y este deberá tener Rigidbody).

```csharp
using UnityEngine;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5f;
    private Rigidbody2D rb;
    private Vector2 entradaMovimiento; // Aquí guardamos el Vector Input

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // 1. UPDATE: El "Cerebro" (Detectar qué quiere hacer el usuario)
    void Update()
    {
        // A. OBTENER EJES (-1 a 1)
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        // B. CREAR EL VECTOR (Concepto matemático)
        entradaMovimiento = new Vector2(inputX, inputY);

        // C. NORMALIZAR (Pitágoras)
        // Evita que correr en diagonal sea más rápido que en línea recta.
        if (entradaMovimiento.magnitude > 1)
        {
            entradaMovimiento.Normalize();
        }
    }

    // 2. FIXED UPDATE: El "Músculo" (Aplicar movimiento físico)
    // Se ejecuta 50 veces por segundo de forma fija.
    void FixedUpdate()
    {
        // D. CALCULAR DESPLAZAMIENTO (Velocidad = Espacio / Tiempo)
        // Vector dirección * velocidad * tiempo fijo
        Vector2 desplazamiento = entradaMovimiento * velocidad * Time.fixedDeltaTime;

        // E. MOVER POSICIÓN
        // MovePosition intenta ir al destino, pero se detiene si choca.
        rb.MovePosition(rb.position + desplazamiento);
    }
}
```
