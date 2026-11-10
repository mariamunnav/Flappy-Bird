using UnityEngine;
//Para pasar nivel 2 y mostrar escena que pone
//  el texto final y la puntuación en pantalla
using UnityEngine.SceneManagement;

public class FinishGoalCollider : MonoBehaviour
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
        if (other.CompareTag("Player"))
        {
           SceneManager.LoadScene("WinScene");
        }
    }
}
