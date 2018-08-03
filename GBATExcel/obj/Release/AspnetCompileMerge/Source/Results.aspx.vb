Imports Excel = Microsoft.Office.Interop.Excel


Public Class WebForm3
    Inherits System.Web.UI.Page

    Dim filePathData As String
    Dim filePathError As String

    Dim DtSet As New DataSet

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Display Results on Page Load
        If Not IsPostBack Then

            filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
            filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString
            GridView1.DataSource = Nothing
            GridView2.DataSource = Nothing

            Session("startNumOutputs") = 0
            Session("endNumOutputs") = 15
            Session("minNumOutputs") = 15
            Session("startNumErrors") = 0
            Session("endNumErrors") = 15
            Session("minNumErrors") = 15

            Session("resultsPageVisited") = True

            previousColumns.Visible = False
            If Session("Filename1") = "" Then
                Response.Redirect("UploadFile.aspx")
            Else
                Tab1.CssClass = "Clicked"
                MainView.ActiveViewIndex = 0
                If Not Session("Flag") = "3S" Then
                    nextColumns.Visible = False
                    loadExcel(filePathData, GridView1, "output")
                Else
                    Session("coloumns") = 1
                    ThreeSLoadExcel()
                End If
            End If
            Session("isCombined") = False

        End If

    End Sub

    Protected Sub nextButton_Click(sender As Object, e As EventArgs) Handles nextButton.Click

        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
        filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString
        If Tab1.CssClass = "Clicked" Then

            Session("startNumOutputs") = Session("startNumOutputs") + 15
            Session("endNumOutputs") = Session("endNumOutputs") + 15

            If Session("startNumOutputs") < Session("ErrorSize") - Session("minNumOutputs") Then
                Session("startNumOutputs") = Session("startNumOutputs") + Session("minNumOutputs")
                Session("endNumOutputs") = Session("endNumOutputs") + Session("minNumOutputs")
            End If

            If Session("startNumOutputs") > 14 Then
                prevButton.Visible = True
            End If

            If Session("endNumOutputs") >= Session("OutputSize") Then
                nextButton.Visible = False
                RegMsgBox("End of Data")
                Session("endNumOutputs") = Session("OutputSize")
            End If

            If Not Session("Flag") = "3S" Then
                loadExcel(filePathData, GridView1, "output")
            Else
                ThreeSLoadExcel()
            End If

        Else

            Session("startNumErrors") = Session("startNumErrors") + 15
            Session("endNumErrors") = Session("endNumErrors") + 15

            If Session("startNumErrors") < Session("ErrorSize") - Session("minNumErrors") Then
                Session("startNumErrors") = Session("startNumErrors") + Session("minNumErrors")
                Session("endNumErrors") = Session("endNumErrors") + Session("minNumErrors")
            End If

            If Session("startNumErrors") > 14 Then
                prevButton.Visible = True
            End If

            If Session("endNumErrors") >= Session("ErrorSize") Then
                nextButton.Visible = False
                RegMsgBox("End of Data")
                Session("endNumErrors") = Session("ErrorSize")
            End If

            loadExcelErrors(filePathError, GridView2, "Error")

        End If

    End Sub

    Protected Sub prevButton_Click(sender As Object, e As EventArgs) Handles prevButton.Click

        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
        filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString

        If Tab1.CssClass = "Clicked" Then

            If Session("startNumOutputs") < 14 Then
                prevButton.Visible = False
            End If

            If ((Session("endNumOutputs") - Session("startNumOutputs")) < 15) Then
                Session("endNumOutputs") = (15 * (Math.Ceiling(Session("endNumOutputs") / 15))) - 15
            Else
                Session("endNumOutputs") = Session("endNumOutputs") - 15
            End If

            Session("startNumOutputs") = Session("startNumOutputs") - 15

            If Session("startNumOutputs") > Session("OutputSize") - Session("minNumOutputs") Then
                Session("startNumOutputs") = Session("startNumOutputs") + Session("minNumOutputs")
                Session("endNumOutputs") = Session("endNumOutputs") + Session("minNumOutputs")
            End If

            If Session("endNumOutputs") < 15 Then
                Session("endNumOutputs") = 15
            End If

            If Not Session("Flag") = "3S" Then
                loadExcel(filePathData, GridView1, "output")
            Else
                ThreeSLoadExcel()
            End If

        Else

            If Session("startNumErrors") < 14 Then
                prevButton.Visible = False
            End If

            Session("startNumErrors") = Session("startNumErrors") - 15
            Session("endNumErrors") = Session("endNumErrors") - 15

            If Session("startNumErrors") < Session("ErrorSize") - Session("minNumErrors") Then
                Session("startNumErrors") = Session("startNumErrors") + Session("minNumErrors")
                Session("endNumErrors") = Session("endNumErrors") + Session("minNumErrors")
            End If

            If Not Session("Flag") = "3S" Then
                loadExcel(filePathData, GridView1, "output")
            Else
                ThreeSLoadExcel()
            End If

        End If

    End Sub

    Protected Sub BackImageButton_Click(sender As Object, e As ImageClickEventArgs) Handles BackImageButton.Click
        Response.Redirect("OutputSelectPage.aspx")
    End Sub

    Protected Sub DownloadExcel_Click(sender As Object, e As EventArgs) Handles DownloadExcelButton.Click

        Dim isCombined As Boolean = Session("isCombined")

        If Not isCombined Then
            CombineSheets()
        End If
        DownloadFile()

    End Sub

    Sub CombineSheets()

        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
        filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString

        Dim appSource As New Excel.Application
        Dim sourceWorkBook As Excel.Workbook = appSource.Workbooks.Open(filePathError)

        Dim sourceWorkSheet As Excel.Worksheet = sourceWorkBook.Worksheets(2)
        Dim targetWorkBook As Excel.Workbook = appSource.Workbooks.Open(filePathData)

        sourceWorkSheet.Copy(After:=targetWorkBook.Worksheets(2))

        sourceWorkBook.Save()
        targetWorkBook.Save()

        sourceWorkBook.Close()
        targetWorkBook.Close()

        Session("isCombined") = True

    End Sub

    Sub DownloadFile()

        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
        filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString

        Dim TargetFile As New System.IO.FileInfo(filePathData)
        ' clear the current output content from the buffer
        Response.Clear()
        ' add the header that specifies the default filename for the Download/
        ' SaveAs dialog
        Response.AddHeader("Content-Disposition", "attachment; filename=" +
            TargetFile.Name)
        ' add the header that specifies the file size, so that the browser
        ' can show the download progress
        Response.AddHeader("Content-Length", TargetFile.Length.ToString())
        ' specify that the response is a stream that cannot be read by the
        ' client and must be downloaded
        Response.ContentType = "application/octet-stream"
        ' send the file stream to the client
        Response.WriteFile(TargetFile.FullName)
        ' stop the execution of this page
        Response.End()

    End Sub

    Sub loadExcel(filePath As String, gv As GridView, sheetName As String)

        Dim startNumber = Session("startNumOutputs").ToString
        Dim endNumber = Session("endNumOutputs").ToString

        If Session("endNumOutputs") >= Session("OutputSize") - 1 Then
            nextButton.Visible = False
            RegMsgBox("End Of Data")
            Session("endNumOutputs") = Session("OutputSize")
        Else
            nextButton.Visible = True
        End If

        If Session("startNumOutputs") > 14 And Session("OutputSize") > 15 Then
            prevButton.Visible = True
        Else
            prevButton.Visible = False
        End If

        Dim MyConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;';")
        Dim MyCommand = New OleDb.OleDbDataAdapter("select * FROM [" + sheetName + "$] where ID > " + startNumber + " AND ID <= " + endNumber + " ", MyConnection)

        MyCommand.Fill(DtSet)
        GridView1.DataSource = DtSet
        GridView1.DataBind()

        If Not GridView1.Rows.Count = 0 Then
            If Not Session("numOfSelectedUserInputs") = 0 Then
                For i As Integer = 0 To Session("numOfSelectedUserInputs")
                    GridView1.HeaderRow.Cells(i).BackColor = Drawing.Color.SkyBlue
                Next
            End If
        End If

        DtSet.Reset()

        MyConnection.Close()
        MyCommand.Dispose()

    End Sub

    Public Function loadExcelErrors(filePath As String, gv As GridView, sheetName As String)

        If Session("startNumErrors") < 15 Then
            prevButton.Visible = False
        End If

        If Session("endNumErrors") >= Session("ErrorSize") Then
            nextButton.Visible = False
            RegMsgBox("End of Data")
            Session("endNumErrors") = Session("ErrorSize")
        Else
            nextButton.Visible = True
        End If

        Dim MyConnection As OleDb.OleDbConnection

        Dim MyCommand As OleDb.OleDbDataAdapter

        MyConnection = New OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & filePath & ";Extended Properties='Excel 12.0 Xml;HDR=YES;';")

        MyCommand = New OleDb.OleDbDataAdapter("select * FROM [" + sheetName + "$] where ID > " + Session("startNumErrors").ToString + " AND ID <= " + Session("endNumErrors").ToString + " ", MyConnection)

        MyCommand.Fill(DtSet)

        gv.DataSource = DtSet
        gv.DataBind()
        DtSet.Reset()

        MyConnection.Close()

        Return Nothing
    End Function

    Public Function ThreeSLoadExcel()

        If Session("endNumOutputs") >= Session("OutputSize") Then
            nextButton.Visible = False
            RegMsgBox("End Of Data")
            Session("endNumOutputs") = Session("OutputSize")
        Else
            nextButton.Visible = True
        End If

        If Session("startNumOutputs") > 14 And Session("OutputSize") > 15 Then
            prevButton.Visible = True
        Else
            prevButton.Visible = False
        End If

        If Not Session("coloumns") = 1 Then
            previousColumns.Visible = True
        Else
            previousColumns.Visible = False
        End If

        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
        Dim taskTable As New DataTable("TaskList")
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        xlApp = New Excel.Application

        Try
            xlWorkBook = xlApp.Workbooks.Open(filePathData)
        Catch ex As Exception

        End Try

        xlWorkSheet = xlWorkBook.Worksheets("output")

        If Not Session("coloumns") = 1 Then
            taskTable.Columns.Add("ID")

            For i As Integer = 0 To Session("3SUserInputs").Count - 1
                taskTable.Columns.Add(Session("3SUserInputs")(i))
            Next

        End If

        For a = Session("coloumns") To Session("coloumns") + 49
            taskTable.Columns.Add(xlWorkSheet.Cells(1, a).value.ToString, GetType(String))
        Next

        Session("ColumnCount") = xlWorkSheet.UsedRange.Columns.Count

        If Session("endNumOutputs") + 1 > Session("OutputSize") Then
            Session("endNumOutputs") = Session("OutputSize") - 1
        End If

        For y = Session("startNumOutputs") + 2 To Session("endNumOutputs") + 1
            Dim tableRow = taskTable.NewRow()


            If Not Session("coloumns") = 1 Then
                tableRow("ID") = xlWorkSheet.Cells(y, 1).value
                For i As Integer = 0 To Session("3SUserInputs").Count - 1
                    For x As Integer = 0 To Session("3SUserInputs").Count - 1
                        If taskTable.Columns(x + 1).ColumnName = Session("3SUserInputs")(i) Then

                            If Session("3SUserInputs")(i) = "Normalized Borough" Then
                                tableRow(Session("3SUserInputs")(i)) = Session("normalizedBoroughs")(y - 2)
                            ElseIf Session("3SUserInputs")(i) = "Normalized Street" Then
                                tableRow(Session("3SUserInputs")(i)) = Session("normalizedStreets")(y - 2)
                            ElseIf Session("3SUserInputs")(i) = "Normalized Street 2" Then
                                tableRow(Session("3SUserInputs")(i)) = Session("normalizedStreets2")(y - 2)
                            ElseIf Session("3SUserInputs")(i) = "Normalized Street 3" Then
                                tableRow(Session("3SUserInputs")(i)) = Session("normalizedStreets3")(y - 2)
                            Else
                                tableRow(Session("3SUserInputs")(i)) = Session("TaskTable").Tables(0).Rows(y - 2)(i).ToString
                            End If

                        End If
                    Next
                Next
            End If

            For x = Session("coloumns") To Session("coloumns") + 49
                tableRow(xlWorkSheet.Cells(1, x).value.ToString) = xlWorkSheet.Cells(y, x).value
            Next

            taskTable.Rows.Add(tableRow)
        Next

        GridView1.DataSource = taskTable
        GridView1.DataBind()

        If Not Session("numOfSelectedUserInputs") = 0 Then
            For i As Integer = 0 To Session("numOfSelectedUserInputs")
                GridView1.HeaderRow.Cells(i).BackColor = Drawing.Color.SkyBlue
            Next
        End If

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
    End Function

    Public Function ThreeSLoadExcelError()

        filePathData = "C:\ExcelFiles\" + Session("Filename1").ToString
        Dim taskTable As New DataTable("TaskList")
        Dim xlApp As Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        xlApp = New Excel.Application

        Try
            xlWorkBook = xlApp.Workbooks.Open(filePathData)
        Catch ex As Exception

        End Try

        xlWorkSheet = xlWorkBook.Worksheets("Error")


        For a = 1 To 10
            taskTable.Columns.Add(xlWorkSheet.Cells(1, a).value.ToString, GetType(String))
        Next

        For y = 2 To Session("3SErrors") + 1
            Dim tableRow = taskTable.NewRow()
            For x = 1 To 10
                tableRow(xlWorkSheet.Cells(1, x).value.ToString) = xlWorkSheet.Cells(y, x).value
            Next
            taskTable.Rows.Add(tableRow)
        Next

        GridView2.DataSource = taskTable
        GridView2.DataBind()

        xlWorkBook.Close()
        xlApp.Quit()

        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)

    End Function

    Protected Sub previousColumns_Click(sender As Object, e As EventArgs) Handles previousColumns.Click
        filePathData = "C: \ExcelFiles\" + Session("Filename2").ToString

        If (Session("coloumns") - 49) > 0 Then
            Session("coloumns") = Session("coloumns") - 49
        Else
            Session("coloumns") = 1
        End If

        ThreeSLoadExcel()

    End Sub

    Protected Sub nextColumns_Click(sender As Object, e As EventArgs) Handles nextColumns.Click
        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString

        If (Session("coloumns") + 49) < Session("ColumnCount") Then
            Session("coloumns") = Session("coloumns") + 49
        Else
            Session("coloumns") = Session("coloumns") + (Session("ColumnCount") - Session("coloumns"))
        End If

        ThreeSLoadExcel()

    End Sub

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

    Protected Sub Tab1_Click(sender As Object, e As EventArgs)
        Tab1.CssClass = "Clicked"
        Tab2.CssClass = "Initial"
        MainView.ActiveViewIndex = 0
        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
        filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString

        If Not Session("Flag") = "3S" Then
            nextColumns.Visible = False
            previousColumns.Visible = False
            loadExcel(filePathData, GridView1, "output")
        Else
            nextColumns.Visible = True
            Session("coloumns") = 1
            ThreeSLoadExcel()
        End If


    End Sub

    Protected Sub Tab2_Click(sender As Object, e As EventArgs)
        Tab1.CssClass = "Initial"
        Tab2.CssClass = "Clicked"
        MainView.ActiveViewIndex = 1
        filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
        filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString

        If Not Session("Flag") = "3S" Then
            nextColumns.Visible = False
            previousColumns.Visible = False
            loadExcelErrors(filePathError, GridView2, "Error")
        Else
            ThreeSLoadExcelError()
        End If

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

End Class