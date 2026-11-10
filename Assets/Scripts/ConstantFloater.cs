using UnityEngine;

public class Constant : MonoBehaviour
{
    //Declaración de variables (vienen en el void Update)
    [SerializeField]
    float amplitude;
    [SerializeField]
    float final_frequency;
    Vector3 startPos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.localPosition;
        //Aquí podría usar Position también
        
    }

    // Update is called once per frame
    void Update()
    {
        float newY = startPos.y + Mathf.Sin(Time.time * final_frequency) * amplitude;
        transform.localPosition = new Vector3(startPos.x, newY, startPos.z);
        
    }
}

