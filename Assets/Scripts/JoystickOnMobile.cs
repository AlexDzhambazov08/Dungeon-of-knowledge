using UnityEngine;

public class JoystickOnMobile : MonoBehaviour
{
    public GameObject mobilePrefab;

    void Start()
    {
#if UNITY_ANDROID || UNITY_IOS
        if (mobilePrefab != null)
        {
            mobilePrefab.SetActive(true);
        }
#endif
#if UNITY_STANDALONE || UNITY_WEBGL
        if (mobilePrefab != null)
        {
            mobilePrefab.SetActive(false);
        }
#endif
    }
}
