using UnityEngine;

[CreateAssetMenu(fileName = "Item_", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemSo : ScriptableObject
{
    [Header("Base Attributes")]
    [SerializeField] string nombre;
    public string Nombre => nombre;

    [SerializeField] Sprite icono;
    public Sprite Icono => icono;

    [SerializeField] bool isUsable;
    public bool IsUsable => isUsable;

    [SerializeField] string usableText;
    public string UsableText => usableText;

    [SerializeField]
    [TextArea] string descripcion;
    public string Descripcion => descripcion;

    public virtual void UseItem(Player player) { }
}