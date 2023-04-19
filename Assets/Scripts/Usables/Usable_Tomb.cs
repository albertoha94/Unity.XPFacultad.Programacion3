using UnityEngine;

public class Usable_Tomb : MonoBehaviour, IUsable
{

    [SerializeField] ItemSo itemSkull;

    public void Usar(Player player)
    {
            Inventario.AgregarItem(itemSkull);
            Destroy(gameObject);
    }
}
