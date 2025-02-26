using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{

    CharacterController characterController;

    public float moveSpeed = 7;

    public float xAxis;
    public float yAxis;

    float xAxisTurnRate = 420;
    float yAxisTurnRate = 420;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float rightInput = Input.GetAxis("Horizontal");

        Vector3 forward = gameObject.transform.forward;
        Vector3 right = gameObject.transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = (forwardInput * forward) + (rightInput * right);
        moveDirection.Normalize();

        if(Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 11;
        }
        else
        {
            moveSpeed = 7;
        }
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
    void LateUpdate()
    {
        float xAxisInput = Input.GetAxis("Mouse Y");
        float yAxisInput = Input.GetAxis("Mouse X");

        xAxis -= xAxisInput * xAxisTurnRate * Time.deltaTime;
        xAxis = Mathf.Clamp(xAxis, -70f, 90f);
        yAxis += yAxisInput * yAxisTurnRate * Time.deltaTime;

        Quaternion newRotate = Quaternion.Euler(xAxis, yAxis, 0f);

        Camera.main.transform.rotation = newRotate;
    }
}
