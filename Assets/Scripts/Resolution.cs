using UnityEngine;

public class nombredelscript : MonoBehaviour
{
    void Start()
    {
        float xx = Screen.width;
        float yy = Screen.height;
        Screen.SetResolution(1920, 1080, true);
        Camera.main.aspect = xx / yy;
    }
}
