using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTowerController : MonoBehaviour
{
    [SerializeField] private GameObject _towerPrefabs;
    public GameObject _towerInPlatform;

    public void AddTower(GameObject tower)
    {
        _towerInPlatform = tower;
    }

    public void RemoveTower()
    {
        _towerInPlatform = null;
    }

    public void BuildTower()
    {
        GameObject tower = Instantiate(_towerPrefabs, transform.TransformPoint(0, 0.52f, 0), Quaternion.identity);
        AddTower(tower);
    }
}
