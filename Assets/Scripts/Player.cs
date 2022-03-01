using EventSystem;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _laneOffset = 6f;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _lerpDuration = 0.5f;

    private ButtonControl _buttonControl;
    private SwipeControl _swipeControl;
    private DragControl _dragControl;

    private Vector3 _targetPosition;
    private float _timeElapsed;

    private void Start()
    {
        _targetPosition = transform.position;
        _buttonControl = transform.GetComponent<ButtonControl>();
        _swipeControl = transform.GetComponent<SwipeControl>();
        _dragControl = transform.GetComponent<DragControl>();
    }

    private void FixedUpdate()
    {
        if (_timeElapsed < _lerpDuration)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, _targetPosition, _curve.Evaluate(_timeElapsed / _lerpDuration));
            _timeElapsed += Time.deltaTime;
        }
        else
        {
            transform.localPosition = _targetPosition;
        }
    }

    private void OnEnable()
    {
        Events.onInputToLeft.AddListener(TurnToLeft);
        Events.onInputToRight.AddListener(TurnToRight);
        //Events.onControlChanged.AddListener(ChangeControl);
    }

    private void OnDisable()
    {
        Events.onInputToLeft.DeleteListener(TurnToLeft);
        Events.onInputToRight.DeleteListener(TurnToRight);
        //Events.onControlChanged.DeleteListener(ChangeControl);
    }

    private void TurnToLeft()
    {
        if (_targetPosition.x > -_laneOffset)
        {
            _timeElapsed = 0;
            _targetPosition = new Vector3(_targetPosition.x - _laneOffset, transform.position.y, transform.position.z);
        }
    }

    private void TurnToRight()
    {
        if (_targetPosition.x < _laneOffset)
        {
            _timeElapsed = 0;
            _targetPosition = new Vector3(_targetPosition.x + _laneOffset, transform.position.y, transform.position.z);
        }
    }

    //private void ChangeControl(TypeOfControl typeOfControl)
    //{
    //    _buttonControl.gameObject.SetActive(false);
    //    _dragControl.gameObject.SetActive(false);
    //    _swipeControl.gameObject.SetActive(false);

    //    switch (typeOfControl)
    //    {
    //        case TypeOfControl.Buttons:
    //            _buttonControl.gameObject.SetActive(true);
    //            break;
    //        case TypeOfControl.Swipe:
    //            _swipeControl.gameObject.SetActive(true);
    //            break;
    //        case TypeOfControl.Drag:
    //            _dragControl.gameObject.SetActive(true);
    //            break;
    //        default:
    //            break;
    //    }
    //}
}
