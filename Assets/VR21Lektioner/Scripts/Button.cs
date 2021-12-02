using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] float threshold = 0.1f;
    [SerializeField] float deadZone = 0.0125f;
    [SerializeField] UnityEvent onPressed;
    [SerializeField] UnityEvent onReleased;
    bool hasBeenPressed = false;
    Vector3 startPosition;
    ConfigurableJoint joint;

    void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasBeenPressed && GetValue() + threshold >= 1.0f)
        {
            StartPressEvent();
        }
        if (hasBeenPressed && GetValue() - threshold <= 0.0f)
        {
            StartRelseaseEvent();
        }
    }
    private float GetValue()
    {
        float value = Vector3.Distance(startPosition, transform.localPosition) / joint.linearLimit.limit;

        if (Mathf.Abs(value) < deadZone)
        {
            value = 0.0f;
        }
        Debug.Log(value);

        return Mathf.Clamp(value, -1.0f, 1.0f);
    }

    private void StartRelseaseEvent()
    {
        Debug.Log("RELEASED!");
        hasBeenPressed = false;
        onReleased?.Invoke();
    }

    private void StartPressEvent()
    {
        Debug.Log("PRESSED");
        hasBeenPressed = true;
        onPressed?.Invoke();
    }
}
