using UnityEngine;
//Para poder poner manejar escenas 
using UnityEngine.SceneManagement;

public class FinishCollider : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //Si detecta que el jugador ha chocado con
        //el trigger de final de nivel, carga la siguiente escena
        if (other.CompareTag("Player"))
        {
            //Guarda la puntuación actual en el ScoreManager, para 
            // que si se pasa de nivel, se guarde la puntuación
            //  y no se reinicie a 0
            if (ScoreManager.instance != null)
            {
                ScoreManager.instance.SetCheckPointScore();
            }
            //Carga la siguiente escena, que es la del siguiente nivel
            //Esto está configurado en Build Profiles, donde se puede 
            // poner el orden de las escenas
            int nextSceneIndex=SceneManager.GetActiveScene().buildIndex+1;
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
