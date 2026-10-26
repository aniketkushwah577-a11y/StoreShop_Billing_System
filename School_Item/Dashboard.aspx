<%@ Page Title="Dashboard" Language="vb"
    AutoEventWireup="false"
    MasterPageFile="~/Default.Master"
    CodeBehind="Dashboard.aspx.vb"
    Inherits="School_Item.Dashboard" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="mb-4">Dashboard</h2>

    <div class="row g-3">

        <div class="col-md-4">
            <div class="card shadow-sm border-0">
                <div class="card-body">
                    <i class="bi bi-box-seam fs-2 text-primary"></i>
                    <h5 class="mt-3">Item Master</h5>
                    <p class="text-muted">Manage school items.</p>
                    <a href="<%= ResolveUrl("~/SchoolForm.aspx") %>"
                       class="btn btn-primary btn-sm">
                        Open Item Master
                    </a>
                </div>
            </div>
        </div>

        <div class="col-md-4">
            <div class="card shadow-sm border-0">
                <div class="card-body">
                    <i class="bi bi-receipt fs-2 text-success"></i>
                    <h5 class="mt-3">Sale Entry</h5>
                    <p class="text-muted">Create a new sale invoice.</p>
                    <a href="<%= ResolveUrl("~/SaleEntry.aspx") %>"
                       class="btn btn-success btn-sm">
                        Open Sale Entry
                    </a>
                </div>
            </div>
        </div>

    </div>

</asp:Content>