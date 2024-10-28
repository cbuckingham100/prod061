' =============================================================================
' PROD061 - General tto components tracking utility
' =============================================================================
'   Ver     Lib     Date        Owner   Description
'   1.0     5.60    25/10/24    RK      TTO Tracking

' =============================================================================+

Imports LinxLib
Imports LinxLib.CommonLib

Public Class frmTTOTrackingSystem

    Public sExeVersion As String = "1.0"
    ' Declare variables for dynamic component textboxes
    Private machine1TextBoxes As List(Of TextBox)
    Private machine2TextBoxes As List(Of TextBox)
    Private machine1EditIcons As List(Of PictureBox)
    Private machine2EditIcons As List(Of PictureBox)
    Private currentComponentIndex As Integer = 0 ' Track current component being scanned
    Dim xLabel_Data As PrinterLabelClass
    Dim editPassword As String = GetConfigData("editpassword")

    ' Handle form load
    Private Sub frmTTOTrackingSystem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        machine1TextBoxes = New List(Of TextBox)()
        machine2TextBoxes = New List(Of TextBox)()
        machine1EditIcons = New List(Of PictureBox)()
        machine2EditIcons = New List(Of PictureBox)()

        ' Hide button complete
        btnComplete1.Hide()
        btnComplete2.Hide()

        lblVersion.Text = "v" + sExeVersion
    End Sub

    ' Dynamically generate components after TTO Serial Number is provided
    Private Sub txtSerialNumber_TextChanged(sender As Object, e As KeyEventArgs) Handles txtSerialNumber.KeyDown
        Dim sPrinterType As String = ""
        Dim sSerialNumber As String = ""
        If e.KeyCode = Keys.Enter AndAlso txtSerialNumber.Text <> "" Then
            sSerialNumber = txtSerialNumber.Text

            ' Clear all fields before loading
            ClearAllTextboxes(True)

            ' Assign Serial number back to text box
            txtSerialNumber.Text = sSerialNumber

            xLabel_Data = New PrinterLabelClass
            xLabel_Data.PrinterSerialNumber = txtSerialNumber.Text
            If Not xLabel_Data.FetchTTOPrinterForComponentTracking() Then
                MsgBox("Err10001 Unable to find tto printer for (serial number = " & txtSerialNumber.Text & ")")
                ClearAllTextboxes(True)
                Exit Sub
            End If

            ' Load save TTO components
            xLabel_Data.GetTTOComponentsBySerialNumber()

            If xLabel_Data.ConfigurationItem.Length > 6 Then
                sPrinterType = xLabel_Data.ConfigurationItem.Substring(0, 6)
                xLabel_Data.PrinterType = sPrinterType
                txtPrinterType.Text = sPrinterType
                Application.DoEvents()
            End If

            ' Create components based on printer type
            CreateComponents(xLabel_Data.PrinterType)
        End If
    End Sub

    ' Dynamically create component TextBoxes, Labels, and Edit buttons based on printer type
    Private Sub CreateComponents(sPrinterType As String)

        Dim machine1Components As String()
        Dim machine2Components As String()

        ' Set components for Machine 1 and Machine 2 based on printer type
        If sPrinterType = "TT0750" Or sPrinterType = "TT1000" Then
            machine1Components = {"Sensor PCB", "Printhead PCBA", "Main PCB", "Printhead", "Light Box PCB"}
            machine2Components = {"PSU PCB", "Raiser PCB", "LCD Screen", "GUI PCB"}
        ElseIf sPrinterType = "TT0500" Then
            machine1Components = {"Printhead", "Raiser PCB"}
            machine2Components = {"Main PCB", "GUI PCB"}
        Else
            Exit Sub
        End If

        ' Show complete buttons
        btnComplete1.Show()
        btnComplete2.Show()

        ' Create Labels, TextBoxes, and Edit Buttons for Machine 1 components
        For i As Integer = 0 To machine1Components.Length - 1
            Dim componentName As String = machine1Components(i)

            ' Create the label for the component
            Dim lblComponent As New Label
            lblComponent.Text = componentName & ":"
            lblComponent.Location = New Point(20, 30 + i * 40)
            lblComponent.Font = New Font("Arial", 11, FontStyle.Bold)
            lblComponent.Width = 150
            grpMachine1.Controls.Add(lblComponent)

            ' Create the TextBox for the component
            Dim txtComponent As New TextBox
            txtComponent.Location = New Point(170, 30 + i * 40)
            txtComponent.Size = New Size(250, 30)
            txtComponent.Enabled = False ' Disable all components initially
            txtComponent.Font = New Font("Arial", 11)

            ' Load saved data for Machine 1
            Select Case componentName
                Case "Sensor PCB" : txtComponent.Text = xLabel_Data.SensorPcb
                Case "Printhead PCBA" : txtComponent.Text = xLabel_Data.PrintheadPcba
                Case "Main PCB" : txtComponent.Text = xLabel_Data.MainPcb
                Case "Printhead" : txtComponent.Text = xLabel_Data.Printhead
                Case "Light Box PCB" : txtComponent.Text = xLabel_Data.LightBoxPcb
            End Select

            ' Add key event handler for automatic jump to next TextBox after scanning
            AddHandler txtComponent.KeyDown, AddressOf ComponentScanned

            grpMachine1.Controls.Add(txtComponent)
            machine1TextBoxes.Add(txtComponent)

            If xLabel_Data.PC1Completed = "True" Then
                ' Create the Edit Icon (PictureBox) for the component
                Dim editIcon As New PictureBox
                editIcon.Image = Image.FromFile(Application.StartupPath & "\Resources\edit.png")
                editIcon.SizeMode = PictureBoxSizeMode.Zoom
                editIcon.Location = New Point(430, 30 + i * 40)
                editIcon.Size = New Size(20, 20)

                ' Associate the PictureBox with the corresponding TextBox using the Tag property
                editIcon.Tag = txtComponent
                editIcon.Cursor = Cursors.Hand

                AddHandler editIcon.Click, AddressOf EditIconClick
                grpMachine1.Controls.Add(editIcon)
                machine1EditIcons.Add(editIcon)
            End If

        Next

        ' Create Labels, TextBoxes, and Edit Buttons for Machine 2 components
        For i As Integer = 0 To machine2Components.Length - 1
            Dim componentName As String = machine2Components(i)

            ' Create the label for the component
            Dim lblComponent As New Label
            lblComponent.Text = componentName & ":"
            lblComponent.Location = New Point(20, 30 + i * 40)
            lblComponent.Font = New Font("Arial", 11, FontStyle.Bold)
            lblComponent.Width = 150
            grpMachine2.Controls.Add(lblComponent)

            ' Create the TextBox for the component
            Dim txtComponent As New TextBox
            txtComponent.Location = New Point(170, 30 + i * 40)
            txtComponent.Size = New Size(250, 30)
            txtComponent.Enabled = False ' Disable all components initially
            txtComponent.Font = New Font("Arial", 11)

            ' Load saved data for Machine 2
            Select Case componentName
                Case "PSU PCB" : txtComponent.Text = xLabel_Data.PSUPcb
                Case "Raiser PCB" : txtComponent.Text = xLabel_Data.RaiserPcb
                Case "LCD Screen" : txtComponent.Text = xLabel_Data.LCDScreen
                Case "GUI PCB" : txtComponent.Text = xLabel_Data.GUIPcb
                Case "Main PCB" : txtComponent.Text = xLabel_Data.MainPcb
            End Select

            ' Add key event handler for automatic jump to next TextBox after scanning
            AddHandler txtComponent.KeyDown, AddressOf ComponentScanned

            grpMachine2.Controls.Add(txtComponent)
            machine2TextBoxes.Add(txtComponent)

            If xLabel_Data.PC2Completed = "True" Then
                ' Create the Edit Icon (PictureBox) for the component
                Dim editIcon As New PictureBox
                editIcon.Image = Image.FromFile(Application.StartupPath & "\Resources\edit.png")
                editIcon.SizeMode = PictureBoxSizeMode.Zoom
                editIcon.Location = New Point(430, 30 + i * 40)
                editIcon.Size = New Size(20, 20)

                ' Associate the PictureBox with the corresponding TextBox using the Tag property
                editIcon.Tag = txtComponent
                editIcon.Cursor = Cursors.Hand

                AddHandler editIcon.Click, AddressOf EditIconClick
                grpMachine2.Controls.Add(editIcon)
                machine2EditIcons.Add(editIcon)

            End If
        Next

        If xLabel_Data.PC1Completed = "True" And xLabel_Data.PC2Completed = "False" Then
            machine2TextBoxes(0).Enabled = True
            machine2TextBoxes(0).Focus() ' Set focus to the machine 2 first TextBox
        ElseIf (xLabel_Data.PC1Completed = "False" Or xLabel_Data.PC1Completed = "") And (xLabel_Data.PC2Completed = "False" Or xLabel_Data.PC2Completed = "") Then
            machine1TextBoxes(0).Enabled = True
            machine1TextBoxes(0).Focus() ' Set focus to the machine 1 first TextBox
        End If
    End Sub

    ' Handle automatic jump after component scanned
    Private Sub ComponentScanned(sender As Object, e As KeyEventArgs)
        ' Get the TextBox that triggered the event
        Dim currentTextBox As TextBox = CType(sender, TextBox)

        If e.KeyCode = Keys.Enter AndAlso currentTextBox.Text <> "" Then
            ' Move to the next TextBox in the list after the current one
            Dim currentMachineTextBoxes As List(Of TextBox) = If(machine1TextBoxes.Contains(currentTextBox), machine1TextBoxes, machine2TextBoxes)
            currentComponentIndex = currentMachineTextBoxes.IndexOf(currentTextBox)

            If currentComponentIndex < currentMachineTextBoxes.Count - 1 Then
                ' Enable and focus on the next component's TextBox
                currentMachineTextBoxes(currentComponentIndex + 1).Enabled = True
                currentMachineTextBoxes(currentComponentIndex + 1).Focus()
            End If
        End If
    End Sub

    ' Handle the Complete button for Bench 2
    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete1.Click
        ' Validate that all Machine 1 components are filled
        For Each tb As TextBox In machine1TextBoxes
            If tb.Text = "" Then
                MessageBox.Show("Please complete all Machine 1 components.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        ' Check printer type and assign values dynamically to xLabel_Data properties
        Select Case xLabel_Data.PrinterType
            Case "TT0750", "TT1000"
                ' Assign values to xLabel_Data properties for TT0750 and TT01000
                With xLabel_Data
                    .SensorPcb = machine1TextBoxes(0).Text
                    .PrintheadPcba = machine1TextBoxes(1).Text
                    .MainPcb = machine1TextBoxes(2).Text
                    .Printhead = machine1TextBoxes(3).Text
                    .LightBoxPcb = machine1TextBoxes(4).Text
                    .PC1Completed = True
                End With

            Case "TTO500"
                ' Assign values to xLabel_Data properties for TTO500
                With xLabel_Data
                    .Printhead = machine1TextBoxes(0).Text
                    .RaiserPcb = machine1TextBoxes(1).Text
                End With

            Case Else
                MessageBox.Show("Unknown printer type. Cannot assign component values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
        End Select

        ' Insert or update the TTO components in the database
        If xLabel_Data.InsertUpdateTTOComponents() Then
            If xLabel_Data.PC2Completed = "False" Then
                MessageBox.Show("Bench 2 components completed. Bench 4 components are now ready to scan.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Bench 2 components completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        CreateComponents(xLabel_Data.PrinterType)

        ' Enable the first component for Machine 2 when it is not completed
        If xLabel_Data.PC2Completed = "False" Then
            machine2TextBoxes(0).Enabled = True
            machine2TextBoxes(0).Focus()
        End If

    End Sub

    ' Handle the Complete button for Bench 4
    Private Sub btnComplete2_Click(sender As Object, e As EventArgs) Handles btnComplete2.Click
        ' Validate that all Machine 2 components are filled
        For Each tb As TextBox In machine2TextBoxes
            If tb.Text = "" Then
                MessageBox.Show("Please complete all Machine 2 components.", "Incomplete", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        Next

        ' Check printer type and assign values dynamically to xLabel_Data properties for Machine 2
        Select Case xLabel_Data.PrinterType
            Case "TT0750", "TT1000"
                ' Assign values to xLabel_Data properties for TT0750 and TT01000
                With xLabel_Data
                    .PSUPcb = machine2TextBoxes(0).Text
                    .RaiserPcb = machine2TextBoxes(1).Text
                    .LCDScreen = machine2TextBoxes(2).Text
                    .GUIPcb = machine2TextBoxes(3).Text
                    .PC2Completed = True
                End With

            Case "TTO500"
                ' Assign values to xLabel_Data properties for TTO500
                With xLabel_Data
                    .MainPcb = machine2TextBoxes(0).Text
                    .GUIPcb = machine2TextBoxes(1).Text
                End With

                ' Add other printer types here as needed

            Case Else
                MessageBox.Show("Unknown printer type. Cannot assign component values.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
        End Select

        ' Insert or update the TTO components in the database for Machine 2
        xLabel_Data.InsertUpdateTTOComponents()

        ' Display success message once all components are completed
        MessageBox.Show("Bench 4 components completed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ClearAllTextboxes(True)
    End Sub

    ' Handle Edit Icon Click to enable TextBox after password validation
    Private Sub EditIconClick(sender As Object, e As EventArgs)
        ' Cast sender as PictureBox, since the click event is triggered by the PictureBox (icon)
        Dim editIcon As PictureBox = CType(sender, PictureBox)

        ' Get the associated TextBox from the PictureBox's Tag property
        Dim txtComponent As TextBox = CType(editIcon.Tag, TextBox)

        ' Show password prompt
        Dim password = InputBox("Enter password to edit this field:", "Password Required")

        If password = editPassword Then
            ' If password is correct, enable the TextBox for editing
            txtComponent.Enabled = True
            txtComponent.Focus()
            Application.DoEvents()
        Else
            MessageBox.Show("Incorrect password. You cannot edit this field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    ' Clear all dynamic textboxes and labels
    Private Sub ClearAllTextboxes(ByVal bflag As Boolean)
        If bflag Then
            xLabel_Data = Nothing
            xLabel_Data = New PrinterLabelClass
        End If

        ' Clear Serial Number and Printer Type textboxes
        txtSerialNumber.Text = ""
        txtPrinterType.Text = ""

        ' Clear previous controls (TextBoxes and Labels) from the group boxes in Bench 2 and Bench 4
        ' Clear Bench 2 controls
        For Each ctrl As Control In grpMachine1.Controls.OfType(Of Control)().ToList()
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is Label Or TypeOf ctrl Is PictureBox Then
                grpMachine1.Controls.Remove(ctrl)
            End If
        Next

        ' Clear Bench 4 controls
        For Each ctrl As Control In grpMachine2.Controls.OfType(Of Control)().ToList()
            If TypeOf ctrl Is TextBox Or TypeOf ctrl Is Label Or TypeOf ctrl Is PictureBox Then
                grpMachine2.Controls.Remove(ctrl)
            End If
        Next


        ' Clear the lists of textboxes
        machine1TextBoxes.Clear()
        machine2TextBoxes.Clear()

        ' Hide button complete
        btnComplete1.Hide()
        btnComplete2.Hide()

        ' Reset the focus back to the serial number input
        txtSerialNumber.Select()

        Application.DoEvents()
    End Sub


    ' Handle the Clear button
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearAllTextboxes(True)
    End Sub

    Private Sub AboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        frmReports.Show()
    End Sub
End Class
