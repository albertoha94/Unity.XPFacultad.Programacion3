using UnityEngine;

public class Cofre : MonoBehaviour, IUsable
{

    public void Usar(Player player)
    {
        player.Sleep = 0;
    }
}
