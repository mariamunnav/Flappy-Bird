    //REINICIO DE NIVEL AL CHOCAR CON OBSTACULOS O SUELO    
    using UnityEngine;
    //Para cargary reiniciar escenas
    using UnityEngine.SceneManagement;


    public class PlayerCollisionManager : MonoBehaviour
    {
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        //Si el jugador choca directamenre con un obstáculo 
        // o con el suelo, se reinicia el nivel actual
        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Obstaculo") ||
            collision.gameObject.CompareTag("Suelo"))
            {
                ReloadCurrentLevel();
            }
        }

        //Si el jugador entra en un trigger de un obstáculo,
        //se reinicia el nivel actual (el trigger no se
        //choca físicamente, pero sí se entra en él)
        private void OnTriggerEnter(Collider other)
        {   
            //Se hace solo con obstáculos, el suelo sñi es sólido
            if (other.CompareTag("Obstaculo"))
            {
                ReloadCurrentLevel();
            }
        }

        void ReloadCurrentLevel()
        {
            //Se reinicia todo lo de ese nivel, incluyendo
            // la posición del jugador y los obstáculos
            int currentScene=SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(currentScene);
        }
    }
