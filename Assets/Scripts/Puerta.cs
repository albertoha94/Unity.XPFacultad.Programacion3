using UnityEngine;

public class Puerta : MonoBehaviour, IUsable
{
    [SerializeField] private LlaveId llaveId;

    public void Usar(Player player)
    {
        var keyFound = Inventario.FindKey(llaveId);
        if (keyFound != null)
        {
            Inventario.SlotItemActivo = keyFound;
            Inventario.UseActiveItem();
            Destroy(gameObject);
        }
    }
}
