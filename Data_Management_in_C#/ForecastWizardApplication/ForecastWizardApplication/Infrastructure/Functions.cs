using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using ForecastWizardApplication.Infrastructure;

namespace ForecastWizardApplication.Infrastructure
{
    class Functions
    {
        public static void UpdateMandatoryStatus(int BlockID)
        {
            //Update the Mandatory Status in the PossiblePlantMasterVariable Table

            //First Check the selection ID from the Forecast Selection Table
            DataTable ForecastSelectionData = new DataTable();
            ForecastSelectionData = HandleSqlQueries.HandleQueries("Select BlockID,BlockEnhancements,TrainID from ForecastSelection where BlockID = " + BlockID.ToString());

            for (int i = 0; i < ForecastSelectionData.Rows.Count; i++)
            {
                //Get the Block Enhancement List from that table for each Forecast Selection
                List<string> BlockEnhancementList = new List<String>();
                List<int> VariableMasterList = new List<int>();
                foreach (string id in ForecastSelectionData.Rows[i][1].ToString().Split(','))
                {
                    BlockEnhancementList.Add(id);
                }
                BlockEnhancementList.RemoveAt(BlockEnhancementList.Count - 1); // The last element is a Null ... as we store the enhancement in the form "AI,SI,"

                //Get the PlantVariableMasterID for which the Mandatory Type is M(C)...
                VariableMasterList = Functions.GetVariableList(BlockEnhancementList);

                //Get The Train ID from the ForecastSelection Table
                List<int> TrainIDList = new List<int>();
                foreach (string id in ForecastSelectionData.Rows[i][2].ToString().Split(','))
                {
                    TrainIDList.Add(Convert.ToInt32(id));
                }

                //Convert the Variable's Mandatory status selected from the GetVariableList() based on the TrainID 
                string Mandatory = "M";
                string MandatoryOptional = "M(C)";
                try
                {
                    string sql = "UPDATE PossiblePlantMasterVariable SET Mandatory = @Mandatory Where PlantMasterVariableID IN (" + String.Join(",", VariableMasterList) + ") AND TrainID IN (" + String.Join(",", TrainIDList) + ") AND BlockID=" + BlockID + " AND Mandatory LIKE '" + MandatoryOptional + "'";
                    using (SqlConnection conn = new SqlConnection(Connection.getConnectionString()))
                    {
                        SqlCommand com = new SqlCommand(sql, conn);
                        com.Parameters.AddWithValue("@Mandatory", Mandatory);
                        conn.Open();
                        if (com.ExecuteNonQuery() > 0)
                        {
                            com.Parameters.Clear();
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            //Search through the PossiblePlantMasterVariable table based on the Train ID and column whose mandatory values are  M(C)..


        }
        public static List<int> GetVariableList(List<string> BlockEnhancementList)
        {
            DataTable VariableMasterData = new DataTable();
            VariableMasterData = HandleSqlQueries.HandleQueries("Select PlantMasterVariableID,Mandatory from EnhancementUniquePlantMasterVariable where EnhancementTypeName IN ('" + String.Join("','", BlockEnhancementList.ToArray()) + "')");

            List<int> VariableMasterList = new List<int>();
            for (int i = 0; i < VariableMasterData.Rows.Count; i++)
            {
                if (VariableMasterData.Rows[i][1].ToString() == "M(C)")
                {
                    VariableMasterList.Add((int)VariableMasterData.Rows[i][0]);
                }
            }
            return VariableMasterList;
        }
        public static void InsertRow(int blockID, DataRow Row, int blockType)
        {
            string sql = string.Empty;
            try
            {
                sql = "INSERT PossiblePlantMasterVariable (PlantVariableID,PlantMasterVariableID,BlockID,Alias,Description,TrainID,PlantObjectTypeID,ObjectGroupID,Mandatory) VALUES (@A,@B,@C,@D,@E,@F,@G,@H,@I)";
                using (SqlConnection conn = new SqlConnection(Connection.getConnectionString()))
                {
                    SqlCommand com = new SqlCommand(sql, conn);
                    conn.Open();
                    switch (blockType)
                    {
                        case 0:
                            {
                                //SqlCommand cmd2 = conn.CreateCommand();
                                //cmd2.CommandText = insertcmd;
                                BlockUserControl.VariableCount++;
                                com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                com.Parameters.AddWithValue("@B", Row[0]);
                                com.Parameters.AddWithValue("@C", blockID);
                                com.Parameters.AddWithValue("@D", Row[2]);
                                com.Parameters.AddWithValue("@E", Row[3]);
                                com.Parameters.AddWithValue("@F", 1);
                                com.Parameters.AddWithValue("@G", Row[4]);
                                com.Parameters.AddWithValue("@H", Row[5]);
                                com.Parameters.AddWithValue("@I", Row[6]);
                                com.ExecuteNonQuery();

                                break;
                            }
                        case 1:
                            {


                                //SqlCommand cmd2 = conn.CreateCommand();
                                //cmd2.CommandText = insertcmd;
                                BlockUserControl.VariableCount++;
                                com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                com.Parameters.AddWithValue("@B", Row[0]);
                                com.Parameters.AddWithValue("@C", blockID);
                                com.Parameters.AddWithValue("@D", Row[2]);
                                com.Parameters.AddWithValue("@E", Row[3]);
                                com.Parameters.AddWithValue("@F", 1);
                                com.Parameters.AddWithValue("@G", Row[4]);
                                com.Parameters.AddWithValue("@H", Row[5]);
                                com.Parameters.AddWithValue("@I", Row[6]);
                                com.ExecuteNonQuery();

                                break;

                            }
                        case 2:
                            {

                                if ((int)Row[4] == 3) //if generator create 4 variable rows
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        //SqlCommand cmd2 = conn.CreateCommand();
                                        //cmd2.CommandText = insertcmd;
                                        BlockUserControl.VariableCount++;
                                        com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                        com.Parameters.AddWithValue("@B", Row[0]);
                                        com.Parameters.AddWithValue("@C", blockID);
                                        com.Parameters.AddWithValue("@D", Row[2]);
                                        com.Parameters.AddWithValue("@G", Row[4]);
                                        com.Parameters.AddWithValue("@H", Row[5]);
                                        com.Parameters.AddWithValue("@I", Row[6]);
                                        if (i == 0)
                                        {
                                            com.Parameters.AddWithValue("@F", 1);
                                            //cmd2.Parameters.AddWithValue("@D", "CT1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                        }
                                        if (i == 1)
                                        {
                                            com.Parameters.AddWithValue("@F", 2);
                                            //cmd2.Parameters.AddWithValue("@D", "ST1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "ST1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                        }
                                    }
                                }
                                else if ((int)Row[4] == 4 || (int)Row[4] == 6)//if Gas Turbine or HRSG
                                {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        //SqlCommand cmd2 = conn.CreateCommand();
                                        //cmd2.CommandText = insertcmd;
                                        BlockUserControl.VariableCount++;
                                        com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                        com.Parameters.AddWithValue("@B", Row[0]);
                                        com.Parameters.AddWithValue("@C", blockID);
                                        com.Parameters.AddWithValue("@D", Row[2]);
                                        com.Parameters.AddWithValue("@G", Row[4]);
                                        com.Parameters.AddWithValue("@H", Row[5]);
                                        com.Parameters.AddWithValue("@I", Row[6]);
                                        if (i == 0)
                                        {
                                            com.Parameters.AddWithValue("@F", 1);
                                            //cmd2.Parameters.AddWithValue("@D", "CT1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                        }

                                    }

                                }
                                else
                                {
                                    //SqlCommand cmd2 = conn.CreateCommand();
                                    //cmd2.CommandText = insertcmd;
                                    BlockUserControl.VariableCount++;
                                    com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                    com.Parameters.AddWithValue("@B", Row[0]);
                                    com.Parameters.AddWithValue("@C", blockID);
                                    com.Parameters.AddWithValue("@D", Row[2]);
                                    com.Parameters.AddWithValue("@E", Row[3]);
                                    com.Parameters.AddWithValue("@F", 1);
                                    com.Parameters.AddWithValue("@G", Row[4]);
                                    com.Parameters.AddWithValue("@H", Row[5]);
                                    com.Parameters.AddWithValue("@I", Row[6]);
                                    com.ExecuteNonQuery();
                                }
                                break;
                            }
                        case 3:
                            {
                                if ((int)Row[4] == 3) //if generator create 4 variable rows
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        //SqlCommand cmd2 = conn.CreateCommand();
                                        //cmd2.CommandText = insertcmd;
                                        BlockUserControl.VariableCount++;
                                        com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                        com.Parameters.AddWithValue("@B", Row[0]);
                                        com.Parameters.AddWithValue("@C", blockID);
                                        com.Parameters.AddWithValue("@D", Row[2]);
                                        com.Parameters.AddWithValue("@G", Row[4]);
                                        com.Parameters.AddWithValue("@H", Row[5]);
                                        com.Parameters.AddWithValue("@I", Row[6]);
                                        if (i == 0)
                                        {
                                            com.Parameters.AddWithValue("@F", 1);
                                            //cmd2.Parameters.AddWithValue("@D", "CT1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 1)
                                        {
                                            com.Parameters.AddWithValue("@F", 2);
                                            //cmd2.Parameters.AddWithValue("@D", "CT2 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT2 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 2)
                                        {
                                            com.Parameters.AddWithValue("@F", 3);
                                            //cmd2.Parameters.AddWithValue("@D", "ST1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "ST1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }

                                    }
                                }
                                else if ((int)Row[4] == 4 || (int)Row[4] == 6)//if Gas Turbine or HRSG  <---
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        //SqlCommand cmd2 = conn.CreateCommand();
                                        //cmd2.CommandText = insertcmd;
                                        BlockUserControl.VariableCount++;
                                        com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                        com.Parameters.AddWithValue("@B", Row[0]);
                                        com.Parameters.AddWithValue("@C", blockID);
                                        com.Parameters.AddWithValue("@D", Row[2]);
                                        com.Parameters.AddWithValue("@G", Row[4]);
                                        com.Parameters.AddWithValue("@H", Row[5]);
                                        com.Parameters.AddWithValue("@I", Row[6]);
                                        if (i == 0)
                                        {
                                            com.Parameters.AddWithValue("@F", 1);
                                            //cmd2.Parameters.AddWithValue("@D", "CT1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 1)
                                        {
                                            com.Parameters.AddWithValue("@F", 2);
                                            //cmd2.Parameters.AddWithValue("@D", "CT2 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT2 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                    }

                                }
                                else
                                {
                                    //SqlCommand cmd2 = conn.CreateCommand();
                                    //cmd2.CommandText = insertcmd;
                                    BlockUserControl.VariableCount++;
                                    com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                    com.Parameters.AddWithValue("@B", Row[0]);
                                    com.Parameters.AddWithValue("@C", blockID);
                                    com.Parameters.AddWithValue("@D", Row[2]);
                                    com.Parameters.AddWithValue("@E", Row[3]);
                                    com.Parameters.AddWithValue("@F", 1);
                                    com.Parameters.AddWithValue("@G", Row[4]);
                                    com.Parameters.AddWithValue("@H", Row[5]);
                                    com.Parameters.AddWithValue("@I", Row[6]);
                                    com.ExecuteNonQuery();
                                }
                                break;
                            }
                        case 4:
                            {
                                if ((int)Row[4] == 3) //if generator create 4 variable rows
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        //SqlCommand cmd2 = conn.CreateCommand();
                                        //cmd2.CommandText = insertcmd;
                                        BlockUserControl.VariableCount++;
                                        com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                        com.Parameters.AddWithValue("@B", Row[0]);
                                        com.Parameters.AddWithValue("@C", blockID);
                                        com.Parameters.AddWithValue("@D", Row[2]);
                                        com.Parameters.AddWithValue("@G", Row[4]);
                                        com.Parameters.AddWithValue("@H", Row[5]);
                                        com.Parameters.AddWithValue("@I", Row[6]);
                                        if (i == 0)
                                        {
                                            com.Parameters.AddWithValue("@F", 1);
                                            //cmd2.Parameters.AddWithValue("@D", "CT1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 1)
                                        {
                                            com.Parameters.AddWithValue("@F", 2);
                                            //cmd2.Parameters.AddWithValue("@D", "CT2 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT2 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 2)
                                        {
                                            com.Parameters.AddWithValue("@F", 3);
                                            //cmd2.Parameters.AddWithValue("@D", "CT3 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT3 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 3)
                                        {
                                            com.Parameters.AddWithValue("@F", 4);
                                            //cmd2.Parameters.AddWithValue("@D", "ST1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "ST1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                    }
                                }
                                else if ((int)Row[4] == 4 || (int)Row[4] == 6)//if Gas Turbine or HRSG
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        //SqlCommand cmd2 = conn.CreateCommand();
                                        //cmd2.CommandText = insertcmd;
                                        BlockUserControl.VariableCount++;
                                        com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                        com.Parameters.AddWithValue("@B", Row[0]);
                                        com.Parameters.AddWithValue("@C", blockID);
                                        com.Parameters.AddWithValue("@D", Row[2]);
                                        com.Parameters.AddWithValue("@G", Row[4]);
                                        com.Parameters.AddWithValue("@H", Row[5]);
                                        com.Parameters.AddWithValue("@I", Row[6]);
                                        if (i == 0)
                                        {
                                            com.Parameters.AddWithValue("@F", 1);
                                            //cmd2.Parameters.AddWithValue("@D", "CT1 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT1 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 1)
                                        {
                                            com.Parameters.AddWithValue("@F", 2);
                                            //cmd2.Parameters.AddWithValue("@D", "CT2 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT2 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                        if (i == 2)
                                        {
                                            com.Parameters.AddWithValue("@F", 3);
                                            //cmd2.Parameters.AddWithValue("@D", "CT3 " + Row[2]);
                                            com.Parameters.AddWithValue("@E", "CT3 " + Row[3]);
                                            com.ExecuteNonQuery();
                                            com.Parameters.Clear();
                                        }
                                    }

                                }
                                else
                                {
                                    //SqlCommand cmd2 = conn.CreateCommand();
                                    //cmd2.CommandText = insertcmd;
                                    BlockUserControl.VariableCount++;
                                    com.Parameters.AddWithValue("@A", BlockUserControl.VariableCount);
                                    com.Parameters.AddWithValue("@B", Row[0]);
                                    com.Parameters.AddWithValue("@C", blockID);
                                    com.Parameters.AddWithValue("@D", Row[2]);
                                    com.Parameters.AddWithValue("@E", Row[3]);
                                    com.Parameters.AddWithValue("@F", 1);
                                    com.Parameters.AddWithValue("@G", Row[4]);
                                    com.Parameters.AddWithValue("@H", Row[5]);
                                    com.Parameters.AddWithValue("@I", Row[6]);
                                    com.ExecuteNonQuery();
                                }
                                break;
                            }
                    }
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
