using UnityEngine;
using System;

namespace Inventory
{
    public abstract class ItemSO : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _image;
        [SerializeField] private string _description;
        [SerializeField] private int _stack;

        public string Id { get { return _id; } protected set { _id = value; } }
        public Sprite Image => _image;
        public virtual string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }
        public int Stack
        {
            get { return _stack; }
            protected set { _stack = value; }
        }

        public abstract void Use();
    }
}
