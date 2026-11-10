using UnityEngine;
//Para poder poner el texto de puntuación de la UI en pantalla
using UnityEngine.UI;
//Para poder pasar de escena al final del nivel
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    //Declaración de variables
    //Esto se hace para acceder al ScoreManager desde 
    //otros scripts
    public static ScoreManager instance;
    //Inicializo la variable score a 0, pra empezar 
    //con 0 puntos siempre al empezar el juego
    public int score=0;
    //Para guardar los puntos exactos con los que se quedó en el
    //nivel 1, y si falla en el nivel 2, volver a empezar con esos puntos y no con 0
    private int savedScore=0;
    private int currentSceneIndex=-1;
    //Referencia al texto de la UI que muestra la puntuación
    [SerializeField] private Text scoreText;
    

    //Esto es necesario que vaya delante de Start() para que
    //la variable instance se inicialice antes de que se ejecute
    //cualquier script, para que no haya errores de conteo por
    //fallos de contadores
    private void Awake()
    {
        if (instance==null)
        {
            instance=this;
            //Evito que cambie la puntuación al cambiar de escena
            DontDestroyOnLoad(gameObject);
        }
        else
        {   //Por si existe ya uno, destruyo el duplicado
            Destroy(gameObject);
        }
    }

    //Suscribo el método UpdateUI al evento de cambio de escena
    private void OnEnable()
    {
        //Suscribo el método UpdateUI al evento de cambio de escena
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //Desuscribo el método UpdateUI al evento de cambio de escena
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name=="WinScene")
        {
            PlayerPrefs.SetInt("FinalScore", score);
            PlayerPrefs.Save(); 
        }
        //Si se vuelve al nivel 1, reinicio la puntuación a 0
        else if (scene.buildIndex == 0)
        {
            score=0;
            savedScore=0;
            currentSceneIndex=0;
        }

        //Primera vez que entramos al nivel 2, fijo los puntos
        //acumulados del nivel 1, para que si mueres en el nivel 2,
        //vuelvas a empezar con esos puntos y no con 0
        else if (scene.buildIndex != currentSceneIndex)
        {
            savedScore=score;
            currentSceneIndex=scene.buildIndex;
        }
        //Si mueres en el nivel 2, vuelvo a empezar con la 
        // puntuación que tenías al acabar el nivel 1, y que no
        //cuente los que has conseguido en el 2 sin pasartelo
        else
        {
            score=savedScore;
        }

        //Busco el texto de puntuación en la UI de la
        // nueva escena cargada (que también he añadido en el
        //nivel 2, para que se vea la puntuación en pantalla)
        GameObject textObj=GameObject.Find("ScoreText");
        if (textObj != null)
        {
            //Referencia al texto de la UI que muestra la puntuación
            scoreText=textObj.GetComponent<Text>();
        }
    
        UpdateUI();
    }


    //Función para fijar los puntos, es llamada por el cambio 
    //de escena, para que si se pasa de nivel, se guarde la puntuación
    public void SetCheckPointScore()
    {
        savedScore=score;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateUI();
    }

    //Función para ir añadiendo puntos al recoger objeto
    public void AddScore(int amount)
    {
        score += amount;
        UpdateUI();
    }

    // Update is called once per frame
    //Va cambiando el texto de puntuación en la UI cada vez
    //  que se consigue un punto
    void UpdateUI()
    {
        //Si no tengo el texto guardado, lo busco en escena
        if (scoreText == null)
        {
            GameObject textObj=GameObject.Find("ScoreText");
            if (textObj != null)
            {
                scoreText=textObj.GetComponent<Text>();
            }
        }

        //Si lo tengo guardado, actualizo el texto de puntuación en la UI
        if (scoreText != null)
        {
            scoreText.text="PUNTOS: " + score;
        }       
    }
}
