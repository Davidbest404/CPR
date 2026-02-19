using Core;
using UnityEngine;

namespace Core
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        public GameInput GameInput;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]

        public static void Init()
        {
            if (Instance != null)
                return;

            GameObject obj = new GameObject("InputManager");
            Instance = obj.AddComponent<InputManager>();
            DontDestroyOnLoad(obj);

        }
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            GameInput = new GameInput();
            GameInput.Enable();
        }


        private void OnDisable()
        {
            if (Instance == this)
            {
                GameInput.Disable();
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
            {
                GameInput?.Dispose();
                GameInput = null;
                Instance = null;
            }
        }
    }
}