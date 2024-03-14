using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    [System.Serializable]
    public class Item
    {
        [SerializeField] private ItemSO _itemSO;
        [SerializeField] private int _currentStack;

        public ItemSO ItemSO
        {
            get { return _itemSO; }
            private set { _itemSO = value; }
        }
        public int CurrentStack
        {
            get { return _currentStack; }
            private set { _currentStack = value; }
        }

        public Item(ItemSO itemSO, int stack)
        {
            ItemSO = itemSO;
            CurrentStack = stack;
        }

        public void AddStack(int stack, out int surplus)
        {
            int calculated = CurrentStack + stack - ItemSO.Stack;
            surplus = calculated > 0 ? calculated : 0;
            CurrentStack = surplus > 0 ? ItemSO.Stack : CurrentStack + stack;
        }
    }
}
