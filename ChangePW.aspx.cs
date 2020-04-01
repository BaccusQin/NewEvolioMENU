using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewEvolioMenu
{
    public partial class ChangePW : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int LangID = Convert.ToInt32(Session["LangID"]);
            switch (LangID)
            {
                case Login.C_LANG_ENG:
                    lbPstPW.Text = "Old Password:  ";
                    lbNEWPW.Text = "New Password:  ";
                    lbNEWCONPW.Text = "Confirm Password:   ";
                    chanPwBtn.Text = "Update";
                    quitWinBtn.Text = "Quit";
                    break;
                case Login.C_LANG_JPN:
                    lbPstPW.Text = "現在のパスワード：  ";
                    lbNEWPW.Text = "新しいパスワード：  ";
                    lbNEWCONPW.Text = "新しいパスワード（確認）： ";
                    chanPwBtn.Text = "変更";
                    quitWinBtn.Text = "閉じる";
                    break;
            }
        }

        protected void chanPwBtn_Click(object sender, EventArgs e)
        {
            string UserID = Session["UserID"].ToString();
            string nowPw = TextBox1.Text;
            string chaPw = TextBox2.Text;
            string chaPwCon = TextBox3.Text;
            ChanPW chanPW = new ChanPW();
            int LangID=Convert.ToInt32(Session["LangID"]);
            try
            {
                if (chanPW.CheckPassWord(UserID, nowPw) == 1)
                {
                    if (chaPw == chaPwCon)
                    {
                        if (chaPw.Trim().Length == 0 || chaPwCon.Trim().Length == 0)
                        {
                            switch (LangID)
                            {
                                case Login.C_LANG_ENG:
                                    ErroMessage.Text = "Please Enter New Password.";
                                    break;
                                case Login.C_LANG_JPN:
                                    ErroMessage.Text = "新しいパスワードを入力してください。";
                                    break;
                            }
                        }
                        else
                        {
                            chanPW.ChanPw(UserID, chaPw);
                            switch (LangID)
                            {
                                case Login.C_LANG_ENG:
                                    ErroMessage.Text = "Password Changed.";
                                    break;
                                case Login.C_LANG_JPN:
                                    ErroMessage.Text = "パスワードを変更しました。";
                                    break;
                            }
                            TextBox1.Text = "";
                            TextBox2.Text = "";
                            TextBox3.Text = "";
                        }
                        
                    }
                    else
                    {
                        switch (LangID)
                        {
                            case Login.C_LANG_ENG:
                                ErroMessage.Text = "New Password Does Not Match.";
                                break;
                            case Login.C_LANG_JPN:
                                ErroMessage.Text = "新しいパスワードが一致しません。";
                                break;
                        }

                    }

                }
                else
                {
                    switch (LangID)
                    {
                        case Login.C_LANG_ENG:
                            ErroMessage.Text = "Old Password Does Not Match.";
                            break;
                        case Login.C_LANG_JPN:
                            ErroMessage.Text = "現在のパスワードが一致しません。";
                            break;
                    }

                }

            }
            catch (Exception ex)
            {
                ErroMessage.Text = ex.Message;
               
            }
            finally
            {
                ErroMessage.Style.Value = "visibility:visible";
            }

        }
    }
}