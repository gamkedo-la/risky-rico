using UnityEngine;
using UnityEngine.Events;

namespace ScriptableObjectArchitecture
{
    [AddComponentMenu(SOArchitecture_Utility.EVENT_LISTENER_SUBMENU + "Game Event Listener")]
    [ExecuteInEditMode]
    public sealed class GameEventListener : BaseGameEventListener<GameEventBase, UnityEvent>
    {
        public void SetResponse(UnityEvent response)
        {
            _response = response;
        }
        public void SetEvent(GameEvent e)
        {
            _event = e;
        }

        public void Register()
        {
            base.Register();
        }
    }
}