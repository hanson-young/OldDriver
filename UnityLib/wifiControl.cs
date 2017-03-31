using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NativeWifi;
using System;
using System.Text;


public class wifiControl : MonoBehaviour {

    /// <summary>
    /// Converts a 802.11 SSID to a string.
    /// </summary>
    static string GetStringForSSID(Wlan.Dot11Ssid ssid)
    {
        return Encoding.ASCII.GetString(ssid.SSID, 0, (int)ssid.SSIDLength);
    }
    public string wifiName = "HeilsCare";
    public string passWord = "hske8888";
    private string wifiXml = "";
    public uint wlanSignalQuality = 0;
    WlanClient client;
    public void ConnectWifi()
    {
        bool wifiInList = false;
        try
        {
            foreach (WlanClient.WlanInterface wlanIface in client.Interfaces)
            {
                // Lists all networks with WEP security
                Wlan.WlanAvailableNetwork[] networks = wlanIface.GetAvailableNetworkList(0);
                foreach (Wlan.WlanAvailableNetwork network in networks)
                {
                    if (network.dot11DefaultCipherAlgorithm == Wlan.Dot11CipherAlgorithm.WEP)
                    {
                        Debug.Log("Found WEP network with SSID {0}." + GetStringForSSID(network.dot11Ssid));
                    }
                }

                // Retrieves XML configurations of existing profiles.
                // This can assist you in constructing your own XML configuration
                // (that is, it will give you an example to follow).
                foreach (Wlan.WlanProfileInfo profileInfo in wlanIface.GetProfiles())
                {
                    string name = profileInfo.profileName; // this is typically the network's SSID

                    string xml = wlanIface.GetProfileXml(profileInfo.profileName);
                    if(name == wifiName)
                    {
                        wifiXml = xml;
                        wifiInList = true;
                    }
                }
                if (wifiInList)
                {
                    // Connects to a known network with WEP security
                    if (wlanIface.InterfaceState == Wlan.WlanInterfaceState.Disconnected || wlanIface.CurrentConnection.profileName != wifiName)
                    {
                        string profileName = wifiName; // this is also the SSID
                        string mac = StringToHex(profileName);
                        string key = passWord;
                        string profileXml = string.Format(wifiXml, profileName, mac, key);
                        wlanIface.SetProfile(Wlan.WlanProfileFlags.AllUser, profileXml, true);
                        wlanIface.Connect(Wlan.WlanConnectionMode.Profile, Wlan.Dot11BssType.Any, profileName);
                        Debug.Log(wifiName + " is connecting!");
                    }
                    else
                    {
                        Debug.Log(wifiName + " has connected!");
                        Debug.Log("name：" + wlanIface.CurrentConnection.profileName);
                        wlanSignalQuality = wlanIface.CurrentConnection.wlanAssociationAttributes.wlanSignalQuality;
                        Debug.Log("信号强度：" + wlanSignalQuality);
                    }
                }
                else
                {
                    Debug.Log(wifiName + " Dont exist!");
                }


            }
        }
        catch(Exception ex)
        {
            Debug.Log(ex);
        }

    }
    public static string StringToHex(string str)
    {
        StringBuilder sb = new StringBuilder();
        byte[] byStr = System.Text.Encoding.Default.GetBytes(str); //默认是System.Text.Encoding.Default.GetBytes(str)
        for (int i = 0; i < byStr.Length; i++)
        {
            sb.Append(Convert.ToString(byStr[i], 16));
        }

        return (sb.ToString().ToUpper());
    }
	// Use this for initialization
	void Start () {
        client = new WlanClient();
        ConnectWifi();
	}
	
	// Update is called once per frame
	void Update () {
        ConnectWifi();
	}
}
