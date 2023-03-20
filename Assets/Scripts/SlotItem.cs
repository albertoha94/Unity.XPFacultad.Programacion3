using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour
{

    private Image icono;
    private Item _item;

    private void Awake()
    {
        icono = transform.GetChild(0).GetComponent<Image>();
    }

    void OnPointerClick(PointerEventData eventData)
    {

    }

    public Item Item
    {
        get => _item;
        set => _item = value;
    }
}
