using UnityEngine;
//Importate para poder manejar con controles el objeto jugador
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    //Definición de variables
    //Fuerza de salto del jugador (private para no poder 
    // modificarla desde el inspector de Unity), aunque con 
    // SerializeField se puede modificar desde el
    // inspector de Unity
    [SerializeField] private float ThrustForce=5f;
    
    [SerializeField] [Range(0f,10f)] private float speed=3f;

     //Rigidbody se encarga de las físicas del objeto
    //private no se puede modificar desde el inspector de Unity
    private Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Meto el Rigidbody del objeto (jugador) dentro de la caja
        //Así puedo aplicarle el salto al jugador
        rb = GetComponent<Rigidbody>();   
    }

    void Update()
    {
        //Muevo el jugador hacia la derecha a velocidad constante
        rb.linearVelocity=new Vector3(speed,rb.linearVelocity.y,0f);
    }

    //Si el jugador pulsa el espacio (OnJump) salta
    public void OnJump(InputValue value)
    {
        if(value.isPressed)
        {
            Jump();
        }
    }

    //Si el jugador hace click izquierdo (OnAttack) salta
    public void OnAttack(InputValue value)
    {
        if (value.isPressed)
        {
            Jump();
        }
    }

    //Defino la función Jump() que aplica fuerza hacia arriba
    //al jugador para que salte 
    private void Jump()
    {
        //Muestro mensaje en consola de Unity
        Debug.Log("Jumping!");
        //Reinicio la velocidad vertical en Y (0f) justo antes de saltar
        //Esto sirve para que no siga cayendo en picado y salte 
        //hacia arriba por el eje y.
        rb.linearVelocity =new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        //Aplico impulso (AddForce) que me dice la variable
        // ThrustForce hacia arriba al jugador (ForceMode aplica
        // la fuerza en un solo frame, de golpe)
        rb.AddForce(Vector3.up * ThrustForce, ForceMode.Impulse);
    }
}
