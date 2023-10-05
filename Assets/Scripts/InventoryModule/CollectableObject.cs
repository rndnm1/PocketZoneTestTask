using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventoryModule
{
    /// <summary>
    /// Represents an item on the ground that can be collected by entities
    /// </summary>
    public class CollectableObject : MonoBehaviour
    {
        public Item storedItem;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Inventory inventory))
            {
                inventory.AddItem(storedItem);
                Destroy(gameObject);
            }
        }
    }
}
