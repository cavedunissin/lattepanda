using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;
using LattePanda.Firmata;

namespace DHT
{
    class Program
    {
        const string WRITEKEY = "THINGSPEAK_KEY_HERE"; //ThingSpeak Key
        const int DELAY = 20;          //Delay time for send packet to ThingSpeak
        const int GET_TEMPERATURE = 0x47;
        const int GET_FAHRENHEIT = 0x48;
        const int GET_HUMIDITY = 0x49;
        static void Main(string[] args)
        {
            Arduino arduino = new Arduino();
            while (true)
            {
                Console.WriteLine("Receiving sensor data...");
                arduino.DHT(GET_TEMPERATURE); 
//For Fahrenheit : GET_FAHRENHEIT
                Thread.Sleep(2000);
                string temp = arduino.STRING_DHT;
                //
                arduino.DHT(GET_HUMIDITY);
                Thread.Sleep(2000);
                string hum = arduino.STRING_DHT;
                try
                {
                    string rec = "";
                    string strUpdateBase = "http://api.ThingSpeak.com/update";
                    string strUpdateURI = strUpdateBase + "?key=" + WRITEKEY;

                    strUpdateURI += "&field1=" + temp;
                    strUpdateURI += "&field2=" + hum;

                    HttpWebRequest request = WebRequest.Create(strUpdateURI) as HttpWebRequest;
                    request.Timeout = 5000;
                    request.Proxy = null;
                    //request.Accept = "application/xrds+xml";  
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    WebHeaderCollection header = response.Headers;
                    var encoding = ASCIIEncoding.ASCII;
                    using (var reader = new System.IO.StreamReader(response.GetResponseStream(), encoding))
                    {
                        rec = reader.ReadToEnd();
                        Console.WriteLine("The data was successfully sent. Node Number: " + rec);
                        Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy - HH:mm:ss") + "      Temperature: " + temp + " °C" + "       Humidity: " + hum+" %");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Thread.Sleep(1000);
                for (int i = 0; i ＜= DELAY; i++)
                {                 
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.WriteLine();
            }
        }
    }
}
