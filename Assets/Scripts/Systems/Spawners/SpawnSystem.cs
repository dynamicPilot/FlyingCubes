using Systems.Objects;
using UnityComponents.Common;
using UnityEngine;

namespace Systems.Spawners
{
    public interface IStopAndStart
    {
        public void OnStop();
        public void OnStart();
    }

    public class SpawnSystem : IStopAndStart
    {
        private SceneData _sceneData;
        private StaticData _staticData;

        private PrefabToSpawn _prefabToSpawn;
        private IFactoryMethod _factoryMethod;
        private IFactoryMethod _factoryWithCollector;
        private CollectorMethod _collectorMethod;

        public SpawnSystem(SceneData sceneData, StaticData staticData)
        {
            _sceneData = sceneData;
            _staticData = staticData;
            _collectorMethod = new CollectorMethod(_sceneData.Factory);

            _factoryMethod = new FactoryMethod(_sceneData.Factory);
            _factoryWithCollector = new FactoryMethod(_collectorMethod);
            
            SetDefaultPrefab();
        }

        public void OnStart()
        {
            _collectorMethod.OnStart();
            _sceneData.InputUIControl.OnNewStartParams += StartSpawn;
            _sceneData.InputUIControl.OnStopSpawnCubes += StopSpawn;
        }

        public void OnStop()
        {
            _collectorMethod.OnStop();
            _sceneData.InputUIControl.OnNewStartParams -= StartSpawn;
            _sceneData.InputUIControl.OnStopSpawnCubes -= StopSpawn;
        }


        private void SetDefaultPrefab()
        {
            _prefabToSpawn = new PrefabToSpawn
            {
                Prefab = _staticData.CubePrefab,
                Position = Vector2.zero,
                Parent = _sceneData.CubeParent
            };
        }

        public void StartSpawn(CubeParams cubeParams)
        {
            if (_sceneData.UseCollector) _sceneData.SpawnTimer.StartSpawn(_prefabToSpawn, cubeParams, _factoryWithCollector);
            else _sceneData.SpawnTimer.StartSpawn(_prefabToSpawn, cubeParams, _factoryMethod);
        }

        private void StopSpawn()
        {
            _sceneData.SpawnTimer.StopSpawn();
        }
    }

}
