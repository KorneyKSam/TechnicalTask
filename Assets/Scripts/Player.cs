using UnityEngine;
using EventSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private AnimationCurve _curve;
    [SerializeField] private float _speed = 0.5f;
    [SerializeField] private Transform _playerTransform;
    private Vector3 _newPosition;

    private Vector3 leftPosition = new Vector3(-6, 0, 0);
    private Vector3 rightPosition = new Vector3(6, 0, 0);

    private void FixedUpdate()
    {
        transform.localPosition = Vector3.Lerp(transform.localPosition, _newPosition, Time.deltaTime);
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
        _newPosition = leftPosition;
        Debug.Log("To Left");
    }

    private void TurnToRight()
    {
        _newPosition = rightPosition;
        Debug.Log("To Right");
    }
}
