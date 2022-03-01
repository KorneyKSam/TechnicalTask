using UnityEngine;
using EventSystem;

public abstract class BaseControl : MonoBehaviour
{
    protected bool _isMobile;

    void Start()
    {
        _isMobile = Application.isMobilePlatform;
    }

}
