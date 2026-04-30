using System;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))] //que composant a besoin de rigid body
public class PlayerController : MonoBehaviour
{
    [SerializeField, Range(1f, 20f)]
    private float speed = 5f;
    
    private Rigidbody2D _rb;
    private Vector2 _movement;
    
    private void Awake()
    {
        Debug.Log("Awake");
        _rb = GetComponent<Rigidbody2D>();
        Debug.Log(_rb);
    }

    private void OnMove(InputValue value)
    {
        _movement = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        _rb.linearVelocity = _movement * speed;
    }
    /*
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update");
    }
    */
}
