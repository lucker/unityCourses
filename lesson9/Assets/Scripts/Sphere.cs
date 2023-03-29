using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    [SerializeField] Rigidbody _rigidbody;
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            _rigidbody.useGravity = true;
        }
    }
}
