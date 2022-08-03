using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateTowerController : MonoBehaviour
{
    [SerializeField] private Button _createTower;
    [SerializeField] private DisplayController _displayController;
    [SerializeField] private GameObject[] _platformTower;
    public List <GameObject> _emptyPlatformTower = new List<GameObject>();

    private void Start()
    {
        _createTower.onClick.AddListener(CheckScoresAndPriceTower);
    }

    private void CheckScoresAndPriceTower()
    {
        if(_displayController._scores >= _displayController._priceTower)
        {
            CreateTowerOnRandomEmptyPlatform();
            _displayController.UpdateScores(_displayController._scores - _displayController._priceTower);
            _displayController.UpdatePriceTower(_displayController._priceTower++);
        }
    }

    private void CreateTowerOnRandomEmptyPlatform()
    {
        _emptyPlatformTower.Clear();
        for (int i = 0; i < _platformTower.Length; i++)
        {
            if (_platformTower[i].GetComponent<PlatformTowerController>()._towerInPlatform == null)
            {
                _emptyPlatformTower.Add(_platformTower[i]);
            }
        }

        if (_emptyPlatformTower.Count > 0)
        {
            int random = Random.Range(0, _emptyPlatformTower.Count);
            _emptyPlatformTower[random].GetComponent<PlatformTowerController>().BuildTower();
        }
    }
}
