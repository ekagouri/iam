<%@ Page Language="C#" AutoEventWireup="true" MaintainScrollPositionOnPostback="true" EnableViewStateMac="false" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8">
	<meta name="viewport" content="width=device-width, initial-scale=1">
	<title>Baxter Account Status</title>
	<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
	<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
	<script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js"></script>
	<script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
	<script src="https://use.fontawesome.com/releases/v5.0.8/js/all.js"></script>
	<link href="css/style.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server"> 
    <nav class="navbar navbar-expand-md navbar-light bg-light sticky-top">
        <div class="container-fluid">
	        <a class="navbar-brand" href="#"><img src="img/baxter.gif"></a>
	        <button class="navbar-toggler" type="button" data-toggle="collapse" 
	        data-target="#navbarResponsive">
		        <span class="navbar-toggler-icon"></span>
	        </button>	       
        </div>
    </nav>
    <!--- Image Slider -->
    <div id="slides" class="carousel slide" data-ride="carousel">	   
    <div class="carousel-inner">
	    <div class="carousel-item active">
		    <img src="img/sustain.PNG">
		    <div class="carousel-caption">
			    <h3>Look up account status</h3>
                <asp:DropDownList ID="ddlOption" CssClass="lead" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlOption_SelectedIndexChanged">
                    <asp:ListItem Value="sAMAccountName">User ID</asp:ListItem>
                    <asp:ListItem Value="employeeNumber">Employee Number</asp:ListItem>
                    <asp:ListItem Value="mail">Email</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtSearch" CssClass="lead" runat="server" Width="300px"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary btn-lg" OnClick="btnSearch_Click"/> 
                <asp:Button ID="btnClear" runat="server" Text="Clear" CssClass="btn btn-primary btn-lg" OnClick="btnClear_Click"/>
		    </div>
	    </div>
    </div>
    </div>

    <!--- Jumbotron -->
    <div class="container-fluid">
    <div class="row jumbotron">
	    <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 col-xl-10" style="vertical-align: top">
            <asp:Panel ID="pnlResult" runat="server">
		    <h3>Account Information</h3>       
            <p class="lead">
              <asp:Label ID="Label1" runat="server" Text="First Name:"></asp:Label> <asp:Label ID="lblFirstName" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            <p class="lead">Last Name: <asp:Label ID="lblLastName" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            <p class="lead">User Id: <asp:Label ID="lblUid" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            <p class="lead">Employee Number: <asp:Label ID="lblEmpNum" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            <p class="lead">Email Address: <asp:Label ID="lblEmail" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            <p class="lead">Display Name: <asp:Label ID="lblDispName" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            <p class="lead">Manager: <asp:Label ID="lblMgr" runat="server" class="lead" Font-Bold="true"></asp:Label></p>         
            <p class="lead">Employee Type: <asp:Label ID="lblEmpType" runat="server" class="lead"></asp:Label> (Account Expires - <asp:Label ID="lblExpires" runat="server" class="lead"></asp:Label>)</p>             
            <p class="lead">Account Created: <asp:Label ID="lblAccountCreated" runat="server" class="lead"></asp:Label></p> 
            <p class="lead">Account Status: <asp:Label ID="lblAccountStatus" runat="server" class="lead" Font-Bold="true"></asp:Label></p>             
            <p class="lead">Account Lockout: <asp:Label ID="lblLockout" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            <p class="lead">Last Password Reset: <asp:Label ID="lblPwdReset" runat="server" class="lead" Font-Bold="true"></asp:Label></p>
            <p><asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="https://connect.baxter.com/sites/functions/IT/Pages/Self-Service-Acct-Mgmt.aspx" Target="_blank">Go to Password Reset Self Service</asp:HyperLink></p> 
            <br />
            <p class="lead">Search was executed from a domain controller (AD Server) : <asp:Label ID="LblLogonServer" runat="server" class="lead" Font-Bold="true"></asp:Label></p> 
            </asp:Panel>
            <p>
                <asp:Label ID="lblError" runat="server" class="lead"></asp:Label></p>
            <script type="text/javascript" src="https://eujira.baxter.com/jira/s/95545bd68197dd0886ecc2623646c4ec-T/-tq38j6/77002/79d2e79ff81b2bdcbe4c4afe1e0a5a60/2.0.24/_/download/batch/com.atlassian.jira.collector.plugin.jira-issue-collector-plugin:issuecollector/com.atlassian.jira.collector.plugin.jira-issue-collector-plugin:issuecollector.js?locale=en-US&collectorId=c3610e78"></script>


	    </div>
    </div>
    </div>

    </form>
</body>
</html>