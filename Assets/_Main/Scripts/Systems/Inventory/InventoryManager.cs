using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryManager : MonoBehaviour
    {
        [SerializeField] private List<Item> _items = new List<Item>();

        #region Test
        [SerializeField] private Gold _gold;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Add(new Item(_gold, 10));
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                Add(new Item(_gold, 999));
            }
        }
        #endregion

        public void Add(Item item)
        {
            Item stackedItem = null;
            for (int i = _items.Count - 1; i > -1; i--)
            {
                if (item.ItemSO.Id != _items[i].ItemSO.Id) continue;
                if (_items[i].CurrentStack < _items[i].ItemSO.Stack)
                {
                    stackedItem = _items[i];
                    break;
                }
            }


            if (stackedItem == null)
            {
                Item newItem = new Item(item.ItemSO, 0);
                _items.Add(newItem);
                stackedItem = newItem;
            }

            int surplus;
            stackedItem.AddStack(item.CurrentStack, out surplus);

            if (surplus > 0)
            {
                for (int i = 0; i < surplus / item.ItemSO.Stack; i++)
                {
                    Add(new Item(item.ItemSO, item.ItemSO.Stack));
                }
                if (surplus % item.ItemSO.Stack > 0)
                {
                    Add(new Item(item.ItemSO, surplus % item.ItemSO.Stack));
                }
            }
        }
    }
}
