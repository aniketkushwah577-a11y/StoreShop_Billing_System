<%@ Page Title="Sale Reports" Language="vb"
    AutoEventWireup="false"
    MasterPageFile="~/Default.Master"
    CodeBehind="SaleReport.aspx.vb"
    Inherits="School_Item.SaleReport" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2"
    ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="card mt-4">
        <div class="card-header">
            <strong>Saved Sale List</strong>
        </div>


        <div class="card-body">
            <p class="text-muted">
                View and manage your sales records here.
            </p>

            <div class="row mb-3">
                <div class="col-md-4">
                    <label>From Date</label>
                    <asp:TextBox ID="txtFromDate" runat="server"
                        CssClass="form-control"
                        TextMode="Date">
                    </asp:TextBox>
                </div>

                <div class="col-md-4">
                    <label>To Date</label>
                    <asp:TextBox ID="txtToDate" runat="server"
                        CssClass="form-control"
                        TextMode="Date">
                    </asp:TextBox>
                </div>

                <div class="col-md-4 mt-4">
                    <asp:Button ID="btnFilter" runat="server"
                        Text="Filter" OnClick="btnFilter_Click"
                        CssClass="btn btn-primary" />

                    <asp:Button ID="btnReset" runat="server"
                        Text="Reset"
                        OnClick="btnReset_Click"
                        CssClass="btn btn-secondary" />
                </div>
            </div>
            <%--<div class="portal-card-body">
                <div class="row justify-content-end">
                    <div class="col-md-4 col-lg-3">
                        <div class="total-panel">
                            <div class="total-label">Grand Total</div>
                            <asp:Label ID="Label1" runat="server"
                                CssClass="total-value"
                                Text="₹ 0.00" />
                        </div>
                    </div>
                </div>--%>
        </div>



        <div class="table-responsive">
            <asp:GridView ID="gvSaleReport" runat="server"
                AutoGenerateColumns="False"
                CssClass="table table-hover table-striped"
                GridLines="None"
                OnRowCommand="gvSaleReport_RowCommand"
                EmptyDataText="No sales records found.">

                <Columns>

                    <asp:BoundField DataField="Sale_Code"
                        HeaderText="Sale Code" />

                    <asp:BoundField DataField="Invoice_No"
                        HeaderText="Invoice No" />

                    <asp:BoundField DataField="Invoice_Date"
                        HeaderText="Invoice Date"
                        DataFormatString="{0:dd-MM-yyyy}" />

                    <asp:BoundField DataField="Party_Name"
                        HeaderText="Party Name" />

                    <asp:BoundField DataField="Grand_Total"
                        HeaderText="Grand Total"
                        DataFormatString="{0:N2}" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnEdit" runat="server"
                                Text="Edit"
                                CommandName="Edit"
                                CommandArgument='<%# Eval("Sale_Code") %>'
                                CssClass="btn btn-warning btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnDelete" runat="server"
                                Text="Delete"
                                CommandName="Delete"
                                CommandArgument='<%# Eval("Sale_Code") %>'
                                CssClass="btn btn-danger btn-sm" />
                            <%--OnClientClick="return confirm('Are you sure you want to delete this sale record?');"--%>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>

            </asp:GridView>
        </div>

    </div>

</asp:Content>
