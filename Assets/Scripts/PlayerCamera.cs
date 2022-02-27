using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private float panSpeed = 5f;
    [SerializeField] private Vector3 positionOffset = new Vector3(0f, 0f, -8f);
    [SerializeField] private Vector3 rotationOffset = new Vector3(0f, 0f, 0f);

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.SetPositionAndRotation(Vector3.Lerp(transform.position, target.transform.position + positionOffset, panSpeed * Time.deltaTime), Quaternion.Euler(rotationOffset));
    }
}
