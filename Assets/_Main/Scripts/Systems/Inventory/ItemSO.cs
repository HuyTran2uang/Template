using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Inventory
{
    public abstract class ItemSO : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private Sprite _image;
        [SerializeField] private string _description;

        public string Id { get { return _id; } protected set { _id = value; } }
        public Sprite Image => _image;
        public virtual string Description
        {
            get { return _description; }
            protected set { _description = value; }
        }

        private void OnEnable()
        {
            _id = Random.Range(0, 1000).ToString("0000");
        }

        public abstract void Use();
    }
}
