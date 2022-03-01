using EventSystem;
using UnityEngine;

public class DragControl : BaseControl
{
    private Vector2 _tapPosition;
    private float _deadZone = 80f;

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
