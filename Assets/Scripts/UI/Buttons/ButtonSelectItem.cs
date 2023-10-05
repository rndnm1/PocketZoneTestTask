using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using InventoryModule;
using Zenject;

namespace UI.Buttons
{
    public class ButtonSelectItem : MonoBehaviour
    {
        public Inventory Inventory;
        public ButtonConfirmItemRemoval ItemRemovalButton;

        private void Start() => GetComponent<Button>().onClick.AddListener(RemoveItem);

        

        private void RemoveItem()
        {
            Debug.Log("abababa");
            Inventory.SelectedItem = GetComponent<ItemVisualization>().RepresentedItem;
            ItemRemovalButton.gameObject.SetActive(true);
        }
    }
}
