using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
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
	/// ChoreographyExecution represents an asynchronous Choreo execution. 
	/// This object can be used to retrieve the status of the execution (RUNNING, SUCCESS, ERROR, etc.)
	/// and, if the Choreo has completed successfully, its output values.
	/// </summary>
	public class ChoreographyExecution
	{
		private String _status = ResultSet.STATUS_UNKNOWN;
		private ResultSet _results = null;


		/// <summary>
		/// Gets or sets the TembooSession representing the Temboo account and application that were used
		/// to initiate execution of the Choreo. 
		/// </summary>
		/// <value>The session.</value>
		public TembooSession session { get; set; }

		/// <summary>
		/// Gets or sets the ID of this Choreo execution
		/// </summary>
		/// <value>The execution identifier.</value>
		public String Id { get; set; }

		/// <summary>
		/// Gets the current status of the Choreo execution.
		/// </summary>
		/// <value>The execution status of the Choreo.</value>
		public String Status 
		{ 
			get 
			{
				// If the Choreo is still running, query Temboo to get its current status
				if (this._status == ResultSet.STATUS_UNKNOWN || this._status == ResultSet.STATUS_RUNNING) 
				{
					String statusJSON = this.getStatusJSON (false);

					// Deserialize the status-info JSON returned by the Temboo platform as a ResultSet object and store them
					this._results =  new JavaScriptSerializer().Deserialize<ResultSet>(statusJSON);

					// If the Choreo has completed successfully, retrieve its outputs and store them
					if (this._results.Execution.Status == ResultSet.STATUS_SUCCESS) 
					{
						String resultsJSON = this.getStatusJSON (true);
						this._results = new JavaScriptSerializer().Deserialize<ResultSet>(resultsJSON);
					}
				}
				return this._results.Execution.Status;
			}
			set 
			{ 
				throw new TembooException ("Execution status cannot be externally set."); 
			}
		}

		/// <summary>
		/// Get the ResultSet containing the output values of this Choreo; may return null if the
		/// Choreo has not yet completed. (Use the ChoreographyExecution.Status property to determine
		/// whether the Choreo is still running.)
		/// </summary>
		/// <value>The ResultSet.</value>
		public ResultSet Results 
		{
			get 
			{
				return this._results;
			}
			set 
			{ 
				throw new TembooException ("Results cannot be externally set."); 
			}		
		}


		/// <summary>
		/// Utility method, to retrieve status information and, optionally, result values, for this 
		/// Choreo execution from the Temboo platform
		/// </summary>
		/// <returns>The status JSON.</returns>
		/// <param name="retrieveResults">If set to <c>true</c> retrieve results; otherwise retrieve only execution metadata.</param>
		protected String getStatusJSON(Boolean retrieveResults)
		{
			// Set up HTTP request
			String uri = "https://" + this.session.AccountName + ".temboolive.com/arcturus-web/api-1.0/choreo-executions/" +
				this.Id;

			if (retrieveResults) 
			{
				uri = uri + "?view=outputs";
			}
			return this.session.makeRequest ("GET", uri, null);
		}
	}
}

