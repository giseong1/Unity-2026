using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;          

    public float smoothing = 5.0f;    // 카메라가 쫓아가는 속도
    public float fixedY = 0f;         

    public float minX = 0f;           // 카메라가 갈 수 있는 최소 왼쪽 한계점
    public float maxX = 31f;          // 카메라가 갈 수 있는 최대 오른쪽 한계점

    void LateUpdate()
    {
        if (target != null)
        {
            
            float targetX = target.position.x;

            
            targetX = Mathf.Clamp(targetX, minX, maxX);

            
            Vector3 targetPosition = new Vector3(targetX, fixedY, transform.position.z);

            
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing * Time.deltaTime);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
