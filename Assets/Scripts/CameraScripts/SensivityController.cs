using UnityEngine;
using UnityEngine.UI;
public class SensivityController : MonoBehaviour
{
    [SerializeField] public float currentSensivity = 500f;

    /*float maxSensivity = 1000f;
    float minSensivity = 100f;

    float defaultSensivity = 500f;

    [SerializeField] Slider sliderSensivity;

    private void Awake()
    {
        currentSensivity = defaultSensivity;

        sliderSensivity.value = (currentSensivity - minSensivity) / (maxSensivity - minSensivity);

        sliderSensivity.onValueChanged.AddListener(value => 
        {
            currentSensivity = Mathf.Max(minSensivity, value * maxSensivity);
        });
    }

    private void OnDestroy()
    {
        sliderSensivity.onValueChanged.RemoveAllListeners();
    }*/
}
