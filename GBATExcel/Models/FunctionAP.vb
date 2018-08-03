﻿Imports DCP.Geosupport.DotNet.GeoX
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Class FunctionAP

    Dim mygeo As New geo
    Dim lbxUserOuts As New List(Of String)()
    Dim lbxOuts As New List(Of String)()
    Dim dt As DataSet
    Dim filename1 As String
    Dim filename2 As String
    Dim UserInputs = System.Web.HttpContext.Current.Session("userInputDictionary")
    Dim normalizedBoroughs = System.Web.HttpContext.Current.Session("normalizedBoroughs")
    Dim normalizedStreets = System.Web.HttpContext.Current.Session("normalizedStreets")

    Dim mywa1 As New Wa1
    Dim mywa2fapx As New Wa2Fapx

    Dim openXmlWriterData As OpenXmlWriter
    Dim openXmlWriterError As OpenXmlWriter

    Dim outputIdCounter = 1
    Dim errorIdCounter = 1

    Public Sub New()
        'constructor
    End Sub

    Public Sub New(filename1 As String, filename2 As String, lbxUserOuts As List(Of String), lbxOuts As List(Of String), dt As DataSet)
        Me.lbxUserOuts = lbxUserOuts
        Me.lbxOuts = lbxOuts
        Me.dt = dt
        Me.filename1 = filename1
        Me.filename2 = filename2
    End Sub

    Public Sub PopulateExcel()

        Dim filePathData = "C:\ExcelFiles\" + filename2
        Dim filePathError = "C:\ExcelFiles\" + filename1

        Dim spreadsheetDocument As SpreadsheetDocument = SpreadsheetDocument.Open(filePathData, True)
        Dim spreadsheetDocumentError As SpreadsheetDocument = SpreadsheetDocument.Open(filePathError, True)

        'Data Section - Heading and Setup
        Dim workSheetPartData = OpenSheet(openXmlWriterData, spreadsheetDocument, "output", 10, 10UI)
        openXmlWriterData = PopulateExcelDataHeadingManual(openXmlWriterData, workSheetPartData)

        'Error Section - Heading and Setup 
        Dim workSheetPartError = OpenSheet(openXmlWriterError, spreadsheetDocumentError, "Error", 10, 10UI)
        openXmlWriterError = PopulateHeadingError(openXmlWriterError, workSheetPartError)

        For index = 0 To UserInputs("Address No").Count - 1
            mywa1.Clear()
            For Each col As KeyValuePair(Of String, ArrayList) In UserInputs
                If Not IsDBNull(col.Value(index)) Then
                    If col.Key = "Borough" Then
                        mywa1.in_b10sc1.boro = col.Value(index)

                    ElseIf col.Key = "Address No" Then

                        mywa1.in_hnd = col.Value(index)

                    ElseIf col.Key = "Street" Then
                        mywa1.in_stname1 = col.Value(index)
                    ElseIf col.Key = "Zip Code" Then
                        mywa1.in_zip_code = col.Value(index)
                    End If
                End If
            Next

            mywa1.in_func_code = "AP"
            mywa1.in_platform_ind = "C"
            mygeo.GeoCall(mywa1, mywa2fapx)

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

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Reason Code"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Reason Code 2"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("X Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Y Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Latitude"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Longitude"))
        oxw.WriteEndElement()

#Region "Property Level Left Column"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Tax Block"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Tax Lot"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("BBL"))
        oxw.WriteEndElement()


        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Low_BBL_of_Condo"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("High_BBL_of_Condo"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("BIN"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Structures"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("RPAD_Condo_Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("RPAD_Co-op_Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Condo_Lot"))
        oxw.WriteEndElement()

#End Region
        'End the row
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

        Dim wa1_ap As New Wa1
        Dim wa2fapx As New Wa2Fapx

        wa1_ap.Clear()
        wa1_ap.in_func_code = "AP"
        wa1_ap.in_platform_ind = "C"
        wa1_ap.in_mode_switch = "X"

        mygeo.GeoCall(wa1_ap, wa2fapx)

#Region "Orientation Left Column"

        Dim iDCell = New Cell()
        iDCell.DataType = CellValues.Number
        oxw.WriteStartElement(iDCell)
        oxw.WriteElement(New CellValue(id))
        oxw.WriteEndElement()

        outputIdCounter = outputIdCounter + 1

        'User Selected Col (first box)
        For v = 0 To lbxUserOuts.Count - 1
            Dim colName = lbxUserOuts(v).ToString
            If colName = "Normalized Borough" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedBoroughs(index)))
                oxw.WriteEndElement()
            ElseIf colName = "Normalized Street" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedStreets(index)))
                oxw.WriteEndElement()
            Else
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
            End If

        Next

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_grc))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_grc2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_reason_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_reason_code2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.latitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.longitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.bbl.block))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.bbl.lot))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.bbl.ToString()))
        oxw.WriteEndElement()

        If mywa2fapx.condo_flag = "C" Then

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue(mywa2fapx.condo_lo_bbl.boro + " - " + mywa2fapx.condo_lo_bbl.block + " - " + mywa2fapx.condo_lo_bbl.lot))
            oxw.WriteEndElement()

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue(mywa2fapx.condo_hi_bbl.boro + " - " + mywa2fapx.condo_hi_bbl.block + " - " + mywa2fapx.condo_hi_bbl.lot))
            oxw.WriteEndElement()

        Else

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("N/A"))
            oxw.WriteEndElement()
            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("N/A"))
            oxw.WriteEndElement()

        End If

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.bin.BINToString()))
        oxw.WriteEndElement()

        If mywa2fapx.num_of_bldgs.Trim() = String.Empty Then

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("0"))
            oxw.WriteEndElement()

        ElseIf mywa2fapx.num_of_bldgs.TrimStart(CChar("0")) = String.Empty Then

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("0"))
            oxw.WriteEndElement()

        Else

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue(mywa2fapx.num_of_bldgs.TrimStart(CChar("0"))))
            oxw.WriteEndElement()

        End If

        If String.IsNullOrEmpty(mywa2fapx.condo_num) Then

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("N/A"))
            oxw.WriteEndElement()

        Else

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue(mywa2fapx.condo_num))
            oxw.WriteEndElement()

        End If


        If String.IsNullOrEmpty(mywa2fapx.coop_num) Then

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("N/A"))
            oxw.WriteEndElement()

        Else

            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue(mywa2fapx.coop_num))
            oxw.WriteEndElement()

        End If

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.condo_flag))
        oxw.WriteEndElement()

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
        oxw.WriteElement(New CellValue("Input Address No"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Input Street"))
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

        errorIdCounter = errorIdCounter + 1

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_func_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_b10sc1.boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_hnd))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_stname1))
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

End Class
