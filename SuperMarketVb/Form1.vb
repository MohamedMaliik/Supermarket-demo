Imports System.Data.SqlClient
Public Class Form1
    Dim co As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MO-Malik\Desktop\SuperMarketVb\SuperMarketVb\superdb.mdf;Integrated Security=Tru")
    Private Sub Guna2Button1_Click(sender As Object, e As EventArgs) Handles Guna2Button1.Click

        If Uuser.Text = "" Then
            MsgBox("Enter Admin user")
        ElseIf Upass.Text = "" Then
            MsgBox("Enter the Password")
        Else
            co.Open()
            Dim query = "select * from AdminTb1 where AdminName =  '" & Uuser.Text & "' and AdminPass = '" & Upass.Text & "' "
            Dim cmd = New SqlCommand(query, co)
            Dim adapter = New SqlDataAdapter(cmd)
            Dim ds As DataSet = New DataSet()
            adapter.Fill(ds)
            Dim a As Integer
            a = ds.Tables(0).Rows.Count
            If a = 0 Then
                MsgBox("wrong Admin  Name or Password")
            Else
                Dim Prod = New Product
                Prod.Show()
                Me.Hide()


            End If
            co.Close()

        End If
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click
        Dim Pr = New Selleing
        Pr.Show()
        Me.Hide()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
