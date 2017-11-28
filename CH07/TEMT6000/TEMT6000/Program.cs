using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Threading;
using LattePanda.Firmata;

using Temboo.Core;
using Temboo.Library.Google.Spreadsheets;

namespace TEMT6000 {
    class Program {
        static void Main(string[] args) {
            int telemetry;

		    Console.WriteLine("Send telemetry to LPData...");
            Arduino arduino = new Arduino();
			telemetry = arduino.analogRead(0);
			telemetry = 700;
			Console.WriteLine(telemetry);
			Thread.Sleep(2000);

			// Instantiate the Choreo, using a previously instantiated TembooSession object, eg:
			TembooSession session = new TembooSession("lct4246", "LPData", "txu6DUoYFWvfCMfrZBJUJdlS11clrqHc");
			AppendRow appendRowChoreo = new AppendRow(session);

			// Set inputs
			appendRowChoreo.setRowData(telemetry.ToString());
			appendRowChoreo.setSpreadsheetTitle("LPData");
			appendRowChoreo.setRefreshToken("1/7gvryqzF14y0PX-UqMlO7lYReiV3gGgB23EitXogyjA");
			appendRowChoreo.setClientSecret("V2GLpLiBCODTmUh76fgwoY9h");
			appendRowChoreo.setClientID("227709529785-vk6q6g45mlrisj7vjeflma45hp18ndqd.apps.googleusercontent.com");

            // Execute Choreo
            AppendRowResultSet appendRowResults = appendRowChoreo.execute();
        } //end of class
    }//end of main
} //end of namespace