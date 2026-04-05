using TMPro;
using UnityEngine;

namespace Scripts.FPSScripts
{
    public class FPSDisplay : MonoCache
    {
        public TMP_Text textFPS;
        [SerializeField] FPSCounter fpsCounter;

        private void Start()
        {
            //textFPS.gameObject.SetActive(false);
        }

        public override void OnTick()
        {
            fpsCounter.FPSBufferUpdate();
            CalculateFPS();
        }

        public void CalculateFPS() => textFPS.text = "FPS: " + Mathf.Clamp(fpsCounter.FPS, 0, 240).ToString(); // limit - FPS: 240
    }
}


