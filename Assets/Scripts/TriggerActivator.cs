using UnityEngine;

public class TriggerActivator : MonoBehaviour
{
    //Nueva línea en la que declaramos tipo private 
    [SerializeField] private Dropper target;
   
   /* Quito el método público, ya que solo se 
   //a usar con este script.
   public class Dropper : MonoBehaviour
    {
        Rigidbody myRigidBody;
        public void Activate()
        {
            myRigidBody.useGravity = true;
        }
    }
    */

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (target) target.Activate();
            //(target) es para incializar el Dropper del
            //objeto DroppingCube
        }
    }
}
