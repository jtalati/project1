Imports DCP.Geosupport.DotNet.GeoX
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet


Public Class Function3

    Dim oxa As New List(Of OpenXmlAttribute)()
    Dim oxw As OpenXmlWriter
    Dim mygeo As New geo
    Dim lbxUserOuts As New List(Of String)()
    Dim lbxOuts As New List(Of String)()
    Dim dt As DataSet
    Dim filename1 As String
    Dim filename2 As String
    Dim UserInputs = System.Web.HttpContext.Current.Session("userInputDictionary")
    Dim normalizedBoroughs = System.Web.HttpContext.Current.Session("normalizedBoroughs")
    Dim normalizedBoroughs2 = System.Web.HttpContext.Current.Session("normalizedBoroughs2")
    Dim normalizedBoroughs3 = System.Web.HttpContext.Current.Session("normalizedBoroughs3")
    Dim normalizedStreets = System.Web.HttpContext.Current.Session("normalizedStreets")
    Dim normalizedStreets2 = System.Web.HttpContext.Current.Session("normalizedStreets2")
    Dim normalizedStreets3 = System.Web.HttpContext.Current.Session("normalizedStreets3")

    Dim mywa1 As New Wa1
    Dim mywa1_stname As New Wa1
    Dim mywa2f3 As New Wa2F3xas
    Dim mywa2f3xas As New Wa2F3xas
    Dim mywa2f1ax As New Wa2F1ax

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

        For index = 0 To UserInputs("Borough 1").Count - 1
            mywa1.Clear()
            For Each col As KeyValuePair(Of String, ArrayList) In UserInputs
                If Not IsDBNull(col.Value(index)) Then
                    If col.Key = "Borough 1" Then
                        mywa1.in_boro1 = col.Value(index)
                    ElseIf col.Key = "Street 1" Then
                        mywa1.in_stname1 = col.Value(index)
                    ElseIf col.Key = "Borough 2" Then
                        mywa1.in_boro2 = col.Value(index)
                    ElseIf col.Key = "Street 2" Then
                        mywa1.in_stname2 = col.Value(index)
                    ElseIf col.Key = "Borough 3" Then
                        mywa1.in_boro3 = col.Value(index)
                    ElseIf col.Key = "Street 3" Then
                        mywa1.in_stname3 = col.Value(index)
                    End If
                End If
            Next

            mywa1.in_func_code = "3"
            mywa1.in_platform_ind = "C"
            mywa1.in_xstreet_names_flag = "E"
            mywa1.in_auxseg_switch = "Y"
            mywa1.in_mode_switch = "X"

            mygeo.GeoCall(mywa1, mywa2f3)
            mygeo.GeoCall(mywa1, mywa2f3xas)

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

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DCP Zoning Map"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Reason Code"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Reason Code 2"))
        oxw.WriteEndElement()

#Region "Geo Information Left Column"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("On Street B7SC/Name"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("LION Key"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DOT Street Light Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment ID"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment Length"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Physical ID"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Generic ID"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Location Status"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Bike Lane"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Bike Lane Traffic Direction"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Number of Park Lanes"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Total Number of Lanes"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Traffic Direction"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment Type"))
        oxw.WriteEndElement()

#End Region

#Region "Geo Information Right Column"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("From Node"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("From X Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("From Y Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("From Latitude"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("From Longitude"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("To Node"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("To X Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("To Y Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("To Latitude"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("To Longitude"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Roadway Type"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Street Width Min"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Street Width Max"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Number Of Travel Lanes"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Curve Flag"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Of Way Type"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Feature Type"))
        oxw.WriteEndElement()

#End Region

#Region "Left Side of Street Information (Left Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Community District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Low House Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side High House Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Zip Code"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side School District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Police Patrol Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Police Precinct"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Health Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Health Center District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Neighborhood Tabulation Area"))
        oxw.WriteEndElement()

#End Region

#Region "Left Side Of Street Information (Right Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side 2010 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side 2010 Census Block"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Atomic Polygon"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side 2000 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side 2000 Census Block"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side CD Eligibility"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Fire Division"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Fire Battalion"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Fire Company"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Left Side Block Face ID"))
        oxw.WriteEndElement()

#End Region

#Region "Right Side Of Street Information (Left Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Community District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Low House Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side High House Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side ZIP Code"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side School District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Police Patrol Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Police Precinct"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Health Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Health Center District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Neighborhood Tabulation Area"))
        oxw.WriteEndElement()

#End Region

#Region "Right Side Of Street Information (Right Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side 2010 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side 2010 Census Block"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Atomic Polygon"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side 2000 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side 2000 Census Block"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side CD Eligibility"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Fire Division"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Fire Battalion"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Fire Company"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Side Block Face ID"))
        oxw.WriteEndElement()

#End Region

        'End the row
        oxw.WriteEndElement()

        Return oxw

    End Function

    Sub PopulateExcelDataManual(id As Integer, oxw As OpenXmlWriter, index As Integer)

        Dim oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("r", Nothing, "A2"))
        oxw.WriteStartElement(New Row(), oxa)

        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))

        Dim Cell = New Cell()

