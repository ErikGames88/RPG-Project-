using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    private Vector3 targetPosition;
    [SerializeField] private float cameraSpeed;




    void Update()
    {
        targetPosition = new Vector3(_target.transform.position.x, _target.transform.position.y, 
        this.transform.position.z);
    }

    void LateUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, 
        Time.deltaTime * cameraSpeed);
    }
}
