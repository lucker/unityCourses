using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float maxX = 5.0f;
    [SerializeField] private float maxZ = 5.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Movement(Vector3.forward);
        } else if (Input.GetKey(KeyCode.S))
        {
            Movement(Vector3.back);
        }

        if (Input.GetKey(KeyCode.A))
        {
            Movement(Vector3.left);
        } else if (Input.GetKey(KeyCode.D))
        {
            Movement(Vector3.right);
        } 

    }

    private void Movement(Vector3 direction)
    {
        Vector3 newPosition = transform.position;
        newPosition += direction * _speed * Time.deltaTime;

        if (CheckIfPositionIsPossible(newPosition))
        {
            transform.position = newPosition;
        }
    }

    private bool CheckIfPositionIsPossible(Vector3 newPosition)
    {
        if (Math.Abs(newPosition.x) > maxX)
        {
            return false;
        }

        if (Math.Abs(newPosition.z) > maxZ)
        {
            return false;
        }

        return true;
    }
}
