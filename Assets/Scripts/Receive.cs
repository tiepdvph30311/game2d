using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receive : MonoBehaviour
{
    public static bool sendMesages;
    public static bool messageReceived;
    public int numberOfMessages;
    public int numberOfNoMesagesReceived;

    public Renderer render;

    public Color newColor;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
        messageReceived = false;
        numberOfMessages = 0;
        numberOfNoMesagesReceived = 0;
        sendMesages = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (sendMesages)
        {
            if (messageReceived){
                numberOfMessages++;
                if (numberOfMessages == 500)
                {
                    newColor = Color.red;
                    render.material.color = newColor;
                }
                if (numberOfMessages == 700)
                {
                    newColor = Color.yellow;
                    render.material.color = newColor;
                }
                if (numberOfMessages == 1000)
                {
                    newColor = Color.green;
                    render.material.color = newColor;
                }

                if (numberOfMessages == 1200)
                {
                    sendMesages = false;
                }
                Debug.Log("I have received " + numberOfMessages + " messages from the transmit script");
            }
            else
            {
                numberOfNoMesagesReceived++;
                Debug.Log("No messages received "+numberOfNoMesagesReceived);
            } 
        }
        
    }
}
