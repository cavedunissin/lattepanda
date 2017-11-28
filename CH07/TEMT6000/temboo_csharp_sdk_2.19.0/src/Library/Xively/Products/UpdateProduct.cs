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

namespace Temboo.Library.Xively.Products
{
    /// <summary>
    /// UpdateProduct
    /// Updates an existing product batch.
    /// </summary>
    public class UpdateProduct : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the UpdateProduct Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public UpdateProduct(TembooSession session) : base(session, "/Library/Xively/Products/UpdateProduct")
        {
        }

         /// <summary>
         /// (required, string) The API Key provided by Xively.
         /// </summary>
         /// <param name="value">Value of the APIKey input for this Choreo.</param>
         public void setAPIKey(String value) {
             base.addInput ("APIKey", value);
         }
         /// <summary>
         /// (optional, json) Optional custom configuration for creating your product in JSON. If you use this field the other optional parameters will be ignored. See Choreo description and Xively documentation for details.
         /// </summary>
         /// <param name="value">Value of the CustomProduct input for this Choreo.</param>
         public void setCustomProduct(String value) {
             base.addInput ("CustomProduct", value);
         }
         /// <summary>
         /// (optional, json) Default device datastream JSON array. Every newly created device in this product will have this default datastream. Ex: [{"id":"channel1"},{"id":"demo"}].
         /// </summary>
         /// <param name="value">Value of the Datastreams input for this Choreo.</param>
         public void setDatastreams(String value) {
             base.addInput ("Datastreams", value);
         }
         /// <summary>
         /// (optional, string) Description of the product.
         /// </summary>
         /// <param name="value">Value of the Description input for this Choreo.</param>
         public void setDescription(String value) {
             base.addInput ("Description", value);
         }
         /// <summary>
         /// (optional, string) Name of the product.
         /// </summary>
         /// <param name="value">Value of the Name input for this Choreo.</param>
         public void setName(String value) {
             base.addInput ("Name", value);
         }
         /// <summary>
         /// (optional, string) Default device feed privacy settings. Valid values: "true", "false" (default). Note - leaving this blank will automatically change a private device feed to a public device feed.
         /// </summary>
         /// <param name="value">Value of the Private input for this Choreo.</param>
         public void setPrivate(String value) {
             base.addInput ("Private", value);
         }
         /// <summary>
         /// (required, string) The ID of the product you are trying to update.
         /// </summary>
         /// <param name="value">Value of the ProductID input for this Choreo.</param>
         public void setProductID(String value) {
             base.addInput ("ProductID", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A UpdateProductResultSet containing execution metadata and results.</returns>
        new public UpdateProductResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            UpdateProductResultSet results = new JavaScriptSerializer().Deserialize<UpdateProductResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the UpdateProduct Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class UpdateProductResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "ResponseStatusCode" output from this Choreo execution
        /// <returns>String - (integer) The response status code returned from Xively. For a successful product update, the code should be 200.</returns>
        /// </summary>
        public String ResponseStatusCode
        {
            get
            {
                return (String) base.Output["ResponseStatusCode"];
            }
        }
    }
}
