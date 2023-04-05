using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Transform _startPoint;
    [SerializeField] public Transform _endPoint;
    [SerializeField] public Transform[] _movemantPoints;
    [SerializeField] private GameObject _enemyPrefub;
    [SerializeField] private TextMeshProUGUI _textForGold;
    [SerializeField] private TextMeshProUGUI _textForEnemies;
    [SerializeField] private TextMeshProUGUI _textForEscapedEnemies;
    private static GameManager _instance;

    public delegate void GoldChanged(int gold);
    public event GoldChanged _notifyGoldChanged;

    public delegate void EnemyEscaped(int enemies);
    public event EnemyEscaped _notifyEnemyEscaped;


    private List<GameObject> _enemies = new List<GameObject>();
    private List<EnemyStates> _enemiesStates = new List<EnemyStates>();
    private List<GameObject> _bullets = new List<GameObject>();
    private int _gold = 0;
    private int _escapedEnemy = 0;
    //private int _diedEnemies = 0;
    

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies(100));
        _notifyGoldChanged += ShowGoldInGUI;
        _notifyEnemyEscaped += ShowEnemyEscapedInGUI;
        AddGold(100);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static GameManager GetInstance()
    {
        return _instance;
    }

    public List<GameObject> GetEnemies()
    {
        return _enemies;
    }

    public List<EnemyStates> GetEnemiesStates()
    {
        return _enemiesStates;
    }

    IEnumerator SpawnEnemies(int numberOfEnemies)
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            GameObject enemyObject = (GameObject)Instantiate(_enemyPrefub, _startPoint.position, Quaternion.identity);
            _enemies.Add(enemyObject);
            _enemiesStates.Add(EnemyStates.Alive);

            //Debug.Log("Enemy: " + enemyObject);

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void AddGold(int gold)
    {
        _gold += gold;
        _notifyGoldChanged?.Invoke(gold);
    }

    private void ShowGoldInGUI(int gold)
    {
        _textForGold.text = "GOLD :" + _gold;
    }

    public void IncreaseEscapedEnemy()
    {
        _escapedEnemy++;
        _notifyEnemyEscaped?.Invoke(_escapedEnemy);
    }

    private void ShowEnemyEscapedInGUI(int enemies)
    {
        _textForEscapedEnemies.text = "Enemies escaped: " + _escapedEnemy;
    }

    public void EnemyDied()
    {
        
    }

    public int GetGold()
    {
        return _gold;
    }
}
