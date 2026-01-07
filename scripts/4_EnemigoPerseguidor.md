### 4. Enemigo Perseguidor (EnemigoPerseguidor.cs)

Hace que el enemigo siga al jugador.

```csharp
using UnityEngine;

public class EnemigoPerseguidor : MonoBehaviour
{
    public Transform objetivo; // Arrastrar al Jugador aquí en el inspector
    public float velocidad = 3f;

    void Update()
    {
        if (objetivo != null)
        {
            // Mueve el objeto actual hacia la posición del objetivo paso a paso
            transform.position = Vector2.MoveTowards(transform.position, objetivo.position, velocidad * Time.deltaTime);
        }
    }
}
```
