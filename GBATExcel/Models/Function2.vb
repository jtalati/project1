Imports DCP.Geosupport.DotNet.GeoX
Imports DocumentFormat.OpenXml
Imports DocumentFormat.OpenXml.Packaging
Imports DocumentFormat.OpenXml.Spreadsheet

Public Class Function2

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
    Dim normalizedStreets = System.Web.HttpContext.Current.Session("normalizedStreets")
    Dim normalizedStreets2 = System.Web.HttpContext.Current.Session("normalizedStreets2")
    Dim normalizedBoroughs2 = System.Web.HttpContext.Current.Session("normalizedBoroughs2")

    Dim mywa1 As New Wa1
    Dim mywa1_stname As New Wa1
    Dim mywa2f2 As New Wa2F2
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
                    ElseIf col.Key = "Compass Direction 1" Then
                        mywa1.in_compass_dir = col.Value(index)
                    End If
                End If
            Next

            mywa1.in_func_code = "2"
            mywa1.in_platform_ind = "C"
            mywa1.in_xstreet_names_flag = "E"

            mygeo.GeoCall(mywa1, mywa2f2)


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
        oxw.WriteElement(New CellValue("Zip Code"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("X Coordinates"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Y Coordinates"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Community District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Compass Direction"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Latitude"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Longitude"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("LION Node Number"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DCP Preferred B7SC/Street Name for Street 1"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DCP Preferred B7SC/Street Name for Street 2"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("2010 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("2000 Census Tract"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanborn 1 Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanborn 1 Volume"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanborn 1 Page"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanborn 2 Borough"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanborn 2 Volume"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanborn 2 Page"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Atomic Polygon"))
        oxw.WriteEndElement()

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
        oxw.WriteElement(New CellValue("School District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Health Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Health Center District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanitation District/Section"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Sanitation Subsection"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("DOT Street Light Area"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("CD Eligibility"))
        oxw.WriteEndElement()

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
        oxw.WriteElement(New CellValue("Municipal Court District"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("State Senate District"))
        oxw.WriteEndElement()

        oxw.WriteEndElement()

        Return oxw

    End Function

    Function PopulateExcelDataManual(id As Integer, oxw As OpenXmlWriter, index As Integer)

        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("r", Nothing, "A2"))
        oxw.WriteStartElement(New Row(), oxa)

        oxa = New List(Of OpenXmlAttribute)()
        oxa.Add(New OpenXmlAttribute("t", Nothing, "str"))

        Dim Cell = New Cell()

        Dim wa1_ap As New Wa1
        Dim Wa2F2w As New Wa2F2w

        wa1_ap.Clear()
        wa1_ap.in_func_code = "2w"
        wa1_ap.in_platform_ind = "C"
        wa1_ap.in_mode_switch = "E"

        Function2(mywa1.in_boro1, mywa1.in_stname1, mywa1.in_boro2, mywa1.in_stname2)

        mygeo.GeoCall(wa1_ap, Wa2F2w)

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
            ElseIf colName = "Normalized Street" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedStreets(index)))
                oxw.WriteEndElement()
            ElseIf colName = "Normalized Street 2" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedStreets2(index)))
                oxw.WriteEndElement()
            ElseIf colName = "Normalized Borough 2" Then
                oxw.WriteStartElement(Cell, oxa)
                oxw.WriteElement(New CellValue(normalizedBoroughs2(index)))
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
        oxw.WriteElement(New CellValue(mywa2f2.zip_code))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.x_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.y_coord))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.com_dist.boro + mywa2f2.com_dist.district_number))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.compass))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.latitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2fapx.latitude))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.lion_node_num))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_b10sc1.boro + mywa1.out_b10sc1.sc5 + mywa2f2.dcp_pref_lgc1 + "/ " + mywa1.in_stname1))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa1.out_b10sc2.boro + mywa1.out_b10sc2.sc5 + mywa2f2.dcp_pref_lgc2 + "/ " + mywa1.in_stname2))
        oxw.WriteEndElement()

#End Region

#Region "Geo Information Right Column"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.census_tract_2010))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.census_tract_2000))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.sanborn1.boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.sanborn1.volume + ", " + mywa2f2.sanborn1.volume_suffix))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.sanborn1.page + ", " + mywa2f2.sanborn1.page_suffix))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.sanborn2.boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.sanborn2.volume + ", " + mywa2f2.sanborn2.volume_suffix))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.sanborn2.page + ", " + mywa2f2.sanborn2.page_suffix))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.atomic_polygon))
        oxw.WriteEndElement()

#End Region

#Region "City Service Information Left Column"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.police_patrol_boro))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.police_pct))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.fire_div))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.fire_bat))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.fire_co_type + " " + mywa2f2.fire_co_num))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.school_dist))
        oxw.WriteEndElement()

#End Region

#Region "Ciy Service Information Right Column"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.health_area))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.health_center_dist))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue((Wa2F2w.wa2f2.san_dist + "/ " + (Wa2F2w.wa2f2.san_dist.Substring(1, 2) + Wa2F2w.wa2f2.san_sub_section.Substring(0, 1)))))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.san_sub_section))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.dot_st_light_contract_area))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.cd_eligible))
        oxw.WriteEndElement()

#End Region

#Region "Political Information"

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.co))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.ad))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.cd))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.mc))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue(mywa2f2.sd))
        oxw.WriteEndElement()

