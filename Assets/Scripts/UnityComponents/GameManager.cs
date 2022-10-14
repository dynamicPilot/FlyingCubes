using Systems.Spawners;
using UnityComponents.Common;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneData _sceneData;
    [SerializeField] private StaticData _staticData;

    private SpawnSystem _spawnSystem;

    private void Awake()
    {
        _spawnSystem = new SpawnSystem(_sceneData, _staticData);
    }

    void Start()
    {
        _spawnSystem.OnStart();
    }

    private void OnDisable()
    {
        _spawnSystem.OnStop();
    }
}
