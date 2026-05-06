using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    public void Shoot(Vector3 force) 
    {
        GetComponent<Rigidbody>().AddForce(force);
    }

    void OnCollisionEnter(Collision collision)
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<ParticleSystem>().Play();
    }
    void Start()
    {
        Application.targetFrameRate = 60;
       // Shoot(new Vector3(0, 200, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
