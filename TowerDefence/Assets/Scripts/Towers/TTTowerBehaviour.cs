using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TTTowerBehaviour : BaseTowerBehaviour
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletPoint;

    private TTTowerBehaviour()
    {
         _timeBetweenAtacks = 0.1f;
          _range = 5.0f;
         _time = 0;
    }

    protected override void Atack(int enemyIndex)
    {
        //Debug.Log("Atack");
        GameManager gameManager = GameManager.GetInstance();
        GameObject bulletObject = Instantiate(_bullet, _bulletPoint.transform.position, Quaternion.identity);

        if (bulletObject.TryGetComponent<BulletBehaviour>(out BulletBehaviour bullet))
        {
            bullet.SetEnemy(enemyIndex);
            //GameObject enemyObject = gameManager.GetEnemies()[enemyIndex];

            //EnemyBehaviour enemy = enemyObject.GetComponent<EnemyBehaviour>();
            //enemy.SetSpeed(1f);
        }
    }
}
