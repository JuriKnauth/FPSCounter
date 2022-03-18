#if !RELEASE
using UnityEngine;

namespace BeamXR.FPSConuter
{
    public class FramesPerSecondCounter : MonoBehaviour
    {
        private readonly float _updateInterval = 0.167f;
        private readonly GUIStyle _style = new GUIStyle();

        private float _nextUpdate;
        private float _timeFactor;
        private float _framesPerSecond;
        private int _frameCount;

        [RuntimeInitializeOnLoadMethod]
        private static void AppInit()
        {
            GameObject fpsCounterLauncherGameObject = new GameObject(nameof(FramesPerSecondCounter));
            DontDestroyOnLoad(fpsCounterLauncherGameObject);
            fpsCounterLauncherGameObject.AddComponent<FramesPerSecondCounter>();
        }

        private void Awake()
        {
            _style.fontStyle = FontStyle.Bold;
            _style.normal.textColor = Color.white;
            _style.alignment = TextAnchor.MiddleRight;
        }

        private void Update()
        {
            UpdateFrameCounter();

            if (Time.time > _nextUpdate)
            {
                UpdateFrameCounterGUI();
            }
        }

        private void UpdateFrameCounter()
        {
            Debug.Log("UpdateFrameCounter");

            _timeFactor += Time.timeScale / Time.deltaTime;
            _frameCount++;
        }

        private void UpdateFrameCounterGUI()
        {
            _nextUpdate = Time.time + _updateInterval;
            _framesPerSecond = _timeFactor / _frameCount;
            _timeFactor = 0f;
            _frameCount = 0;
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 5, 50, 25), _framesPerSecond.ToString("F2"), _style);
        }

#if UNITY_EDITOR

        public float FramesPerSecond() => _framesPerSecond;
        public float CurrentFramesPerSecond() => _timeFactor / _frameCount;
        public float UpdateInterval() => _updateInterval;
        public float FrameCount() => _frameCount;
        public float NextUpdate() => _nextUpdate;

#endif
    }
}
#endif