using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{
    //Object Which is used as orbit origin 
    public Transform orbitOrigin;
    //Camera which is going to be faced towards object;
    public Transform OCamera;
    public float multiplier = 1;
    public float MaxScrollDelta = 20;
    public float MinScrollDelta = 1;
    [SerializeField] float scrollDelta;
    [SerializeField] bool LockMouse;

    float h, v;
    private void FixedUpdate()
    {

        if (Input.mouseScrollDelta.y > 0)
        {
            scrollDelta++;
            OCamera.position += OCamera.forward;
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            scrollDelta--;
            OCamera.position -= OCamera.forward;
        }


        #region KeepDistanceToOrbitOrigin
        if (scrollDelta < MinScrollDelta)
        {
            scrollDelta++;
            OCamera.position += OCamera.forward;
        }
        else if (scrollDelta > MaxScrollDelta)
        {
            scrollDelta--;
            OCamera.position -= OCamera.forward;
        }
        #endregion

        OCamera.transform.LookAt(orbitOrigin);

        h += Input.GetAxis("Mouse X");
        v += Input.GetAxis("Mouse Y");
        transform.rotation = Quaternion.Euler(v * multiplier * Time.deltaTime, h * multiplier * Time.deltaTime, 0);

    }
    
    private void Start()
    {
        if (LockMouse)  Cursor.lockState = CursorLockMode.Locked;
    
    }
}
