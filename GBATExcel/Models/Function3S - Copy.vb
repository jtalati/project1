Imports DCP.Geosupport.DotNet.GeoX
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet
Imports Excel = Microsoft.Office.Interop.Excel


Class Function3S2


    Dim mygeo As New geo
    Dim lbxUserOuts As New List(Of String)()
    Dim lbxOuts As New List(Of String)()
    Dim dt As DataSet
    Dim filename1 As String
    Dim filename2 As String

    Dim realStreet As Boolean
    Dim visited As Boolean

    Dim mywa1 As New Wa1
    Dim mywa1_stname As New Wa1
    Dim mywa2f3s As Wa2F3s = New Wa2F3s()

    Dim openXmlWriterData As OpenXmlWriter
    Dim openXmlWriterError As OpenXmlWriter

    Dim outputIdCounter = 1
    Dim errorIdCounter = 1
    Dim filePathData As String
    Dim filePathError As String


    Dim selectedCols As List(Of String)


    Public Sub New()
        'constructor
    End Sub

    Public Sub New(filename1 As String, filename2 As String, lbxUserOuts As List(Of String), lbxOuts As List(Of String), dt As DataSet, selectedCols As List(Of String), realStreet As Boolean, visited As Boolean)
        Me.lbxUserOuts = lbxUserOuts
        Me.lbxOuts = lbxOuts
        Me.dt = dt
        Me.filename1 = filename1
        Me.filename2 = filename2
        Me.selectedCols = selectedCols
        Me.realStreet = realStreet
        Me.visited = visited
    End Sub

    Public Sub PopulateExcel()
        filePathData = "C:\ExcelFiles\" + filename2
        filePathError = "C:\ExcelFiles\" + filename1

        Dim spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Open(filePathData, True)
        Dim spreadsheetDocumentError As SpreadsheetDocument = SpreadsheetDocument.Open(filePathError, True)

        If visited = False Then
            'Data Section - Heading and Setup
            Dim workSheetPartData = OpenSheet(openXmlWriterData, spreadsheetDocument, "output", 10, 10UI)
            openXmlWriterData = PopulateExcelDataHeadingManual(openXmlWriterData, workSheetPartData)


            'Error Section - Heading and Setup 
            Dim workSheetPartError = OpenSheet(openXmlWriterError, spreadsheetDocumentError, "Error", 10, 10UI)
            openXmlWriterError = PopulateHeadingError(openXmlWriterError, workSheetPartError)
        Else
            Dim workSheetPartData = OpenSheet(openXmlWriterData, spreadsheetDocument, "output", 11, 10UI)
            openXmlWriterData = PopulateExcelDataHeadingManual(openXmlWriterData, workSheetPartData)


            'Error Section - Heading and Setup 
            Dim workSheetPartError = OpenSheet(openXmlWriterError, spreadsheetDocumentError, "Error", 11, 10UI)
            openXmlWriterError = PopulateHeadingError(openXmlWriterError, workSheetPartError)
        End If



        Dim UserInputs = System.Web.HttpContext.Current.Session("userInputDictionary")

        For index = 0 To UserInputs("Borough").Count - 1

            For Each col As KeyValuePair(Of String, ArrayList) In UserInputs
                If col.Key = "Borough" Then
                    mywa1.in_b10sc1.boro = col.Value(index)
                ElseIf col.Key = "On Street" Then
                    mywa1.in_stname1 = col.Value(index)
                ElseIf col.Key = "First Cross Street" Then
                    mywa1.in_stname2 = col.Value(index)
                ElseIf col.Key = "Second Cross Street" Then
                    mywa1.in_stname3 = col.Value(index)
                ElseIf col.Key = "Compass Direction 1" Then
                    mywa1.in_compass_dir = col.Value(index)
                ElseIf col.Key = "Compass Direction 2" Then
                    mywa1.in_compass_dir2 = col.Value(index)
                End If
            Next
            mywa1.in_func_code = "3S"
            mywa1.in_platform_ind = "C"

            If realStreet = True Then
                mywa1.in_real_street_only = "R"
            Else
                mywa1.in_real_street_only = ""
            End If

            mygeo.GeoCall(mywa1, mywa2f3s)


            'Start Manual Call 
            If Not mywa1.out_grc = "00" And Not mywa1.out_grc = "01" Then
                PopulateExcelError(openXmlWriterError, mywa1, errorIdCounter)
            Else
                PopulateExcelDataManual(outputIdCounter, openXmlWriterData, index)
            End If


        Next

        System.Web.HttpContext.Current.Session("ErrorSize") = errorIdCounter
        System.Web.HttpContext.Current.Session("OutputSize") = outputIdCounter

        CloseSheet(openXmlWriterData, spreadsheetDocument)
        CloseSheet(openXmlWriterError, spreadsheetDocumentError)





    End Sub


