using System;
using UnityEngine;

namespace GameEvents
{
    [Serializable]
    public class GameEvent : ScriptableObject
    {
        // Private
        private GameObject sender = null;

        // Properties
        public GameObject Sender
        {
            get { return sender; }
        }

        // Methods
        public virtual void OnRaise(GameObject sender, object data)
        {

        }
    }
}
