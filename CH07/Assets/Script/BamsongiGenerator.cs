using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    public float throwForce = 10f;
    private float startY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);

            float power = Input.mousePosition.y - startY;

            Vector3 dir = (transform.forward + transform.up).normalized;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            bamsongi.GetComponent<BamsongiController>().Shoot(dir * power * throwForce);
            
        }
    }
}
