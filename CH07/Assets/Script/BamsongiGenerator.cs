using UnityEngine;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bamsongi = Instantiate(bamsongiPrefab);
            bamsongi.GetComponent<BamsongiController>().Shoot(new Vector3(0, 200, 2000))
        }
    }
}
