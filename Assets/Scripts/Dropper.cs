using UnityEngine;

public class Dropper : MonoBehaviour
{
    Rigidbody myRigidBody;
    MeshRenderer myMeshRenderer;
    float tiempo;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       //tiempo=Time.time;
        myRigidBody = GetComponent<Rigidbody>();
        myMeshRenderer = GetComponent<MeshRenderer>();
    }

    //Nueva función Activate() que activa la gravedad 
    //del objeto Dropper
    public void Activate()
    {
        myRigidBody.useGravity = true;
        myMeshRenderer.enabled = true;        
    }
}

