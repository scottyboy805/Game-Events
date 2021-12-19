using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace GameEvents
{
    [Serializable]
    public sealed class GameEventDispatcher
    {
        // Private
        [SerializeField]
        private GameEvent gameEvent = null;
        [SerializeField]
        private List<GameEventListener> eventListeners = new List<GameEventListener>();

        // Methods
        public void Raise(GameObject sender)
        {
            // Check for null
            if (gameEvent == null)
                return;

            // Check for any listeners
            if(eventListeners.Count > 0)
            {
                // Setup sender
                gameEvent.OnRaise(sender, null);

                // Send event
                InvokeListeners();
            }
        }

        public void Raise<T>(GameObject sender, T value)
        {
            // Check for null
            if (gameEvent == null)
                return;

            // Check for any listeners
            if (eventListeners.Count > 0)
            {
                // Setup sender
                gameEvent.OnRaise(sender, value);

                // Send event
                InvokeListeners();
            }
        }

        private void InvokeListeners()
        {
            foreach(GameEventListener listener in eventListeners)
            {
                listener.Invoke(gameEvent);
            }
        }
    }
}
