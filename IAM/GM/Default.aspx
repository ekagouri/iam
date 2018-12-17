<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Group_Management_Default" %>

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
	        <a class="navbar-brand" href="#"><img src="../img/baxter.gif"></a>
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
		    <img src="../img/sustain.PNG">
		    <div class="carousel-caption">
			    <h3>Update Group</h3>
                <script type="text/javascript" src="https://eujira.baxter.com/jira/s/65ef1e00d3214f75449a8833f432eb23-T/jgwhd7/77002/79d2e79ff81b2bdcbe4c4afe1e0a5a60/2.0.24/_/download/batch/com.atlassian.jira.collector.plugin.jira-issue-collector-plugin:issuecollector/com.atlassian.jira.collector.plugin.jira-issue-collector-plugin:issuecollector.js?locale=en-US&collectorId=c3610e78"></script>

		    </div>
	    </div>
    </div>
    </div>

    <!--- Jumbotron -->
    <div class="container-fluid">
    <div class="row jumbotron">
	    <div class="col-xs-12 col-sm-12 col-md-9 col-lg-9 col-xl-10" style="vertical-align: top">
       
	    </div>
    </div>
    </div>

    </form>
</body>
</html>
