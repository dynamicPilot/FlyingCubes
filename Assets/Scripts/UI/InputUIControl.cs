using Systems.Objects;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public interface IUIControl
    {
        public delegate void NewStartParams(CubeParams cubeParams);
        public event NewStartParams OnNewStartParams;

        public delegate void StopSpawnCubes();
        public event StopSpawnCubes OnStopSpawnCubes;
    }

    public class InputUIControl : MonoBehaviour, IUIControl
    {
        [SerializeField] private InputFieldUI _timeField;
        [SerializeField] private InputFieldUI _velocityField;
        [SerializeField] private InputFieldUI _distanceField;
        [SerializeField] private Toggle _inLineToggle;
        [SerializeField] private Button _startButton;

        public event IUIControl.NewStartParams OnNewStartParams;
        public event IUIControl.StopSpawnCubes OnStopSpawnCubes;

        public void StartSpawn()
        {
            float time = _timeField.Value;
            float velocity = _velocityField.Value;
            float distance = _distanceField.Value;

            if (time > 0 && velocity > 0 && distance > 0)
            {
                OnNewStartParams?.Invoke(new CubeParams
                {
                    Time = time,
                    Velocity = velocity,
                    Distance = distance,
                    InLine = _inLineToggle.isOn,
                });
                _startButton.interactable = false;
            }
        }

        public void StopSpawn()
        {
            OnStopSpawnCubes?.Invoke();
            _startButton.interactable = true;
        }

    }

}
