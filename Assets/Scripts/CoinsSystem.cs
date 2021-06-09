using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoinsSystem
{
    public static void AddCoin(long amount) => Balance += amount;
    public static void WastCoins(long amount) => Balance -= amount;
    public static long Balance
    {
        get;
        private set;
    }
}
