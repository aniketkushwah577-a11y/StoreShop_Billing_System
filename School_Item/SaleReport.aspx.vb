Imports System.Data.SqlClient

Public Class SaleReport
    Inherits System.Web.UI.Page

    Private ReadOnly connStr As String =
        ConfigurationManager.ConnectionStrings("ConnString").ConnectionString

    Protected Sub Page_Load(ByVal sender As Object,
                        ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            txtFromDate.Text = ""
            txtToDate.Text = ""

            'Starting mein GridView mein koi record load nahi hoga
            gvSaleReport.DataSource = Nothing
            gvSaleReport.DataBind()
        End If

    End Sub

    Private Sub LoadSavedSales()

        If txtFromDate.Text.Trim() = "" OrElse
       txtToDate.Text.Trim() = "" Then

            gvSaleReport.DataSource = Nothing
            gvSaleReport.DataBind()
            Return

        End If

        Dim fromDate As DateTime
        Dim toDate As DateTime

        If Not DateTime.TryParse(txtFromDate.Text, fromDate) OrElse
       Not DateTime.TryParse(txtToDate.Text, toDate) Then

            gvSaleReport.DataSource = Nothing
            gvSaleReport.DataBind()
            Return

        End If

        Using con As New SqlConnection(connStr)

            Dim sql As String =
            "SELECT DISTINCT M.Sale_Code, M.Invoice_No, M.Invoice_Date, " &
            "M.Party_Name, M.Grand_Total " &
            "FROM usr_iomsapp.Sale_Master M " &
            "INNER JOIN usr_iomsapp.Sale_Details D " &
            "ON M.Sale_Code = D.Sale_Code " &
            "WHERE M.Invoice_Date >= @FromDate " &
            "AND M.Invoice_Date < DATEADD(DAY, 1, @ToDate) " &
            "ORDER BY M.Sale_Code DESC"

            Using cmd As New SqlCommand(sql, con)

                cmd.Parameters.Add("@FromDate", SqlDbType.Date).Value = fromDate.Date
                cmd.Parameters.Add("@ToDate", SqlDbType.Date).Value = toDate.Date

                Using da As New SqlDataAdapter(cmd)

                    Dim dt As New DataTable()
                    da.Fill(dt)

                    gvSaleReport.DataSource = dt
                    gvSaleReport.DataBind()

                End Using

            End Using
        End Using

    End Sub

    Protected Sub btnFilter_Click(sender As Object,
                                  e As EventArgs) Handles btnFilter.Click

        If txtFromDate.Text.Trim() = "" OrElse
   txtToDate.Text.Trim() = "" Then

            ClientScript.RegisterStartupScript(
        Me.GetType(),
        "dateRequired",
        "alert('Please select both From Date and To Date.');",
        True)

            Return
        End If

        Dim fromDate As DateTime
        Dim toDate As DateTime

        If Not DateTime.TryParse(txtFromDate.Text, fromDate) OrElse
   Not DateTime.TryParse(txtToDate.Text, toDate) Then

            ClientScript.RegisterStartupScript(
        Me.GetType(),
        "invalidDate",
        "alert('Please select valid dates.');",
        True)

            Return
        End If

        If fromDate.Date > toDate.Date Then

            ClientScript.RegisterStartupScript(
        Me.GetType(),
        "dateError",
        "alert('From Date cannot be greater than To Date.');",
        True)

            Return
        End If

        LoadSavedSales()

    End Sub

    Protected Sub btnReset_Click(sender As Object,
                                 e As EventArgs) Handles btnReset.Click
        txtFromDate.Text = ""
        txtToDate.Text = ""

        gvSaleReport.DataSource = Nothing
        gvSaleReport.DataBind()

    End Sub

    Private Sub DeleteSaleRecord(saleCode As Integer)

        Using con As New SqlConnection(connStr)

            Dim sql As String =
            "DELETE FROM Sale_Master WHERE Sale_Code = @Sale_Code"

            Using cmd As New SqlCommand(sql, con)

                cmd.Parameters.Add("@Sale_Code", SqlDbType.Int).Value =
                saleCode

                con.Open()
                cmd.ExecuteNonQuery()

            End Using

        End Using

    End Sub
    Protected Sub gvSaleReport_RowCommand(sender As Object, e As GridViewCommandEventArgs)

    End Sub

End Class
