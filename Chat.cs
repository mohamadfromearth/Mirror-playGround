using System;
using Mirror;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class Chat : NetworkBehaviour
{
    private TMP_InputField chatInput;
    private static String chatsList = "";

    private Button button;
    private TMP_Text chatText;


    public override void OnStartAuthority()
    {
        base.OnStartAuthority();
        CmdPlayerJoined();
    }


    private void Start()
    {
        chatText = GameObject.FindWithTag("ChatText").GetComponent<TMP_Text>();
        button = GameObject.FindWithTag("SendBtn").GetComponent<Button>();
        chatInput = GameObject.FindWithTag("ChatInput").GetComponent<TMP_InputField>();
        button.onClick.AddListener(OnSendClick);
    }


    [Command]
    private void CmdSendMessage(string message)
    {
        chatsList += $"\n player {connectionToClient.connectionId}: {message}";
        RpcOnGetMessage(chatsList);
    }


    [Command]
    private void CmdPlayerJoined()
    {
        chatsList += $"\n Player {connectionToClient.connectionId} has joined";
        RpcOnGetMessage(chatsList);
    }

    [ClientRpc]
    private void RpcOnGetMessage(String message)
    {
        chatText.text = message;
    }


    private void ChatChange(String oldValue, String newValue)
    {
        chatText.text = newValue;
    }


    private void OnSendClick()
    {
        Debug.Log("SendMessage");
        CmdSendMessage(chatInput.text);
    }
}