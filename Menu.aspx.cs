using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace NewEvolioMenu
{
    public partial class Menu : System.Web.UI.Page
    {
        public string strLiList;
        public string strSubTbl;
        ConnectDB MenuData = new ConnectDB();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string UserID = Session["UserID"].ToString();
           if (!IsPostBack)
           {
              MenuData.GetUserValue(UserID);
              SetMenuStr();
              userName.Text = MenuData.strUserNm;
              TxtEvoPas.Text = MenuData.strEvolioPW;
              TxtEvoUsr.Text = MenuData.strEvolioID;
              HdnLangState.Text = MenuData.strLangeCd;
              Session["LangID"] = MenuData.strLangeCd;
              switch (Convert.ToInt32(MenuData.strLangeCd))
              {
                  case Login.C_LANG_ENG:
                      deptName.Text = MenuData.strBseJpn;
                      LabDept.Text = "Site: ";
                      LabUserName.Text = "User: ";
                      chanPW.Text = "ChangePassword";
                      logOut.Text = "LogOut";
                      mainPageTitle.Text = ConfigurationManager.AppSettings["MainTitleEng"].ToString();
                      subPageTitle.Text = ConfigurationManager.AppSettings["SubTitleEng"].ToString();
                      break;
                  case Login.C_LANG_JPN:
                      deptName.Text = MenuData.strBseEng;
                      LabDept.Text = "拠点名: ";
                      LabUserName.Text = "ユーザID: ";
                      chanPW.Text = "パスワード変更";
                      logOut.Text = "ログアウト";
                      mainPageTitle.Text = ConfigurationManager.AppSettings["MainTitleJpn"].ToString();
                      subPageTitle.Text = ConfigurationManager.AppSettings["SubTitleJpn"].ToString();
                      break;
              }

           }



        }
        private void SetMenuStr()
        {
            StringBuilder liList = new StringBuilder();
            StringBuilder strEvolioList = new StringBuilder();
           
            DataTable mainTableData = new DataTable();
            
            mainTableData=MenuData.GetMenu();
            int inloop = 0;
            for(int loop=0;loop<mainTableData.Rows.Count;loop++)
            {   
                string strinloop = inloop.ToString().PadLeft(2, '0');
                string strloop = loop.ToString().PadLeft(2, '0');
                if (loop==0 || mainTableData.Rows[loop]["BaseCd"].ToString() != mainTableData.Rows[loop - 1]["BaseCd"].ToString())
                {
                    liList.Append(@"<li> <a href=""#/"" id=""LeftTopItem" + strinloop + @""" class=""nav-top-item"" onclick=""SetLeftTop('" + strinloop + @"')"">");
                    switch (Convert.ToInt32(MenuData.strLangeCd))
                    {
                        case Login.C_LANG_ENG:
                            liList.Append(mainTableData.Rows[loop]["BaseNameEng"].ToString());
                            break;
                        case Login.C_LANG_JPN:
                            liList.Append(mainTableData.Rows[loop]["BaseNameJpn"].ToString());
                             break;

                     }                 
                    liList.Append(@"</a><ul>");
                    inloop++;
                }
                liList.Append(@" <li><a href=""#"" id=""LeftSubItem" + strloop + @""" onclick=""LeftSubItem('" + strloop + @"')"" >");
                switch (Convert.ToInt32(MenuData.strLangeCd))
                {
                    case Login.C_LANG_ENG:
                        liList.Append(mainTableData.Rows[loop]["DeptNameEng"].ToString());
                        break;
                    case Login.C_LANG_JPN:
                        liList.Append(mainTableData.Rows[loop]["DeptNameJpn"].ToString());
                        break;
                }
                liList.Append( @"</a></li>");

                if ((loop < mainTableData.Rows.Count - 1 && mainTableData.Rows[loop]["BaseCd"].ToString() != mainTableData.Rows[loop + 1]["BaseCd"].ToString())|| loop == mainTableData.Rows.Count)
                {
                        liList.Append(@"</ul></li>");     
                }
                strEvolioList.Append(SetSubMenuStr(mainTableData.Rows[loop]["BaseCd"].ToString(), mainTableData.Rows[loop]["DeptCd"].ToString(), strloop, mainTableData.Rows[loop]["EvolioCd"].ToString()));
            }
            strLiList = liList.ToString();
            strSubTbl = strEvolioList.ToString();
        }
        protected string SetSubMenuStr(string pstBaseCd,string pstDeptCd,string subLoop,string pstEvolioCd)
        {
            
                
            StringBuilder subTblList = new StringBuilder();
            DataTable subTblDt = new DataTable();
            subTblDt = MenuData.GetSubTbl(pstBaseCd, pstDeptCd , pstEvolioCd);
            if (subTblDt.Rows.Count > 0)
            {
                for (int loop = 0; loop < subTblDt.Rows.Count; loop++)
                {
                    if (loop == 0)
                    {
                        subTblList.Append(@"<table class=""OBJ_INVISIBLE"" id=""RightTable" + subLoop + @"""><tr>");
                    }
                    if(loop % 2 ==0 && loop >0 )
                    {
                        subTblList.Append(@"<tr>");
                    }
                    switch (Convert.ToInt32(MenuData.strLangeCd))
                    {
                        case Login.C_LANG_ENG:
                            subTblList.Append(@"<td><a href=""#"" onclick=""excelPop('" + subTblDt.Rows[loop]["EvolioFileEng"] + @"');return false;"">" + subTblDt.Rows[loop]["EvolioNameEng"].ToString() + @"</td>");
                            break;
                        case Login.C_LANG_JPN:
                            subTblList.Append(@"<td><a href=""#"" onclick=""excelPop('" + subTblDt.Rows[loop]["EvolioFileJpn"] + @"');return false;"">" + subTblDt.Rows[loop]["EvolioNameJpn"].ToString() + @"</td>");
                            break;
                    }
                    if (loop % 2 == 1 && loop>0)
                    {
                        subTblList.Append(@"</tr>");
                    }

                    if (loop == subTblDt.Rows.Count - 1)
                    {   
                        if(loop % 2 == 1)
                        {
                            subTblList.Append(@"</table>");
                        }
                        else
                        {
                            subTblList.Append(@"<td> </td></tr></table>");
                        }
                        
                    }
                }

            }
            else
            {
               subTblList.Append( @"<table boder=""1"" class=""OBJ_INVISIBLE"" id=""RightTable" + subLoop + @"""><td><tr>    </tr></td></table>");
            }
                
            return subTblList.ToString();
        }

        protected void logOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
       
    }
}