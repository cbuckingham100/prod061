Imports System.IO
Imports System.Text.RegularExpressions
Imports LinxLib

Public Class frmReports

    Private Sub frmReports_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadReports()
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadReports()
        Application.DoEvents()
    End Sub

    Private Sub LoadReports()
        Dim xLabel_Data As New PrinterLabelClass
        DataGridView.DataSource = xLabel_Data.GetAllTTOComponents(dtFromDate.Value, dtToDate.Value)
        If DataGridView.DataSource IsNot Nothing Then
            With DataGridView

                ''Header
                .Columns(0).HeaderText = "Serial Number"
                .Columns(1).HeaderText = "Printer Type"
                .Columns(2).HeaderText = "Date Time"
                .Columns(3).HeaderText = "Sales Order"
                .Columns(4).HeaderText = "Customer"
                .Columns(5).HeaderText = "Sensor PCB"
                .Columns(6).HeaderText = "Printhead PCBA"
                .Columns(7).HeaderText = "Main PCB"
                .Columns(8).HeaderText = "Printhead"
                .Columns(9).HeaderText = "Light Box PCB"
                .Columns(10).HeaderText = "Psu PCB"
                .Columns(11).HeaderText = "Raiser PCB"
                .Columns(12).HeaderText = "LCD Screen"
                .Columns(13).HeaderText = "GUI PCB"
                .Columns(14).HeaderText = "Bench 2 Completed"
                .Columns(15).HeaderText = "Bench 4 Completed"
            End With
        End If

    End Sub


    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        ExportToCSV()
    End Sub
    Private Sub ExportToCSV()
        Try
            ' Fetch data from PrinterLabelClass
            Dim xLabel_Data As New PrinterLabelClass
            DataGridView.DataSource = xLabel_Data.GetAllTTOComponents(dtFromDate.Value, dtToDate.Value)

            ' Ensure that jobList contains data
            If DataGridView.DataSource IsNot Nothing AndAlso DataGridView.DataSource.Count > 0 Then

                ' Add the headers
                Dim sTemp As String = "Serial Number,Printer Type,Date Time,Sales Order,Customer,Sensor PCB,Printhead PCBA,Main PCB,Printhead,Light Box PCB,Psu PCB,Raiser PCB,LCD Screen,GUI PCB,Bench 2 Completed,Bench 4 Completed" & vbCrLf

                ' Loop through the BindingSource and append the data
                For i = 0 To DataGridView.DataSource.Count - 1
                    Dim rowData As DataRowView = CType(DataGridView.DataSource.Item(i), DataRowView)
                    sTemp &= Trim(CleanseCSVField(rowData("tto_serial_number").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("printer_type").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("date_time").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("sales_order").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("customer").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("sensor_pcb").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("printhead_pcba").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("main_pcb").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("printhead").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("light_box_pcb").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("psu_pcb").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("raiser_pcb").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("lcd_screen").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("gui_pcb").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("pc1_completed").ToString())) & ","
                    sTemp &= Trim(CleanseCSVField(rowData("pc2_completed").ToString())) & "," & vbCrLf
                Next

                ' Define the path for the CSV file (e.g., Downloads folder)
                Dim downloadFolder As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads")
                Dim fileName As String = "Export_TTO_Components_" + DateTime.Now.ToShortDateString().Replace("/", "")
                Dim fullPath As String = Path.Combine(downloadFolder, fileName & ".csv")

                Dim fileCounter As Integer = 1
                While File.Exists(fullPath)
                    fullPath = Path.Combine(downloadFolder, fileName & "_" & fileCounter.ToString() & ".csv")
                    fileCounter += 1
                End While
                ' Write the CSV content to the file
                File.WriteAllText(fullPath, sTemp.ToString())

                ' Notify the user that the export was successful
                MessageBox.Show("CSV file exported successfully to: " & fullPath, "Export Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("No data available to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

        Catch ex As Exception
            ' Display any errors
            MessageBox.Show("An error occurred during CSV export: " & ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Function CleanseCSVField(ByVal field As String) As String
        ' Trim leading and trailing whitespace
        field = field.Trim()

        ' Remove any characters that are not allowed in a CSV field, such as non-printable characters
        field = Regex.Replace(field, "[^\x20-\x7E]", "")

        ' If the field contains commas, quotes, or ampersands, wrap it in quotes and escape quotes
        If Regex.IsMatch(field, "[,""&]") Then
            field = """" & field.Replace("""", """""") & """"
        End If

        Return field
    End Function

End Class