#Region "Manual Call Without User Selection"


    Function PopulateExcelDataHeadingManual(oxw As OpenXmlWriter, workSheetPart As WorksheetPart)

        Dim oxa As New List(Of OpenXmlAttribute)()
        oxw = OpenXmlWriter.Create(workSheetPart)
        oxw.WriteStartElement(New Worksheet())
        oxw.WriteStartElement(New SheetData())


        '1. Create a new row
        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("r", Nothing, "A1"))
        oxw.WriteStartElement(New Row(), oxa)

        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))


        Dim Cell = New Cell()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("ID"))
        oxw.WriteEndElement()

        Dim userInputCounter As Integer = 0
        'User Selected Cols (First Box)
        For i = 0 To lbxUserOuts.Count - 1
            userInputCounter = userInputCounter + 1
            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue(lbxUserOuts(i)))
            oxw.WriteEndElement()
        Next

        System.Web.HttpContext.Current.Session("numOfSelectedUserInputs") = userInputCounter

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("GRC"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("GRC2"))
        oxw.WriteEndElement()

        For index = 0 To 349

            Try
                For k = 0 To selectedCols.Count - 1
                    If selectedCols(k) = "Intersecting Street" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("Intersecting Street " + index.ToString))
                        oxw.WriteEndElement()
                    End If


                    If selectedCols(k) = "2nd Intersecting Street (if any)" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("2nd Intersecting Street (if any) " + index.ToString))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "3nd Intersecting Street (if any)" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("3nd Intersecting Street (if any) " + index.ToString))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "4nd Intersecting Street (if any)" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("4nd Intersecting Street (if any) " + index.ToString))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "5nd Intersecting Street (if any)" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("5nd Intersecting Street (if any) " + index.ToString))
                        oxw.WriteEndElement()
                    End If


                    If selectedCols(k) = "Cross Street Count" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("Cross Street Count " + index.ToString))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "Number of Ft. from Previous Intersection" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("Number of Ft. from Previous Intersection " + index.ToString))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "Gap Flag" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("Gap Flag " + index.ToString))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "Node ID" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue("Node ID " + index.ToString))
                        oxw.WriteEndElement()
                    End If
                Next

            Catch ex As Exception

            End Try

        Next

        oxw.WriteEndElement()

        Return oxw

    End Function

    Sub PopulateExcelDataManual(id As Integer, oxw As OpenXmlWriter, index As Integer)

        'Create a a new row
        Dim oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("r", Nothing, "A2"))
        oxw.WriteStartElement(New Row(), oxa)

        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))

        Dim Cell = New Cell()


        Dim mywa1_dl1 = New Wa1()
        mywa1_dl1.in_func_code = "DL"
        mywa1_dl1.in_platform_ind = "C"

#Region "3S Data"

        Dim iDCell = New Cell()
        iDCell.DataType = CellValues.Number
        oxw.WriteStartElement(iDCell)
        oxw.WriteElement(New CellValue(id))
        oxw.WriteEndElement()

        outputIdCounter = outputIdCounter + 1


        'User Selected Col (first box)
        For v = 0 To lbxUserOuts.Count - 1
            Dim colName = lbxUserOuts(v).ToString
            Dim valueForXML = dt.Tables(0).Columns(colName).Table.Rows(index)(colName)
            If Not IsDBNull(valueForXML) Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(valueForXML))
                oxw.WriteEndElement()
            Else
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(""))
                oxw.WriteEndElement()
            End If
        Next

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_grc))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_grc2))
        oxw.WriteEndElement()

        'Start 1
        For index = 0 To 349

            Try

                For k = 0 To selectedCols.Count - 1
                    If selectedCols(k) = "Intersecting Street" Then
                        mywa1_dl1.out_b7sc_list(0) = mywa2f3s.xstr_list(index).xstr_b7sc_list(0)
                        mygeo.GeoCall(mywa1_dl1)
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa1_dl1.out_stname_list(0).Trim()))
                        oxw.WriteEndElement()

                    End If

                    If selectedCols(k) = "2nd Intersecting Street (if any)" Then
                        mywa1_dl1.out_b7sc_list(1) = mywa2f3s.xstr_list(index).xstr_b7sc_list(1)
                        mygeo.GeoCall(mywa1_dl1)
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa1_dl1.out_stname_list(1).Trim()))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "3nd Intersecting Street (if any)" Then
                        mywa1_dl1.out_b7sc_list(2) = mywa2f3s.xstr_list(0).xstr_b7sc_list(3)
                        mygeo.GeoCall(mywa1_dl1)
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa1_dl1.out_stname_list(2).Trim()))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "4nd Intersecting Street (if any)" Then
                        mywa1_dl1.out_b7sc_list(3) = mywa2f3s.xstr_list(0).xstr_b7sc_list(3)
                        mygeo.GeoCall(mywa1_dl1)
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa1_dl1.out_stname_list(3).Trim()))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "5nd Intersecting Street (if any)" Then
                        mywa1_dl1.out_b7sc_list(4) = mywa2f3s.xstr_list(0).xstr_b7sc_list(4)
                        mygeo.GeoCall(mywa1_dl1)
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa1_dl1.out_stname_list(4).Trim()))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "Cross Street Count" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa2f3s.xstr_list(0).xstr_cnt))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "Number of Ft. from Previous Intersection" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa2f3s.xstr_list(0).distance))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "Gap Flag" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa2f3s.xstr_list(0).gap_flag))
                        oxw.WriteEndElement()
                    End If

                    If selectedCols(k) = "Node ID" Then
                        oxw.WriteStartElement(Cell, oxa)
                        oxw.WriteElement(New CellValue(mywa2f3s.xstr_list(0).node_num))
                        oxw.WriteEndElement()
                    End If
                Next


            Catch ex As Exception

            End Try


        Next


