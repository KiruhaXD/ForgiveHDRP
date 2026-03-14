using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class TransitionsController : MonoBehaviour
{
    [SerializeField] Image beginTransitionWindow;

    private void Awake()
    {
        ChangeAlphaValueForBeginWindow();
    }

    public void ChangeAlphaValueForBeginWindow() => beginTransitionWindow.DOColor(new Color(0, 0, 0, 0), 8f);
}
