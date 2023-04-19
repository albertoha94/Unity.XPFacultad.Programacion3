using UnityEngine;

public class Usable_Tree : MonoBehaviour, IUsable
{
    [SerializeField] ItemSo itemTree;

    public void Usar(Player player)
    {
            Inventario.AgregarItem(itemTree);
            Destroy(gameObject);
    }
}
