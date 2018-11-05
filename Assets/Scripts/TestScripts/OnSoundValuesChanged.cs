using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(InputManager))]
public class OnSoundValuesChanged : MonoBehaviour
{
    private InputManager _inputMan;

    private void Start()
    {
        _inputMan = GetComponent<InputManager>();
    }

    public void OnSliderValueChanged(float value)
    {
        _inputMan.m_soundPitch = value;
    }

    public void OnToggleValueChanged(bool value)
    {
        _inputMan.m_lightState = value;
    }
}
