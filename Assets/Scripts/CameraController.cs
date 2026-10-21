using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Vector3 Offset;

    void LateUpdate()
    {
        this.transform.position = playerPos.transform.position + Offset;
    }

}
