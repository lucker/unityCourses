using UnityEngine;
using System.Collections;

public class TurretTowerBehaviour : BaseTowerBehaviour
{

    [SerializeField] private GameObject _bullet;
    [SerializeField] private GameObject _bulletPoint_1;
    [SerializeField] private GameObject _bulletPoint_2;

    protected override void Atack(int enemyIndex)
    {
        //Debug.Log("Atack");
        GameManager gameManager = GameManager.GetInstance();
        GameObject bulletObject1 = Instantiate(_bullet, _bulletPoint_1.transform.position, Quaternion.identity);
        GameObject bulletObject2 = Instantiate(_bullet, _bulletPoint_2.transform.position, Quaternion.identity);

        if (bulletObject1.TryGetComponent<BulletBehaviour>(out BulletBehaviour bullet))
        {
            bullet.SetEnemy(enemyIndex);
            //GameObject enemyObject = gameManager.GetEnemies()[enemyIndex];

            //EnemyBehaviour enemy = enemyObject.GetComponent<EnemyBehaviour>();
            //enemy.SetSpeed(1f);
        }


        if (bulletObject2.TryGetComponent<BulletBehaviour>(out BulletBehaviour bullet2))
        {
            bullet2.SetEnemy(enemyIndex);
            //GameObject enemyObject = gameManager.GetEnemies()[enemyIndex];

            //EnemyBehaviour enemy = enemyObject.GetComponent<EnemyBehaviour>();
            //enemy.SetSpeed(1f);
        }
    }
}

