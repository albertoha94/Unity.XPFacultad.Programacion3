using UnityEngine;

[CreateAssetMenu(fileName = "CAUItem_", menuName = "ScriptableObjects/Change Attribute Usable Item", order = 2)]
public class ChangeAttributeItemSo : ItemSo
{

    [Header("Attributes to change")]
    [SerializeField] private int hygieneAmount = 0;
    [SerializeField] private int sleepAmount = 0;
    [SerializeField] private int thirstAmount = 0;
    [SerializeField] private int heatAmount = 0;
    [SerializeField] private int hungerAmount = 0;
    [SerializeField] private int coinAmount = 0;

    public override void UseItem(Player player)
    {
        player.Limpieza += hygieneAmount;
        player.Sleep += sleepAmount;
        player.Sed += thirstAmount;
        player.Calor += heatAmount;
        player.Hambre += hungerAmount;
        player.Monedas += coinAmount;
    }
}
