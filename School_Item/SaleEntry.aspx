<%@ Page Title="Sale Entry" Language="vb" AutoEventWireup="false"
    MasterPageFile="~/Default.Master"
    CodeBehind="SaleEntry.aspx.vb"
    Inherits="School_Item.SaleEntry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .sale-portal {
            background: #f4f7fb;
            min-height: 85vh;
            padding: 24px;
        }

        .portal-heading {
            display: flex;
            justify-content: space-between;
            align-items: center;
            margin-bottom: 22px;
        }

            .portal-heading h3 {
                font-size: 24px;
                font-weight: 700;
                color: #1e293b;
                margin: 0;
            }

        .portal-subtitle {
            color: #64748b;
            font-size: 13px;
            margin-top: 5px;
        }

        .portal-card {
            background: #fff;
            border: 1px solid #e2e8f0;
            border-radius: 10px;
            margin-bottom: 20px;
            overflow: hidden;
            box-shadow: 0 3px 12px rgba(15, 23, 42, .04);
        }

        .portal-card-header {
            padding: 15px 20px;
            background: #fff;
            border-bottom: 1px solid #e9eef5;
            font-size: 15px;
            font-weight: 700;
            color: #24364b;
        }

        .portal-card-body {
            padding: 20px;
        }

        .sale-portal label {
            display: block;
            font-size: 12px;
            font-weight: 600;
            color: #475569;
            margin-bottom: 6px;
        }

        .sale-portal .form-control,
        .sale-portal .form-select {
            border-color: #d7e0eb;
            border-radius: 6px;
            font-size: 13px;
            min-width: 0;
            box-shadow: none;
        }

            .sale-portal .form-control:focus,
            .sale-portal .form-select:focus {
                border-color: #3b82f6;
                box-shadow: 0 0 0 3px rgba(59, 130, 246, .12);
            }

        .sale-portal .form-control-sm,
        .sale-portal .form-select-sm {
            min-height: 36px;
        }

        .item-entry-grid {
            display: grid;
            grid-template-columns: 1fr 1.5fr .7fr .8fr .9fr .9fr auto;
            gap: 12px;
            align-items: end;
        }

        .btn-add-item {
            height: 36px;
            padding: 0 20px;
            font-size: 13px;
            font-weight: 600;
            white-space: nowrap;
        }

        .total-panel {
            background: #eff6ff;
            border: 1px solid #bfdbfe;
            border-radius: 8px;
            padding: 14px 18px;
            text-align: right;
        }

        .total-label {
            color: #475569;
            font-size: 12px;
        }

        .total-value {
            font-size: 24px;
            font-weight: 700;
            color: #1d4ed8;
        }

        .sale-grid {
            width: 100%;
            border-collapse: collapse;
            font-size: 13px;
        }

            .sale-grid th {
                background: #f1f5f9;
                color: #475569;
                padding: 12px;
                text-align: left;
                border-bottom: 1px solid #e2e8f0;
            }

            .sale-grid td {
                padding: 11px 12px;
                border-bottom: 1px solid #edf1f6;
            }

        @media (max-width: 992px) {
            .item-entry-grid {
                grid-template-columns: repeat(3, minmax(0, 1fr));
            }
        }

        @media (max-width: 576px) {
            .sale-portal {
                padding: 12px;
            }

            .item-entry-grid {
                grid-template-columns: repeat(2, minmax(0, 1fr));
            }

            .portal-card-body {
                padding: 14px;
            }
        }
    </style>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="sale-portal">

        <!-- Page Heading -->
        <div class="portal-heading">
            <div>
                <h3>Sale Entry</h3>
                <div class="portal-subtitle">
                    Sales Management / Create New Invoice
                </div>
            </div>

            <span class="badge text-bg-primary px-3 py-2">NEW SALE
            </span>
        </div>

        <!-- Invoice Information -->
        <div class="portal-card">
            <div class="portal-card-header">
                Invoice Information
            </div>
            <asp:Label ID="lblMessage" runat="server"
                CssClass="text-danger" />
            <div class="portal-card-body">
                <div class="row g-3">

                    <div class="col-lg-3 col-md-6">
                        <label>Invoice No.</label>
                        <asp:TextBox ID="txtInvoiceNo" runat="server"
                            CssClass="form-control form-control-sm"
                            ReadOnly="True" />
                    </div>

                    <div class="col-lg-3 col-md-6">
                        <label>Invoice Date</label>
                        <asp:TextBox ID="txtInvoiceDate" runat="server"
                            TextMode="Date"
                            CssClass="form-control form-control-sm" />
                    </div>

                    <div class="col-lg-3 col-md-6">
                        <label>Party Number</label>
                        <asp:TextBox ID="txtpartyNo" runat="server"
                            CssClass="form-control form-control-sm" />
                    </div>

                    <div class="col-lg-3 col-md-6">
                        <label>Party Name</label>
                        <asp:TextBox ID="txtPartyName" runat="server"
                            CssClass="form-control form-control-sm" />
                    </div>

                </div>
            </div>
        </div>

        <!-- Item Entry -->
        <div class="portal-card">
            <div class="portal-card-header">
                Add Sale Item
            </div>

            <div class="portal-card-body">
                <div class="item-entry-grid">

                    <div>
                        <label>Item ID / Name</label>
                        <asp:DropDownList ID="ddlItemId" runat="server"
                            CssClass="form-control form-control-sm"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlItemId_SelectedIndexChanged" />
                    </div>

                    <div>
                        <label>Item Description</label>

                        <asp:TextBox ID="txtItemDescription" runat="server"
                            CssClass="form-control form-control-sm"
                            ReadOnly="True" />

                    </div>

                    <div>
                        <label>Quantity</label>
                        <asp:TextBox ID="txtQty" runat="server"
                            CssClass="form-control"
                            oninput="calculateAmount()" />
                    </div>

                    <div>
                        <label>Unit</label>
                        <asp:TextBox ID="txtUnit" runat="server"
                            CssClass="form-control form-control-sm"
                            ReadOnly="true" />
                    </div>

                    <div>
                        <label>Rate (₹)</label>
                        <asp:TextBox ID="txtRate" runat="server"
                            CssClass="form-control form-control-sm"
                            ReadOnly="true"
                            AutoPostBack="true"
                            OnTextChanged="txtRate_TextChanged"/>
                    </div>


                    <div>
                        <label>Amount (₹)</label>
                        <asp:TextBox ID="txtAmount" runat="server"
                            CssClass="form-control"
                            ReadOnly="true" />
                    </div>

                    <div>
                        <label>&nbsp;</label>
                        <asp:Button ID="btnAddItem" runat="server"
                            Text="+ Add"
                            CssClass="btn btn-primary btn-sm btn-add-item"
                            OnClick="btnAddItem_Click" />
                    </div>

                </div>
            </div>
        </div>

        <!-- Sale Items Table GridView -->
        <div class="portal-card">
            <div class="portal-card-header">
                To Day Sale Item List
            </div>

            <div class="table-responsive">

                <asp:GridView ID="gvSaleItems" runat="server"
                    AutoGenerateColumns="False"
                    CssClass="sale-grid"
                    GridLines="None"
                    EmptyDataText="No items added yet.">

                    <Columns>

                        <asp:BoundField DataField="Item_Name"
                            HeaderText="Item Name" />

                        <asp:BoundField DataField="Qty"
                            HeaderText="Quantity" />

                        <asp:BoundField DataField="Unit"
                            HeaderText="Unit_Name" />

                        <asp:BoundField DataField="Rate"
                            HeaderText="Rate (₹)"
                            DataFormatString="{0:N2}" />

                        <asp:BoundField DataField="Amount"
                            HeaderText="Amount (₹)"
                            DataFormatString="{0:N2}" />

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>

                               <%-- <asp:Button ID="btnEditItem" runat="server"
                                    Text="Edit"
                                    CssClass="btn btn-warning btn-sm"
                                    CommandName="EditItem"
                                    CommandArgument='<%# Container.DataItemIndex %>'
                                    CausesValidation="false" />

                                <asp:Button ID="btnRemoveItem" runat="server"
                                    Text="Remove"
                                    CssClass="btn btn-danger btn-sm"
                                    CommandName="RemoveItem"
                                    CommandArgument='<%# Container.DataItemIndex %>'
                                    CausesValidation="false" />--%>

                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
            </div>
        </div>

        <div class="portal-card-body">
            <div class="row justify-content-end">
                <div class="col-md-4 col-lg-3">
                    <div class="total-panel">
                        <div class="total-label">Grand Total</div>
                        <asp:Label ID="lblGrandTotal" runat="server"
                            CssClass="total-value"
                            Text="₹ 0.00" />
                    </div>
                </div>
            </div>
            <asp:Button ID="btnsave" runat="server"
                Text="Save"
                onclick="btnSaveSale_Click"
                CssClass="btn btn-primary"
                 />
        </div>
    </div>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.8/dist/js/bootstrap.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/overlayscrollbars@2.11.0/browser/overlayscrollbars.browser.es6.min.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/admin-lte@4.10.0/dist/js/adminlte.min.js"></script>


</asp:Content>
