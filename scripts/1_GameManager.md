### 1. Game Manager (`GameManager.cs`)

Este script controla la puntuación, las vidas y la interfaz. Es el "cerebro" de la partida.

Este script no se asigna al jugador ni a la cámara, sino a un objeto vacío dedicado exclusivamente a gestionar la lógica global del juego para que sea independiente. Si se lo pusieramos al personaje y el personaje muere (y se destruye o desactiva), el contador de puntos y la lógica de "Game Over" dejarían de funcionar. Al tenerlo en su propio objeto vacío, nos aseguramos de que siempre esté activo pase lo que pase en el juego.

```csharp
using UnityEngine;
using UnityEngine.UI; // Necesario para variables de Texto UI clásico
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class GameManager : MonoBehaviour
{
    // Referencias a los objetos de texto en la interfaz (Arrastrar desde el Inspector)
    public Text textoPuntos;
    public Text textoVidas;
    public GameObject panelGameOver; // Panel que contiene el mensaje de fin de juego y botón reinicio

    private int puntos = 0;
    
    // Configuración Singleton muy básica para acceder desde otros scripts fácilmente
    public static GameManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ActualizarPuntos(int puntosSumar)
    {
        puntos += puntosSumar;
        textoPuntos.text = "Puntos: " + puntos;
    }

    public void ActualizarVidas(int vidasRestantes)
    {
        textoVidas.text = "Vidas: " + vidasRestantes;
        
        if (vidasRestantes <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        panelGameOver.SetActive(true); // Mostrar el menú de fin de juego
        Time.timeScale = 0; // Pausar el juego
    }

    // Esta función se enlazará al botón del menú
    public void ReiniciarJuego()
    {
        Time.timeScale = 1; // Reactivar el tiempo
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recargar escena actual
    }
}
