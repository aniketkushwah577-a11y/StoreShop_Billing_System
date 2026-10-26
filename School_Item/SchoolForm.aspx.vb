Imports System
Imports System.Configuration
Imports System.Data
Imports System.Data.Common
Imports System.Data.SqlClient
Imports System.Drawing
Imports System.Security.Cryptography.X509Certificates

Public Class SchoolForm
    Inherits System.Web.UI.Page
    'Dim DataAdapter As SqlDataAdapter
    Private ReadOnly connstr As String = ConfigurationManager.ConnectionStrings("ConnString").ConnectionString




    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            ShowUnit()
            Show_SchoolItem()
            Dim Item_Id As Integer

            If Integer.TryParse(Request.QueryString("Item_Id"), Item_Id) Then
                LoadSchoolItem(Item_Id)
            End If

        End If

    End Sub
    Public Sub Show_SchoolItem()



        Using conn As New SqlConnection(connstr)

            Dim cmd As New SqlCommand("SELECT Item_Id, Item_Name, Unit_Name, Price FROM School_Item join Unit on School_Item.Unit = Unit.Unit_Id", conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            grid.DataSource = dt
            grid.DataBind()
        End Using
    End Sub

    Public Sub ClearForm()
        txtname.Text = ""
        txtprice.Text = ""
        ddlunit.SelectedIndex = 0
    End Sub

    Public Sub ShowUnit()
        Using conn As New SqlConnection(connstr)
            Dim cmd As New SqlCommand("SELECT * FROM Unit", conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()
            da.Fill(dt)
            ddlunit.DataTextField = "Unit_Name"
            ddlunit.DataValueField = "Unit_ID"
            ddlunit.DataSource = dt
            ddlunit.DataBind()

            ddlunit.Items.Insert(0, New ListItem("Select Unit", "0"))
        End Using
    End Sub
    Protected Sub btnsave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        SaveSchoolItem()

    End Sub

    Public Sub SaveSchoolItem()

        If String.IsNullOrWhiteSpace(txtname.Text) Then
            Response.Write("<script>alert('Please enter item name.');</script>")
            Exit Sub
        End If

        ' Validate Price
        Dim price As Decimal

        If Not Decimal.TryParse(txtprice.Text.Trim(), price) OrElse price < 0 Then
            Response.Write("<script>alert('Please enter a valid price.');</script>")
            Exit Sub
        End If

        Using conn As New SqlConnection(connstr)

            conn.Open()

            ' Check duplicate item name
            Dim checkSql As String =
            "SELECT COUNT(*) FROM School_Item " &
            "WHERE LOWER(LTRIM(RTRIM(Item_Name))) = " &
            "LOWER(LTRIM(RTRIM(@Item_Name)))"

            Using checkCmd As New SqlCommand(checkSql, conn)

                checkCmd.Parameters.AddWithValue(
                "@Item_Name", txtname.Text.Trim())

                Dim count As Integer =
                Convert.ToInt32(checkCmd.ExecuteScalar())

                If count > 0 Then
                    Response.Write(
                    "<script>alert('Item name already exists!');</script>")
                    Exit Sub
                End If

            End Using

            ' Insert item
            Dim query As String =
            "INSERT INTO School_Item (Item_Name, Unit, Price) " &
            "VALUES (@Item_Name, @Unit, @Price)"

            Using cmd As New SqlCommand(query, conn)

                cmd.Parameters.AddWithValue(
                "@Item_Name", txtname.Text.Trim())

                cmd.Parameters.AddWithValue(
                "@Unit", ddlunit.SelectedValue)

                cmd.Parameters.Add("@Price", SqlDbType.Decimal).Value = price

                cmd.ExecuteNonQuery()

            End Using

        End Using

        ' Show success and refresh form/list
        Response.Write(
        "<script>alert('Record inserted successfully!');</script>")

        ClearForm()
        Show_SchoolItem()

    End Sub


    Private Sub LoadSchoolItem(id As Integer)

        Using con As New SqlConnection(connstr)

            Dim sql As String =
            "SELECT Item_Id, Item_Name, Unit, Price " &
            "FROM School_Item WHERE Item_Id = @Id"

            Using cmd As New SqlCommand(sql, con)

                cmd.Parameters.AddWithValue("@Id", id)
                con.Open()

                Using dr As SqlDataReader = cmd.ExecuteReader()

                    If dr.Read() Then

                        hfItemId.Value = dr("Item_Id").ToString()
                        txtname.Text = dr("Item_Name").ToString()
                        txtprice.Text = dr("Price").ToString()

                        Dim unitValue As String = dr("Unit").ToString()

                        If ddlunit.Items.FindByValue(unitValue) IsNot Nothing Then
                            ddlunit.SelectedValue = unitValue
                        End If

                        btnsave.Visible = False
                        btnupdate.Visible = True

                    End If

                End Using
            End Using
        End Using

    End Sub



    Protected Sub grid_RowCommand(sender As Object, e As GridViewCommandEventArgs)

        Dim Item_Id As Integer

        If Not Integer.TryParse(Convert.ToString(e.CommandArgument),
                             Item_Id) Then
            Return
        End If

        If e.CommandName = "A" Then
            Response.Redirect("~/SchoolForm.aspx?Item_Id=" & Item_Id)

        ElseIf e.CommandName = "B" Then
            Using con As New SqlConnection(connstr)
                Dim sql As String = "delete from School_Item where Item_Id = @Item_Id"
                Using cmd As SqlCommand = New SqlCommand(sql, con)
                    cmd.Parameters.AddWithValue("@Item_Id", Item_Id)
                    con.Open()
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Show_SchoolItem()
        End If

    End Sub

    Protected Sub btnupdate_Click(sender As Object, e As EventArgs)
        Dim id As Integer
        Dim price As Decimal

        If Not Integer.TryParse(hfItemId.Value, id) OrElse
           String.IsNullOrWhiteSpace(txtname.Text) OrElse
           ddlunit.SelectedValue = "0" OrElse
           Not Decimal.TryParse(txtprice.Text, price) OrElse
           price < 0 Then

            'lblMessage.Text = "Please enter valid item details."
            Return
        End If

        Using con As New SqlConnection(connstr)

            Dim sql As String =
                "UPDATE School_Item SET Item_Name=@Name, " &
                "Unit=@Unit, Price=@Price WHERE Item_Id=@Id"

            Using cmd As New SqlCommand(sql, con)

                cmd.Parameters.AddWithValue("@Id", id)
                cmd.Parameters.AddWithValue("@Name", txtname.Text.Trim())
                cmd.Parameters.AddWithValue("@Unit", ddlunit.SelectedValue)
                cmd.Parameters.AddWithValue("@Price", price)

                con.Open()
                Dim rows As Integer = cmd.ExecuteNonQuery()

                If rows > 0 Then
                    Response.Redirect("SchoolForm.aspx")
                Else
                    'lblMessage.Text = "Item not found."
                End If
                Show_SchoolItem()

            End Using
        End Using
    End Sub
End Class