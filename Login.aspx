<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NewEvolioMenu.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,Chrome=1" />
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Cache-Control" content="no-cache" />
<meta http-equiv="content-script-type" content="text/javascript" />
  <title>EvolioLogin</title>
    <!--                       CSS                       -->
<!-- Reset Stylesheet -->
<link rel="stylesheet" href="resources/css/reset.css" type="text/css" media="screen" />
<!-- Main Stylesheet -->
<link rel="stylesheet" href="resources/css/style.css" type="text/css" media="screen" />
<!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
<link rel="stylesheet" href="resources/css/invalid.css" type="text/css" media="screen" />
<!--                       Javascripts                       -->
<!-- jQuery -->
<script type="text/javascript" src="resources/scripts/jquery-1.3.2.min.js"></script>
<!-- jQuery Configuration -->
<script type="text/javascript" src="resources/scripts/simpla.jquery.configuration.js"></script>
<!-- Facebox jQuery Plugin -->
<script type="text/javascript" src="resources/scripts/facebox.js"></script>
<!-- jQuery WYSIWYG Plugin -->
<script type="text/javascript" src="resources/scripts/jquery.wysiwyg.js"></script>
<script type="text/javascript" src="resources/scripts/Common.js" charset="utf-8"></script>
</head>
<body id="login">
<form id="LOGINFORM" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
<div id="login-wrapper" class="png_bg">
    <div id="login-la"> 
     <asp:LinkButton ID="insDownload" runat="server" CssClass="LaLinkButton" style="margin:20px 0 0 40px;display:inline-block;width:300px;" OnClientClick="downloadInstaller();">Installer Download</asp:LinkButton>
    <asp:LinkButton ID="LinkEn" runat="server" Text="English" CssClass="LaLinkButton" Style="margin: 20px 0 0 600px;width:100px" OnClick="LinkEn_Click" ></asp:LinkButton>
    <asp:LinkButton ID="LinkJa" runat="server" Text="日本語" CssClass="LaLinkButton" Style="margin: 20px 0 0 10px;" OnClick="LinkJa_Click" ></asp:LinkButton>
   
    </div>
  <div id="login-top">
    <h1>EVOLIO MENU</h1>
    <!-- Logo (221px width) -->
    <a><img id="logo" src="resources/images/logo.png" /></a> 
  </div>
  <!-- End #logn-top -->
 
  <div id="login-content">
  
      <div id="NotiDiv" class="notification information error " runat="server">
          <div><asp:Label ID="lb_Notification" runat="server" Text="Label" ></asp:Label></div>
      </div>
      
      <p>
        <asp:label ID="lb_UserName" runat="server" Text="UserName"  style="font-size:17px;float:left;"></asp:label> 
        <asp:TextBox ID="TextUserName" runat="server" Cssclass="text-input" type="text" Width="200px" />
      </p>
      
      <div class="clear"></div>
      <p>
      <asp:label ID="lb_PassWord" runat="server" Text="PassWord" style="font-size:17px;float:left"></asp:label>
      <asp:TextBox ID="TextPassWord" class="text-input" type="password" runat="server"/>
      </p>
      <div style="float:left">
      <asp:Button ID="BtnLogin" runat="server" Text="Login" class="button"  style="width:90px;font-size:14px;margin:0 0 0 200px" Onclick="BtnLogin_Click" />
      </div>
  </div>
  </ContentTemplate>
 </asp:UpdatePanel>
  <!-- End #login-content -->


<!-- End #login-wrapper -->
 </form>
</body>

</html>
