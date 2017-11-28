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

namespace Temboo.Library.Kiva.Loans
{
    /// <summary>
    /// SearchLoans
    /// Returns a keyword search for loan listings by multiple criteria.
    /// </summary>
    public class SearchLoans : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the SearchLoans Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public SearchLoans(TembooSession session) : base(session, "/Library/Kiva/Loans/SearchLoans")
        {
        }

         /// <summary>
         /// (optional, string) Your unique application ID, usually in reverse DNS notation.
         /// </summary>
         /// <param name="value">Value of the AppID input for this Choreo.</param>
         public void setAppID(String value) {
             base.addInput ("AppID", value);
         }
         /// <summary>
         /// (optional, string) A list of two-character ISO codes of countries by which to filter results.
         /// </summary>
         /// <param name="value">Value of the CountryCode input for this Choreo.</param>
         public void setCountryCode(String value) {
             base.addInput ("CountryCode", value);
         }
         /// <summary>
         /// (optional, string) If supplied, results are filtered to loans with entrepreneurs of the specified gender. In the case of group loans, this matches against the predominate gender in the group: male or female.
         /// </summary>
         /// <param name="value">Value of the Gender input for this Choreo.</param>
         public void setGender(String value) {
             base.addInput ("Gender", value);
         }
         /// <summary>
         /// (optional, integer) The page position of results to return. Defaults to 1.
         /// </summary>
         /// <param name="value">Value of the Page input for this Choreo.</param>
         public void setPage(String value) {
             base.addInput ("Page", value);
         }
         /// <summary>
         /// (optional, string) A list of partner IDs for which to filter results.
         /// </summary>
         /// <param name="value">Value of the Partner input for this Choreo.</param>
         public void setPartner(String value) {
             base.addInput ("Partner", value);
         }
         /// <summary>
         /// (optional, string) A query string against which results should be returned.
         /// </summary>
         /// <param name="value">Value of the Query input for this Choreo.</param>
         public void setQuery(String value) {
             base.addInput ("Query", value);
         }
         /// <summary>
         /// (optional, string) List of two-letter codes corresponding to regions in which Kiva operates. If supplied, results are filtered to loans only from the specified regions: na, ca, sa, af, as, me, ee.
         /// </summary>
         /// <param name="value">Value of the Region input for this Choreo.</param>
         public void setRegion(String value) {
             base.addInput ("Region", value);
         }
         /// <summary>
         /// (optional, string) Output returned can be XML or JSON. Defaults to JSON.
         /// </summary>
         /// <param name="value">Value of the ResponseType input for this Choreo.</param>
         public void setResponseType(String value) {
             base.addInput ("ResponseType", value);
         }
         /// <summary>
         /// (optional, string) A list of business sectors for which to filter results.
         /// </summary>
         /// <param name="value">Value of the Sector input for this Choreo.</param>
         public void setSector(String value) {
             base.addInput ("Sector", value);
         }
         /// <summary>
         /// (optional, string) The order by which to sort results. Acceptable values: popularity, loan_amount, oldest, expiration, newest, amount_remaining, repayment_term. Defaults to newest.
         /// </summary>
         /// <param name="value">Value of the SortBy input for this Choreo.</param>
         public void setSortBy(String value) {
             base.addInput ("SortBy", value);
         }
         /// <summary>
         /// (optional, string) The status of loans to return: fundraising, funded, in_repayment, paid, ended_with_loss.
         /// </summary>
         /// <param name="value">Value of the Status input for this Choreo.</param>
         public void setStatus(String value) {
             base.addInput ("Status", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A SearchLoansResultSet containing execution metadata and results.</returns>
        new public SearchLoansResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            SearchLoansResultSet results = new JavaScriptSerializer().Deserialize<SearchLoansResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the SearchLoans Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class SearchLoansResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Kiva.</returns>
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
