<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="ControlPannel.aspx.cs" Inherits="Administrator_ControlPannel" %>

<%@ Register Assembly="CollectionPager" Namespace="SiteUtils" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .table
        {
            border-top: 1px solid #DDDDDD !important;
            clear: both;
            margin: 0;
            overflow: hidden;
            padding-left: 20px;
            padding-right: 20px;
            padding-top: 20px !important;
        }
        .totalCus
        {
            font-size: 40px;
            padding-top: 20px;
            position: relative;
            top: 20px;
        }
        #H1
        {
            position: relative;
            top: 10px;
        }
        
        #container
        {
            background: none repeat scroll 0 0 #FFFFFF;
            clear: both;
            margin: 0 40px;
            min-height: 100%;
            overflow: hidden;
            padding: 0 0 50px;
        }
        #content #left
        {
            position: static;
        }
        #left
        {
            float: left;
            width: 25%;
            height: 80px;
        }
        #right
        {
            float: left;
            width: 35%;
            height: 80px;
        }
        #buttonXem
        {
            float: left;
            margin-top: 8px;
        }
        #content #right
        {
            clear: none;
            margin: 0px;
            width: 290px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <script type="text/javascript">
            var index = "";
            $(document).ready(function () {
                $("input.add").click(function () {
                    window.location.replace(window.location.pathname + "?module=clipsadd");
                });
                $("input.del").click(function () {
                    $("table input[type=checkbox].item").each(function () {
                        var checked = $(this).attr("checked");
                        if (checked) {
                            index = index + $(this).attr("value") + ";";
                        }
                    });
                    $("#<%=hdfCheck.ClientID%>").val(index);
                    if (index == "") return false;
                    else return confirm("Xác nhận xóa !");
                });

            });
        </script>
        <asp:HiddenField ID="hdfCheck" runat="server" />
        <div class="box" id="boxMess" runat="server">
            <!-- box / title -->
            <div class="title" style="background-color: #3B5998">
                <h5 id="txtTitle">
                    Control Pannel
                </h5>
            </div>
            <div id="divMessage" runat="server">
            </div>
            <!-- end box / title -->            
        </div>
        <!-- end table -->
    </div>
</asp:Content>
