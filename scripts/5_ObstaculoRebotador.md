### 5. Obstáculo Rebotador (ObstaculoRebote.cs)

Se mueve solo y rebota en los límites definidos.

```csharp
using UnityEngine;

public class ObstaculoRebote : MonoBehaviour
{
    public float velocidad = 4f;
    
    // Límites de la pantalla (ajustar en el Inspector según tu escena)
    public float limiteX = 8f;
    public float limiteY = 4.5f;

    private Vector2 direccion;

    void Start()
    {
        // Elegir una dirección aleatoria al inicio
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        direccion = new Vector2(x, y).normalized;
    }

    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // Comprobar rebote horizontal
        if (transform.position.x > limiteX || transform.position.x < -limiteX)
        {
            direccion.x = -direccion.x; // Invertir dirección X
        }

        // Comprobar rebote vertical
        if (transform.position.y > limiteY || transform.position.y < -limiteY)
        {
            direccion.y = -direccion.y; // Invertir dirección Y
        }
    }
}
```
