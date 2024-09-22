using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerCollector _playerCollector;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private float _timeToWin;
    private float _timeLeft = 0;
    private int _seconds;
    private bool _isRunning = true;

    private void Awake()
    {
        _timeLeft = _timeToWin;
    }

    private void Update()
    {
        if (_isRunning == true)
            CalculateTime();
        DisplayText();

        if (_timeLeft == 0 && _playerCollector.IsMoneyReached == false)
        {
            Debug.Log("You lose");
            _isRunning = false;
            _playerCollector.gameObject.SetActive(false);
        }
        if (_timeLeft > 0 && _playerCollector.IsMoneyReached == true)
        {
            Debug.Log("You win");
            _isRunning = false;
            _playerCollector.gameObject.SetActive(false);
        }
    }

    private void CalculateTime()
    {
        _timeLeft -= Time.deltaTime;

        if (_timeLeft <= 0)
            _timeLeft = 0;
            

        _seconds = Mathf.FloorToInt(_timeLeft % 60);
    }

    private void DisplayText()
    {
        _text.text = $"Time left {_seconds}";
    }
}
