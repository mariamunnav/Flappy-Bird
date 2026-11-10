using UnityEngine;

public class GoldPicker : MonoBehaviour
{
    //Asigno cuantos puntos da este objeto al recogerlo,
    //por defecto 1 punto, pero se puede cambiar desde
    //el inspector de Unity
    [SerializeField] private int pointValue=1;
    //Como player y goldpicker tienen colliders, necesito asegurarme
    //de que el objeto goldpicker solo se pueda recoger una vez
    private bool isCollected=false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Si el jugador toca el objeto con ScoreManager, suma 
    //puntos y destruye el objeto
     private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected=true;
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.AddScore(pointValue);
            }
            Destroy(gameObject);
        }  
    }

}