#Region "Initial Setup"

        Dim in_func_code = mywa1.in_func_code
        Dim in_boro = mywa1.in_boro1
        Dim in_stname1 = mywa1.in_stname1
        Dim in_compass_dir = mywa1.in_compass_dir
        Dim in_boro2 = mywa1.in_boro2
        Dim in_stname2 = mywa1.in_stname2
        Dim in_boro3 = mywa1.in_boro3
        Dim in_stname3 = mywa1.in_stname3
        Dim out_grc = mywa1.out_grc
        Dim out_grc2 = mywa1.out_grc2

#End Region

#Region "Geo Information Left Column"

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
            ElseIf colName = "Normalized Borough 2" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedBoroughs2(index)))
                oxw.WriteEndElement()
            ElseIf colName = "Normalized Borough 3" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedBoroughs3(index)))
                oxw.WriteEndElement()
            ElseIf colName = "Normalized Street" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedStreets(index)))
                oxw.WriteEndElement()
            ElseIf colName = "Normalized Street 2" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedStreets2(index)))
                oxw.WriteEndElement()
            ElseIf colName = "Normalized Street 3" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedStreets3(index)))
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
        oxw.WriteElement(New CellValue(mywa2f1ax.DCP_Zoning_Map))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_reason_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_reason_code2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(GetStreetCode(mywa1.out_b10sc1, mywa1.out_b10sc1.lgc) + " / " + CheckGeoX(mywa1.out_stname1)))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.lionkey.ToString()))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.dot_street_light_contract_area))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.segment_id))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.segment_len))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.physical_id))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.generic_id))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.loc_status))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.bike_lane2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.bike_traffic_direction))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.No_Parking_lanes))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.Total_Lanes))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.traffic_direction))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.segment_type))
        oxw.WriteEndElement()
        'TODO: Low End Cross Streets (Offlien B7SC/Name)
#End Region

#Region "Geo Information Right Column"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.from_node))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.from_x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.from_y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.from_latitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.from_longitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.to_node))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.to_x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.to_y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.to_latitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.to_longitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.roadway_type))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.street_width))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.st_width_max))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.No_Traveling_lanes))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.curve_flag))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_of_way_type))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.feature_type))
        oxw.WriteEndElement()
        'TODO: High End Cross Streets (Offline B7SC/Name)
#End Region

#Region "Left Side of Street Information (Left Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.comdist.district_number))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.lhnd))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.hhnd))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.zip_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.school_dist))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.police_patrol_boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.police_pct))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.health_area.Substring(0, 2) + "." + mywa2f3.wa2f3x.left_side.health_area.Substring(2, 2)))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_health_center_dist))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.left_side.nta + ": " + mywa2f3xas.wa2f3x.nta_name_left))
        oxw.WriteEndElement()

#End Region

#Region "Left Side Of Street Information (Right Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.census_tract_2010))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.census_block_2010))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.left_side.dynamic_block))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.census_tract_2000))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.census_block_2000))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.left_side.iaei))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.fire_div))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.fire_bat))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_side.fire_co_type + " " + mywa2f3.wa2f3x.left_side.fire_co_num))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.left_blockface_id))
        oxw.WriteEndElement()

#End Region

#Region "Right Side Of Street Information (Left Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.comdist.district_number))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.lhnd))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.hhnd))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.zip_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.school_dist))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.police_patrol_boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.police_pct))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.health_area.Substring(0, 2) + "." + mywa2f3.wa2f3x.right_side.health_area.Substring(2, 2)))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_health_center_dist))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.right_side.nta + ": " + mywa2f3xas.wa2f3x.nta_name_right))
        oxw.WriteEndElement()

#End Region

#Region "Right Side Of Street Information (Right Column)"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.census_tract_2010))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.census_block_2010))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.right_side.dynamic_block))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.census_tract_2000))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.census_block_2000))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3xas.wa2f3x.right_side.iaei))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.fire_div))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.fire_bat))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_side.fire_co_type + " " + mywa2f3.wa2f3x.right_side.fire_co_num))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f3.wa2f3x.right_blockface_id))
        oxw.WriteEndElement()

#End Region
        'End the row by writing to excel
        oxw.WriteEndElement()

    End Sub

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
        oxw.WriteElement(New CellValue("Input Borough 1"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Input Street 1"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Input Borough 2"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Input Street 2"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Input Borough 3"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Input Street 3"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Campus Direction"))
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
        oxw.WriteElement(New CellValue(mywa1.in_boro1))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_stname1))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_boro2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_stname2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_boro3))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_stname3))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.in_compass_dir))
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

    Private Function GetStreetCode(myB10sc As B10sc, mylgc As [String]) As String
        Return myB10sc.boro.Trim().TrimStart("0"c) + myB10sc.sc5.Trim() + mylgc
    End Function

    Private Function CheckGeoX(inputvalue As String) As String
        Dim rx As New Regex("^[0-9a-zA-Z\s'?!;,:\-()\.\&\/]+$")
        Dim mch As Match = rx.Match(inputvalue)

        Dim outputvalue As String = ""

        If mch.Success Then
            outputvalue = inputvalue
        Else
            outputvalue = ""
        End If

        Return outputvalue
    End Function

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
