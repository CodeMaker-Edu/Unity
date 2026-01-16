using UnityEngine;

public class JugadorCamara : MonoBehaviour
{
    [Header("Configuración")]
    public float velocidad = 6f;
    public float fuerzaSalto = 8f;
    public float sensibilidadMouse = 100f;
    public float gravedad = -9.8f;
    
    [Header("Referencias")]
    public Transform camaraTransform; // ¡Arrastra aquí tu Main Camera en el inspector!
    
    private CharacterController controller;
    private Animator animator;
    private Vector3 velocidadY;
    private float rotacionX = 0f; // Para mirar arriba/abajo

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        
        Cursor.lockState = CursorLockMode.Locked; // Esto oculta el ratón y lo bloquea en el centro de la pantalla
    }

    void Update()
    {
        // --- 1. ROTACIÓN (RATÓN) ---
        // Ratón izquierda/derecha -> Gira TODO el cuerpo del personaje
        float mouseX = Input.GetAxis("Mouse X") * sensibilidadMouse * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);

        // Ratón arriba/abajo -> Gira SOLO la cámara (para no inclinar el cuerpo)
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Tope para no romperse el cuello (90 grados)
        
        if(camaraTransform != null)
        {
            camaraTransform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        }

        // --- 2. MOVIMIENTO (WASD) ---
        // Ahora nos movemos respecto a hacia donde miramos
        float x = Input.GetAxis("Horizontal"); // A y D (pasos laterales)
        float z = Input.GetAxis("Vertical");   // W y S (avanzar/retroceder)

        Vector3 mover = transform.right * x + transform.forward * z;
        controller.Move(mover * velocidad * Time.deltaTime);

        // --- 3. ANIMACIÓN ---
        // Si el vector de movimiento no es cero, activamos animación
        if (animator != null)
        {
            // Usamos magnitud al cuadrado porque es más rápido para el procesador
            bool seMueve = mover.sqrMagnitude > 0.01f; 
            animator.SetBool("Andando", seMueve);
        }

        // --- 4. SALTO Y GRAVEDAD ---
        if (controller.isGrounded)
        {
            if (velocidadY.y < 0) velocidadY.y = -2f;

            if (Input.GetButtonDown("Jump"))
            {
                velocidadY.y = Mathf.Sqrt(fuerzaSalto * -2f * gravedad);
            }
        }

        velocidadY.y += gravedad * Time.deltaTime;
        controller.Move(velocidadY * Time.deltaTime);
    }
}
