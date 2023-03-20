using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Llave : Item
{
    [SerializeField] private LlaveId llaveId;
    public LlaveId LlaveId => llaveId;
}

public enum LlaveId
{
    PuertaPrincipal,
    PuertaSotano
}
