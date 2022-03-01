Imports System.Data.SqlClient

Public Class Selleing
    Dim co As New SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\MO-Malik\Desktop\SuperMarketVb\SuperMarketVb\superdb.mdf;Integrated Security=True")
    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click
        Dim Prod = New Category
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub fillcom()
        co.Open()
        Dim sql = "select * from ProductTb1"
        Dim cmd As New SqlCommand(sql, co)
        Dim adpter As New SqlDataAdapter(cmd)
        Dim tb1 As New DataTable()
        adpter.Fill(tb1)
        ProdNamecom.DataSource = tb1
        ProdNamecom.DisplayMember = "ProdName"
        ProdNamecom.ValueMember = "ProdName"
        co.Close()

    End Sub
    Dim price = 0

    Private Sub fetchPrice()

        co.Open()
        Dim sql = "select * from ProductTb1 where ProdName = '" & ProdNamecom.SelectedValue.ToString() & "' "
        Dim cmd As New SqlCommand(sql, co)
        Dim Rdr As SqlDataReader
        Dim tb1 As New DataTable()
        Rdr = cmd.ExecuteReader()
        While Rdr.Read
            price = Rdr(2)
            selPrice.Text = price
        End While
        co.Close()

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub prodGired_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

    End Sub

    Private Sub Selleing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillcom()
    End Sub

    Private Sub ProdNamecom_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ProdNamecom.SelectionChangeCommitted
        fetchPrice()

    End Sub
    Dim i = 0, GetTotla = 0

    Private Sub Label9_Click(sender As Object, e As EventArgs)
        Dim Prod = New Form1
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
        Dim Prod = New Admin
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Application.Exit()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label9_Click_1(sender As Object, e As EventArgs) Handles Label9.Click
        Dim Prod = New Form1
        Prod.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If selPrice.Text = "" Or ProdQun.Text = "" Then
            MsgBox("Select The Quantity")
        ElseIf price = 0 Then
            MsgBox("Selct The Product")
        Else
            Dim rn As Integer = GriedView.Rows.Add()
            i = i + i
            GriedView.Rows.Item(rn).Cells("Column1").Value = i
            GriedView.Rows.Item(rn).Cells("Column2").Value = ProdNamecom.SelectedValue.ToString
            GriedView.Rows.Item(rn).Cells("Column3").Value = price
            GriedView.Rows.Item(rn).Cells("Column4").Value = ProdQun.Text
            GriedView.Rows.Item(rn).Cells("Column5").Value = price * Integer.Parse(ProdQun.Text)
            GetTotla = GetTotla + (price * Integer.Parse(ProdQun.Text))
            GetTotalLbl.Text = "SD" + GetTotla.ToString()

        End If
    End Sub
End Class