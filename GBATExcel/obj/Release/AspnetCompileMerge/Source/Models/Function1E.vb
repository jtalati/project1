Imports DCP.Geosupport.DotNet.GeoX
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Class Function1E

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
    Dim mywa1_stname As New Wa1
    Dim mywa2f1ex As New Wa2F1ex

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

            mywa1.in_func_code = "1E"
            mywa1.in_platform_ind = "C"
            mywa1.in_mode_switch = "X"

            mygeo.GeoCall(mywa1, mywa2f1ex)

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

#Region "Orientation Left Column"

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

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Community District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Lion Face Code"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Lion Sequence Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Street Code B10SC"))
        oxw.WriteEndElement()

        If (String.IsNullOrEmpty(mywa2f1ex.alx)) Then
            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("Alley/Cross Street Flag"))
            oxw.WriteEndElement()
        Else
            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("Alley/Cross Street Flag"))
            oxw.WriteEndElement()
        End If

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Traffic Direction"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Coincident Segment Count"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment Type"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("2010 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("2010 Census Block"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Number Of Park Lanes"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Number of Travel Lanes"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Total Number of Lanes"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Atomic Polygon"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("2000 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("2000 Census Block"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("CD Eligibility"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Curve Flag"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Zip Code/USPS Preferred City Name"))
        oxw.WriteEndElement()

        Dim the_b5sc = mywa1.out_b10sc1.sc5.ToString()
        Dim the_boro = mywa1.out_b10sc1.boro.ToString()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DCP Preferred B7SC/Street Name"))
        oxw.WriteEndElement()

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
        oxw.WriteElement(New CellValue("To Node"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("To X Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("To Y Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment From Node"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment From X Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment From Y Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment To Node"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment To X Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment To Y Coordinate"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Segment ID/Length"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Feature Type"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Roadway Type"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Right Of Way Type"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Bike Lane"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Bike Lane Traffic Direction"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Street Width Min/Max"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Physical Id"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Generic Id"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Block Face ID"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Special Address"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Low house Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("High house Number"))
        oxw.WriteEndElement()

#End Region

#Region "City Service"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Police Patrol Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Police Precinct"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Fire Division"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Fire Battalion"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Fire Company"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Health Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Health Center District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DOT Street Light Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("School District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Neighborhood Tabulation Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanitatation District/Section"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanitation Subsection"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Regular Sanitation Pickup"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Recycling Sanitation Pickup"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Organics Recycling Pickup"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanitation Bulk Pickup"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DSNY Snow Priority"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Hurricane Evac Zone"))
        oxw.WriteEndElement()

#End Region

#Region "Political Information"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("City Council District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Assembly District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Congressional District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("BOE Preferred B7SC/Street Name"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Municipal Court District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Election District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("State Senate District"))
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
        oxw.WriteElement(New CellValue(mywa2f1ex.x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.latitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.longitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.com_dist.boro + mywa2f1ex.com_dist.district_number))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.lion_key.face_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.lion_key.sequence_number))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_b10sc1.B10scToString()))
        oxw.WriteEndElement()

        If (String.IsNullOrEmpty(mywa2f1ex.alx)) Then
            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue("None"))
            oxw.WriteEndElement()
        Else
            oxw.WriteStartElement(Cell, oxa)
            oxw.WriteElement(New CellValue(mywa2f1ex.alx))
            oxw.WriteEndElement()
        End If

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.traffic_dir))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.coincident_seg_cnt))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.segment_type))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.census_tract_2010))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.census_block_2010))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.No_Parking_lanes))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.No_Traveling_lanes))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.No_Total_Lanes))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.dynamic_block))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.census_tract_2000))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.census_block_2000))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.res_gss))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.curve_flag))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.zip_code + " / " + mywa2f1ex.USPS_city_name))
        oxw.WriteEndElement()

        Dim the_b5sc = mywa1.out_b10sc1.sc5.ToString()
        Dim the_boro = mywa1.out_b10sc1.boro.ToString()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(the_boro + the_b5sc + mywa2f1ex.dcp_pref_lgc + " / " + GetStreetNameDG(the_boro, the_b5sc, mywa2f1ex.dcp_pref_lgc)))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.from_node))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.lo_x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.lo_y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.to_node))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.hi_x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.hi_y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.seg_from_node))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.seg_from_x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.seg_from_y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.seg_to_node))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.seg_to_x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.seg_to_y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.segment_id + " / " + mywa2f1ex.segment_len))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.feature_type))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.roadway_type))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.right_of_way_type))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.bike_lane2))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.bike_traffic_direction))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.street_width + ", " + mywa2f1ex.st_width_max))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.physical_id))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.generic_id))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.blockface_id))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.spec_addr_flag))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.lo_hns))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.hi_hns))
        oxw.WriteEndElement()

#End Region

#Region "City Service"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.police_patrol_boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.police_pct))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.fire_div))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.fire_bat))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.fire_co_type + " " + mywa2f1ex.fire_co_num))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.health_area.Substring(0, 2) + "." + mywa2f1ex.health_area.Substring(2, 2)))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.health_center_dist))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.dot_st_light_contract_area))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.school_dist))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.nta.ToString() + " / " + mywa2f1ex.nta_name.ToString()))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.san_dist + " / " + mywa2f1ex.san_dist.Remove(0, 1) + mywa2f1ex.san_sched.Remove(1)))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.san_sched.ToString()))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.san_reg))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.san_recycle))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.san_org_pick_up))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.san_bulk))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.dsny_snow_priority))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.hurricane_zone))
        oxw.WriteEndElement()

#End Region

#Region "Political Information"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.co))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.ad))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.cd))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.boe_preferred_b7sc.ToString() + " / " + mywa2f1ex.boe_preferred_stname.ToString()))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.mc))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.ed))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f1ex.sd))
        oxw.WriteEndElement()

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

    Function GetStreetNameDG(the_boro As [String], the_sc5 As [String], mylgc As [String]) As String
        Dim mywa1_dg As New Wa1()

        mywa1_dg.in_func_code = "DG"
        mywa1_dg.in_platform_ind = "C"

        mywa1_dg.in_b10sc1.boro = the_boro
        mywa1_dg.in_b10sc1.sc5 = the_sc5
        mywa1_dg.in_b10sc1.lgc = mylgc

        mygeo.GeoCall(mywa1_dg)

        Return mywa1_dg.out_stname1

    End Function

    Function GetStreetName(borough_code As String, street_code As String) As String

        Dim fdgeo As New geo()
        Dim fdconn As New GeoConn()
        Dim fdconns As New GeoConnCollection()
        Dim mywa1 As New Wa1()

        mywa1.Clear()
        mywa1.in_func_code = "D"
        mywa1.in_platform_ind = "C"
        mywa1.in_b10sc1.boro = borough_code.ToString()
        mywa1.in_b10sc1.sc5 = street_code
        fdgeo.GeoCall(mywa1)

        Return mywa1.out_stname1

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
