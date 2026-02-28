using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Scripts.FPSScripts
{
    public class FPSDisplay : MonoBehaviour
    {
        public TMP_Text textFPS;
        [SerializeField] FPSCounter fpsCounter;

        private void Start()
        {
            //textFPS.gameObject.SetActive(false);
        }

        private void Update()
        {
            fpsCounter.FPSBufferUpdate();
            CalculateFPS();
        }

        public void CalculateFPS() => textFPS.text = "FPS: " + Mathf.Clamp(fpsCounter.FPS, 0, 240).ToString(); // limit - FPS: 240
    }
}


