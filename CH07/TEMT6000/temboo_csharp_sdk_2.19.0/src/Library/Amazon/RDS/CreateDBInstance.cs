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

namespace Temboo.Library.Amazon.RDS
{
    /// <summary>
    /// CreateDBInstance
    /// Creates a new database instance.
    /// </summary>
    public class CreateDBInstance : Temboo.Core.Choreography
    {

        /// <summary>
        /// Create a new instance of the CreateDBInstance Choreo
        /// </summary>
        /// <param name="session">A TembooSession object, containing a valid set of Temboo credentials.</param>
        public CreateDBInstance(TembooSession session) : base(session, "/Library/Amazon/RDS/CreateDBInstance")
        {
        }

         /// <summary>
         /// (required, string) The Access Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSAccessKeyId input for this Choreo.</param>
         public void setAWSAccessKeyId(String value) {
             base.addInput ("AWSAccessKeyId", value);
         }
         /// <summary>
         /// (required, string) The Secret Key ID provided by Amazon Web Services.
         /// </summary>
         /// <param name="value">Value of the AWSSecretKeyId input for this Choreo.</param>
         public void setAWSSecretKeyId(String value) {
             base.addInput ("AWSSecretKeyId", value);
         }
         /// <summary>
         /// (required, integer) Storage amount (in gigabytes) to be configured for the DB. Use 5 to 1024 for MySQL , 10 to 1024 for Oracle, or 200 to 1024 for SQLServer.
         /// </summary>
         /// <param name="value">Value of the AllocatedStorage input for this Choreo.</param>
         public void setAllocatedStorage(String value) {
             base.addInput ("AllocatedStorage", value);
         }
         /// <summary>
         /// (optional, boolean) Indicates that minor engine upgrades will be applied to the DB Instance automatically during the maintenance window.
         /// </summary>
         /// <param name="value">Value of the AutoMinorVersionUpgrade input for this Choreo.</param>
         public void setAutoMinorVersionUpgrade(String value) {
             base.addInput ("AutoMinorVersionUpgrade", value);
         }
         /// <summary>
         /// (optional, string) The EC2 Availability Zone that the database instance will be created in (e.g. us-east-1a, us-east-1b, us-east-1c).
         /// </summary>
         /// <param name="value">Value of the AvailabilityZone input for this Choreo.</param>
         public void setAvailabilityZone(String value) {
             base.addInput ("AvailabilityZone", value);
         }
         /// <summary>
         /// (optional, integer) The number of days for which automated backups are retained. When set to a positive number, backups are enabled. Set to 0 to disable automated backups.
         /// </summary>
         /// <param name="value">Value of the BackupRetentionPeriod input for this Choreo.</param>
         public void setBackupRetentionPeriod(String value) {
             base.addInput ("BackupRetentionPeriod", value);
         }
         /// <summary>
         /// (optional, string) Indicates that the DB Instance should be associated with the specified CharacterSet.
         /// </summary>
         /// <param name="value">Value of the CharacterSetName input for this Choreo.</param>
         public void setCharacterSetName(String value) {
             base.addInput ("CharacterSetName", value);
         }
         /// <summary>
         /// (required, string) Capacity for the DB instance.  (db.t1.micro, db.m1.small, db.m1.large, db.m1.xlarge, db.m2.xlarge, db.m2.2xlarge, or db.m2.4xlarge).
         /// </summary>
         /// <param name="value">Value of the DBInstanceClass input for this Choreo.</param>
         public void setDBInstanceClass(String value) {
             base.addInput ("DBInstanceClass", value);
         }
         /// <summary>
         /// (required, string) The DB Instance identifier. Should be in all lowercase.
         /// </summary>
         /// <param name="value">Value of the DBInstanceIdentifier input for this Choreo.</param>
         public void setDBInstanceIdentifier(String value) {
             base.addInput ("DBInstanceIdentifier", value);
         }
         /// <summary>
         /// (conditional, string) For MySQL, this is the name of the db that is created on the instance. For Oracle, it refers to the SID. Must be null for SQLServer.
         /// </summary>
         /// <param name="value">Value of the DBName input for this Choreo.</param>
         public void setDBName(String value) {
             base.addInput ("DBName", value);
         }
         /// <summary>
         /// (optional, string) The name of the DB Parameter Group to associate with this DB instance. If this argument is omitted, the default DBParameterGroup for the specified engine will be used.
         /// </summary>
         /// <param name="value">Value of the DBParameterGroupName input for this Choreo.</param>
         public void setDBParameterGroupName(String value) {
             base.addInput ("DBParameterGroupName", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of up to 10 DB Security Groups to associate with this DB Instance.
         /// </summary>
         /// <param name="value">Value of the DBSecurityGroups input for this Choreo.</param>
         public void setDBSecurityGroups(String value) {
             base.addInput ("DBSecurityGroups", value);
         }
         /// <summary>
         /// (optional, string) A DB Subnet Group to associate with this DB Instance. When not specified, it indicates that this is a non-VPC DB instance.
         /// </summary>
         /// <param name="value">Value of the DBSubnetGroupName input for this Choreo.</param>
         public void setDBSubnetGroupName(String value) {
             base.addInput ("DBSubnetGroupName", value);
         }
         /// <summary>
         /// (required, string) The name of the database engine to use for the instance. Options are: MySQL, oracle-se1, oracle-se, oracle-ee, sqlserver-ee, sqlserver-se, sqlserver-ex, sqlserver-web.
         /// </summary>
         /// <param name="value">Value of the Engine input for this Choreo.</param>
         public void setEngine(String value) {
             base.addInput ("Engine", value);
         }
         /// <summary>
         /// (optional, string) The version number of the database engine to use.
         /// </summary>
         /// <param name="value">Value of the EngineVersion input for this Choreo.</param>
         public void setEngineVersion(String value) {
             base.addInput ("EngineVersion", value);
         }
         /// <summary>
         /// (optional, string) The amount of provisioned input/output operations per second to be initially allocated for the DB Instance.
         /// </summary>
         /// <param name="value">Value of the Iops input for this Choreo.</param>
         public void setIops(String value) {
             base.addInput ("Iops", value);
         }
         /// <summary>
         /// (optional, string) License model information for this DB Instance. Valid values are: license-included, bring-your-own-license, general-public-license.
         /// </summary>
         /// <param name="value">Value of the LicenseModel input for this Choreo.</param>
         public void setLicenseModel(String value) {
             base.addInput ("LicenseModel", value);
         }
         /// <summary>
         /// (required, password) The master password for the DB instance.
         /// </summary>
         /// <param name="value">Value of the MasterUserPassword input for this Choreo.</param>
         public void setMasterUserPassword(String value) {
             base.addInput ("MasterUserPassword", value);
         }
         /// <summary>
         /// (required, string) The master username for the DB instance.
         /// </summary>
         /// <param name="value">Value of the MasterUsername input for this Choreo.</param>
         public void setMasterUsername(String value) {
             base.addInput ("MasterUsername", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies if the DB Instance is a Multi-AZ deployment. You cannot set the AvailabilityZone parameter if the MultiAZ parameter is set to true.
         /// </summary>
         /// <param name="value">Value of the MultiAZ input for this Choreo.</param>
         public void setMultiAZ(String value) {
             base.addInput ("MultiAZ", value);
         }
         /// <summary>
         /// (optional, string) Indicates that the DB Instance should be associated with the specified option group.
         /// </summary>
         /// <param name="value">Value of the OptionGroupName input for this Choreo.</param>
         public void setOptionGroupName(String value) {
             base.addInput ("OptionGroupName", value);
         }
         /// <summary>
         /// (optional, integer) The port number on which the database accepts connections. Valid range for MySQL is 1150-65535. Valid range for Oracle is 1150-65535. Valid range for SQLServer is 1150-65535 except for 1434 and 3389.
         /// </summary>
         /// <param name="value">Value of the Port input for this Choreo.</param>
         public void setPort(String value) {
             base.addInput ("Port", value);
         }
         /// <summary>
         /// (optional, string) The daily time range during which automated backups are created if automated backups are enabled, using the BackupRetentionPeriod parameter. Must be in the format hh24:mi-hh24:mi (in UTC).
         /// </summary>
         /// <param name="value">Value of the PreferredBackupWindow input for this Choreo.</param>
         public void setPreferredBackupWindow(String value) {
             base.addInput ("PreferredBackupWindow", value);
         }
         /// <summary>
         /// (optional, string) The weekly time range (in UTC) during which system maintenance can occur. Format: ddd:hh24:mi-ddd:hh24:mi.
         /// </summary>
         /// <param name="value">Value of the PreferredMaintenanceWindow input for this Choreo.</param>
         public void setPreferredMaintenanceWindow(String value) {
             base.addInput ("PreferredMaintenanceWindow", value);
         }
         /// <summary>
         /// (optional, boolean) Specifies the accessibility options for the DB Instance. The default behavior varies depending on whether a VPC has been requested or not.
         /// </summary>
         /// <param name="value">Value of the PubliclyAccessible input for this Choreo.</param>
         public void setPubliclyAccessible(String value) {
             base.addInput ("PubliclyAccessible", value);
         }
         /// <summary>
         /// (optional, string) The AWS region that corresponds to the RDS endpoint you wish to access. The default region is "us-east-1". See description below for valid values.
         /// </summary>
         /// <param name="value">Value of the UserRegion input for this Choreo.</param>
         public void setUserRegion(String value) {
             base.addInput ("UserRegion", value);
         }
         /// <summary>
         /// (optional, string) A comma separated list of up to 10 EC2 VPC Security Groups to associate with this DB Instance.
         /// </summary>
         /// <param name="value">Value of the VpcSecurityGroupIds input for this Choreo.</param>
         public void setVpcSecurityGroupIds(String value) {
             base.addInput ("VpcSecurityGroupIds", value);
         }

        /// <summary>
        /// Execute the Choreo using the specified InputSet as parameters, wait for the Choreo to complete
        /// and return a ResultSet containing the execution results
        /// </summary>
        /// <returns>A CreateDBInstanceResultSet containing execution metadata and results.</returns>
        new public CreateDBInstanceResultSet execute()
        {
            String json = base.getResponseJSON(false, true);
            CreateDBInstanceResultSet results = new JavaScriptSerializer().Deserialize<CreateDBInstanceResultSet>(json);

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
    /// A ResultSet with methods tailored to the values returned by the CreateDBInstance Choreo
    /// The ResultSet object is used to retrieve the results of a Choreo execution
    /// </summary>
    public class CreateDBInstanceResultSet : Temboo.Core.ResultSet
    {
        /// <summary> 
        /// Retrieve the value for the "Response" output from this Choreo execution
        /// <returns>String - (xml) The response from Amazon.</returns>
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
