using UnityEngine;
using System.Collections;

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

/// <summary>
/// This script establishes a UDP connection via pre-defined IP
/// and network params. Any program listening to the port defined
/// in the init (int port) can receive sent messages in ASCII form.
/// 
/// The only publicly modifiable param should be the port number
/// for testing purposes.
/// 
/// Code derived from https://forum.unity.com/threads/simple-udp-implementation-send-read-via-mono-c.15900/
/// Modified & formatted by Ali Egseem
/// </summary>

public class UDPSend : MonoBehaviour
{
    private static int localPort;
    private string IP;  // define in init
    public int port;  // define in init
    public string strMessage = "";

    IPEndPoint remoteEndPoint;
    UdpClient client;

    // call it from shell (as program)
    private static void Main()
    {
        UDPSend sendObj = new UDPSend();
        sendObj.init();
    }

    // init connection and params as soon as the object is instanciated
    public void Start()
    {
        init();
    }

    public void init()
    {
        // Define end point , from which the messages are sent.
        print("UDPSend.init()");

        // Define network params
        IP = "127.0.0.1";
        port = 8001;

        // Define remote points
        remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
        client = new UdpClient();

        // Debug status
        print("Sending to " +IP + " : " +port);
        print("Testing: nc - lu " +IP + " : " +port);
        sendString("jt");
    }

    private void inputFromConsole()
    {
        try
        {
            string text;
            do
            {
                text = Console.ReadLine();

                if (text != "")
                {
                    // Encode data using the UTF8 encoding to binary format.
                    byte[] data = Encoding.UTF8.GetBytes(text);

                    // Send the text to the remote client.
                    client.Send(data, data.Length, remoteEndPoint);
                }
            } while (text != "");
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    //Sends info through client, ASCII encoded
    //Call this when you need to send a message!!
    private void sendString(string message)
    {
        try
        {
            if (message != "")
            {
                // Encode data using the UTF8 encoding to binary format.
                byte[] data = Encoding.UTF8.GetBytes(message);

                // Send the message to the remote client.
                client.Send(data, data.Length, remoteEndPoint);
            }
        }
        catch (Exception err)
        {
            print(err.ToString());
        }
    }

    void Update()
    {
        //send test string on update to see if max updates consistently
        sendString("woahboy");
    }
}
