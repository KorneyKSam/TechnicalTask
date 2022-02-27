using UnityEngine;
using EventSystem;

public class InputManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var direction = new Vector3(Input.GetAxis(Axis.Vertical), 0f, Input.GetAxis(Axis.Horizontal));

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Events.onInputToRight.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Events.onInputToLeft.Invoke();
        }
    }
}
