using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlaneRed : MonoBehaviour
{
    [SerializeField] private Button _createTower;
    [SerializeField] private Button _restart;
    [SerializeField] private TMP_Text _youLose;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SkeletController>())
        {
            _createTower.gameObject.SetActive(false);
            _restart.gameObject.SetActive(true);
            _youLose.gameObject.SetActive(true);
        }
    }
}
