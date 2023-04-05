using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private float _speed = 15.0f;
    private int _enemyIndex;
    private float _bulletAtack = 2.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void SetEnemy(int enemyIndex)
    {
        _enemyIndex = enemyIndex;
    }

    private void FixedUpdate()
    {
        GameManager gameManager = GameManager.GetInstance();
        GameObject enemy = gameManager.GetEnemies()[_enemyIndex];

        if (enemy == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 movementVector = enemy.transform.position - transform.position;

        if (movementVector.magnitude >= 0.1f)
        {
            transform.position += Time.fixedDeltaTime * _speed * movementVector.normalized;
        }
        else
        {
            if (enemy.TryGetComponent<EnemyBehaviour>(out EnemyBehaviour enemyBehaviour))
            {
                float health = enemyBehaviour.GetHealth();
                int gold = enemyBehaviour.GetEnemyCost();
                enemyBehaviour.SetHealth(health - _bulletAtack);
                //Debug.Log("Health :" + health + " index: " + _enemyIndex);

                if (health <= 0)
                {
                    gameManager.GetEnemiesStates()[_enemyIndex] = EnemyStates.Dead;
                    gameManager.AddGold(gold);
                    Destroy(enemy);
                }
            }

            Destroy(gameObject);
        }
    }
}
