Imports System.Data.SqlClient


Public Class Product

    Dim co As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MO-Malik\Desktop\SuperMarketVb\SuperMarketVb\superdb.mdf;Integrated Security=True")

    Public Sub populate()
        co.Open()
        Dim sql = "select * from ProductTb1"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, co)
        Dim Buldier As SqlCommandBuilder
        Buldier = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        prodGired.DataSource = ds.Tables(0)
        co.Close()

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        co.Open()
        Dim query As String

        query = "insert into ProductTb1 values (" & ProdId.Text & ",'" & ProdName.Text & "'," & ProdPrice.Text & ",'" & Catab.SelectedValue & "' ) "
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(query, co)
        cmd.ExecuteNonQuery()
        MsgBox("Product Added Success")
        co.Close()
        populate()


    End Sub

    Private Sub Product_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
        fillcom()
    End Sub

    Private Sub fillcom()
        co.Open()
        Dim sql = "select * from CategoryTb1"
        Dim cmd As New SqlCommand(sql, co)
        Dim adpter As New SqlDataAdapter(cmd)
        Dim tb1 As New DataTable()
        adpter.Fill(tb1)
        Catab.DataSource = tb1
        Catab.DisplayMember = "CatName"
        Catab.ValueMember = "CatName"
        co.Close()

    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If ProdId.Text = "" Then
            MsgBox("Select the Porduct to be Deleted")
        Else
            co.Open()

            Dim query As String

            query = "delete from ProductTb1 where ProductId = " & ProdId.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, co)
            cmd.ExecuteNonQuery()
            MsgBox("product deleted successfully")
            co.Close()
            populate()

        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        ProdId.Text = ""
        ProdName.Text = ""
        ProdPrice.Text = ""

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If ProdId.Text = "" Or ProdName.Text = "" Or ProdPrice.Text = "" Then
            MsgBox("missing Information")
        Else
            co.Open()
            Dim query As String
            query = "update ProductTb1 set ProdName =  '" & ProdName.Text & "',ProdPrice = " & ProdPrice.Text & " , Catcb= '" & Catab.SelectedValue & "' where ProductId =" & ProdId.Text & " "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, co)
            cmd.ExecuteNonQuery()
            MsgBox("Has been Updated")
            co.Close()
            populate()
        End If
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim cat = New Category
        cat.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim Prod = New Admin
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Dim Prod = New Form1
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub ProdGired_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles prodGired.CellContentClick

    End Sub
End Class