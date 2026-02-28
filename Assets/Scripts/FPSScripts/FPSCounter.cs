using UnityEngine;

namespace Scripts.FPSScripts
{
    public class FPSCounter : MonoBehaviour
    {
        private int frameRange = 240;
        
        public int FPS { get; private set; }

        private int[] fpsBuffer;
        private int fpsBufferIndex;

        public void FPSBufferUpdate()
        {
            if(fpsBuffer == null || fpsBuffer.Length != frameRange)
                InitializeBuffer();
            
            UpdateBuffer();
            CalculateFPS();
        }

        public void InitializeBuffer()
        {
            if (frameRange <= 0)
                frameRange = 1;
            
            fpsBuffer = new int[frameRange];
            fpsBufferIndex = 0;
        }

        public void UpdateBuffer()
        {
            fpsBuffer[fpsBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
            
            if(fpsBufferIndex >= frameRange)
                fpsBufferIndex = 0;
        }

        public void CalculateFPS()
        {
            int sum = 0;

            for (int i = 0; i < frameRange; i++)
            {
                sum += fpsBuffer[i];
            }
            
            FPS = sum / frameRange;
        }
    }
}


