using TMPro;
using UnityEngine;

namespace UI
{

    public class InputFieldUI : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [HideInInspector] public float Value { get; private set; }
        private void Awake()
        {
            Value = 0f;
        }
        public void OnEndEdit()
        {
            Value = float.Parse(_inputField.text);
        }
    }
}
