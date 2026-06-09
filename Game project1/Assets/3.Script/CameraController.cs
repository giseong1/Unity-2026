using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // 카메라가 쫓아갈 플레이어

    public float fixedY = 0f; // 카메라의 고정된 높이
    public float minX = 0f;   // 왼쪽 이동 한계점
    public float maxX = 31f;  // 오른쪽 이동 한계점

    void Update()
    {
        float targetX = target.position.x;

        if (targetX < minX)
        {
            targetX = minX;
        }
        else if (targetX > maxX)
        {
            targetX = maxX;
        }

        transform.position = new Vector3(targetX, fixedY, transform.position.z);
    }
}