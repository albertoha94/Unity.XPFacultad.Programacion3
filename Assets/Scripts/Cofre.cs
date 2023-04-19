using UnityEngine;

public class Cofre : MonoBehaviour, IUsable
{

    [SerializeField] private Sprite spriteAbierto;
    SpriteRenderer spriteRenderer;
    Usable usable;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        usable = GetComponentInChildren<Usable>();
    }

    public void Usar(Player player)
    {
        player.Monedas += 10;
        spriteRenderer.sprite = spriteAbierto;
        Destroy(usable.gameObject);
    }
}
