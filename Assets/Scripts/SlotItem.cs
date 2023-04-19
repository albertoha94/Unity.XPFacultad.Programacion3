using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotItem : MonoBehaviour, IPointerClickHandler
{

    private Image icono;
    private ItemSo _itemSo;

    private void Awake()
    {
        icono = transform.GetChild(0).GetComponent<Image>();
    }

    void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    {
        Inventario.SlotItemActivo = this;
    }

    public ItemSo ItemSo
    {
        get => _itemSo;
        set
        {
            _itemSo = value;

            if (value)
            {
                icono.enabled = true;
                icono.sprite = value.Icono;
            }
            else
            {
                icono.enabled = false;
            }
        }
    }
}
