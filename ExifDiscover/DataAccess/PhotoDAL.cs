using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;

using ObjectModel;

namespace DataAccess
{
    /// <summary>
    /// Data Access Class for Project Management
    /// </summary>
    public class PhotoDAL
    {
        private string __connectionString = string.Empty;

        #region Stored Procedure Constants

        /// <summary>
        /// Stored Procedure Constants
        /// </summary>
        internal struct SPs
        {
            internal struct Photo
            {
                public const string Get = "Photo_Get";
            }

        }

        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PhotoDAL()
        {
            __connectionString = ConfigurationManager.ConnectionStrings["Primary"].ToString();
        }

        #region public Get Methods

        //public List<ApprovalReportGroupEntry> GetApprovalReportGroupEntries(ApprovalReportGroupEntry filter)
        //{
        //    // Fill an Array List with the results
        //    return (List<ApprovalReportGroupEntry>)FillList(SPs.ApprovalReportGroupEntry.Get, filter, new List<ApprovalReportGroupEntry>());
        //}

        #endregion

        #region public Save Methods

        /// <summary>
        /// Returns new Project Id if successful, -1 if failed.
        /// </summary>
        /// <param name="project"></param>
        /// <param name="userLogin"></param>
        /// <returns></returns>
        public int SaveProject()
        {
            return 0;
//            SqlParameter[] parms = 
//            { 
//                new SqlParameter("@ProjectXML", SqlDbType.NText),
//                new SqlParameter("@UserLogin", SqlDbType.VarChar, 35),
//                new SqlParameter("@ProjectId", SqlDbType.Int)
//            };

//            //
//            // Before we can serialize the project we need to remove the circular references from
//            // the approvals that are on the action items for convenience, we can also remove the 
//            // Person object from the Approver to reduce XML clutter as the PersonId will be preserved.
//            //
//            // Added: Clean up Time Unit Records off of Persons
//            //
//            if (project != null && project.MilestoneCollection != null && project.MilestoneCollection.Count > 0)
//            {
//                if (project.Resources != null)
//                {
//                    foreach (Person res in project.Resources)
//                    {
//                        res.WorkHistory = null;
//                    }
//                }

//                foreach (Milestone m in project.MilestoneCollection)
//                {
//                    if (m.ApprovalRequest != null)
//                    {
//                        if (m.ApprovalRequest.Approvers != null && m.ApprovalRequest.Approvers.Count > 0)
//                        {
//                            foreach (Approver app in m.ApprovalRequest.Approvers)
//                            {
//                                app.Person = null;
//                                if (app.ApprovalActions != null && app.ApprovalActions.Count > 0)
//                                {
//                                    foreach (ApprovalAction aa in app.ApprovalActions)
//                                    {
//                                        aa.Approver = null;
//                                    }
//                                }
//                            }
//                        }
//                    }
//                }
//            }


//            string projectXML = SerialService.Serialize(project, false);

//#if DEBUG
//            using (StreamWriter writer = new StreamWriter("ProjectXML.txt", false))
//            {
//                writer.Write(projectXML);
//            }
//#endif

//            parms[0].Value = projectXML;
//            parms[1].Value = userLogin;
//            parms[2].Direction = ParameterDirection.Output;
//            parms[2].IsNullable = true;

//            try
//            {
//                DataService.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, SPs.Project.Save, parms);
//            }
//            catch (Exception ex)
//            {
//#if DEBUG
//                Console.Write(ex.Message);
//#endif
//                return -1;
//            }

//            if (parms[2] != null && parms[2].Value != System.DBNull.Value)
//            {
//                return ((int)parms[2].Value);
//            }
//            else
//            {
//                return project.ProjectId;
//            }
        }

        #endregion

        #region Non-Query

        //public bool DeleteProject(int ProjectId, string userLogin)
        //{
        //    SqlParameter[] parms = 
        //    { 
        //        new SqlParameter("@ProjectId", SqlDbType.Int),
        //        new SqlParameter("@UserLogin", SqlDbType.VarChar, 35)
        //    };

        //    parms[0].Value = ProjectId;
        //    parms[1].Value = userLogin;

        //    try
        //    {
        //        DataService.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, SPs.Project.Delete, parms);  
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //public bool RetireProject(int ProjectId, string userLogin)
        //{
        //    SqlParameter[] parms = 
        //    { 
        //        new SqlParameter("@ProjectId", SqlDbType.Int),
        //        new SqlParameter("@UserLogin", SqlDbType.VarChar, 35)
        //    };

        //    parms[0].Value = ProjectId;
        //    parms[1].Value = userLogin;

