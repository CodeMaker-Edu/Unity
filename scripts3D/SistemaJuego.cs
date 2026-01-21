using UnityEngine;
using UnityEngine.SceneManagement;

public class SistemaJuego : MonoBehaviour
{
    [Header("Estadísticas Iniciales")]
    public int vidas = 3;
    public int puntos = 0;

    private void OnTriggerEnter(Collider other)
    {
        // CASO 1: MONEDA
        if (other.CompareTag("Moneda"))
        {
            puntos = puntos + 1;
            Debug.Log("💰 ¡Moneda! Tienes: " + puntos + " puntos.");
            Destroy(other.gameObject);
        }

        // CASO 2: DAÑO (Pinchos, Fuego, Enemigos)
        else if (other.CompareTag("Daño"))
        {
            vidas = vidas - 1;
            Debug.Log("💀 ¡Auch! Te quedan: " + vidas + " vidas.");
                        
            if (vidas <= 0)
            {
                Debug.Log("❌ GAME OVER ❌");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        // CASO 3: MEDICAMENTO / VIDA EXTRA
        else if (other.CompareTag("Medicamento"))
        {
            vidas = vidas + 1;
            Debug.Log("❤️ ¡Curado! Tienes: " + vidas + " vidas.");
            Destroy(other.gameObject);
        }
        
        // CASO 4: META (Para ganar)
        else if (other.CompareTag("Meta"))
        {
             Debug.Log("🏆 ¡HAS GANADO EL JUEGO! 🏆");
        }
    }
}
