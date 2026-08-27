using UnityEngine;

public class SunController : MonoBehaviour
{
    Quaternion mainQuaternionNight = new Quaternion(.66f, -.64f, .10f, -.35f);

    public void ChangeRotationSun() => transform.rotation = mainQuaternionNight;
    
}
