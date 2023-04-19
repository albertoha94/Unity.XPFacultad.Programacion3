using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private ItemSo itemSo;
    public ItemSo ItemSo => itemSo;
}
