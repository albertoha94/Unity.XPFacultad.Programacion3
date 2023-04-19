using UnityEngine;

public class Usable_Well : MonoBehaviour, IUsable
{

    [SerializeField] ItemSo itemCoins;

    public void Usar(Player player)
    {
        Inventario.AgregarItem(itemCoins);
        var usableChildComponent = GetComponentInChildren<Usable>();
        Destroy(usableChildComponent.gameObject);
        Destroy(this);
    }
}
