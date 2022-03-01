using EventSystem;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ControlDropdown : MonoBehaviour
{
    private TMP_Dropdown _dropdown;

    void Start()
    {
        _dropdown = transform.GetComponent<TMP_Dropdown>();
        //_dropdown.onValueChanged.AddListener(delegate { DropdownValueChanged(_dropdown); });
        FillDropdown();
    }

    private void FillDropdown()
    {
        _dropdown.options?.Clear();

        List<string> controlTypes = new List<string>();
        controlTypes.Add(TypeOfControl.Buttons.ToString());
        controlTypes.Add(TypeOfControl.Drag.ToString());
        controlTypes.Add(TypeOfControl.Swipe.ToString());

        _dropdown.AddOptions(controlTypes);
    }

    public void DropdownValueChanged()
    {
        if (Enum.IsDefined(typeof(TypeOfControl), _dropdown.value))
        {
            TypeOfControl control = (TypeOfControl)_dropdown.value;
            Events.onControlChanged.Invoke(control);
        }
        else
        {
            Debug.Log("Unknown value!");
        }
    }
}
