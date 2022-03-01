Imports System.Data.SqlClient

Public Class Category
    Dim co As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MO-Malik\Desktop\SuperMarketVb\SuperMarketVb\superdb.mdf;Integrated Security=True")
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        catName.Text = ""
        CatId.Text = ""
        CatDec.Text = ""


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        co.Open()
        Dim query As String

        query = "insert into CategoryTb1 values (" & CatId.Text & ",'" & catName.Text & "','" & CatDec.Text & "') "
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(query, co)
        cmd.ExecuteNonQuery()
        MsgBox("Catgory Added Success")
        co.Close()
        populate()

    End Sub
    Public Sub populate()
        co.Open()
        Dim sql = "select * from CategoryTb1"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, co)
        Dim Buldier As SqlCommandBuilder
        Buldier = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        CatGirdView.DataSource = ds.Tables(0)
        co.Close()

    End Sub

    Private Sub Category_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If CatId.Text = "" Then
            MsgBox("Select the Category to be Deleted")

        Else
            co.Open()

            Dim query As String

            query = "delete from CategoryTb1 where CatId = " & CatId.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, co)
            cmd.ExecuteNonQuery()
            MsgBox("Category deleted successfully")
            co.Close()
            populate()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If CatId.Text = "" Or catName.Text = "" Or CatDec.Text = "" Then
            MsgBox("missing Information")
        Else
            co.Open()
            Dim query As String
            query = "update CategoryTb1 set CatName =  '" & catName.Text & "',CatDec = '" & CatDec.Text & "'  CatId =" & CatId.Text & " "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, co)
            cmd.ExecuteNonQuery()
            MsgBox("Category Updated")
            co.Close()
            populate()
        End If

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim Prod = New Product
        Prod.Show()
        Me.Hide()

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim Prod = New Admin
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim Prod = New Form1
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Application.Exit()
    End Sub

    Private Sub CatGirdView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles CatGirdView.CellContentClick

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class