using UnityEngine;
using UnityEngine.Events;

namespace UnityComponents.Common
{
    [DefaultExecutionOrder(-1)]
    public class FreeEventManager : MonoBehaviour
    {
        private UnityEvent<GameObject> _freeCubeEvent;
        private static FreeEventManager _eventManager;
        public static FreeEventManager instance
        {
            get
            {
                if (!_eventManager)
                {
                    _eventManager = FindObjectOfType(typeof(FreeEventManager)) as FreeEventManager;

                    if (!_eventManager)
                    {
                        Debug.LogError("There needs to be one active EventManger script on a GameObject in your scene.");
                    }
                    else
                    {
                        _eventManager.Init();
                    }
                }

                return _eventManager;
            }
        }

        private void Init()
        {
            _freeCubeEvent = new UnityEvent<GameObject>();
        }

        public static void StartListening(UnityAction<GameObject> listener)
        {
            instance._freeCubeEvent.AddListener(listener);
        }
        public static void StopListening(UnityAction<GameObject> listener)
        {
            instance._freeCubeEvent.RemoveListener(listener);
        }

        public static void TriggerEvent(GameObject gObj)
        {
            instance._freeCubeEvent.Invoke(gObj);
        }
    }
}