#End Region


        'End the row
        oxw.WriteEndElement()
    End Sub


#End Region



#Region "Error Data Section"

    Public Function PopulateHeadingError(oxw As OpenXmlWriter, workSheetPart As WorksheetPart)

        Dim oxa As New List(Of OpenXmlAttribute)()
        oxw = OpenXmlWriter.Create(workSheetPart)
        oxw.WriteStartElement(New Worksheet())
        oxw.WriteStartElement(New SheetData())

        '1. Create a new row
        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("r", Nothing, "A1"))
        oxw.WriteStartElement(New Row(), oxa)

        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))


        Dim Cell = New Cell()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("ID"))
        oxw.WriteEndElement()

        '2. Write to cell
        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("In Function"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Input Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("On Street"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("First Cross Street"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Second Cross Street"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Reason Code 01"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Reason Code 02"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Error Message"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Error Message 2"))
        oxw.WriteEndElement()



        'End the row
        oxw.WriteEndElement()

        Return oxw
    End Function

    Sub PopulateExcelError(oxw As OpenXmlWriter, mywa1 As Wa1, id As Integer)

        'Create a a new row
        Dim oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("r", Nothing, "A2"))
        oxw.WriteStartElement(New Row(), oxa)

        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))

        Dim Cell = New Cell()

        Dim iDCell = New Cell()
        iDCell.DataType = CellValues.Number
        oxw.WriteStartElement(iDCell)
        oxw.WriteElement(New CellValue(id))
        oxw.WriteEndElement()

        outputIdCounter = outputIdCounter + 1

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_func_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_b10sc1.boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_stname1))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_stname2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_stname3))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_grc))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_grc2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_error_message))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_error_message2))
        oxw.WriteEndElement()

        '3. End the row by writing to excel
        oxw.WriteEndElement()
    End Sub

#End Region




#Region "OpenXML Functions"

    Function OpenSheet(oxw As OpenXmlWriter, spreadsheetDocument As SpreadsheetDocument, sheetName As String, sheetIDString As String, sheetID As UInt32)
        Dim workbookPart As WorkbookPart = spreadsheetDocument.WorkbookPart
        Dim rId As String = "rId" + sheetIDString
        Dim sheet As New Sheet()
        sheet.Name = sheetName
        sheet.SheetId = sheetID
        sheet.Id = rId
        workbookPart.Workbook.Sheets.Append(sheet)
        Dim worksheetPart As WorksheetPart = workbookPart.AddNewPart(Of WorksheetPart)(rId)
        Dim worksheet As New Worksheet()
        worksheet.AddNamespaceDeclaration("r", "http://schemas.openxmlformats.org/officeDocument/2006/relationships")

        Return worksheetPart
    End Function

    Sub CloseSheet(oxw As OpenXmlWriter, spreadsheetDocument As SpreadsheetDocument)

        'this is for SheetData
        oxw.WriteEndElement()
        'this is for Worksheet
        oxw.WriteEndElement()
        oxw.Close()

        spreadsheetDocument.Close()

    End Sub

#End Region


#Region "Style Heading"

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Sub StyleHeading()

        'Excel Objects

        Try
            xlWorkBook = xlApp.Workbooks.Open(filePathData)
            xlWorkSheet = xlWorkBook.Worksheets(2)

        Catch ex As Exception

        End Try

        Dim endCount = xlWorkSheet.UsedRange.Columns.Count

        'Style
        xlWorkSheet.UsedRange.Columns.AutoFit()
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, endCount)).Interior.Color = RGB(93, 123, 157)
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, endCount)).Font.Color = RGB(255, 255, 255)
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, endCount)).Font.FontStyle = "Bold"
        xlWorkSheet.UsedRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.UsedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous




        xlWorkBook.Save()
        xlWorkBook.Close()

        StyleErrorSheet()

    End Sub


    Sub StyleErrorSheet()
        xlWorkBook = xlApp.Workbooks.Open(filePathError)
        xlWorkSheet = xlWorkBook.Worksheets(2)
        xlWorkSheet.UsedRange.Columns.AutoFit()

        Dim lastCell = xlWorkSheet.UsedRange.Columns.Count

        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, lastCell)).Interior.Color = RGB(93, 123, 157)
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, lastCell)).Font.Color = RGB(255, 255, 255)
        xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, lastCell)).Font.FontStyle = "Bold"
        xlWorkSheet.UsedRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
        xlWorkSheet.UsedRange.Borders.LineStyle = Excel.XlLineStyle.xlContinuous

        xlApp.Visible = False
        xlApp.DisplayAlerts = False

        xlWorkBook.SaveAs(filePathError)
        xlWorkBook.Close()

    End Sub


#End Region







End Class