        //    try
        //    {
        //        DataService.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, SPs.Project.Retire, parms);
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        //public bool ReportSummaryUpdate(string userLogin)
        //{
        //    SqlParameter[] parms = 
        //    { 
        //        new SqlParameter("@UserLogin", SqlDbType.VarChar, 35)
        //    };

        //    parms[0].Value = userLogin;

        //    try
        //    {
        //        DataService.ExecuteNonQuery(Constants.ConnectionString, CommandType.StoredProcedure, SPs.ReportSummaryUpdate.Save, parms);
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

        #endregion

        #region General DataReader and Fill Helper Methods

        /// <summary>
        /// Does the work of getting a data reader
        /// </summary>
        /// <param name="storedProcedure"></param>
        /// <param name="filterObject"></param>
        /// <returns></returns>
        private SqlDataReader GetDataReader(string storedProcedure, object filterObject)
        {
            // TODO: Dynamically create the parameters
            // SqlParameter[] parameters = SqlHelperParameterCache.GetSpParameterSet(connectionString, storedProcdure);

            //Declare the parameters
            SqlParameter[] parameters = 
                  {
                  };

            // TODO: Dynamically assigne parameter values based on the filterObject Properties
            
            // Declare the DataReader outside the try catch
            SqlDataReader dr = null;
            try
            {
                // Create the Data Reader
                dr = DataService.ExecuteReader(__connectionString, CommandType.StoredProcedure, storedProcedure, parameters);

                // return the data reader
                return dr;
            }
            catch (Exception e)
            {
                DataService.CloseDataReaderIfOpen(dr);
                //ExceptionManager.Publish(e);
                throw e;
            }
        }

        /// <summary>
        /// Does all the work of getting a List from the database
        /// </summary>
        /// <param name="procedureName">The Precedure to Call.</param>
        /// <param name="filterObject">Set an properties you want to filter by on this object.</param>
        /// <param name="returnList">The List that will be returned.</param>
        /// <returns></returns>
        private object FillList(string procedureName, object filterObject, object returnList)
        {
            // Get the MethodInfo for the Add Method
            MethodInfo listAddMethodInfo = returnList.GetType().GetMethod("Add");

            //Get the Type for filterObject
            Type singleItemType = filterObject.GetType();

            // Declare the single item object
            object singleItem = singleItemType.GetConstructor(System.Type.EmptyTypes).Invoke(null);

            // Get the Single Item ConstructorInfo
            ConstructorInfo singleItemConstructorInfo = singleItemType.GetConstructor(System.Type.EmptyTypes);

            // Declare our Data Reader outside the try catch
            SqlDataReader dr = null;

            try
            {
                // Get our Data Reader
                dr = GetDataReader(procedureName, filterObject);

                #region Get the Info we need to perform the Fill from the Data Reader to the Type
                // Declare the output variables
                int[] ordinals;
                PropertyInfo[] propertyInfoForDataReaderOrdinals;
                string[] ordinalDataTypes;
 
                //Get the Fill the Info we need
                GetDataReaderFillForTypeInfo(dr, singleItemType, out ordinals, out propertyInfoForDataReaderOrdinals, out ordinalDataTypes);
                #endregion 

                // Loop through the data reader
                while (dr.Read())
                {
                    // Create a new EntityType object
                    singleItem = singleItemConstructorInfo.Invoke(null);

                    // Populate the properties from the the data reader using the Fill Info we've gotten.
                    SetObjectPropertiesFromDataReader(singleItem, dr, ordinals, propertyInfoForDataReaderOrdinals, ordinalDataTypes);
            
                    // Declare the single item array.  This is used later when invoking the "Add" method on the list.
                    object[] singleItemObjectArray = { singleItem };

                    // Add the Item to the return List 
                    listAddMethodInfo.Invoke(returnList, singleItemObjectArray);

                }

                // Close our data reader
                DataService.CloseDataReaderIfOpen(dr);

                //Return our List
                return returnList;
            }
            catch (Exception e)
            {
                DataService.CloseDataReaderIfOpen(dr);
                //ExceptionManager.Publish(e);
                throw e;
            }
        }

