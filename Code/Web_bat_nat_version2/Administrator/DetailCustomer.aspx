﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Administrator/MasterPage.master"
    AutoEventWireup="true" CodeFile="DetailCustomer.aspx.cs" Inherits="Administrator_DetailCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="content">
        <div class="box">
            <!-- box / title -->
            <div class="title">
                <h5>
                    Cập nhật khách hàng
                </h5>
            </div>
            <!-- end box / title -->
            <div id="divMessage" runat="server">
            </div>
            <div class="form">
                <div class="fields">
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Tên khách hàng</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtCustomerName" MaxLength="500" class="required medium" Width="500"
                                runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Email</label></div>
                        <div class="input">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="required email" Width="500"></asp:TextBox>
                        </div>
                    </div>
                    <div class="field">
                        <div class="label">
                            <label class="small-label">
                                Số điện thoại
                            </label>
                        </div>
                        <div class="input">
                            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="required" Width="500"></asp:TextBox>
                        </div>
                    </div>
                    <div class="buttons">
                        <div class="button ">
                            <div class="highlight">
                                <asp:Button CssClass="ui-button ui-widget ui-state-default ui-corner-all" Text="Cập nhật"
                                    ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" />
                            </div>
                            <input aria-disabled="false" role="button" class="ui-button ui-widget ui-state-default ui-corner-all"
                                value="Quay lại" onclick="location.href='../Administrator/Customer.aspx'" type="button">&nbsp;
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>