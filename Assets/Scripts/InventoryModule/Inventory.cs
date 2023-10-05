using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

namespace InventoryModule
{
    public class Inventory : MonoBehaviour
    {
        [HideInInspector] public Item SelectedItem = null;
        public Action<Item> OnItemAdded;
        public Action<Item> OnItemRemoved;

        public List<Item> Items { get; } = new List<Item>();

        public void AddItem(Item itemToAdd)
        {
            Items.Add(itemToAdd);
            OnItemAdded?.Invoke(itemToAdd);
        }
        public void RemoveItem(Item itemToRemove)
        {
            Items.Remove(itemToRemove);
            OnItemRemoved?.Invoke(itemToRemove);
        }

        public int GetItemAmount(Item itemToCount)
        {
            int count = 0;
            foreach (var item in Items)
            {
                if (item.Equals(itemToCount)) count++;
            }
            return count;
        }
        public List<int> GetListOfItemIDs()
        {
            List<int> listOfIDs = new List<int>();
            for (int i = 0; i < Items.Count; i++) listOfIDs.Add(Items[i].ItemID);
            return listOfIDs;
        }

    }
}
