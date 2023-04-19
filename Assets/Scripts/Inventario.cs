using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventario : MonoBehaviour
{

    const string TAG_PLAYER = "Player";

    #region Static

    private static Inventario self;
    private static Canvas canvas;

    public static bool Activo
    {
        get => canvas.enabled;
        set => canvas.enabled = value;
    }

    #endregion

    #region PanelInfo
    [Header("Panel info")]
    [SerializeField] private Image infoIcono;
    [SerializeField] private TMP_Text infoNombre;
    [SerializeField] private TMP_Text infoDescripcion;
    [SerializeField] private Button botonUsar;

    private static SlotItem _infoSlotItemActivo;
    public static SlotItem SlotItemActivo
    {
        get => _infoSlotItemActivo;
        set
        {
            _infoSlotItemActivo = value;

            if (_infoSlotItemActivo && _infoSlotItemActivo.ItemSo)
            {
                self.infoIcono.enabled = true;
                self.infoIcono.sprite = value.ItemSo.Icono;
                self.infoNombre.text = value.ItemSo.Nombre;
                self.infoDescripcion.text = value.ItemSo.Descripcion;

                var itemSO = value.ItemSo;
                var isUsable = value.ItemSo.IsUsable;
                self.botonUsar.gameObject.SetActive(isUsable);
                var buttonTextComponent = self.botonUsar.GetComponentInChildren<TMP_Text>();
                if (isUsable && itemSO.UsableText.Length > 0)
                {
                    buttonTextComponent.SetText(itemSO.UsableText);
                }
                else
                {
                    buttonTextComponent.SetText("Usar");
                }
            }
            else
            {
                self.infoIcono.enabled = false;
                self.infoNombre.text = string.Empty;
                self.infoDescripcion.text = string.Empty;
                self.botonUsar.gameObject.SetActive(false);
            }
        }
    }

    #endregion

    #region PanelSlots

    [Header("Panel Slots")]
    [SerializeField] private Transform panelSlots;

    private SlotItem[] slots;

    public static void AgregarItem(ItemSo itemSo)
    {
        foreach (SlotItem slotItem in self.slots)
        {
            if (slotItem.ItemSo == null)
            {
                slotItem.ItemSo = itemSo;
                break;
            }
        }
    }

    public static void RemoveItem(ItemSo itemSo)
    {
        foreach (SlotItem slotItem in self.slots)
        {
            if (slotItem.ItemSo == itemSo)
            {
                slotItem.ItemSo = null;
                break;
            }
        }
    }
    public static SlotItem FindKey(LlaveId keyId)
    {
        var itemFound = self.slots.FirstOrDefault(mItem =>
        {
            if (mItem.ItemSo == null)
                return false;

            if (mItem.ItemSo.GetType() != typeof(KeyItemSo))
                return false;

            var typedItem = (mItem.ItemSo as KeyItemSo);
            if (typedItem.KeyId == keyId)
                return true;
            else
                return false;
        });

        if (itemFound == null)
            return null;
        else
            return itemFound;
    }

    #endregion

    private void Awake()
    {
        self = this;
        canvas = GetComponent<Canvas>();
        slots = panelSlots.GetComponentsInChildren<SlotItem>();
    }

    public static void UseActiveItem()
    {
        if (SlotItemActivo == null ||
            SlotItemActivo.ItemSo == null)
            return;

        var player = GameObject.FindGameObjectWithTag(TAG_PLAYER).GetComponent<Player>();
        var itemSo = SlotItemActivo.ItemSo;
        itemSo.UseItem(player);
        RemoveItem(itemSo);
        SlotItemActivo = null;
    }
}
