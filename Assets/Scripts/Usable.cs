using UnityEngine;

public class Usable : MonoBehaviour
{

    Canvas canvas;
    IUsable iUsable;

    private void Awake()
    {
        canvas = transform.GetChild(0).GetComponent<Canvas>();
        iUsable = transform.parent.GetComponent<IUsable>();

        canvas.enabled = false;
    }

    public void Usar(Player player)
    {
        iUsable.Usar(player);
    }

    public bool Activado
    {
        set => canvas.enabled = value;
    }
}
