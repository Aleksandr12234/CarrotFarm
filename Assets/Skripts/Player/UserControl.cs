using UnityEngine;

public class UserControl : MonoBehaviour
{
    private bool isMobile;
    [SerializeField] private float sensitivityMouseX;
    [SerializeField] private float sensitivityMouseY;

    void Start()
    {
        #if UNITY_ANDROID
            isMobile = true;
        #else
            isMobile = false;
        #endif
        
        if (!isMobile) Cursor.lockState = CursorLockMode.Locked;
    }

    public Vector3 GetMoveDirection()
    {
        Vector3 output = new Vector3();

        if (!isMobile)
        {
            output.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }

        return output;
    }

    public Vector3 GetRotateDirection()
    {
        Vector3 output = new Vector3();

        if (!isMobile)
        {
            output.Set(Input.GetAxis("Mouse X") * sensitivityMouseX, Input.GetAxis("Mouse Y") * sensitivityMouseY, 0);
        }

        return output;
    }

    public bool GetAktionButton()
    {
        bool output = false;

        if (!isMobile) output = Input.GetMouseButtonDown(1);

        return output;
    }
}
