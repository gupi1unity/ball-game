using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private int _money;

    public void AddCoin(int coinNominal)
    {
        _money += coinNominal;
    }
}