        /// <summary>
        /// General Method that get's fill information between a Type and a DataReader
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="type"></param>
        /// <param name="ordinals"></param>
        /// <param name="propertyInfoForDataReaderOrdinals"></param>
        /// <param name="ordinalDataTypes"></param>
        internal void GetDataReaderFillForTypeInfo(SqlDataReader dr, Type type,
            out int[] ordinals, out PropertyInfo[] propertyInfoForDataReaderOrdinals, out string[] ordinalDataTypes)
        {
            // Store the ordinal of each field.
            Dictionary<string, int> fieldOrdinals = GetFieldDict(dr);

            // Get the property info Array of the Type
            PropertyInfo[] completePropertyArray = type.GetProperties();

            // Setup Loop Variables
            Dictionary<string, PropertyInfo> propertyInfoDict = new Dictionary<string, PropertyInfo>();
            int dataReaderPropertyMatchCount = 0;
            PropertyInfo propertyInfo;
            int propertyCount = completePropertyArray.GetUpperBound(0) + 1;

            // Loop through and find matches between the data reader and the objects type.
            // Also cache the Property Info.
            for (int i = 0; i < propertyCount; i++)
            {
                // Set the propertyInfo variable for this loop iteration
                propertyInfo = completePropertyArray[i];

                // Cache the propertyInfo
                propertyInfoDict.Add(propertyInfo.Name, propertyInfo);

                // See if it is in the Data Reader Field Names
                if (fieldOrdinals.ContainsKey(propertyInfo.Name))
                {
                    // Increment our match count.
                    dataReaderPropertyMatchCount++;
                }

#if(DEBUG)
                else
                {
                    System.Diagnostics.Debug.WriteLine("Property is not returned by DataReader: " + propertyInfo.Name);
                }
#endif
            }

            // Initialize the output Arrays
            ordinals = new int[dataReaderPropertyMatchCount];
            propertyInfoForDataReaderOrdinals = new PropertyInfo[dataReaderPropertyMatchCount];
            ordinalDataTypes = new string[dataReaderPropertyMatchCount];

            // Loop variables
            int matchIndex = 0;
            string columnName;

            // Loop through and set the output
            for (int i = 0; i < dr.FieldCount; i++)
            {
                // Get the Column Name
                columnName = dr.GetName(i);

                // See if this was a match
                if (propertyInfoDict.ContainsKey(columnName))
                {
                    // Set the Ordinal for this nth match.
                    ordinals[matchIndex] = i;

                    // Set the PropertyInfo for the Property this ordinal will map to.
                    propertyInfoForDataReaderOrdinals[matchIndex] = propertyInfoDict[columnName];

                    // Set the DataType of the Data Reader
                    ordinalDataTypes[matchIndex] = dr.GetDataTypeName(i);

                    // Increment the matchIndex;
                    matchIndex++;
                }

#if(DEBUG)
                else
                {
                    System.Diagnostics.Debug.WriteLine("DataReader returns property that does not match any object property: " + columnName);
                }
#endif
            }

            return;
        }

        /// <summary>
        /// General Method that Fills an object from a DataReader.
        /// Call GetDataReaderFillForTypeInfo() to get the information to pass in.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="dr"></param>
        /// <param name="ordinals"></param>
        /// <param name="propertyInfoForDataReaderOrdinals"></param>
        /// <param name="ordinalDataTypes"></param>
        internal void SetObjectPropertiesFromDataReader(Object obj, SqlDataReader dr, int[] ordinals, PropertyInfo[] propertyInfoForDataReaderOrdinals, string[] ordinalDataTypes)
        {
            // Get the # of property's to fill from the dataReader
            int fillPropertiesCount = ordinals.GetUpperBound(0) + 1;

            // Setup Loop variables.
            int ordinal;
            PropertyInfo propertyInfo;
            string dataType;

            // Fill the Fields
            for (int i = 0; i < fillPropertiesCount; i++)
            {

                // Set the variables for this loop
                ordinal = ordinals[i];

                // Todo: determine how to handle enforcing non-nullability.
                if (dr.IsDBNull(ordinal))
                    continue;

                propertyInfo = propertyInfoForDataReaderOrdinals[i];
                dataType = ordinalDataTypes[i];

                // Set the property
                switch (dataType)
                {
                    case "datetime":
                        propertyInfo.SetValue(obj, dr.GetDateTime(ordinal), null);
                        break;
                    case "decimal":
                        propertyInfo.SetValue(obj, dr.GetDecimal(ordinal), null);
                        break;
                    case "varchar":
                        propertyInfo.SetValue(obj, dr.GetString(ordinal), null);
                        break;
                    case "bit":
                        propertyInfo.SetValue(obj, dr.GetBoolean(ordinal), null);
                        break;
                    case "int":
                        propertyInfo.SetValue(obj, dr.GetInt32(ordinal), null);
                        break;
                    default:
                        propertyInfo.SetValue(obj, dr[ordinal], null);
                        break;
                }
            }



        }

        /// <summary>
        /// Gets a Dictionary of the ordinals by FieldName from the DataReader
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        internal Dictionary<string, int> GetFieldDict(SqlDataReader dr)
        {
            // Create the new Dictionary
            Dictionary<string, int> dictFields = new Dictionary<string, int>();

            // Cache the Names and Fields.
            for (int i = 0; i < dr.FieldCount; i++)
                dictFields.Add(dr.GetName(i), i);

            // Return the Field Hash
            return dictFields;
        }

        #endregion


    }
}
