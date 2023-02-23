using UnityEngine;

public class EscalerasTrigger : MonoBehaviour
{

    internal Nivel nivel;

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObject collidedGO = collision.gameObject;
        collidedGO.layer = (int)nivel;
        print(nivel.ToString());

        if (collidedGO.TryGetComponent(out SpriteRenderer sprite))
            sprite.sortingLayerName = nivel.ToString();

        foreach (SpriteRenderer sr in collidedGO.GetComponentsInChildren<SpriteRenderer>())
            sr.sortingLayerName = nivel.ToString();
    }
}
