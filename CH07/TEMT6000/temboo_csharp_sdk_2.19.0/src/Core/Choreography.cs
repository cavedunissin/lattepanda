using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;

/*
Copyright 2014 Temboo, Inc.

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

namespace Temboo.Core
{
	/// <summary>
	/// Choreography is the superclass for a runnable Temboo process. This class contains the high-level
	/// logic for configuring the inputs for a Temboo Choreo, and to executing the Choreo synchronously
	/// or asynchronously.
	/// </summary>
	public class Choreography
	{
		private static readonly String SDK_IDENTIFIER = "C#SDK_2.19.0";

		private String choreoPath;
		private TembooSession session;
		private InputSet inputs;

		/// <summary>
		/// Initializes a new instance of the <see cref="Temboo.Core.Choreography"/> class.
		/// </summary>
		/// <param name="session">A TembooSession object, representing a valid set of Application credentials within a specified Temboo account.</param>
		/// <param name="choreoPath">The URI path identifying the Choreo to be executed.</param>
		public Choreography(TembooSession session, String choreoPath) 
		{
			this.choreoPath = choreoPath;
			this.session = session;
			this.inputs = new InputSet();
		}

		/// <summary>
		/// Add a named input value to this Choreo.
		/// </summary>
		/// <param name="name">The name of the input</param>
		/// <param name="value">The input value.</param>
		public void addInput(String name, String value) 
		{
			this.inputs.addInput(name, value);
		}

        /// <summary>
        /// Add an output filter to this Choreo.
        /// </summary>
        /// <param name="name">The name of the result</param>
        /// <param name="path">The xpath to filter with.</param>
        /// <param name="variable">The output variable to apply the filter to.</param>
        public void addOutputFilter(String name, String path, String variable)
        {
            this.inputs.addOutputFilter(name, path, variable);
        }

		/// <summary>
		/// Set the Credential (stored on the Temboo platform) to use with this Choreo execution.
		/// </summary>
		/// <param name="credentialName">Credential name.</param>
		public void setCredential(String credentialName)
		{
			this.inputs.preset = credentialName;
		}

        public void addProfile(String profileName)
        {
            this.inputs.preset = profileName;
        }

		/// <summary>
		/// Execute the Temboo Choreo synchronously, blocking until the Choreo completes and returning
		/// a ResultSet object representing its output. 
		/// </summary>
		public ResultSet execute()
		{
			// Make the web request and get the response JSON
			String responseJSON = this.getResponseJSON(false, true);

			// Deserialize the result data into a ResultSet
			ResultSet results = new JavaScriptSerializer().Deserialize<ResultSet>(responseJSON);

			// Note that we may actually have run into an exception while trying to execute
			// this request; if so, then throw an appropriate exception
			if(results.Execution.Status != ResultSet.STATUS_SUCCESS)
			{
				throw new TembooException (results.Execution.LastError);
			}
			return results;
		}

		/// <summary>
		/// Execute the Temboo Choreo as a "fire and forget" operation, without returning its output
		/// </summary>
		public void executeNoResults()
		{
			this.getResponseJSON(true, false);
		}

		/// <summary>
		/// Execute the Temboo Choreo asynchronously. Rather than blocking for completion of the Choreo and returning its
		/// results, this method returns a ChoreographyExecution object which can be used to monitor the status of the Choreo
		/// (running, completed, etc.) and retrieve its results at a later time.
		/// </summary>
		/// <returns>The ChoreographyExecution object which can be used to monitor this Choreo execution.</returns>
		public ChoreographyExecution executeAsync()
		{
			// Send the HTTP request to Temboo, to kick off Choreo execution
			String responseJSON = this.getResponseJSON (true, true);

			// Deserialize the result data into a ChoreoExecution.
			ChoreographyExecution executionInfo = new JavaScriptSerializer().Deserialize<ChoreographyExecution>(responseJSON);

			// Make sure the ChoreoExecution object has access to the session object, so that it can
			// appropriately authenticate itself for later status checks.
			executionInfo.session = this.session;
			return executionInfo;
		}

		/// <summary>
		/// Perform an HTTP POST operation to execute this Choreo on the Temboo platform, and return the response value
		/// as an unparsed JSON string. The JSON returned by this method may represent either a successful or unsuccessful
		/// execution attempt; it's the responsibility of the calling method to distinguish between the two.
		/// </summary>
		/// <returns>The response JSON.</returns>
		/// <param name="async">If set to <c>true</c>, run this Choreo asynchronously.</param>
		/// <param name="storeResults">If set to <c>true</c> store the results of this Choreo for future retrieval.</param>
		protected String getResponseJSON(Boolean async, Boolean storeResults)
		{
			// Set up HTTP request path
			String uri = "https://" + this.session.AccountName + ".temboolive.com/arcturus-web/api-1.0/choreos" +
				this.choreoPath + "?source_id=" + WebUtility.UrlEncode(SDK_IDENTIFIER);

			// Configure any needed querystring parameters
			if (async) 
			{
				uri = uri + "&mode=async";
				if (storeResults)
					uri = uri + "&store_results=true";
				else
					uri = uri + "&store_results=false";
			}

			// Make the request, and return the response body
			return this.session.makeRequest ("POST", uri, new JavaScriptSerializer ().Serialize (this.inputs));
		}
	}

	/// <summary>
	/// InputSet represents a set of structured input arguments to be supplied when running a Temboo Choreo.
	/// </summary>
	class InputSet
	{
		// To faciliate serialization of this object in the format that the Temboo platform 
		// expects, the set of input items needs to be stored as a list rather than a hashtable.
		public InputSet() 
		{
			inputs = new List<InputItem>();
            outputFilters = new List<OutputFilter>();
		}

		/// <summary>
		/// Sets the name of the Credential object to be used when executing the Choreo
		/// </summary>
		/// <value>The Credential name.</value>
		public String preset { get; set; }

		/// <summary>
		/// Gets or sets the set of InputItems describing the input values to be used when executing the Choreo.
		/// </summary>
		/// <value>The inputs.</value>
		public List<InputItem> inputs { get; set; }

        public List<OutputFilter> outputFilters { get; set; }

		/// <summary>
		/// Add a named input key/value pair to the execution-configuration of this Choreo
		/// </summary>
		/// <param name="name">Input name.</param>
		/// <param name="value">Input value.</param>
		public void addInput(String name, String value) 
		{
			Boolean found = false;
			foreach(InputItem i in this.inputs) 
			{
				if(i.name.Equals(name)) 
				{
					i.value = value;
					found = true;
					break;
				}
			}
			if(!found) 
			{
				InputItem i = new InputItem (name, value);
				this.inputs.Add (i);
			}
		}

        public void addOutputFilter(String filterName, String path, String outputVariableSource)
        {
            this.outputFilters.Add(new OutputFilter(filterName, path, outputVariableSource));
        }

	}

	/// <summary>
	/// InputItem represents a single key/value pair supplied as an argument to this Choreo; this class
	/// is used primarily for JSON serialization.
	/// </summary>
	class InputItem 
	{
		public InputItem(String name, String value) 
		{
			this.name = name;
			this.value = value;
		}
		public String name { get; set; }
		public String value { get; set; }
	}

    class OutputFilter
    {
        public OutputFilter(String theFilterName, String thePath, String theOutputVariableSource)
        {
            this.name = theFilterName;
            this.path = thePath;
            this.variable = theOutputVariableSource;
        }

        public String name { get; set; }
        public String path { get; set; }
        public String variable { get; set; }
    }
}

