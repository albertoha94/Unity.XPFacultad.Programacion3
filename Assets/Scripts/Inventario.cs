using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    #region PanelInfo
    [Header("Panel info")]
    [SerializeField] private Image infoIcono;
    [SerializeField] private TMP_Text infoNombre;
    [SerializeField] private TMP_Text infoDescripcion;
    [SerializeField] private Button botonUsar;
    private SlotItem _infoSlotItem;

    public SlotItem SlotItem
    {
        get => _infoSlotItem;
        set
        {
            _infoSlotItem = value;

            if (_infoSlotItem)
            {
                infoIcono.sprite = value.Item.Icono;
            }
        }
    }

    #endregion

    #region PanelSlots

    [Header("Panel Slots")]
    [SerializeField] private Transform panelSlots;

    private SlotItem[] slots;

    private void Awake()
    {
        slots = panelSlots.GetComponentsInChildren<SlotItem>();
    }

    #endregion
}
