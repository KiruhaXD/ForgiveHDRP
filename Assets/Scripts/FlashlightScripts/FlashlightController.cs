using UnityEngine;

namespace Scripts.FlashlightScripts 
{
    public class FlashlightController : MonoBehaviour
    {
        [SerializeField] Light _spotLight;

        int _isKeyPressONOrOFF = 0;

        public void OnAndOffLight()
        {
            if (Input.GetKeyDown(KeyCode.E)) 
            {
                switch (_isKeyPressONOrOFF) 
                {
                    case 0:
                        _isKeyPressONOrOFF = 1;
                        OnFlashlight();
                        break;

                    case 1:
                        _isKeyPressONOrOFF = 0;
                        OffFlashlight();
                        break;
                }
            }
        }

        public void OnFlashlight() => _spotLight.gameObject.SetActive(true);

        public void OffFlashlight() => _spotLight.gameObject.SetActive(false);
    }
}

