using LattePanda.Firmata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WelcomeLP
{
    public partial class WelcomeLP : Form
    {
        int telemetry;
        Arduino arduino = new Arduino();

        public WelcomeLP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonLEDSW_Click(object sender, EventArgs e)
        {
            arduino.pinMode(13, Arduino.OUTPUT);//Set the digital pin 13 as output
            
            // ==== set the led on or off
            arduino.digitalWrite(13, Arduino.HIGH);//set the LED　on
            Thread.Sleep(2000);//delay a seconds
            arduino.digitalWrite(13, Arduino.LOW);//set the LED　off
            Thread.Sleep(1000);//delay a seconds
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            for (int i=1; i<100; i++)
            {
                telemetry = arduino.analogRead(0);
                Thread.Sleep(100);
                labelFlameTelemetry.Text = telemetry.ToString();
                this.Refresh();
                Console.WriteLine(telemetry);
            } //end of for
        } //end of buttonStart_Click()
    } //end of WelcomeLP::
} //end of WelcomeLP