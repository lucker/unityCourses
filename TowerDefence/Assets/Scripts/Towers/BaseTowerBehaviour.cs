using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseTowerBehaviour : MonoBehaviour
{
    protected float _timeBetweenAtacks = 0.1f;
    protected float _range = 5.0f;
    protected float _time = 0;
    [SerializeField] private GameObject _towerTop;

    void FixedUpdate()
    {
        _time -= Time.fixedDeltaTime;
        GameManager gameManager = GameManager.GetInstance();
        List<GameObject> enemyList = gameManager.GetEnemies();
        //foreach (GameObject enemy in gameManager.GetEnemies())
        for (int enemyIndex = 0; enemyIndex < enemyList.Count; enemyIndex++)
        {
            if (enemyList[enemyIndex] == null)
            {
                continue;
            }

            Vector3 distance = enemyList[enemyIndex].transform.position - transform.position;

            if (distance.magnitude <= _range && _time <= 0)
            {
                Vector3 lookRotation = Quaternion.LookRotation(distance).eulerAngles;
                _towerTop.transform.rotation = Quaternion.Euler(0f, lookRotation.y, 0f);
                Atack(enemyIndex);
                _time = _timeBetweenAtacks;
                break;
            }
        }

        //Debug.Log(_time);
        if (_time <= 0)
        {
            _time = _timeBetweenAtacks;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }

    protected abstract void Atack(int enemyIndex);
}
