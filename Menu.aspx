<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="NewEvolioMenu.Menu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

 <title>EVOLIO MENU</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=edge,Chrome=1" />
<meta http-equiv="Pragma" content="no-cache" />
<meta http-equiv="Cache-Control" content="no-cache" />
<meta http-equiv="content-script-type" content="text/javascript" />
<!--                       CSS                       -->
<!-- Reset Stylesheet -->
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
<body>
<form id="Menu" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

 <div id="body-wrapper">
  <!-- Wrapper for the radial gradient background -->
  <div id="sidebar">
    <div id="sidebar-wrapper">
      <!-- Sidebar with logo and menu -->
      <h1 id="sidebar-title"><a href="#">Simpla Admin</a></h1>
      <!-- Logo (221px wide) -->
      <a href="#"><img id="logo" src="resources/images/logo.png" alt="Simpla Admin logo" /></a>
      <!-- Sidebar Profile links -->
      <div id="profile-links"> <asp:Label ID="LabUserName"  runat="server" Text="Label"></asp:Label><asp:Label ID="userName" runat="server" Text="Label"></asp:Label> &nbsp &nbsp<asp:Label ID="LabDept" runat="server" Text="Label"></asp:Label><asp:Label ID="deptName" runat="server" Text="Label"></asp:Label> <br />
        <br />
     <asp:LinkButton ID="chanPW" runat="server" OnClientClick="ShowDiv('MyDiv','fade');return false;">LinkButton</asp:LinkButton>&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <asp:LinkButton ID="logOut" runat="server" OnClick="logOut_Click">LinkButton</asp:LinkButton> </div>
      <ul id="main-nav">
        <%=strLiList%>
      </ul>
         
      <!-- End #main-nav -->
      <div id="messages" style="display: none">
        <!-- Messages are shown when a link with these attributes are clicked: href="#messages" rel="modal"  -->
        <h3>3 Messages</h3>
        <p> <strong>17th May 2009</strong> by Admin<br />
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus magna. Cras in mi at felis aliquet congue. <small><a href="#" class="remove-link" title="Remove message">Remove</a></small> </p>
        <p> <strong>2nd May 2009</strong> by Jane Doe<br />
          Ut a est eget ligula molestie gravida. Curabitur massa. Donec eleifend, libero at sagittis mollis, tellus est malesuada tellus, at luctus turpis elit sit amet quam. Vivamus pretium ornare est. <small><a href="#" class="remove-link" title="Remove message">Remove</a></small> </p>
        <p> <strong>25th April 2009</strong> by Admin<br />
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus magna. Cras in mi at felis aliquet congue. <small><a href="#" class="remove-link" title="Remove message">Remove</a></small> </p>
        
      </div>
      <!-- End #messages -->
    </div>
  </div>
  <!-- End #sidebar -->

  <div id="main-content">
    <!-- Page Head -->
    <div style="height:100px" class="content-box-content">
    <h2><asp:Label ID="mainPageTitle" runat="server" Text="Label"></asp:Label></h2>
    <p id="page-intro">
        <asp:Label ID="subPageTitle" runat="server" Text="Label"></asp:Label></p>
    </div>
    <!-- End .shortcut-buttons-set -->
    <div class="clear"></div>
    <!-- End .clear -->
    <div style="height:500px;overflow:scroll;">
  
      <!-- End .content-box-header -->
  
          <!-- This is the target div. id must match the href of this div's tab -->
     
            <%=strSubTbl%>

    </div>
      <asp:Label ID="TxtEvoUsr" runat="server" Text="Label" style="display:none;"></asp:Label>
      <asp:Label ID="TxtEvoPas" runat="server" Text="Label" style="display:none;"></asp:Label>
      <asp:Label ID="HdnLangState" runat="server" Text="Label" style="display:none;"></asp:Label>
    <div class="clear"></div>
    <div id="footer"> <small>
      <!-- Remove this notice or replace it with whatever you want -->
      &#169; Copyright 2020 NTMC | Powered by <a href="#">FTC IS</a> | <a href="#">Top</a> </small> <a href="#"  target="_blank"></a></div>
    <!-- End #footer -->
  </div>
  <!-- End #main-content -->
</div>

<div id="fade" class="black_overlay">
</div>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
 <ContentTemplate>
<div id="MyDiv" class="white_content_small" style="height:200px;overflow:hidden;width:470px;">
<iframe id="MyFrame" src="ChangePW.aspx"  style="width:100%; height:100%;overflow:hidden;">
    <div><input value="button"></div>
</iframe>
</div>
  </ContentTemplate>
 </asp:UpdatePanel>
</form>
</body>
</html>
