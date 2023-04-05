using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildManager : MonoBehaviour
{
    [SerializeField] private Button _buyTTTowerButton;
    [SerializeField] private Button _buyTurretTowerButton;
    [SerializeField] private GameObject _TTTowerPrefub;
    [SerializeField] private GameObject _TurretTowerPrefub;
    [SerializeField] private GameObject _buyGUIBlock;
    private static BuildManager _instance;
    private GameObject _unitToBuild;
    private GameObject _blockWhereWeBuilding;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    private void Start()
    {
        _buyTTTowerButton.onClick.AddListener(OnBuyTTTowerButtonHandler);
        _buyTurretTowerButton.onClick.AddListener(OnBuyTurretButtonHandler);
    }

    public static BuildManager GetInstance()
    {
        return _instance;
    }

    private void SetUnitToBuild(GameObject unitToBuild)
    {
        _unitToBuild = unitToBuild;
    }

    private GameObject GetUnitToBuild()
    {
        return _unitToBuild;
    }

    public GameObject GetBuyGUIBlock()
    {
        return _buyGUIBlock;
    }

    public void SetBlockWhereWeBuilding(GameObject block)
    {
        if (_blockWhereWeBuilding != null)
        {
            _blockWhereWeBuilding.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        } else
        {

        }

        _blockWhereWeBuilding = block;
        //gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    public GameObject GetBlockWhereWeBuilding()
    {
        return _blockWhereWeBuilding;
    }

    private void OnBuyTTTowerButtonHandler()
    {
        var gameManager = GameManager.GetInstance();
        int gold = gameManager.GetGold();

        if (gold >= 10)
        {
            Instantiate(_TTTowerPrefub, _blockWhereWeBuilding.transform.position, Quaternion.identity);
            gameManager.AddGold(-10);
            _blockWhereWeBuilding.GetComponent<CubeBehaviour>().SetType(BlockType.AlreadyBuilded);
            SetBlockWhereWeBuilding(null);
        }
    }

    private void OnBuyTurretButtonHandler()
    {
        var gameManager = GameManager.GetInstance();
        int gold = gameManager.GetGold();

        if (gold >= 30)
        {
            Instantiate(_TurretTowerPrefub, _blockWhereWeBuilding.transform.position, Quaternion.identity);
            gameManager.AddGold(-30);
            _blockWhereWeBuilding.GetComponent<CubeBehaviour>().SetType(BlockType.AlreadyBuilded);
            SetBlockWhereWeBuilding(null);
        }
    }
}
