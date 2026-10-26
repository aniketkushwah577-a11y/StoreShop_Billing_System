Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web.UI
Imports System.Configuration
Imports System.Globalization
Imports System.Data.Common

Public Class SaleEntry
    Inherits System.Web.UI.Page

    Private ReadOnly connStr As String = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            txtInvoiceDate.Text = DateTime.Today.ToString("yyyy-MM-dd")
            'LoadList()
            'BindCart()
            'CalculateAmount()
            'LoadInvoiceNo()
        End If

    End Sub

    '    Dim sale_code As Integer = "hfSaleCode.Value"

    '    Private Sub LoadList()

    '        Using con As New SqlConnection(connStr)

    '            Dim sql As String =
    '            "SELECT Item_Id, Item_Name, Unit_Name, Price " &
    '            "FROM usr_iomsapp.School_Item join usr_iomsapp.Unit on usr_iomsapp.School_Item.Unit = usr_iomsapp.Unit.Unit_Id " &
    '            "ORDER BY Item_Name"

    '            Using cmd As New SqlCommand(sql, con)
    '                Using da As New SqlDataAdapter(cmd)

    '                    Dim dt As New DataTable()
    '                    da.Fill(dt)

    '                    ddlItemId.DataSource = dt
    '                    ddlItemId.DataTextField = "Item_Name"
    '                    ddlItemId.DataValueField = "Item_Id"
    '                    ddlItemId.DataBind()

    '                    ddlItemId.Items.Insert(
    '                    0, New ListItem("-- Select Item --", ""))

    '                End Using
    '            End Using
    '        End Using

    '    End Sub

    '    Private Sub CalculateAmount()

    '        Dim qty As Decimal
    '        Dim rate As Decimal

    '        If Decimal.TryParse(txtQty.Text, qty) AndAlso
    '       Decimal.TryParse(txtRate.Text, rate) Then

    '            Dim amount As Decimal = Math.Round(qty * rate, 2)
    '            txtAmount.Text = amount.ToString("0.00")

    '        Else
    '            txtAmount.Text = ""
    '        End If

    '    End Sub

    '    Private Sub LoadInvoiceNo()

    '        Using con As New SqlConnection(connStr)

    '            Dim sql As String =
    '            "SELECT ISNULL(MAX(Invoice_No), 0) + 1 " &
    '            "FROM usr_iomsapp.Sale_Master"

    '            Using cmd As New SqlCommand(sql, con)

    '                con.Open()

    '                txtInvoiceNo.Text =
    '                Convert.ToInt32(cmd.ExecuteScalar()).ToString()

    '            End Using
    '        End Using

    '    End Sub
    '    Private Sub GenerateInvoiceNo()

    '        'Agar Invoice No. pehle se generate hai, to use change nahi karein
    '        If txtInvoiceNo.Text.Trim() <> "" Then
    '            Return
    '        End If

    '        Using con As New SqlConnection(connStr)

    '            Dim sql As String =
    '            "SELECT NEXT VALUE FOR usr_iomsapp.InvoiceNoSequence"

    '            Using cmd As New SqlCommand(sql, con)

    '                con.Open()

    '                Dim invoiceNo As Long =
    '                Convert.ToInt64(cmd.ExecuteScalar())

    '                txtInvoiceNo.Text = invoiceNo.ToString()

    '            End Using

    '        End Using

    '    End Sub
    '    Protected Sub txtQty_TextChanged(
    '    sender As Object, e As EventArgs)

    '        CalculateAmount()

    '    End Sub
    '    Protected Sub txtRate_TextChanged(
    '    sender As Object, e As EventArgs)

    '        CalculateAmount()

    '    End Sub

    '    Protected Sub ddlItemId_SelectedIndexChanged(sender As Object, e As EventArgs)
    '        CalculateAmount()
    '        txtItemDescription.Text = ""
    '        txtUnit.Text = ""
    '        txtRate.Text = ""
    '        txtAmount.Text = ""

    '        If String.IsNullOrWhiteSpace(ddlItemId.SelectedValue) Then
    '            Return
    '        End If

    '        Using con As New SqlConnection(connStr)

    '            Dim sql As String =
    '            "SELECT Item_Name, Unit, Price " &
    '            "FROM usr_iomsapp.School_Item " &
    '            "WHERE Item_Id = @ItemId"

    '            Using cmd As New SqlCommand(sql, con)

    '                cmd.Parameters.Add("@ItemId",
    '                SqlDbType.Int).Value =
    '                Convert.ToInt32(ddlItemId.SelectedValue)

    '                con.Open()

    '                Using dr As SqlDataReader = cmd.ExecuteReader()

    '                    If dr.Read() Then

    '                        txtItemDescription.Text =
    '                        Convert.ToString(dr("Item_Name"))

    '                        txtUnit.Text =
    '                        Convert.ToString(dr("Unit"))

    '                        If Not IsDBNull(dr("Price")) Then
    '                            txtRate.Text =
    '        Convert.ToDecimal(dr("Price")).ToString("0.00")
    '                        End If

    '                        'Amount calculate karein
    '                        CalculateAmount()

    '                    End If

    '                End Using
    '            End Using
    '        End Using

    '    End Sub

    '    Private Property Cart As DataTable
    '        Get
    '            If ViewState("Cart") Is Nothing Then

    '                Dim dt As New DataTable()
    '                dt.Columns.Add("SNo", GetType(Integer))
    '                dt.Columns.Add("Item_Id", GetType(Integer))
    '                dt.Columns.Add("Item_Name", GetType(String))
    '                dt.Columns.Add("Qty", GetType(Decimal))
    '                dt.Columns.Add("Unit", GetType(String))
    '                dt.Columns.Add("Rate", GetType(Decimal))
    '                dt.Columns.Add("Amount", GetType(Decimal))

    '                ViewState("Cart") = dt
    '            End If

    '            Return DirectCast(ViewState("Cart"), DataTable)
    '        End Get

    '        Set(value As DataTable)
    '            ViewState("Cart") = value
    '        End Set
    '    End Property

    '    Protected Sub btnAddItem_Click(sender As Object, e As EventArgs)

    '        Dim qty As Decimal
    '        Dim rate As Decimal


    '        If String.IsNullOrWhiteSpace(ddlItemId.SelectedValue) Then
    '            Return
    '        End If

    '        If Not Decimal.TryParse(txtQty.Text, qty) OrElse qty <= 0 Then
    '            Return
    '        End If

    '        If Not Decimal.TryParse(txtRate.Text, rate) OrElse rate < 0 Then
    '            Return
    '        End If

    '        Dim dt As DataTable = Cart
    '        Dim amount As Decimal = Math.Round(qty * rate, 2)

    '        If EditingRowIndex >= 0 Then

    '            'Existing item ki row update karein
    '            If EditingRowIndex >= dt.Rows.Count Then
    '                EditingRowIndex = -1
    '                Return
    '            End If

    '            Dim row As DataRow = dt.Rows(EditingRowIndex)

    '            row("Item_Id") = Convert.ToInt32(ddlItemId.SelectedValue)
    '            row("Item_Name") = ddlItemId.SelectedItem.Text
    '            row("Qty") = qty
    '            row("Unit") = txtUnit.Text
    '            row("Rate") = rate
    '            row("Amount") = amount

    '            EditingRowIndex = -1

    '        Else

    '            'Normal mode mein nayi row add karein
    '            Dim row As DataRow = dt.NewRow()

    '            row("SNo") = dt.Rows.Count + 1
    '            row("Item_Id") = Convert.ToInt32(ddlItemId.SelectedValue)
    '            row("Item_Name") = ddlItemId.SelectedItem.Text
    '            row("Qty") = qty
    '            row("Unit") = txtUnit.Text
    '            row("Rate") = rate
    '            row("Amount") = amount

    '            dt.Rows.Add(row)

    '        End If
    '        Cart = dt
    '        BindCart()

    '        'Invoice No. generate karein, agar pehle se nahi hai
    '        GenerateInvoiceNo()

    '        ClearItemEntry()
    '        btnAddItem.Text = "+ Add"
    '    End Sub

    '    Private Sub BindCart()

    '        gvSaleItems.DataSource = Cart
    '        gvSaleItems.DataBind()

    '        Dim total As Decimal = 0D

    '        For Each row As DataRow In Cart.Rows
    '            total += Convert.ToDecimal(row("Amount"))
    '        Next

    '        lblGrandTotal.Text = total.ToString("N2")

    '    End Sub

    '    Private Property EditingRowIndex As Integer
    '        Get
    '            If ViewState("EditingRowIndex") Is Nothing Then
    '                Return -1
    '            End If

    '            Return Convert.ToInt32(ViewState("EditingRowIndex"))
    '        End Get

    '        Set(value As Integer)
    '            ViewState("EditingRowIndex") = value
    '        End Set
    '    End Property

    '    Private Sub ClearItemEntry()

    '        ddlItemId.SelectedIndex = 0
    '        txtItemDescription.Text = ""
    '        txtQty.Text = ""
    '        txtUnit.Text = ""
    '        txtRate.Text = ""
    '        txtAmount.Text = ""

    '    End Sub

    '    Protected Sub gvSaleItems_RowCommand(
    '    sender As Object,
    '    e As GridViewCommandEventArgs
    ')

    '        Dim rowIndex As Integer

    '        If Not Integer.TryParse(Convert.ToString(e.CommandArgument), rowIndex) Then
    '            Return
    '        End If

    '        Dim dt As DataTable = Cart

    '        If rowIndex < 0 OrElse rowIndex >= dt.Rows.Count Then
    '            Return
    '        End If

    '        If e.CommandName = "EditItem" Then

    '            Dim row As DataRow = dt.Rows(rowIndex)

    '            Dim itemId As String = Convert.ToString(row("Item_Id"))

    '            If ddlItemId.Items.FindByValue(itemId) IsNot Nothing Then
    '                ddlItemId.SelectedValue = itemId
    '            End If

    '            txtItemDescription.Text = Convert.ToString(row("Item_Name"))
    '            txtQty.Text = Convert.ToDecimal(row("Qty")).ToString("0.###")
    '            txtUnit.Text = Convert.ToString(row("Unit"))
    '            txtRate.Text = Convert.ToDecimal(row("Rate")).ToString("0.00")
    '            txtAmount.Text = Convert.ToDecimal(row("Amount")).ToString("0.00")

    '            EditingRowIndex = rowIndex
    '            btnAddItem.Text = "Update Item"

    '        ElseIf e.CommandName = "RemoveItem" Then

    '            dt.Rows.RemoveAt(rowIndex)

    '            For i As Integer = 0 To dt.Rows.Count - 1
    '                dt.Rows(i)("SNo") = i + 1
    '            Next

    '            Cart = dt
    '            EditingRowIndex = -1

    '            BindCart()
    '            ClearItemEntry()

    '            btnAddItem.Text = "+ Add"

    '        End If

    '    End Sub


    '    Protected Sub btnSaveSale_Click(sender As Object, e As EventArgs)

    '        lblMessage.Text = ""

    '        ' 1. Validate Party Name
    '        If String.IsNullOrWhiteSpace(txtPartyName.Text) Then
    '            lblMessage.ForeColor = System.Drawing.Color.Red
    '            lblMessage.Text = "Please enter Party Name."
    '            Return
    '        End If

    '        ' 2. Validate Cart
    '        If Cart Is Nothing OrElse Cart.Rows.Count = 0 Then
    '            lblMessage.ForeColor = System.Drawing.Color.Red
    '            lblMessage.Text = "Please add at least one item."
    '            Return
    '        End If

    '        ' 3. Validate Invoice Date
    '        Dim invoiceDate As DateTime

    '        If Not DateTime.TryParseExact(
    '            txtInvoiceDate.Text.Trim(),
    '            "yyyy-MM-dd",
    '            CultureInfo.InvariantCulture,
    '            DateTimeStyles.None,
    '            invoiceDate) Then

    '            lblMessage.ForeColor = System.Drawing.Color.Red
    '            lblMessage.Text = "Please select a valid Invoice Date."
    '            Return
    '        End If

    '        ' 4. Calculate Grand Total
    '        Dim grandTotal As Decimal = 0D

    '        Try
    '            For Each row As DataRow In Cart.Rows
    '                grandTotal += Convert.ToDecimal(row("Amount"))
    '            Next

    '            grandTotal = Math.Round(grandTotal, 2)

    '        Catch ex As Exception
    '            lblMessage.ForeColor = System.Drawing.Color.Red
    '            lblMessage.Text = "Error calculating total: " &
    '                Server.HtmlEncode(ex.Message)
    '            Return
    '        End Try

    '        ' 5. Save Sale Master and Sale Details
    '        Try

    '            Using con As New SqlConnection(connStr)

    '                con.Open()

    '                Using tran As SqlTransaction =
    '                    con.BeginTransaction(IsolationLevel.Serializable)

    '                    Try

    '                        Dim invoiceNo As Integer
    '                        Dim saleCode As Integer

    '                        ' Generate next invoice number
    '                        Dim invoiceSql As String =
    '                            "SELECT ISNULL(MAX(Invoice_No), 0) + 1 " &
    '                            "FROM usr_iomsapp.Sale_Master WITH (UPDLOCK, HOLDLOCK)"

    '                        Using cmd As New SqlCommand(invoiceSql, con, tran)

    '                            invoiceNo = Convert.ToInt32(cmd.ExecuteScalar())

    '                        End Using

    '                        ' Insert Sale Master
    '                        Dim masterSql As String =
    '                            "INSERT INTO usr_iomsapp.Sale_Master " &
    '                            "(Invoice_No, Invoice_Date, Party_Name, Grand_Total) " &
    '                            "OUTPUT INSERTED.Sale_Code " &
    '                            "VALUES (@InvoiceNo, @InvoiceDate, @PartyName, @GrandTotal)"

    '                        Using cmd As New SqlCommand(masterSql, con, tran)

    '                            cmd.Parameters.Add(
    '                                "@InvoiceNo", SqlDbType.Int).Value = invoiceNo

    '                            cmd.Parameters.Add(
    '                                "@InvoiceDate", SqlDbType.Date).Value = invoiceDate.Date

    '                            cmd.Parameters.Add(
    '                                "@PartyName", SqlDbType.VarChar, 150).Value =
    '                                txtPartyName.Text.Trim()

    '                            Dim totalParam As SqlParameter =
    '                                cmd.Parameters.Add(
    '                                    "@GrandTotal", SqlDbType.Decimal)

    '                            totalParam.Precision = 18
    '                            totalParam.Scale = 2
    '                            totalParam.Value = grandTotal

    '                            saleCode = Convert.ToInt32(cmd.ExecuteScalar())

    '                        End Using

    '                        ' Insert Sale Details
    '                        For Each row As DataRow In Cart.Rows

    '                            Dim detailSql As String =
    '                                "INSERT INTO usr_iomsapp.Sale_Details " &
    '                                "(Sale_Code, Item_Id, Qty, Unit, Rate, Amount) " &
    '                                "VALUES (@SaleCode, @ItemId, @Qty, @Unit, @Rate, @Amount)"

    '                            Using cmd As New SqlCommand(detailSql, con, tran)

    '                                cmd.Parameters.Add(
    '                                    "@SaleCode", SqlDbType.Int).Value = saleCode

    '                                cmd.Parameters.Add(
    '                                    "@ItemId", SqlDbType.Int).Value =
    '                                    Convert.ToInt32(row("Item_Id"))

    '                                Dim qtyParam As SqlParameter =
    '                                    cmd.Parameters.Add(
    '                                        "@Qty", SqlDbType.Decimal)

    '                                qtyParam.Precision = 18
    '                                qtyParam.Scale = 3
    '                                qtyParam.Value = Convert.ToDecimal(row("Qty"))

    '                                cmd.Parameters.Add(
    '                                    "@Unit", SqlDbType.NVarChar, 50).Value =
    '                                    Convert.ToString(row("Unit"))

    '                                Dim rateParam As SqlParameter =
    '                                    cmd.Parameters.Add(
    '                                        "@Rate", SqlDbType.Decimal)

    '                                rateParam.Precision = 18
    '                                rateParam.Scale = 2
    '                                rateParam.Value = Convert.ToDecimal(row("Rate"))

    '                                Dim amountParam As SqlParameter =
    '                                    cmd.Parameters.Add(
    '                                        "@Amount", SqlDbType.Decimal)

    '                                amountParam.Precision = 18
    '                                amountParam.Scale = 2
    '                                amountParam.Value = Convert.ToDecimal(row("Amount"))

    '                                cmd.ExecuteNonQuery()

    '                            End Using

    '                        Next

    '                        ' Commit transaction
    '                        tran.Commit()

    '                        ' Success message
    '                        lblMessage.ForeColor = System.Drawing.Color.Green

    '                        lblMessage.Text = "Sale saved successfully! Invoice No: " &
    '                  invoiceNo.ToString() &
    '                  " | Sale Code: " & saleCode.ToString()

    '                        ' Clear cart after successful save
    '                        ' Clear form after successful save
    '                        txtPartyName.Text = ""
    '                        txtpartyNo.Text = ""

    '                        txtInvoiceDate.Text = DateTime.Today.ToString("yyyy-MM-dd")

    '                        txtQty.Text = ""
    '                        txtUnit.Text = ""
    '                        txtRate.Text = ""
    '                        txtAmount.Text = ""
    '                        txtItemDescription.Text = ""

    '                        Cart = Nothing
    '                        BindCart()

    '                        If ddlItemId.Items.Count > 0 Then
    '                            ddlItemId.SelectedIndex = 0
    '                        End If

    '                    Catch ex As Exception

    '                        Try
    '                            tran.Rollback()
    '                        Catch
    '                            ' Rollback may fail if transaction has ended.
    '                        End Try

    '                        System.Diagnostics.Trace.TraceError(ex.ToString())

    '                        lblMessage.ForeColor = System.Drawing.Color.Red

    '                        lblMessage.Text =
    '                            "Save failed: " &
    '                            Server.HtmlEncode(ex.Message)

    '                    End Try

    '                End Using

    '            End Using

    '        Catch ex As Exception

    '            ' Handles connection or transaction initialization errors
    '            System.Diagnostics.Trace.TraceError(ex.ToString())

    '            lblMessage.ForeColor = System.Drawing.Color.Red

    '            lblMessage.Text =
    '                "Database error: " &
    '                Server.HtmlEncode(ex.Message)

    '        End Try

    '    End Sub

End Class



