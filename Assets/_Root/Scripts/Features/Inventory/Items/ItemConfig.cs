
using UnityEngine;

namespace Features.Inventory.Items
{

    [CreateAssetMenu(fileName = nameof(ItemConfig), menuName = "Configs/" + nameof(ItemConfig))]
    internal sealed class ItemConfig : ScriptableObject
    {
        public string Id;
        public string Title;
        public Sprite Icon;
    }
}
