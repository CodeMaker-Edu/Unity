# Proyecto 2D: Juego Básico en Unity

Este proyecto sirve como introducción al scripting en C# dentro de Unity. Crearemos un juego de vista cenital (top-down) donde el jugador debe esquivar enemigos, evitar obstáculos y recolectar puntos.

## 🛠️ Configuración Previa en Unity (Importante)

Para que los scripts funcionen, debes configurar la escena así:

1.  **Físicas 2D:**
    * El **Jugador** debe tener un componente `Rigidbody 2D` con `Gravity Scale = 0` (para que no caiga).
    * El **Jugador** debe tener un `Box Collider 2D`.
    * Los **Enemigos** y **Obstáculos** deben tener `Box Collider 2D` (y `Rigidbody 2D` si queremos que empujen).
    * Las **Monedas/Puntos** deben tener `Box Collider 2D` con la casilla **Is Trigger** marcada (para atravesarlas).

2.  **Tags (Etiquetas):**
    * Crea y asigna el Tag **"Enemigo"** a los enemigos y obstáculos.
    * Crea y asigna el Tag **"Puntos"** a los objetos recolectables.
    * Asigna el Tag **"Player"** a tu personaje.

3.  **UI (Interfaz):**
    * Crea un Canvas (`GameObject > UI > Canvas`).
    * Añade dos textos (`UI > Legacy > Text` o `TextMeshPro`): Uno para "Vidas" y otro para "Puntos".
    * Añade un Panel para "Game Over" con un Botón de reiniciar (oculto al principio).

## 🎮 Pasos Finales para la Interfaz
Crea un Empty GameObject en la escena y llámalo GameManager.

Arrastra el script GameManager.cs a ese objeto.

Arrastra tus objetos de Texto (Vidas y Puntos) a las casillas correspondientes del script GameManager.

Arrastra tu Panel de Game Over a la variable panelGameOver.

En el botón de tu Panel de Game Over, busca el evento OnClick(), dale al +, arrastra el objeto GameManager y selecciona la función GameManager -> ReiniciarJuego.
