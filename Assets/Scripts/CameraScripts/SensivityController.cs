using UnityEngine;
using UnityEngine.UI;
public class SensivityController : MonoBehaviour
{
    public const string SensivitySettingsKey = "sensivity_settings";

    [SerializeField] public float currentSensivity = 1000f;

    float minSensivity = 100f;
    float maxSensivity = 1000f;

    [SerializeField] Slider sliderSensivity;

    private void Awake()
    {
        if(PlayerPrefs.HasKey(SensivitySettingsKey))
            sliderSensivity.value = PlayerPrefs.GetFloat(SensivitySettingsKey);
    }

    private void Start()
    {
        sliderSensivity.value = (currentSensivity - minSensivity) / (maxSensivity - minSensivity);

        sliderSensivity.onValueChanged.AddListener(value =>
        {
            currentSensivity = Mathf.Max(minSensivity, value * maxSensivity);
        });
    }

    private void OnDisable()
    {
        sliderSensivity.onValueChanged.RemoveAllListeners();

        PlayerPrefs.SetFloat(SensivitySettingsKey, sliderSensivity.value);
    }
}
