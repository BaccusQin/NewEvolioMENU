using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NewEvolioMenu
{
    public partial class Login : System.Web.UI.Page
    {
    
        public const int C_LANG_JPN = 0;　　//日本語
        public const int C_LANG_ENG = 1;   //英語
        public int intLocalLaId
        {
            get
            {
                return (int)ViewState["intLa"];
            }
            set
            {
                ViewState["intLa"] = value;
            }
        }
        




        protected void Page_Load(object sender, EventArgs e)
        {
            NotiDiv.Style.Value = "visibility:hidden";
            if (!IsPostBack)
            {
                intLocalLaId = 1;
                
            }
            
           
        }
        

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                
                ConnectDB myconn = new ConnectDB();
                int LoginStatue = myconn.CheckPassWord(TextUserName.Text, TextPassWord.Text);
                if (LoginStatue == 1)
                {
                    Session["UserID"] = TextUserName.Text;
                    Response.Redirect("Menu.aspx");
                }
                else
                {
                    switch (intLocalLaId)
                    {
                        case C_LANG_ENG:
                             lb_Notification.Text = "Certification Failed.";
                            break;
                        case C_LANG_JPN:
                             lb_Notification.Text = "認証に失敗しました。";
                            break;
                    }
                       
                    NotiDiv.Style.Value = "visibility:visible";
                }
                myconn.CloseDB();
            }
            catch(Exception ex)
            {
                lb_Notification.Text = ex.Message;
                NotiDiv.Style.Value = "visibility:visible";
            }
           
        }

        protected void LinkEn_Click(object sender, EventArgs e)
        {
            lb_UserName.Text = "UserName";
            lb_PassWord.Text = "PassWord";
            BtnLogin.Text = "Login";
            intLocalLaId = 1;
            insDownload.Text = "Installer Download";
        }

        protected void LinkJa_Click(object sender, EventArgs e)
        {
            lb_UserName.Text = "ユーザID";
            lb_PassWord.Text = "パスワード";
            BtnLogin.Text = "ログイン";
            intLocalLaId = 0;
            insDownload.Text = "インストーラ ダウンロード";
        }
    }
}