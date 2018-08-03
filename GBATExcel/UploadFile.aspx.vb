Imports System.IO
Imports DCP.Geosupport.DotNet.GeoX
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Data.SqlClient
Imports System.Data.OleDb


Public Class _Default
    Inherits Page
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

        ' Create Session variables
        ' IsPostBack checks to see if user is visiting page for the first time or if the user pressed the "back" button on their browser. 

        If Not IsPostBack Then
            Session("containsListBox2Item") = New ArrayList()
            Session("containsListBox4Item") = New ArrayList()
            Session("containsListBox6Item") = New ArrayList()
            Session("normalizedBoroughs") = New ArrayList()
            Session("normalizedBoroughs2") = New ArrayList()
            Session("normalizedBoroughs3") = New ArrayList()
            Session("normalizedStreets") = New ArrayList()
            Session("normalizedStreets2") = New ArrayList()
            Session("normalizedStreets3") = New ArrayList()
            Session("containsListBox8Item") = New ArrayList()
            Session("containsListBox10Item") = New ArrayList()
            Session("UserSelectedCol") = New Dictionary(Of String, Integer)
            Session("BoroughSelectedOverZip") = False
            Session("savedPath") = ""
            Session("filepathname") = ""
            Session("zip") = New ArrayList()
            Session("boro") = New ArrayList()
            Session("st") = New ArrayList()
            Session("unitNo") = New ArrayList()
            Session("addressNo") = New ArrayList()
            Session("boro1") = New ArrayList()
            Session("boro2") = New ArrayList()
            Session("street1") = New ArrayList()
            Session("street2") = New ArrayList()
            Session("boro3") = New ArrayList()
            Session("street3") = New ArrayList()
            Session("sideOfStreet") = New ArrayList()
            Session("bin") = New ArrayList()
            Session("block") = New ArrayList()
            Session("lot") = New ArrayList()
            Session("3SUserInputs") = New ArrayList()
            Session("gridview1TotalRowCount") = 0
            Session("gridview1RowCount") = 0
            Session("Filename1") = ""
            Session("Filename2") = ""
            Session("Filename3") = ""
            Session("boroPlace") = New Integer
            Session("onstPlace") = New Integer
            Session("compDirect1") = New Integer
            Session("compDirect2") = New Integer
            Session("CompassDirection1Selected") = New Boolean
            Session("CompassDirection2Selected") = New Boolean
            Session("resultsPageVisited") = False

            Session("Flag") = ""
            Session.Remove(Session("mygeoconns"))

            Session("boroSelectedTwice") = False
            Session("addressNoSelectedTwice") = False
            Session("streetSelectedTwice") = False
            Session("zipSelectedTwice") = False
            Session("unitNoSelectedTwice") = False

            Session("Dttbl") = New DataSet
            Session("headerRowText") = New ArrayList()
            Session("3SErrors") = 0
            Session("endNum") = 0
            Session("startNum") = 0
            Session("startState") = 0
            Session("startPage") = 0
            Session("minNum") = 15

            Session("realStreet") = False

            Session("gridviewInputBackButtonFlag") = False
            Session("outputSelectBackButtonFlag") = False
            Session("resultsBackButtonFlag") = False

            Session("Roadbed Specific Information") = False

            Session("TPAD") = False

            Session("gridview1TotalRowCount") = 0

        End If
    End Sub

    ' When the user presses the "Next" button this function executes:
    Protected Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click

        If FileUpload1.FileName IsNot "" Then 'making sure there is a file 

            Session("FileType") = System.IO.Path.GetExtension(FileUpload1.FileName)

            Dim passedExcelLimitTest As Boolean = True

            If Session("FileType") = ".xls" Or Session("FileType") = ".xlsx" Or Session("FileType") = "xls" Or Session("FileType") = "xlsx" Then

                '************ Creation of Excel Sheet ****************
                Session("savedPath") = "C:\ExcelFiles\"
                Dim rng As New Random
                Dim number As Integer = rng.Next(1, 100000)
                Dim digits As String = number.ToString("000000")
                Dim fileName1 As String = "WorkBook" + digits + ".xlsx"
                Dim fileName2 As String = "WorkBook" + digits + "XML" + ".xlsx"
                Dim fileName3 As String = "WorkBook" + digits + "Error" + ".xlsx"
                Session("Filename1") = fileName1
                Session("Filename2") = fileName2
                Session("Filename3") = fileName3

                Session("FileUpload1") = FileUpload1

                FileUpload1.SaveAs(Path.Combine(Session("savedPath"), fileName1))

                FileUpload1.SaveAs(Path.Combine(Session("savedPath"), fileName2))


                '***************************** TEST CODE ***********************
                'Change Excel Sheet Name to Sheet1 and change format to TEXT
                If Session("FileType") = ".xls" Or Session("FileType") = ".xlsx" Or Session("FileType") = "xls" Or Session("FileType") = "xlsx" Then
                    changeExcelSheetName()
                End If

                Dim MyConnection As System.Data.OleDb.OleDbConnection

                Dim DtSet As New System.Data.DataSet("TaskTable")

                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                Dim filePath = Path.Combine(Session("savedPath"), Session("Filename1"))

                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties='Excel 12.0 Xml;';")

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)

                MyCommand.Fill(DtSet)

                Session("TaskTable") = DtSet

                MyConnection.Close()

                getTotalRowsCount() 'obtains the total number of rows on the excelsheet


                'This was all code for a csv file, that needs a csv file to succesfully convert to xls with the worksheet name

            ElseIf Session("FileType") = ".csv" Or Session("FileType") = "csv" Then


                Session("savedPath") = "C:\csvfiles\"
                Dim rng As New Random
                Dim number As Integer = rng.Next(1, 100000)
                Dim digits As String = number.ToString("000000")
                Dim sheetName1 As String = "CSVFile" + digits
                Dim fileName1 As String = "CSVFile" + digits + ".xls"
                Session("Filename1") = fileName1
                FileUpload1.SaveAs(Path.Combine(Session("savedPath"), Session("Filename1")))
                Dim filePath = Path.Combine(Session("savedPath"), Session("Filename1"))
                Dim x = IO.File.ReadAllText(filePath)
                x = x.Replace(",", Chr(9))
                IO.File.WriteAllText(filePath, x)

                Dim MyConnection As System.Data.OleDb.OleDbConnection


                Dim DtSet As New System.Data.DataSet("TaskTable")

                Dim MyCommand As System.Data.OleDb.OleDbDataAdapter

                MyConnection = New System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties='Excel 12.0 Xml;';")

                MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [" & sheetName1.ToString() & "]", MyConnection)

                MyCommand.Fill(DtSet)

                Session("TaskTable") = DtSet

                MyConnection.Close()

                getTotalRowsCount() 'obtains the total number of rows on the excelsheet

            Else
                'If not an xls or xlsx sheet
                passedExcelLimitTest = False
                RegMsgBox("Invalid File Format")
            End If

            setRadioButtonSelectFlag()

            'Checks to see if the excelsheets are too big or not
            If Session("Flag") = "3S" Then
                If Session("gridview1TotalRowCount") > 999 Then
                    RegMsgBox("Excelsheet cannot exceed 1000 rows")
                    passedExcelLimitTest = False
                End If
            Else
                If Session("gridview1TotalRowCount") > 99999 Then
                    RegMsgBox("Excelsheet cannot exceed 100,000 rows")
                    passedExcelLimitTest = False
                End If
            End If

            If passedExcelLimitTest = True Then
                Response.Redirect("GridViewInputPage.aspx", True)
            End If

        Else
            RegMsgBox("please upload an Excel file with a Header Row")
        End If
    End Sub


    Public Function changeExcelSheetName()
        'sets the name of the excel spreadsheet being uploaded to Sheet1
        Dim filename = Path.Combine(Session("savedPath"), Session("Filename1"))
        Dim app As Excel.Application = New Excel.Application()
        Dim excelWorkbook As Excel.Workbook
        Dim excelWorkSheet As Excel.Worksheet

        Try
            excelWorkbook = app.Workbooks.Open(filename)

            If excelWorkbook.Sheets.Count > 0 Then
                excelWorkSheet = excelWorkbook.Sheets(1)
                excelWorkSheet.Cells.NumberFormat = "@"
                excelWorkSheet.Name = "Sheet1" 'Rename the sheet
            End If

            excelWorkbook.Save() 'Save the excel

            excelWorkbook.Close(filename) 'Close the excel

        Catch ex As Exception

            RegMsgBox("Export Excel Failed: " & ex.Message)

        Finally

            app.Quit()
            app = Nothing
            GC.Collect()

            GC.WaitForPendingFinalizers()
        End Try
        Return Nothing
    End Function


    Public Function setRadioButtonSelectFlag()

        If RadioButtonList1.SelectedValue = "1B" Then
            Session("Flag") = "1B"

            If CheckBoxList1.SelectedValue = "Roadbed Specific Information" Then
                Session("Roadbed Specific Information") = True
            Else
                Session("Roadbed Specific Information") = False
            End If

            If CheckBoxList2.SelectedValue = "TPAD" Then
                Session("TPAD") = True
            Else
                Session("TPAD") = False
            End If

        ElseIf RadioButtonList1.SelectedValue = "2" Then
            Session("Flag") = "2"
        ElseIf RadioButtonList1.SelectedValue = "1A" Then
            Session("Flag") = "1A"
        ElseIf RadioButtonList1.SelectedValue = "1E" Then
            Session("Flag") = "1E"
        ElseIf RadioButtonList1.SelectedValue = "3" Then
            Session("Flag") = "3"
        ElseIf RadioButtonList1.SelectedValue = "3S" Then
            Session("Flag") = "3S"

            If CheckBoxList1.SelectedValue = "Real Streets Only" Then
                Session("realStreet") = True
            Else
                Session("realStreet") = False
            End If

        ElseIf RadioButtonList1.SelectedValue = "BL" Then
            Session("Flag") = "BL"

            If CheckBoxList2.SelectedValue = "TPAD" Then
                Session("TPAD") = True
            Else
                Session("TPAD") = False
            End If

        ElseIf RadioButtonList1.SelectedValue = "BN" Then
            Session("Flag") = "BN"

            If CheckBoxList2.SelectedValue = "TPAD" Then
                Session("TPAD") = True
            Else
                Session("TPAD") = False
            End If

        ElseIf RadioButtonList1.SelectedValue = "Name/Code" Then
                If RadioButtonList2.SelectedValue = "N" Then
                    Session("Flag") = "N"
                ElseIf RadioButtonList2.SelectedValue = "D" Then
                    Session("Flag") = "D"
                Else
                    Session("Flag") = "1N"
                End If
            ElseIf RadioButtonList1.SelectedValue = "AP" Then
                Session("Flag") = "AP"
        End If
        Return Nothing
    End Function


    Public Function getTotalRowsCount()
        Session("gridview1TotalRowCount") = Session("TaskTable").Tables(0).Rows.Count
        Return Nothing
    End Function
    'How to open the excel sheet Below:

    Public Function getSpreadSheetRowCount()
        Dim xls As New Excel.Application
        Dim sheet As Excel.Worksheet
        Session("filepathname") = Path.Combine(Session("savedPath"), Session("Filename1"))
        xls.Workbooks.Open(Session("filepathname"))
        sheet = xls.ActiveWorkbook.Sheets(1)
        Dim maxSize As Integer = 2
        Dim row As Integer = 1
        'Do Until sheet.Cells(row, 1).value Is Nothing
        Do
            row += 1
            'Loop While sheet.Cells(row, 1).value IsNot Nothing AndAlso row <= 10000
        Loop While sheet.Cells(row, 1).value IsNot Nothing
        xls.Workbooks.Close()
        xls.Quit()
        releaseObject(sheet)
        releaseObject(xls)
        Return Nothing
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Sub RegMsgBox(ByVal Message As String)
        Dim sb As New System.Text.StringBuilder()
        sb.Append("<script type = 'text/javascript'>")
        sb.Append("window.onload=function(){")
        sb.Append("alert('")
        sb.Append(Message)
        sb.Append("')};")
        sb.Append("</script>")
        ClientScript.RegisterClientScriptBlock(Me.GetType(), "alert", sb.ToString())
    End Sub

    Protected Sub RadioButtonList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonList1.SelectedIndexChanged
        'If RadioButtonList1.SelectedIndex = 0 Then
        If RadioButtonList1.SelectedValue = "1B" Then
            CheckBoxList1.Visible = True
            CheckBoxList1.Items.Remove("Real Streets Only")
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")
            CheckBoxList1.Items.Add("Roadbed Specific Information")
            CheckBoxList1.Items.Add("TPAD")
            RadioButtonList2.Visible = False

        ElseIf RadioButtonList1.SelectedValue = "1A" Then
            CheckBoxList1.Visible = True
            CheckBoxList1.Items.Remove("Real Streets Only")
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")
            CheckBoxList1.Items.Add("TPAD")
            RadioButtonList2.Visible = False

        ElseIf RadioButtonList1.SelectedValue = "BL" Then
            CheckBoxList1.Visible = True
            CheckBoxList1.Items.Remove("Real Streets Only")
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")
            CheckBoxList1.Items.Add("TPAD")
            RadioButtonList2.Visible = False

        ElseIf RadioButtonList1.SelectedValue = "BN" Then
            CheckBoxList1.Visible = True
            CheckBoxList1.Items.Remove("Real Streets Only")
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")
            CheckBoxList1.Items.Add("TPAD")
            RadioButtonList2.Visible = False

        ElseIf RadioButtonList1.SelectedValue = "1E" Then

            CheckBoxList1.Visible = True
            CheckBoxList1.Items.Remove("Real Streets Only")
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")

            RadioButtonList2.Visible = False

        ElseIf RadioButtonList1.SelectedValue = "3S" Then
            CheckBoxList1.Visible = True
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")
            CheckBoxList1.Items.Add("Real Streets Only")
            RadioButtonList2.Visible = False
        ElseIf RadioButtonList1.SelectedValue = "Name/Code" Then
            CheckBoxList1.Items.Remove("Real Streets Only")
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")
            CheckBoxList1.Visible = False
            RadioButtonList2.Visible = True
        Else
            CheckBoxList1.Items.Remove("Real Streets Only")
            CheckBoxList1.Items.Remove("Roadbed Specific Information")
            CheckBoxList1.Items.Remove("TPAD")
            CheckBoxList1.Visible = False
            RadioButtonList2.Visible = False
        End If
    End Sub

    Private Sub RadioButtonList1_CallingDataMethods(sender As Object, e As CallingDataMethodsEventArgs) Handles RadioButtonList1.CallingDataMethods

    End Sub
End Class