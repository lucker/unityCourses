using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    private float _speed = 5.0f;
    private float _health = 30f;
    private int _gold = 10;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        //Debug.Log("Start movemant");
        GameManager gameManager = GameManager.GetInstance();
        Vector3 nullVector = new Vector3(0f, 0f, 0f);
        Vector3 moveToVector = nullVector;
        float minDistance = Mathf.Infinity;
        float distanceFromEnemyToEndPoint = (gameManager._endPoint.position - transform.position).magnitude;

        foreach (Transform movemantPoint in gameManager._movemantPoints)
        {
            Vector3 distance = movemantPoint.position - transform.position;
            Vector3 distanceFromBlockToEndPoint = gameManager._endPoint.position - movemantPoint.position;

            if (minDistance > distance.magnitude
                && distance.magnitude >= 0.5f
                && distanceFromEnemyToEndPoint > distanceFromBlockToEndPoint.magnitude
                )
            {
                minDistance = distance.magnitude;
                moveToVector = distance;
                //movemantPoint.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);

                //Debug.Log("minDistance: " + minDistance);
                //Debug.Log("distance: " + distance);
            }
        }

        //Debug.Log("moveToVector: " + moveToVector);
        Vector3 moveV = new Vector3(moveToVector.normalized.x, 0, moveToVector.normalized.z);
        transform.position += Time.fixedDeltaTime * moveV.normalized * _speed;

        if (moveToVector == nullVector)
        {
            gameManager.IncreaseEscapedEnemy();
            Destroy(gameObject);
        }
    }

    public float GetHealth()
    {
        return _health;
    }

    public void SetHealth(float health)
    {
        _health = health;
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public int GetEnemyCost()
    {
        return _gold;
    }
}

public enum EnemyStates
{
    Alive,
    Dead
}
