using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxSpeed = 5f;
    [SerializeField] private List<Transform> _points;
    private Transform _currentPoint;
    private Vector3 _direction;
    private bool _isMoving = false;
    [SerializeField] private bool _isJumping = false;
    private Rigidbody _rb;
    [SerializeField] float _jumpForce;



    // Start is called before the first frame update
    void Start()
    {
        transform.position = _points[1].position;
        _currentPoint = _points[1];
        _rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_currentPoint != _points[0])
            {
                _currentPoint = _currentPoint == _points[1] ? _points[0] : _points[1];
                _isMoving = true;
            }


        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_currentPoint != _points[2])
            {
                _currentPoint = _currentPoint == _points[1] ? _points[2] : _points[1];
                _isMoving = true;
            }          
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (!_isJumping) 
            {
                float _yBeforeJump = transform.position.y;
                _rb.AddForce(Vector3.up * _jumpForce);
                _isJumping = true;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            
        }

        if (_isMoving)
        {
            MoveToLine(_currentPoint);
            if (transform.position.x == _currentPoint.position.x)
            {
                _isMoving = false;
            }
        }


    }

    private void MoveToLine(Transform _line)
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3 (_line.position.x, transform.position.y, _line.position.z ), ref _direction, 0, _maxSpeed, Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _isJumping = false;
    }

}
