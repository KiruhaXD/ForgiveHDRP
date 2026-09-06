using UnityEngine;
using UnityEngine.UI;

public class Marker : MonoBehaviour
{
    [SerializeField] RawImage markerImage;
    [SerializeField] Transform objectTransform;
    
    void Update()
    {
        markerImage.uvRect = new Rect(objectTransform.localEulerAngles.y / 360f, 0f, 1f, 1f);
    }
}
