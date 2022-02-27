using EventSystem;
using UnityEngine;

public class TouchControl : MonoBehaviour
{
    private Vector2 _tapPosition;
    private bool _isMobile;
    private float _deadZone = 80f;

    void Start()
    {
        _isMobile = Application.isMobilePlatform;
    }

    void Update()
    {
        _tapPosition = Vector2.zero;
        if (!_isMobile)
        {
            if (Input.GetMouseButtonDown(0))
            {
                _tapPosition = Input.mousePosition;
            }
        }
        else
        {
            if (Input.touchCount > 0)
            {
                _tapPosition = Input.GetTouch(0).position;
            }
        }

        if (_tapPosition.magnitude > _deadZone)
        {
            if (Mathf.Abs(_tapPosition.x) > Screen.width / 2)
            {
                Events.onInputToRight.Invoke();
            }
            else if (Mathf.Abs(_tapPosition.x) < Screen.width / 2)
            {
                Events.onInputToLeft.Invoke();
            }
        }
    }
}
