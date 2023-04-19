using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{

    [SerializeField] SlotStat sleep;
    [SerializeField] SlotStat sed;
    [SerializeField] SlotStat hambre;
    [SerializeField] SlotStat calor;
    [SerializeField] SlotStat limpieza;
    [SerializeField] TMP_Text monedas;

    private void Awake()
    {
        self = this;
    }

    private static HUD self;
    public static SlotStat Sleep => self.sleep;
    public static SlotStat Sed => self.sed;
    public static SlotStat Hambre => self.hambre;
    public static SlotStat Calor => self.calor;
    public static SlotStat Limpieza => self.limpieza;

    public static int Monedas
    {
        set => self.monedas.text = value.ToString();
    }
}
