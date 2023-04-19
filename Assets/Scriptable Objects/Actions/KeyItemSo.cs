using UnityEngine;

[CreateAssetMenu(fileName = "KItem_", menuName = "ScriptableObjects/Key Item", order = 3)]
public class KeyItemSo : ItemSo
{

    [Header("KeyId")]
    [SerializeField] private LlaveId keyId;
    public LlaveId KeyId => keyId;
}
