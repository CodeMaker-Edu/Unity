### 6. Cámara (CamaraSeguimiento.cs)

Sigue al jugador suavemente.

```csharp
using UnityEngine;

public class CamaraSeguimiento : MonoBehaviour
{
    public Transform objetivo; // El jugador

    // LateUpdate se ejecuta después de que el jugador se haya movido en Update
    // Esto evita que la cámara vibre.
    void LateUpdate()
    {
        if (objetivo != null)
        {
            // Mantenemos la Z de la cámara en -10 para seguir viendo la escena 2D
            transform.position = new Vector3(objetivo.position.x, objetivo.position.y, -10f);
        }
    }
}
```
