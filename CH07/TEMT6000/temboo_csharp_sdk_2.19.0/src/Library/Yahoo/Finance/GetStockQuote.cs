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

namespace Temboo.Library.Yahoo.Finance
{
    /// <summary>
    /// GetStockQuote
    /// Retrieves information for the specified stock symbol from Yahoo Finance.
    /// </summary>
    public class GetStockQuote : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the GetStockQuote Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public GetStockQuote(TembooSession session) : base(session, "/Library/Yahoo/Finance/GetStockQuote")
        {
        }

         /// <summary>
         /// (optional, string) The format that the response should be in. Valid values are: json (the default) and xml.
         /// </summary>
         /// <param name="value">Value of the ResponseFormat input for this Choreo.</param>
         public void setResponseFormat(String value) {
             base.addInput ("ResponseFormat", value);
         }
         /// <summary>
         /// (required, string) The stock ticker symbol to search for (e.g., AAPL, GOOG, etc).
         /// </summary>
         /// <param name="value">Value of the StockSymbol input for this Choreo.</param>
         public void setStockSymbol(String value) {
             base.addInput ("StockSymbol", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A GetStockQuoteResultSet containing execution metadata and results.</returns>
        new public GetStockQuoteResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            GetStockQuoteResultSet results = new JavaScriptSerializer().Deserialize<GetStockQuoteResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the GetStockQuote Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class GetStockQuoteResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Ask" output from this Choreo execution
        /// <returns>String - (decimal) The asking price.</returns>
        /// </summary>
        public String Ask
        {
            get
            {
                return (String) base.Output["Ask"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Bid" output from this Choreo execution
        /// <returns>String - (decimal) The bid price.</returns>
        /// </summary>
        public String Bid
        {
            get
            {
                return (String) base.Output["Bid"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Change" output from this Choreo execution
        /// <returns>String - (string) The change in the stock price.</returns>
        /// </summary>
        public String Change
        {
            get
            {
                return (String) base.Output["Change"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "DaysHigh" output from this Choreo execution
        /// <returns>String - (decimal) The high price of the day.</returns>
        /// </summary>
        public String DaysHigh
        {
            get
            {
                return (String) base.Output["DaysHigh"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "DaysLow" output from this Choreo execution
        /// <returns>String - (decimal) The low price of the day.</returns>
        /// </summary>
        public String DaysLow
        {
            get
            {
                return (String) base.Output["DaysLow"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "LastTradePriceOnly" output from this Choreo execution
        /// <returns>String - (decimal) The last trade price.</returns>
        /// </summary>
        public String LastTradePriceOnly
        {
            get
            {
                return (String) base.Output["LastTradePriceOnly"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Open" output from this Choreo execution
        /// <returns>String - (decimal) The price when the market last opened.</returns>
        /// </summary>
        public String Open
        {
            get
            {
                return (String) base.Output["Open"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "PreviousClose" output from this Choreo execution
        /// <returns>String - (decimal) The previous closing price.</returns>
        /// </summary>
        public String PreviousClose
        {
            get
            {
                return (String) base.Output["PreviousClose"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Volume" output from this Choreo execution
        /// <returns>String - (integer) The volume traded.</returns>
        /// </summary>
        public String Volume
        {
            get
            {
                return (String) base.Output["Volume"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "YearHigh" output from this Choreo execution
        /// <returns>String - (decimal) The price for the year high.</returns>
        /// </summary>
        public String YearHigh
        {
            get
            {
                return (String) base.Output["YearHigh"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "YearLow" output from this Choreo execution
        /// <returns>String - (decimal) The price for the year low.</returns>
        /// </summary>
        public String YearLow
        {
            get
            {
                return (String) base.Output["YearLow"];
            }
        }
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - The response from Yahoo Finance.</returns>
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
