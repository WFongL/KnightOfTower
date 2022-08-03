using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerController : MonoBehaviour
{
    private int _levelTower = 1;
    [SerializeField] TMP_Text _levelText;
    [SerializeField] GameObject _topTower;
    [SerializeField] private GameObject _knightPrefab;
    Plane plane = new Plane(Vector3.down, 1);
    RaycastHit _startingPosition;

    private void Start()
    {
        InvokeRepeating("SpawnKnight", 1, 5);
    }

    private void SpawnKnight()
    {
        GameObject skelet = Instantiate(_knightPrefab, transform.position, Quaternion.identity);
    }

    private void OnMouseDown()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        if (Physics.Raycast(ray, out _startingPosition) && _startingPosition.collider.gameObject.GetComponent<PlatformTowerController>())
        {
            _startingPosition.collider.gameObject.GetComponent<PlatformTowerController>().RemoveTower();
        }
    }

    private void OnMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float distance))
        {
            transform.position = ray.GetPoint(distance);
        }
    }

    private void OnMouseUp()
    {
        Ray ray = new Ray(transform.position, Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.GetComponent<PlatformTowerController>())
        {
            if (hit.collider.gameObject.GetComponent<PlatformTowerController>()._towerInPlatform == null)
            {
                Vector3 posObject = hit.collider.gameObject.transform.position;
                transform.position = new Vector3(posObject.x, 0.52f, posObject.z);

                hit.collider.gameObject.GetComponent<PlatformTowerController>().AddTower(gameObject);
            }
            else if(hit.collider.gameObject.GetComponent<PlatformTowerController>()._towerInPlatform.GetComponent<TowerController>()._levelTower == _levelTower)
            {
                hit.collider.gameObject.GetComponent<PlatformTowerController>()._towerInPlatform.GetComponent<TowerController>().UpLevel();
                Destroy(gameObject);
            }
            else
            {
                Vector3 posObject = _startingPosition.collider.gameObject.transform.position;
                transform.position = new Vector3(posObject.x, 0.52f, posObject.z);
                _startingPosition.collider.gameObject.GetComponent<PlatformTowerController>().AddTower(gameObject);
            }
        }
        else
        {
            Vector3 posObject = _startingPosition.collider.gameObject.transform.position;
            transform.position = new Vector3(posObject.x, 0.52f, posObject.z);
            _startingPosition.collider.gameObject.GetComponent<PlatformTowerController>().AddTower(gameObject);
        }
    }

    public void UpLevel()
    {
        _levelTower++;
        _levelText.text = _levelTower.ToString();

        if (_levelTower == 2)
        {
            _topTower.GetComponent<Renderer>().material.color = Color.green;
        }
        else if (_levelTower == 3)
        {
            _topTower.GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
