<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Default.Master" CodeBehind="SchoolForm.aspx.vb" Inherits="School_Item.SchoolForm" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-8">
                <!-- Form: 8 columns -->
                <div class="form-row">
                    <div class="form-col-8">
                        <div class="card">

                            <h2>School Item Form</h2>

                            <div class="form-group">
                                <label>Item Name</label>
                                <asp:TextBox ID="txtname" runat="server"
                                    CssClass="form-control" />
                                <asp:Label id="lblMessage" runat="server" EnableViewState="false" ></asp:Label>
                            </div>

                            <div class="form-group">
                                <label>Unit</label>
                                <asp:DropDownList ID="ddlunit" runat="server"
                                    CssClass="form-control" />
                            </div>

                            <div class="form-group">
                                <label>Price</label>

                                <asp:TextBox ID="txtprice" runat="server"
                                    CssClass="form-control"
                                    onkeypress="return isNumberKey(event)"
                                    onpaste="return false;" />

                            </div>

                            <script type="text/javascript">
    function isNumberKey(evt) {
        var charCode = evt.which ? evt.which : evt.keyCode; 
        if (charCode >= 48 && charCode <= 57) {
            return true;
        }
        if (charCode === 46) {
            return true;
        }
        if (charCode < 32) {
            return true;
        }

        return false;
    }
                            </script>
                        <asp:HiddenField ID="hfItemId" runat="server" />

                        <asp:Button ID="btnsave" runat="server"
                            Text="Save"
                            CssClass="btn btn-primary"
                            OnClick="btnsave_Click" />

                        <asp:Button ID="btnupdate" runat="server"
                            Text="Update"
                            Visible="False"
                            CssClass="btn btn-primary"
                            OnClick="btnupdate_Click" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-4">
            <!-- GridView: 6 columns -->
            <div class="grid-row">
                <div class="grid-col-6">
                    <div class="school-card">

                        <h2>School Item List</h2>

                        <div class="grid-scroll">
                            <asp:GridView ID="grid" runat="server"
                                CssClass="table"
                                OnRowCommand="grid_RowCommand"
                                AutoGenerateColumns="False"
                                GridLines="None">

                                <Columns>
                                    <asp:TemplateField HeaderText="ID">
                                        <ItemTemplate>
                                            <%# Eval("Item_Id") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Name">
                                        <ItemTemplate>
                                            <%# Eval("Item_Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <%# Eval("Unit_Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Price">
                                        <ItemTemplate>
                                            <%# Eval("Price") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:Button ID="btnedit" runat="server"
                                                Text="Edit"
                                                CssClass="btn btn-primary"
                                                CommandName="A"
                                                CommandArgument='<%# Eval("Item_Id") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:Button ID="btndelet" runat="server"
                                                Text="Delete"
                                                CssClass="btn btn-primary"
                                                CommandName="B"
                                                CommandArgument='<%# Eval("Item_Id") %>'
                                                OnClientClick="return confirm('Delete this item?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>

                            </asp:GridView>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>


