using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    [SerializeField] private int _moneyToWin;
    private int _money;
    public bool IsMoneyReached { get; private set; } = false;

    private void Update()
    {
        if (_money >= _moneyToWin)
            IsMoneyReached = true;
    }

    public void AddCoin(int coinNominal)
    {
        _money += coinNominal;
    }

    public void CoinMessage()
    {
        Debug.Log("Money" + _money);
    }
}
