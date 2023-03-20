using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_PocionSleep : Item
{
    [SerializeField] private int sleepRecuperacion;

    public override void Usar(Player player)
    {
        player.Sleep += sleepRecuperacion;
    }
}
