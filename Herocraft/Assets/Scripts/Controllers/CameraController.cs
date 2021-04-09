using UnityEngine;


public class CameraController : MonoBehaviour
{

    Transform m_target;
    [SerializeField] Vector3 offset;
    [SerializeField] float zoomSpeed = 4f;
    [SerializeField] float minZoom = 5f;
    [SerializeField] float maxZoom = 15f;
    [SerializeField] float pitch = 2f;
    float currentZoom = 10f;
    float currentRot = 90f;
    float prevMouseX;

    public Transform target { set { m_target = value; } }

    void Update()
    {
        if (m_target != null)
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            if (Input.GetMouseButton(1))
            {
                currentRot += Input.mousePosition.x - prevMouseX;
            }
        }
        prevMouseX = Input.mousePosition.x;
    }

    void LateUpdate()
    {
        if (m_target != null)
        {
            transform.position = m_target.position - offset * currentZoom;
            transform.LookAt(m_target.position + Vector3.up * pitch);
            transform.RotateAround(m_target.position, Vector3.up, currentRot);
        }
    }
}
