using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController _controller;
    public float _speed;
    public float gravity;
    public float _groundDistance;
    public float _jumpHeight;
    public Transform _groundCheck;
    public LayerMask _groundMask;

    private Vector3 _velocity;
    public Inventory _inventory;
    public bool _isGrounded;

    private void Start()
    {
        gravity = -200f;
        _speed = 100f;
        _groundDistance = 0.4f;
        _jumpHeight = 15f;
        _inventory = GetComponent<Inventory>();
    }

    private void Update()
    {
        if (_inventory._currentHunger <= 20)
        {
            _speed = 20f;
        }
        else if (_inventory._currentHunger <= 50)
        {
            _speed = 60f;
        }
        else
        {
            _speed = 100f;
        }

        _isGrounded = Physics.CheckSphere(_groundCheck.position, _groundDistance, _groundMask);

        if (_isGrounded && _velocity.y < 0)
        {
            _velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        _controller.Move(move * _speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            _velocity.y = Mathf.Sqrt(_jumpHeight * -2f * gravity);
        }

        _velocity.y += gravity * Time.deltaTime;

        _controller.Move(_velocity * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<AIControl>() != null || other.gameObject.GetComponent<WaypointFollow>() != null)
        {
            SceneManager.LoadScene(0);
        }
    }
}
