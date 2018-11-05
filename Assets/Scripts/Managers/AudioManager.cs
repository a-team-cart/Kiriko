using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public UDPSend UDPScript;
    private InputManager _inputMan;

    // Use this for initialization
    void Start () {
        _inputMan = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update () {
        UDPScript.SendData(_inputMan.m_soundPitch);
	}
}
