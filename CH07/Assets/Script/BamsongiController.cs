using UnityEngine;

public class BamsongiController : MonoBehaviour
{
    void Shoot(Vector3 dir) 
    {
        GetComponent<Rigidbody>().AddForce(dir);
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
