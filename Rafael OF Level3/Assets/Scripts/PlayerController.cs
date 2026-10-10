using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rig;
    public float speed = 10;
    public float jumpForce = 10;
    public LayerMask floorLayers;

    public Transform camPivot;
    public float yRotSpeed = 0.1f;
    public float xRotSpeed = 0.1f;
    public float xRotMin = -45;
    public float xRotMax = 45;

    public GameObject bulletPrefab;
    public Transform bulletPoint;
    public float bulletSpeed = 30;

    private Vector2 moveInput;
    private float xRot = 0f;

    private void FixedUpdate()
    {
        Vector3 vX = transform.right * speed * moveInput.x;
        Vector3 vY = transform.up * rig.linearVelocity.y;
        Vector3 vZ = transform.forward * speed * moveInput.y;

        rig.linearVelocity = vX + vY + vZ;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 lookInput = context.ReadValue<Vector2>();
        transform.Rotate(lookInput.x * yRotSpeed * Vector3.up);

        xRot = Mathf.Clamp(xRot - lookInput.y * xRotSpeed, xRotMin, xRotMax);
        camPivot.localRotation = Quaternion.Euler(xRot, 0f, 0f);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.performed && Physics.Raycast(transform.position, Vector3.down, 1.1f, floorLayers))
        {
            rig.linearVelocity = new Vector3(rig.linearVelocity.x, jumpForce, rig.linearVelocity.z);
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            GameObject b = Instantiate(bulletPrefab, bulletPoint.position, bulletPoint.rotation);
            b.GetComponent<Rigidbody>().linearVelocity = bulletPoint.forward * bulletSpeed;
        }
    }
}