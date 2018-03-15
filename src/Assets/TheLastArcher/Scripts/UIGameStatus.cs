using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class UIGameStatus : IInit
{
    [SerializeField]
    private Text _currentScoreText;
    [SerializeField]
    private GameObject[] _hearts;

    public void Init()
    {
        UpdateScoreText(0);
    }

    public void UpdateHearts(int i = 1)
    {
        for (; i < _hearts.Length; i++) {
            _hearts[i].SetActive(false);
        }
    }

    public void UpdateScoreText(int score)
    {
        _currentScoreText.text = score.ToString();
    }
}