
<%@ Page Title="Settings" Language="vb"
    AutoEventWireup="false"
    MasterPageFile="~/Default.Master"
    CodeBehind="Settings.aspx.vb"
    Inherits="School_Item.Settings" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">

        <h2 class="mb-1">Settings</h2>
        <p class="text-muted mb-4">
            Manage your application preferences.
        </p>

        <div class="card border-0 shadow-sm">

            <div class="card-header bg-white">
                <h5 class="mb-0">
                    <i class="bi bi-gear me-2"></i>
                    General Settings
                </h5>
            </div>

            <div class="card-body">

                <div class="row g-3">

                    <div class="col-md-6">
                        <label class="form-label">Application Name</label>
                        <asp:TextBox ID="txtAppName" runat="server"
                            CssClass="form-control"
                            Text="School Item Management" />
                    </div>

                    <div class="col-md-6">
                        <label class="form-label">Administrator Name</label>
                        <asp:TextBox ID="txtAdminName" runat="server"
                            CssClass="form-control"
                            Text="Administrator" />
                    </div>

                    <div class="col-md-6">
                        <label class="form-label">Date Format</label>
                        <asp:DropDownList ID="ddlDateFormat" runat="server"
                            CssClass="form-select">
                            <asp:ListItem Text="DD-MM-YYYY" Value="dd-MM-yyyy" />
                            <asp:ListItem Text="MM-DD-YYYY" Value="MM-dd-yyyy" />
                            <asp:ListItem Text="YYYY-MM-DD" Value="yyyy-MM-dd" />
                        </asp:DropDownList>
                    </div>

                    <div class="col-12">
                        <asp:Button ID="btnSaveSettings" runat="server"
                            Text="Save Settings"
                            CssClass="btn btn-primary" />
                    </div>

                </div>

            </div>
        </div>

    </div>

</asp:Content>
