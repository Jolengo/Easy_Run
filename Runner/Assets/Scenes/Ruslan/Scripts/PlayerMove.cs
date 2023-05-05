using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public Rigidbody PlayerRigidBody;

    public float WalkSpeed = 6f;
    public float RunSpeed = 10f;
    public float JumpForce = 10f;

    private bool _grounded;

    /*
    public float Gravity = -9.81f;
    public float JumpHeight = 3f;
    public float MaxBoost = -2f;
    public float GroundDistance = 0.4f;

    public Transform GroundCheck;
    public LayerMask GroundMask;

    private Vector3 _velocity;
    public bool IsGrounded;
    private float _height;

    private void Start()
    {
        _height = Controller.height;
    }
    */

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && _grounded)
        {
            PlayerRigidBody.AddForce(0f, JumpForce, 0f, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        //IsGrounded = Physics.CheckSphere(GroundCheck.position, GroundDistance, GroundMask);

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        Vector3 speedVectorRelativeToPlayer;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedVectorRelativeToPlayer = move * RunSpeed;
            PlayerRigidBody.velocity = new Vector3(speedVectorRelativeToPlayer.x, PlayerRigidBody.velocity.y, speedVectorRelativeToPlayer.z);
        }
        else
        {
            speedVectorRelativeToPlayer = move * WalkSpeed;
            PlayerRigidBody.velocity = new Vector3(speedVectorRelativeToPlayer.x, PlayerRigidBody.velocity.y, speedVectorRelativeToPlayer.z);
        } 
    }

    private void OnCollisionStay(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;

        float dot = Vector3.Dot(normal, Vector3.up);
        if (dot > 0.5f)
            _grounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _grounded = false;
    }
}
