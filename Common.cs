using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data;

namespace NewEvolioMenu
{
    public class ConnectDB
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        protected  SqlConnection sqlConn = new SqlConnection(connectionString);
        public string strLangeCd;
        public string strUserId;
        public string strUserNm;     //ユーザ名
        public string strBaseCd;      //拠点コード
        public string strAuthCd;     //権限コード
        public string strBseJpn;     //拠点名（日本語）
        public string strBseEng;     //拠点名（英語）
        public string strUserPW;
        public string strEvolioID;
        public string strEvolioPW;
        public string test;
        public  ConnectDB()
        {
            try
            {
                sqlConn.Open();
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
        public void CloseDB()
        {
            try
            {
                sqlConn.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void GetUserValue(string UserId )
        {
            try
            {
                DataSet myds = new DataSet();
                StringBuilder strGetUserValue = new StringBuilder();
                strGetUserValue.Append("select Usr.UserName,Usr.Password,Usr.EvolioUserId,Usr.EvolioPassword,")
                     .Append("Usr.LanguageCd,")
                     .Append("Usr.BaseCd,")
                     .Append("AuthCd,")
                     .Append("Bse.BaseNameJpn,")
                     .Append("Bse.BaseNameEng" + " ")
                     .Append("FROM" + " ")
                     .Append("Mst_User AS Usr LEFT JOIN Mst_Base AS Bse" + " ")
                     .Append("on Bse.BaseCd=Usr.BaseCd" + " ")
                     .Append("where UserId= '" + UserId + "'");
                SqlDataAdapter myad = new SqlDataAdapter(strGetUserValue.ToString(), sqlConn);
                myad.Fill(myds, "mydata");
                CloseDB();
                strLangeCd = myds.Tables[0].Rows[0]["LanguageCd"].ToString();
                strUserId = UserId;
                strUserNm = myds.Tables[0].Rows[0]["UserName"].ToString();     //ユーザ名
                strBaseCd = myds.Tables[0].Rows[0]["BaseCd"].ToString();      //拠点コード
                strAuthCd = myds.Tables[0].Rows[0]["AuthCd"].ToString();      //権限コード
                strBseJpn = myds.Tables[0].Rows[0]["BaseNameJpn"].ToString();      //拠点名（日本語）
                strBseEng = myds.Tables[0].Rows[0]["BaseNameEng"].ToString();      //拠点名（英語）
                strUserPW = myds.Tables[0].Rows[0]["Password"].ToString();
                strEvolioID= myds.Tables[0].Rows[0]["EvolioUserId"].ToString();
                strEvolioPW = myds.Tables[0].Rows[0]["EvolioPassword"].ToString();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


        }
        public int CheckPassWord(string UserId,String PassWord)
        {     
            DataSet myds = new DataSet();
            StringBuilder GetPW = new StringBuilder();
            GetPW.Append("select * ")
                 .Append("FROM"+" ")
                 .Append("Mst_User "+" ")
                 .Append("where UserId= '" + UserId + "' ")
                 .Append("and PassWord='" + PassWord + "' ");
            SqlDataAdapter myad = new SqlDataAdapter(GetPW.ToString(), sqlConn);
            try
            {
               
                myad.Fill(myds, "mydata");
                CloseDB();
                if (myds.Tables[0].Rows.Count>0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
               
            }
            catch(SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            
            
        }
        public DataTable GetMenu()
        {
            try
            {
                DataSet myds = new DataSet();
                StringBuilder strGetMenu = new StringBuilder();
                strGetMenu.Append("SELECT                                                                             " + " ")
                          .Append("    Mnu.BaseCd,                                                                    " + " ")
                          .Append("    Mnu.BaseNameJpn,                                                               " + " ")
                          .Append("    Mnu.BaseNameEng,                                                               " + " ")
                          .Append("    Mnu.DeptCd,                                                                    " + " ")
                          .Append("    Mnu.DeptNameJpn,                                                               " + " ")
                          .Append("    Mnu.DeptNameEng,                                                                " + " ")
                          .Append("    Ath.EvolioCd                                                                  " + " ")
                          .Append("FROM                                                                               " + " ")
                          .Append("(                                                                                  " + " ")
                          .Append("    SELECT                                                                         " + " ")
                          .Append("        Bse.BaseCd,                                                                " + " ")
                          .Append("        Bse.BaseNameJpn,                                                           " + " ")
                          .Append("        Bse.BaseNameEng,                                                           " + " ")
                          .Append("        Dpt.DeptCd,                                                                " + " ")
                          .Append("        Dpt.DeptNameJpn,                                                           " + " ")
                          .Append("        Dpt.DeptNameEng                                                            " + " ")
                          .Append("    FROM                                                                           " + " ")
                          .Append("        Mst_Base AS Bse                                                            " + " ")
                          .Append("    INNER JOIN                                                                     " + " ")
                          .Append("        Mst_Dept AS Dpt                                                            " + " ")
                          .Append("    ON                                                                             " + " ")
                          .Append("        Bse.BaseCd = Dpt.BaseCd                                                    " + " ")
                          .Append(") AS Mnu                                                                           " + " ")
                          .Append("INNER JOIN                                                                         " + " ")
                          .Append("    Mst_Auth AS Ath                                                                " + " ")
                          .Append("ON                                                                                 " + " ")
                          .Append("    Mnu.BaseCd = CASE WHEN Ath.BaseCd = 'ALL' THEN Mnu.BaseCd ELSE Ath.BaseCd END  " + " ")
                          .Append("AND Mnu.DeptCd = CASE WHEN Ath.DeptCd = 'ALL' THEN Mnu.DeptCd ELSE Ath.DeptCd END  " + " ")
                          .Append("WHERE                 " + " ")
                          .Append("    Ath.AuthCd   = '" + strAuthCd +"' order by BaseCd");
                SqlDataAdapter myad = new SqlDataAdapter(strGetMenu.ToString(), sqlConn);
                myad.Fill(myds, "mydata");
                CloseDB();
                return myds.Tables[0];

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public DataTable GetSubTbl(string pstBaseCd,string pstDeptCd,string pstEvolioCd)
        {
            try
            {
                string [] ED = pstEvolioCd.Split(',');
                StringBuilder strEvolioCd = new StringBuilder();
                String finStrEvo;
                if (ED[0] != "ALL")
                {
                    foreach (string pED in ED)
                    {
                        strEvolioCd.Append("'" + pED + "',");
                    }
                    finStrEvo = strEvolioCd.ToString().Substring(0, strEvolioCd.ToString().Length - 1);
                }
                else
                {
                    finStrEvo = "Evo.No";
                }
                
                
                DataSet myds = new DataSet();
                StringBuilder strGetSubTbl = new StringBuilder();
                strGetSubTbl.Append("SELECT                                                                             " + " ")
                            .Append("    Evo.EvolioNameJpn,                                                             " + " ")
                            .Append("    Evo.EvolioFileJpn,                                                             " + " ")
                            .Append("    Evo.EvolioNameEng,                                                             " + " ")
                            .Append("    Evo.EvolioFileEng                                                              " + " ")
                            .Append("FROM                                                                               " + " ")
                            .Append("    Mst_Evolio AS Evo                                                              " + " ")
                            .Append("WHERE                                                                              " + " ")
                            .Append("    Evo.BaseCd   = '" + pstBaseCd + "'                                             " + " ")
                            .Append("AND Evo.DeptCd   = '" + pstDeptCd + "'                                             " + " ")
                            .Append("AND Evo.No in (" + finStrEvo  + ") ")
                            .Append("and( EvolioNameJpn is not null or EvolioNameEng is not null   )                    " + " ")
                            .Append("ORDER BY                                                                           " + " ")
                            .Append("    Evo.No                                                                         " + " ");

                SqlDataAdapter myad = new SqlDataAdapter(strGetSubTbl.ToString(), sqlConn);
                myad.Fill(myds, "mydata");
                CloseDB();
                return myds.Tables[0];
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
    public class ChanPW : ConnectDB
    {
        public void ChanPw(string UserId,string newPW)
        {
            try
            {
                sqlConn.Open();
                StringBuilder strChanPw = new StringBuilder();
                strChanPw.Append("update Mst_User set Password = '")
                         .Append(newPW)
                         .Append("' ,UpdateDate = getdate() where UserId= '")
                         .Append(UserId + "' COLLATE Japanese_CS_AS");
                SqlCommand cmd = new SqlCommand(strChanPw.ToString(),sqlConn);
                cmd.ExecuteNonQuery();
                CloseDB();
            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }


        }
        

    }
}