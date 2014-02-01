<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <%--<section class="featured">
        <div class="content-wrapper" style="position:fixed;">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Modify this template to jump-start your ASP.NET application.</h2>
            </hgroup>
          
           
        </div>
         
    </section>--%>
    <link rel="stylesheet" type="text/css" href="dist/jquery.gridster.css">
            <link rel="stylesheet" type="text/css" href="assets/demo.css">
</asp:Content>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
   
    <%--<ol class="round">
        <li class="one">
            <h5>Getting Started</h5>
            ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245146">Learn more…</a>
        </li>
        <li class="two">
            <h5>Add NuGet packages and jump-start your coding</h5>
            NuGet makes it easy to install and update free libraries and tools.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245147">Learn more…</a>
        </li>
        <li class="three">
            <h5>Find Web Hosting</h5>
            You can easily find a web hosting company that offers the right mix of features and price for your applications.
            <a href="http://go.microsoft.com/fwlink/?LinkId=245143">Learn more…</a>
        </li>
    </ol>--%>
   <%-- <h6>Add widgets dynamically</h6>
    <p>Create a grid adding widgets from an Array (not from HTML) using <code>add_widget</code> method. Widget position (col, row) not specified.</p>--%>

    <div class="gridster">
           
        <ul>
            
                  
        </ul>
    </div>

    <script type="text/javascript" src="assets/jquery.js"></script>
    <script src="dist/jquery.gridster.js" type="text/javascript" charset="utf-8"></script>

    <script type="text/javascript" id="code">
        var gridster;
        function cre(t) {
            var widgets = t;
           
            $(function () {
              
                gridster = $(".gridster > ul").gridster({
                    widget_base_dimensions: [100, 100],
                    widget_margins: [5, 5],
                   
                  }).data('gridster');

                  $.each(widgets, function (i, widget) {
                      gridster.add_widget.apply(gridster, widget)


                      gridster.$el
           .on('click', '> div', function () {
              var abc = document.getElementById('pass').value;
               alert(abc);
               window.location = '<%= ResolveUrl("~/Demo hover.aspx?param1=") %>';
             //  gridster.resize_widget($(this), 3, 3);
           })
           .on('mouseleave', '> li', function () {
               gridster.resize_widget($(this), 2, 2);
           });
                });

            });
        }
       
    </script>
</asp:Content>
