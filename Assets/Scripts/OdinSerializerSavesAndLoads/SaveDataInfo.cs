using UnityEngine;
using DG.Tweening;
using TMPro;

public class SaveDataInfo : MonoBehaviour
{
    [SerializeField] TMP_Text saveDataInfoText;

    public void InfoActive() => saveDataInfoText.DOColor(new Color(255, 255, 255, 255), 3f);
    
    public void InfoNonActive() => saveDataInfoText.DOColor(new Color(255, 255, 255, 0), 3f);
    
}
