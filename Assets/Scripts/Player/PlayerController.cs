using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Input Fileds
    private PlayerInputsAsset playerActionAsssets;
    private InputAction move;

    //Movement Fields
    private Rigidbody rb;
    [SerializeField] float movementForce;
    [SerializeField] float jumpForce;
    [SerializeField] float maxSpeed;
    [SerializeField] float gravityMultiplier;
    [SerializeField] float turnSmoothVelocity;
    [SerializeField] float turnSmoothTime = 0.1f;

    public ParticleSystem particles;

    private Vector3 forceDirection = Vector3.zero;

    public LayerMask Ground;

    [SerializeField] Camera playerCamera;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerActionAsssets = new PlayerInputsAsset();
        Cursor.lockState = CursorLockMode.Confined;
    }
   
    private void OnEnable()
    {
        playerActionAsssets.Player.Jump.started += DoJump;
        move = playerActionAsssets.Player.Move;
        playerActionAsssets.Player.Enable();
    }
    private void OnDisable()
    {
        playerActionAsssets.Player.Jump.started -= DoJump;
        playerActionAsssets.Player.Disable();        
    }

    private void DoJump(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            forceDirection += Vector3.up * jumpForce;
        }
    }

    private bool IsGrounded()
    {
        Ray ray = new Ray(this.transform.position + -Vector3.up, Vector3.down);
        if (Physics.Raycast(ray, out RaycastHit hit, 1.2f, Ground))
            return true;
        else
            return false;
    }

    private void FixedUpdate()
    {
        forceDirection += move.ReadValue<Vector2>().x * GetCameraRight(playerCamera) * movementForce;
        forceDirection += move.ReadValue<Vector2>().y * GetCameraForward(playerCamera) * movementForce;

        rb.AddForce(forceDirection, ForceMode.Impulse);
        forceDirection = Vector3.zero;

        if (rb.velocity.y < 0f)
            rb.velocity -= Vector3.down * Physics.gravity.y * Time.fixedDeltaTime * gravityMultiplier;

        Vector3 horizontalVelocity = rb.velocity;
        horizontalVelocity.y = 0;
        if (horizontalVelocity.sqrMagnitude > maxSpeed * maxSpeed)
            rb.velocity = horizontalVelocity.normalized * maxSpeed + Vector3.up * rb.velocity.y;

        LookAt();
    }

    private void LookAt()
    {
        Vector3 direction = rb.velocity;
        direction.y = 0f;

        if (move.ReadValue<Vector2>().sqrMagnitude > 0.1f && direction.sqrMagnitude > 0.1f)
        {
            float targetAngle = MathF.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        else
            rb.angularVelocity = Vector3.zero;
    }

    private Vector3 GetCameraForward(Camera playerCamera)
    {
        Vector3 forward = playerCamera.transform.forward;
        forward.y = 0;
        return forward.normalized;
    }

    private Vector3 GetCameraRight(Camera playerCamera)
    {
        Vector3 right = playerCamera.transform.right;
        right.y = 0;
        return right.normalized;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sun"))
        {
            particles.Play();
        }
    }
}
