using UnityEngine;
using System.Collections.Generic;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;

public class Channel {

	private const int CONNECTION_CLOSED_CODE = 10054;

	private UdpClient udpSend = new UdpClient();
    private UdpClient udpReceive = new UdpClient();
    private System.Object bufferLock = new System.Object();
	private List<Packet> packetBuffer = new List<Packet>();

    private Thread receiveThread;
	public Channel(string ip, int port) {
		try {
            udpReceive.Client.Bind(new IPEndPoint(IPAddress.Any, 42069));
            udpSend.Connect(new IPEndPoint(IPAddress.Parse(ip), 42069));
            //udpClient.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            receiveThread = new Thread(Receive);
            receiveThread.Start();
        } catch (Exception e) {
			Debug.Log("could not connect socket: " + e.Message);
		}
	}

	public void Disconnect() {
		if (udpSend != null) {
			Debug.Log("socket closed");
			udpSend.Close();
			udpSend = null;
		}
        if (udpReceive != null) {
            Debug.Log("socket closed");
            udpReceive.Close();
            udpReceive = null;
        }
    }

	public Packet GetPacket() {
		Packet packet = null;
		lock (bufferLock) {
			if (packetBuffer.Count > 0) {
				packet = packetBuffer[0];
				packetBuffer.RemoveAt(0);
			}
		}
		return packet;
	}

	private void Receive() {
		IPEndPoint endPoint = new IPEndPoint(IPAddress.None, 0);
        Debug.Log("Listening");
        EndPoint remoteEndPoint = (EndPoint) endPoint;
        Debug.Log("Listening");
        Debug.Log("Listening");
        while (udpReceive != null) {
			try {
                Debug.Log("Listening");
                Packet packet = Packet.Obtain();
                Debug.Log("Listening");
                int byteCount = udpReceive.Client.ReceiveFrom(packet.buffer.GetBuffer().GetBuffer(), ref remoteEndPoint);
                Debug.Log("received bytes " + byteCount);
				packet.buffer.SetAvailableByteCount(byteCount);
				lock (bufferLock) {
					packetBuffer.Add(packet);
				}
			} catch (SocketException e) {
				if (e.ErrorCode != CONNECTION_CLOSED_CODE) {
					Debug.Log("SocketException while reading from socket: " + e + " (" + e.ErrorCode + ")");
				}
			} catch (Exception e) {
				Debug.Log("Exception while reading from socket: " + e);
			}
		}
	}

	public void Send(Packet packet) {		
		if (udpSend != null) {
            Debug.Log("send " + packet.buffer.GetAvailableByteCount());
			int s = udpSend.Send(packet.buffer.GetBuffer().GetBuffer(), packet.buffer.GetAvailableByteCount());
            Debug.Log("Sent: " + s);
		}
	}

	private string ByteArrayToString(byte[] data, int length) {
		StringBuilder sb = new StringBuilder();
		for (int i = 0; i < length; i++) {
			sb.Append(data[i]).Append(", ");
		}
		return sb.ToString();
	}
    public void abortThread()
    {
        Disconnect();
        receiveThread.Abort();
     
    }

}
