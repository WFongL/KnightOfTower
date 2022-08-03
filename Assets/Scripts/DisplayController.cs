using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayController : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoresDisplay;
    public int _scores = 60;
    [SerializeField] private Button _createTower;
    [SerializeField] private TMP_Text _priceTowerDisplay;
    public int _priceTower = 10;

    public int GiveScores()
    {
        return _scores;
    }

    public void UpdateScores(int scores)
    {
        _scores = scores;
        _scoresDisplay.text = scores.ToString();
    }

    public void AddScores(int scores)
    {
        _scores += scores;
        _scoresDisplay.text = scores.ToString();
    }

    public void UpdatePriceTower(int priceTower)
    {
        _priceTowerDisplay.text = priceTower.ToString();
    }
}
