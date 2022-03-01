using EventSystem;
using UnityEngine;

public class ButtonControl : BaseControl
{
    void Update()
    {
        if (!_isMobile)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                Events.onInputToRight.Invoke();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Events.onInputToLeft.Invoke();
            }
        }
        else
        {

        }
    }
}
