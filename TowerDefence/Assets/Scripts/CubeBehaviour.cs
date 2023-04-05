using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public enum BlockType
{
    cantBuild,
    canBuild,
    AlreadyBuilded
}

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] private BlockType _type;
    private GameManager _gameManager;
    private BuildManager _buildManager;

    private void Start()
    {
        _gameManager = GameManager.GetInstance();
        _buildManager = BuildManager.GetInstance();
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_type == BlockType.cantBuild || _type == BlockType.AlreadyBuilded)
        {
            _buildManager.GetBuyGUIBlock().SetActive(false);
            _buildManager.SetBlockWhereWeBuilding(null);
        }
        else
        {
            _buildManager.GetBuyGUIBlock().SetActive(true);
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            _buildManager.SetBlockWhereWeBuilding(gameObject);
        }


        //Instantiate(BuildManager.GetInstance()._prefub, transform.position, Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        if (_type == BlockType.cantBuild || _type == BlockType.AlreadyBuilded)
        {
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }


        gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
    }

    private void OnMouseExit()
    {
        if (_type == BlockType.cantBuild || _type == BlockType.AlreadyBuilded)
        {
            return;
        }

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (_buildManager.GetBlockWhereWeBuilding() != gameObject)
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.white);
        }
    }

    public void SetType(BlockType type)
    {
        _type = type;
    }
}