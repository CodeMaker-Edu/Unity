using UnityEngine;

public class MovimientoRB : MonoBehaviour
{
    [Header("Ajustes")]
    public float velocidad = 5f;
    public float sensibilidad = 2f;
    public float fuerzaSalto = 5f;

    [Header("Referencias")]
    public Camera camaraJugador;

    private Rigidbody rb;
    private float rotacionX = 0f;
    private bool puedeSaltar;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        rb.freezeRotation = true; 
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // --- 1. ROTACIÓN ---
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidad;
        rotacionX -= mouseY;
        rotacionX = Mathf.Clamp(rotacionX, -90f, 90f); // Tope para no romperse el cuello
        
        if (camaraJugador != null)
        {
            camaraJugador.transform.localRotation = Quaternion.Euler(rotacionX, 0f, 0f);
        }

        float mouseX = Input.GetAxis("Mouse X") * sensibilidad;
        transform.Rotate(Vector3.up * mouseX);


        // --- 2. MOVIMIENTO ---
        float movX = Input.GetAxis("Horizontal");
        float movZ = Input.GetAxis("Vertical");
        
        Vector3 movimiento = transform.right * movX + transform.forward * movZ;
        
        Vector3 velocidadFinal = movimiento * velocidad;
        velocidadFinal.y = rb.velocity.y; 
        
        rb.velocity = velocidadFinal;


        // --- 3. SALTO ---
        if (Input.GetKeyDown(KeyCode.Space) && puedeSaltar)
        {
            rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z); 
            rb.AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
            puedeSaltar = false;
        }
    }

    void OnCollisionStay(Collision collision)
    {
        puedeSaltar = true;
    }
    
    void OnCollisionExit(Collision collision)
    {
        puedeSaltar = false;
    }
}
