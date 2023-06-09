using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class mqttController1 : MonoBehaviour
{
    public string nameController = "Controller 1";
    public string tagOfTheMQTTReceiver="Receiver1";
    public mqttReceiver1 _eventSender;

    //void Start()
    //{
    //  _eventSender=GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent<mqttReceiver1>();
    //  _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    //}

    void Start()
    {
        _eventSender = null;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver);
        if (gameObjects.Length > 0)
        {
            _eventSender = gameObjects[0].gameObject.GetComponent<mqttReceiver1>();
            if (_eventSender != null)
            {
                _eventSender.OnMessageArrived += OnMessageArrivedHandler;
                _eventSender.Publish("sample", "sample");
            }
        }

    }

    private void OnMessageArrivedHandler(string newMsg)
  {
  	
  	this.GetComponent<TextMeshPro>().text = newMsg;
  	
    Debug.Log("Event Fired. The message, from Object " +nameController+" is = " + newMsg);
  }
}