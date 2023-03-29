using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] GameObject _textObject;
    [SerializeField] Transform _startPoint;

    private float _radius = 10.0f;
    private bool StartTimer = false;
    float time = 5;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ON COLIISION");
        gameObject.GetComponent<Renderer>().material.color = Color.red;
        StartTimer = true;
        _textObject.SetActive(true);
    }

    private void FixedUpdate()
    {
        if (StartTimer && time > 0)
        {
            time -= Time.fixedDeltaTime;
            if (time < 0)
            {
                time = 0;
                _textObject.SetActive(false);
                Explosition();
            }

            _text.text = time.ToString("0.00");
        }
    }

    private void Explosition()
    {
        var colliders = Physics.SphereCastAll(_startPoint.position, _radius, _startPoint.up);

        foreach (var collider in colliders)
        {
            if (collider.collider.TryGetComponent<Rigidbody>(out Rigidbody _body))
            {
                _body.AddExplosionForce(600.0f, _startPoint.position, _radius);
            }
        }
    }
}
