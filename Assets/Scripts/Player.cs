using EventSystem;
using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private float _laneOffset = 6f;
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _lerpDuration = 0.5f;

    private Vector3 _targetPosition;
    private float _timeElapsed;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _targetPosition = transform.position;

        _rigidbody = GetComponentInChildren<Rigidbody>();
        if (_rigidbody == null)
        {
            throw new NullReferenceException("Player child doesn't have a Rigidbody!");
        }
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
    }

    private void OnDisable()
    {
        Events.onInputToLeft.DeleteListener(TurnToLeft);
        Events.onInputToRight.DeleteListener(TurnToRight);
    }

    private void TurnToLeft()
    {
        Debug.Log("To Left");
        if (_targetPosition.x > -_laneOffset)
        {
            _timeElapsed = 0;
            _targetPosition = new Vector3(_targetPosition.x - _laneOffset, transform.position.y, transform.position.z);
        }
    }

    private void TurnToRight()
    {
        Debug.Log("To Right");
        if (_targetPosition.x < _laneOffset)
        {
            _timeElapsed = 0;
            _targetPosition = new Vector3(_targetPosition.x + _laneOffset, transform.position.y, transform.position.z);
        }
    }
}
