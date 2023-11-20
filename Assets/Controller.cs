using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public float moveSpeed = 1;
    public float lookSpeed = 1f;
    public float jumpPower = 15f;

    private Rigidbody rigidbody;

    private bool isJumping = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float _moveSpeed = moveSpeed;

        if(Input.GetKey(KeyCode.LeftShift)) {
            _moveSpeed += 2;
        }

        if(Input.GetKeyDown("space") && !isJumping) {
            isJumping = true;
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJumping = false;
        }

        Vector3 velocity = transform.right * Input.GetAxisRaw("Horizontal");
        velocity += transform.forward * Input.GetAxisRaw("Vertical");

        rigidbody.velocity = Vector3.ClampMagnitude(velocity, 1) * _moveSpeed;

        transform.Rotate(transform.up, Input.GetAxisRaw("Mouse X") * Mathf.Rad2Deg * Time.deltaTime * lookSpeed);

        Camera.main.transform.Rotate(Vector3.right, -Input.GetAxisRaw("Mouse Y") * Mathf.Rad2Deg * Time.deltaTime * lookSpeed);

        float angle = Camera.main.transform.localEulerAngles.x;

        if(angle > 180)
            angle -= 360;
        if(angle < -180)
            angle += 360;
        
        angle = Mathf.Clamp(angle, -60f, 60f);

        Camera.main.transform.localEulerAngles = new Vector3(angle, 0, 0);
    }
}
