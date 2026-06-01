using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed;
    private CharacterController controller; // Referencia al componente de física

    void Start()
    {
        // Obtener el componente Character Controller al empezar
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. Obtener los inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 2. Calcular la dirección relativa a donde mira el personaje
        // Usamos transform.right y transform.forward para que "W" siempre sea hacia adelante
        Vector3 move = transform.right * x + transform.forward * z;

        // 3. APLICAR EL MOVIMIENTO USANDO EL CONTROLLER
        // Esta función SI detecta paredes y suelos.
        controller.Move(move * speed * Time.deltaTime);

        // Lógica para liberar el ratón
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}