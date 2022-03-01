Imports System.Data.SqlClient

Public Class Admin
    Dim co As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MO-Malik\Desktop\SuperMarketVb\SuperMarketVb\superdb.mdf;Integrated Security=True")
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        co.Open()
        Dim query As String

        query = "insert into AdminTb1 values (" & AdId.Text & ",'" & AdName.Text & "','" & AdPass.Text & "') "
        Dim cmd As New SqlCommand
        cmd = New SqlCommand(query, co)
        cmd.ExecuteNonQuery()
        MsgBox("Admin Added Success")
        co.Close()
        populate()
    End Sub
    Public Sub populate()
        co.Open()
        Dim sql = "select * from AdminTb1"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(sql, co)
        Dim Buldier As SqlCommandBuilder
        Buldier = New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        AdminGirdView.DataSource = ds.Tables(0)
        co.Close()

    End Sub

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        populate()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If AdId.Text = "" Then
            MsgBox("Select the Admin to be Deleted")

        Else
            co.Open()

            Dim query As String

            query = "delete from AdminTb1 where AdminId = " & AdId.Text & ""
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, co)
            cmd.ExecuteNonQuery()
            MsgBox("Admin deleted successfully")
            co.Close()
            populate()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If AdId.Text = "" Or AdName.Text = "" Or AdPass.Text = "" Then
            MsgBox("missing Information")
        Else
            co.Open()
            Dim query As String
            query = "update AdminTb1 set AdminName =  '" & AdName.Text & "',AdminPass = '" & AdPass.Text & "'  where AdminId =" & AdId.Text & " "
            Dim cmd As SqlCommand
            cmd = New SqlCommand(query, co)
            cmd.ExecuteNonQuery()
            MsgBox("Admin Updated")
            co.Close()
            populate()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        AdId.Text = ""
        AdName.Text = ""
        AdPass.Text = ""
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        Dim Prod = New Admin
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        Dim Prod = New Category
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Dim Prod = New Form1
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Application.Exit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class