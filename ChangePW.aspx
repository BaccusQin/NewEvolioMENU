<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePW.aspx.cs" Inherits="NewEvolioMenu.ChangePW" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ChangePassWord</title>
<link rel="stylesheet" href="resources/css/reset.css" type="text/css" media="screen" />
<!-- Main Stylesheet -->
<link rel="stylesheet" href="resources/css/style.css" type="text/css" media="screen" />
<!-- Invalid Stylesheet. This makes stuff look pretty. Remove it if you want the CSS completely valid -->
<link rel="stylesheet" href="resources/css/invalid.css" type="text/css" media="screen" />
<!-- jQuery -->
<script type="text/javascript" src="resources/scripts/jquery-1.3.2.min.js"></script>
<!-- jQuery Configuration -->
<script type="text/javascript" src="resources/scripts/simpla.jquery.configuration.js"></script>
<!-- Facebox jQuery Plugin -->
<script type="text/javascript" src="resources/scripts/facebox.js"></script>
<!-- jQuery WYSIWYG Plugin -->
<script type="text/javascript" src="resources/scripts/jquery.wysiwyg.js"></script>
<!-- jQuery Datepicker Plugin -->
<script type="text/javascript" src="resources/scripts/jquery.datePicker.js"></script>
<script type="text/javascript" src="resources/scripts/jquery.date.js"></script>
<script type="text/javascript" src="resources/scripts/Common.js" charset="utf-8"></script>
</head>
<body style="overflow:hidden;background:#438f2d">
    <form id="form1" runat="server">
    <div style="overflow:hidden; width:auto;">
         <div  style="text-align:center;margin:8px 0 0 0;color:red;font-size:13px;">
     <asp:Label ID="ErroMessage" runat="server" Text="ErroMessage" style="visibility:hidden;align-content:center;"></asp:Label>
    </div>
  <div style="position:absolute;top:20%;left:20%;font-size:13px;color:#030000;width:400px;">
      <table style="width:auto;table-layout:fixed;height:110px;" >
      <tr>
          <td>
             <asp:Label ID="lbPstPW" runat="server" Text="Label"></asp:Label>
          </td>
          <td>
              &nbsp&nbsp<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          </td>
      </tr>
      <tr>
          <td>
            <asp:Label ID="lbNEWPW" runat="server" Text="Label"></asp:Label>
          </td>
          <td>
            &nbsp  <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          </td>
      </tr>
      <tr>
          <td>
              <asp:Label ID="lbNEWCONPW" runat="server" Text="Label"></asp:Label>
          </td>
          <td>
             &nbsp <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
          </td>
      </tr>
      </table>
   </div>
    <div style="text-align:center;position:absolute;top:80%;left:36%;overflow:hidden;">
    
     <asp:Button ID="chanPwBtn" runat="server" Text="Button" class="staticbutton" Onclick="chanPwBtn_Click" />&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp
     <asp:Button ID="quitWinBtn" runat="server" Text="Button" class="staticbutton" OnClientClick="closeSubWin();"  />
    </div>
    </div>
    </form>
</body>
</html>
