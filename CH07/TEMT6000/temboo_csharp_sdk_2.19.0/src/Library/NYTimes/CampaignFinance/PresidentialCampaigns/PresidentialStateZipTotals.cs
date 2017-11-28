using System;
using Temboo.Core;
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

namespace Temboo.Library.NYTimes.CampaignFinance.PresidentialCampaigns
{
    /// <summary>
    /// PresidentialStateZipTotals
    /// Retrieve the total amount of donations aggregated by a specified location (by state and/or zipcode).
    /// </summary>
    public class PresidentialStateZipTotals : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the PresidentialStateZipTotals Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public PresidentialStateZipTotals(TembooSession session) : base(session, "/Library/NYTimes/CampaignFinance/PresidentialCampaigns/PresidentialStateZipTotals")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by NY Times.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (required, integer) Enter the campaign cycle year in YYYY format.  This must be an even year. 
         /// </summary>
         /// <param name="value">Value of the CampaignCycle input for this Choreo.</param>
         public void setCampaignCycle(String value) {
             base.addInput ("CampaignCycle", value);
         }
         /// <summary>
         /// (required, string) Enter the location for which data will be retrieved. If ResourceType = states, use a two-letter state abbreviation (example: NY).  For zips, enter a five-digit zip code.
         /// </summary>
         /// <param name="value">Value of the Location input for this Choreo.</param>
         public void setLocation(String value) {
             base.addInput ("Location", value);
         }
         /// <summary>
         /// (required, string) Specify the type of resource to use when retrieving donor data. Valid formats include: zips, or states.
         /// </summary>
         /// <param name="value">Value of the ResourceType input for this Choreo.</param>
         public void setResourceType(String value) {
             base.addInput ("ResourceType", value);
         }
         /// <summary>
         /// (optional, string) Enter json or xml.  Default is json.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A PresidentialStateZipTotalsResultSet containing execution metadata and results.</returns>
        new public PresidentialStateZipTotalsResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            PresidentialStateZipTotalsResultSet results = new JavaScriptSerializer().Deserialize<PresidentialStateZipTotalsResultSet>(json);

            // Note that we may actually have run into an exception while trying to execute
            // this request; if so, then throw an appropriate exception
            if (results.Execution.LastError != null)
            {
                throw new TembooException(results.Execution.LastError);
            }
            return results;
        }

    }

    /// <summary>
    /// A ResultSet with methods tailored to the values returned by the PresidentialStateZipTotals Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class PresidentialStateZipTotalsResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from the NY Times API corresponds to the setting (json, or xml) entered in the ResponseFormat variable.  Default is set to json.</returns>
        /// </summary>
        public String Response
        {
            get
            {
                return (String) base.Output["Response"];
            }
        }
    }
}
