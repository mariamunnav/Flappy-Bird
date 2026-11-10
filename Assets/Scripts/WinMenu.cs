using UnityEngine;
//Para mostrar el menú de victoria al final del nivel
using UnityEngine.UI;


public class WinMenu : MonoBehaviour
{
    [SerializeField] private Text victoryText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        int finalScore=0;
        if (ScoreManager.instance!=null)
        {
            finalScore=ScoreManager.instance.score;
        }

        if (victoryText != null)
        {
            victoryText.text="¡ENHORABUENA!\nHAS COMPLETADO EL JUEGO\n\nPuntuación Final: " + finalScore;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
