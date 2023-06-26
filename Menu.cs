using System;
using System.Collections;
using System.Collections.Generic;
using Mirror;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private TMP_InputField hostInput;

    
    
    public void OnHostClick()
    {
        NetworkManager.singleton.StartHost();
    }

    public void OnJoinClick()
    {
        NetworkManager.singleton.networkAddress = hostInput.text;
        NetworkManager.singleton.StartClient();
    }

    public void OnStopServerClick()
    {
        NetworkManager.singleton.StopHost();
    }

    public void OnStopClient()
    {
        NetworkManager.singleton.StartClient();
    }
}