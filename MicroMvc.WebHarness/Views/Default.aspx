<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MicroMvc.WebTest._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head >
    <title>Untitled Page</title>
</head>
<body>
    <h1>MicroMVC Success!</h1>

    <table border=1 cellpadding=10px>
        <tr><th>Property</th><th>Value</th></tr>
        <tr><td><b>FirstName</b></td><td><%= this.ViewData.FirstName %></td></tr>
        <tr><td><b>LastName</b></td><td><%= this.ViewData.LastName %></td></tr>
        <tr><td><b>Phone</b></td><td><%= this.ViewData.Phone%></td></tr>
    </table>

    <div>
    See this data in a differnt view
    <ul>
    <li>As <a href="<%= this.ViewData.FirstName %>?xml">XML</a></li>
    <li>As <a href="<%= this.ViewData.FirstName %>?json">json</a></li>
    </ul>
    </div>
    
    <p>Powerd by <a href="http://code.google.com/p/micromvc-asp">MicroMVC</a></p>
</body>
</html>
