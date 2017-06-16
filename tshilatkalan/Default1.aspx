<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default1.aspx.cs" Inherits="Default1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <asp:TreeView ID="treeView1"  ExpandDepth="0" 
  PopulateNodesFromClient="true"
  ShowLines="true" 
  ShowExpandCollapse="true" runat="server" MaxDataBindDepth="2" 
            ontreenodepopulate="treeView1_TreeNodePopulate" OnSelectedNodeChanged="trch" Width="295px">



        </asp:TreeView>

    </div>
    </form>
</body>
</html>
