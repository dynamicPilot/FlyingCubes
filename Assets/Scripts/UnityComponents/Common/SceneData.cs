using UI;
using UnityComponents.Spawners;
using UnityEngine;

namespace UnityComponents.Common
{
    public class SceneData : MonoBehaviour
    {
        [Header("Factories")]
        public bool UseCollector = true;
        public SpawnByTimer SpawnTimer;
        public Factory Factory;

        [Header("Parent Objects")]
        public Transform CubeParent;

        [Header("UIControl")]
        public InputUIControl InputUIControl;
    }
}

