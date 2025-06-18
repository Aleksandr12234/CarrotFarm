using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private new Rigidbody rigidbody;
    [SerializeField] private new Transform camera;
    [SerializeField] private AudioScript audioScript;
    [SerializeField] private UserControl control;
    [SerializeField] private float speed = 10f;


    private float angle = 0;

    private void FixedUpdate()
    {
        Vector3 zero = control.GetMoveDirection();

        Vector3 direction = new Vector3(zero.x, 0, zero.z);
        direction.y = rigidbody.linearVelocity.y;
        rigidbody.linearVelocity = transform.TransformVector(direction * speed);
        if (zero.x != 0 || zero.z != 0) audioScript.Step();

        zero = control.GetRotateDirection();
        float mouseX = zero.x * Time.deltaTime;
        float mouseY = zero.y * Time.deltaTime;
        transform.Rotate(0, mouseX, 0);
        angle -= mouseY;
        angle = Mathf.Clamp(angle, -80, 80);
        camera.localEulerAngles = new Vector3(angle, 0, 0);
    }
}
