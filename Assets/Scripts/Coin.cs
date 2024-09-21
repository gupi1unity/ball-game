using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _minimalValue;
    [SerializeField] private int _maximumValue;
    private PlayerCollector _playerCollector;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<PlayerCollector>(out PlayerCollector _playerCollector))
        {
            int coinNominal = Random.Range(_minimalValue, _maximumValue);
            _playerCollector.AddCoin(coinNominal);
            _playerCollector.CoinMessage();
            gameObject.SetActive(false);
        }
    }
}
