using System;
using UnityEngine;
using UnityEngine.UI;

public class Compass : MonoBehaviour
{
    [SerializeField] RawImage compassImage;
    [SerializeField] Transform playerTransform;
    
    void Update()
    {
        compassImage.uvRect = new Rect(playerTransform.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
