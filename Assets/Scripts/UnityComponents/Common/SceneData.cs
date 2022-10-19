using UI;
using UnityComponents.Spawners;
using UnityEngine;

namespace UnityComponents.Common
{
    public class SceneData : MonoBehaviour
    {
        [Header("Factories")]
        public bool UseCollector = true;        
        

        [Header("Parent Objects")]
        public Transform CubeParent;

        public IUIControl UIControl { get; private set; }
        public ISpawnTimer SpawnTimer { get; private set; }
        public ISpawn Factory { get; private set; }

        private void Awake()
        {
            UIControl = GetComponent<IUIControl>();
            SpawnTimer = GetComponent<ISpawnTimer>();
            Factory = GetComponent<ISpawn>();
        }
    }
}