#End Region

        oxw.WriteEndElement()

    End Function

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

        '2. Write to cell
        Dim Cell = New Cell()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("ID"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("In Function"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Borough 1"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Street 1"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Borough 2"))
        oxw.WriteEndElement()

        oxw.WriteStartElement(Cell, oxa)
        oxw.WriteElement(New CellValue("Street 2"))
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

    Function PopulateGeoXDictionary(mywa1 As Wa1, mywa2f2 As Wa2F2, wa2fapx As Wa2F2w)

        Dim allValuesForSelectedFields As New Dictionary(Of String, String)

#Region "Geo Information Left Column"

        allValuesForSelectedFields.Add("Zip Code", mywa2f2.zip_code)
        allValuesForSelectedFields.Add("X,Y Coordinates", mywa2f2.x_coord + ", " + mywa2f2.y_coord)
        allValuesForSelectedFields.Add("Community District", mywa2f2.com_dist.boro + mywa2f2.com_dist.district_number)
        allValuesForSelectedFields.Add("Compass Direction", mywa2f2.compass)
        allValuesForSelectedFields.Add("Latitude, Longitude", wa2fapx.latitude + ", " + wa2fapx.longitude)
        allValuesForSelectedFields.Add("LION Node Number", mywa2f2.lion_node_num)

        allValuesForSelectedFields.Add("DCP Preferred B7SC/Street Name for Street 1", mywa1.out_b10sc1.boro + mywa1.out_b10sc1.sc5 + mywa2f2.dcp_pref_lgc1 + "/ " + mywa1.in_stname1)
        allValuesForSelectedFields.Add("DCP Preferred B7SC/Street Name for Street 2", mywa1.out_b10sc2.boro + mywa1.out_b10sc2.sc5 + mywa2f2.dcp_pref_lgc2 + "/ " + mywa1.in_stname2)

#End Region

#Region "Geo Information Right Column"

        allValuesForSelectedFields.Add("2010 Census Tract", mywa2f2.census_tract_2010)
        allValuesForSelectedFields.Add("2000 Census Tract", mywa2f2.census_tract_2000)
        allValuesForSelectedFields.Add("Sanborn 1 Boro/Vol/Page", mywa2f2.sanborn1.boro + ", " + mywa2f2.sanborn1.volume + ", " + mywa2f2.sanborn1.volume_suffix + ", " + mywa2f2.sanborn1.page + ", " + mywa2f2.sanborn1.page_suffix)
        allValuesForSelectedFields.Add("Sanborn 2 Boro/Vol/Page", mywa2f2.sanborn2.boro + ", " + mywa2f2.sanborn2.volume + ", " + mywa2f2.sanborn2.volume_suffix + ", " + mywa2f2.sanborn2.page + ", " + mywa2f2.sanborn2.page_suffix)
        allValuesForSelectedFields.Add("Atomic Polygon", mywa2f2.atomic_polygon)

#End Region

#Region "City Service Information Left Column"

        allValuesForSelectedFields.Add("Police Patrol Borough", mywa2f2.police_patrol_boro)
        allValuesForSelectedFields.Add("Police Precinct", mywa2f2.police_pct)
        allValuesForSelectedFields.Add("Fire Division", mywa2f2.fire_div)
        allValuesForSelectedFields.Add("Fire Battalion", mywa2f2.fire_bat)
        allValuesForSelectedFields.Add("Fire Company", mywa2f2.fire_co_type + " " + mywa2f2.fire_co_num)
        allValuesForSelectedFields.Add("School District", mywa2f2.school_dist)

#End Region


#Region "Ciy Service Information Right Column"

        allValuesForSelectedFields.Add("Health Area", mywa2f2.health_area)
        allValuesForSelectedFields.Add("Health Center District", mywa2f2.health_center_dist)
        allValuesForSelectedFields.Add("Sanitation District/Section", wa2fapx.wa2f2.san_dist + "/ " + wa2fapx.wa2f2.san_dist.Substring(1, 2) + wa2fapx.wa2f2.san_sub_section.Substring(0, 1))
        allValuesForSelectedFields.Add("Sanitation Subsection", mywa2f2.san_sub_section)
        allValuesForSelectedFields.Add("DOT Street Light Area", mywa2f2.dot_st_light_contract_area)
        allValuesForSelectedFields.Add("CD Eligibility", mywa2f2.cd_eligible)

#End Region

#Region "Political Information"

        allValuesForSelectedFields.Add("City Council District", mywa2f2.co)
        allValuesForSelectedFields.Add("Assembly District", mywa2f2.ad)
        allValuesForSelectedFields.Add("Congressional District", mywa2f2.cd)
        allValuesForSelectedFields.Add("Municipal Court District", mywa2f2.mc)
        allValuesForSelectedFields.Add("State Senate District", mywa2f2.sd)

#End Region


        Return allValuesForSelectedFields
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

    Private Function Function2(boro1 As String, street1 As String, boro2 As String, street2 As String) As Wa2F2w
        Dim wa2f2w As New Wa2F2w()
        Dim wa1 As New Wa1()

        wa1.in_boro1 = boro1
        wa1.in_stname1 = street1
        wa1.in_boro2 = boro2
        wa1.in_stname2 = street2

        'mywa1.in_mode_switch = "X";
        wa1.in_func_code = "2w"
        wa1.in_platform_ind = "C"
        'mywa1.in_tpad_switch = "Y";
        wa1.in_xstreet_names_flag = "E"
        mygeo.GeoCall(wa1, wa2f2w)
        Return wa2f2w
    End Function
End Class