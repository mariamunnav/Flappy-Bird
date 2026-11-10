using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
    //Definición de variables
    //Defino la velocidad y la distancia a recorrer del bloque
    [SerializeField] private float speed=2f;
    [SerializeField] private float distance=3f;
    private Vector3 startPos;   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Guardo la posición iniciald del bloque
        startPos = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calculo el movimiento de [-distance,distance]
        float offset=Mathf.Sin(Time.time*speed)*distance;
        //Para hacer que se mueva horizonzalmente (eje x) ese movimiento
        transform.position=new Vector3(startPos.x+offset, startPos.y, startPos.z);
    }
}
