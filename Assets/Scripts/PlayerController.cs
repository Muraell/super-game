using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float g = 9.8f;
    public float jumpForce;
    public float speed;

    public Animator animator;

    private Vector3 _moveVector;
    private float _fallVelosity = 0;
    private CharacterController _characterController;
    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    private void Update()
    {
        _moveVector = Vector3.zero;
        var runDirection = 0;

        if (Input.GetKey(KeyCode.W))
        {
            _moveVector += transform.forward;
            runDirection = 1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            _moveVector -= transform.right;
            runDirection = 4;
        }

        if (Input.GetKey(KeyCode.S))
        {
            _moveVector -= transform.forward;
            runDirection = 2;
        }

        if (Input.GetKey(KeyCode.D))
        {
            _moveVector += transform.right;
            runDirection = 3;
        }
        animator.SetInteger("run direction", runDirection);

        if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        {
            _fallVelosity = -jumpForce;
        }

    }
    void FixedUpdate()
    {
        _characterController.Move(_moveVector * speed * Time.deltaTime);    

        _fallVelosity += g * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelosity * Time.deltaTime);

        if (_characterController.isGrounded)
        {
            _fallVelosity = 0;
        }
    }
}
