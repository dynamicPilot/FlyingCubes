using System.Collections.Generic;
using Unity.VisualScripting;
using UnityComponents.Common;
using UnityComponents.Spawners;
using UnityEngine;


namespace Systems.Spawners
{
    public class CollectorMethod : ISpawn, IStopAndStart
    {
        private Queue<GameObject> _queue;
        private ISpawn _factory;
        public CollectorMethod(ISpawn factory)
        {
            _queue = new Queue<GameObject>();
            _factory = factory;            
        }

        public void OnStart()
        {
            FreeEventManager.StartListening(AddToCollector);
        }

        public void OnStop()
        {
            FreeEventManager.StopListening(AddToCollector);
        }

        private void AddToCollector(GameObject gObj)
        {
            
            _queue.Enqueue(gObj);
            Debug.Log("Add to collection " + _queue.Count);
        }

        public GameObject Spawn(PrefabToSpawn prefab)
        {
            Debug.Log("Get from collection");
            if (_queue.Count == 0) return _factory.Spawn(prefab);
            else
            {                
                GameObject gObj = _queue.Dequeue();
                gObj.transform.position = Vector3.zero;
                gObj.SetActive(true);
                return gObj;
            }
        }
    }
}

