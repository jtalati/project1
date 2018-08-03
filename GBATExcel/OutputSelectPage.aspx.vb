Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports DCP.Geosupport.DotNet.GeoX

Public Class WebForm2
    Inherits System.Web.UI.Page

    Dim dt As DataSet
    Dim filePathData As String
    Dim filePathError As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Session("includeNormalizedInputs") = False
            If Session("Filename1") = "" Then
                Response.Redirect("UploadFile.aspx")
            Else

                If Session("resultsPageVisited") = True Then

                    Session("containsListBox2Item").Clear()
                    Session("containsListBox4Item").Clear()
                    Session("containsListBox6Item").Clear()
                    Session("containsListBox8Item").Clear()
                    Session("containsListBox10Item").Clear()
                    Session("userInputDictionary").Clear()

                    Dim rng As New Random
                    Dim number As Integer = rng.Next(1, 100000)
                    Dim digits As String = number.ToString("000000")
                    Dim fileName1 As String = "WorkBook" + digits + ".xlsx"
                    Dim fileName2 As String = "WorkBook" + digits + "XML" + ".xlsx"
                    Dim fileName3 As String = "WorkBook" + digits + "Error" + ".xlsx"

                    filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
                    filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString

                    My.Computer.FileSystem.DeleteFile(filePathData)
                    My.Computer.FileSystem.DeleteFile(filePathError)

                    Session("Filename1") = fileName1
                    Session("Filename2") = fileName2
                    Session("Filename3") = fileName3

                    Session("FileUpload1").SaveAs(Path.Combine(Session("savedPath"), fileName1))
                    Session("FileUpload1").SaveAs(Path.Combine(Session("savedPath"), fileName2))

                End If

                Session("outputSelectBackButtonFlag") = False
                If Session("Flag") = "1B" Then
                    addListBoxItemsOfFunction1B()
                ElseIf Session("Flag") = "1A" Then
                    addListBoxItemsOfFunction1A()
                ElseIf Session("Flag") = "1E" Then
                    addListBoxItemsOfFunction1E()
                ElseIf Session("Flag") = "1N" Then
                    addListBoxItemsOfFunction1N()
                ElseIf Session("Flag") = "2" Then
                    addListBoxItemsOfFunction2()
                ElseIf Session("Flag") = "3" Then
                    addListBoxItemsOfFunction3()
                ElseIf Session("Flag") = "3S" Then
                    addListBoxItemsOfFunction3S()
                ElseIf Session("Flag") = "BL" Then
                    addListBoxItemsOfFunctionBL()
                ElseIf Session("Flag") = "BN" Then
                    addListBoxItemsOfFunctionBN()
                ElseIf Session("Flag") = "N" Then
                    addListBoxItemsOfFunctionN()
                ElseIf Session("Flag") = "AP" Then
                    addListBoxItemsOfFunctionAP()
                ElseIf Session("Flag") = "D" Then
                    addListBoxItemsOfFunctionD()
                End If

                hideShowButton()
                addExcelInputsToListBox()
                Session("3SUserInputs").Clear()
                Session("containsListBox2Item").Clear()
                Session("containsListBox4Item").Clear()
                Session("containsListBox6Item").Clear()
                Session("containsListBox8Item").Clear()
                Session("containsListBox10Item").Clear()
                Session("normalizedBoroughs").Clear()
                Session("normalizedBoroughs2").Clear()
                Session("normalizedBoroughs3").Clear()
                Session("normalizedStreets").Clear()
                Session("normalizedStreets2").Clear()
                Session("normalizedStreets3").Clear()
                Session("firstIntersectionSelected") = False
                Session("secondIntersectionSelected") = False
                Session("thirdIntersectionSelected") = False
                Session("fourthIntersectionSelected") = False
                Session("fifthIntersectionSelected") = False
                Session("numOfFeetSelected") = False
                Session("gapFlagSelected") = False
                Session("nodeIDSelected") = False

            End If
        Else

            If Session("resultsPageVisited") = True Then

                Session("containsListBox2Item").Clear()
                Session("containsListBox4Item").Clear()
                Session("containsListBox6Item").Clear()
                Session("containsListBox8Item").Clear()
                Session("containsListBox10Item").Clear()
                Session("userInputDictionary").Clear()

                Dim rng As New Random
                Dim number As Integer = rng.Next(1, 100000)
                Dim digits As String = number.ToString("000000")
                Dim fileName1 As String = "WorkBook" + digits + ".xlsx"
                Dim fileName2 As String = "WorkBook" + digits + "XML" + ".xlsx"
                Dim fileName3 As String = "WorkBook" + digits + "Error" + ".xlsx"

                filePathData = "C:\ExcelFiles\" + Session("Filename2").ToString
                filePathError = "C:\ExcelFiles\" + Session("Filename1").ToString

                My.Computer.FileSystem.DeleteFile(filePathData)
                My.Computer.FileSystem.DeleteFile(filePathError)

                Session("Filename1") = fileName1
                Session("Filename2") = fileName2
                Session("Filename3") = fileName3

                Session("FileUpload1").SaveAs(Path.Combine(Session("savedPath"), fileName1))
                Session("FileUpload1").SaveAs(Path.Combine(Session("savedPath"), fileName2))

            End If
        End If

        dt = Session("TaskTable")

        If Session("flag") = "BN" Then
            CheckBox1.Visible = False
        End If

        If Session("flag") = "N" Then
            CheckBox1.Visible = False
        End If

        If Session("flag") = "D" Then
            CheckBox1.Visible = False
        End If

        Session("3SErrors") = 0

    End Sub

    Sub PopulateFunctionInputs()
        Dim dictionary As New Dictionary(Of String, ArrayList)
        'Dim dt As DataSet = Session("TaskTable")
        Dim AllData = dt.Tables(0)
        Dim userSelectedCol = Session("UserSelectedCol")

        For Each col As KeyValuePair(Of String, Integer) In userSelectedCol
            Dim key = col.Key
            Dim colValuesList As New ArrayList
            Dim userCol = AllData.Columns(col.Value)
            Dim rowCount = AllData.Columns(col.Value).Table.Rows.Count

            If key = "Borough" Or key = "Borough 1" Then
                For index = 0 To rowCount - 1 'dataTable.Rows.Count - 1
                    Dim rows = userCol.Table.Rows

                    If Not IsDBNull(rows(index)(col.Value)) Then

                        'colValuesList.Add(userCol(index))
                        If (rows(index)(col.Value).ToUpper = "MANHATTAN") Or (rows(index)(col.Value).ToUpper = "MAN") Then
                            colValuesList.Add(1.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "QUEENS") Or (rows(index)(col.Value).ToUpper = "Queens") Then
                            colValuesList.Add(4.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "STATEN ISLAND") Or (rows(index)(col.Value).ToUpper = "SI") Then
                            colValuesList.Add(5.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "BRONX") Or (rows(index)(col.Value).ToUpper = "BX") Then
                            colValuesList.Add(2.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "BROOKLYN") Or (rows(index)(col.Value).ToUpper = "BK") Then
                            colValuesList.Add(3.ToString)
                        Else
                            colValuesList.Add(rows(index)(col.Value))
                        End If

                        If CheckBox1.Checked = True Then
                            If (rows(index)(col.Value).ToUpper = "1") Then
                                Session("normalizedBoroughs").Add("Manhattan")
                            ElseIf (rows(index)(col.Value).ToUpper = "2") Then
                                Session("normalizedBoroughs").Add("Bronx")
                            ElseIf (rows(index)(col.Value).ToUpper = "3") Then
                                Session("normalizedBoroughs").Add("Brooklyn")
                            ElseIf (rows(index)(col.Value).ToUpper = "4") Then
                                Session("normalizedBoroughs").Add("Queens")
                            ElseIf (rows(index)(col.Value).ToUpper = "5") Then
                                Session("normalizedBoroughs").Add("Staten Island")
                            Else
                                Session("normalizedBoroughs").Add(rows(index)(col.Value))
                            End If
                        End If
                    Else
                        If CheckBox1.Checked = True Then
                            Session("normalizedBoroughs").Add("")
                        End If
                        colValuesList.Add(rows(index)(col.Value))
                    End If
                Next


            ElseIf key = "Borough 2" Then

                For index = 0 To rowCount - 1 'dataTable.Rows.Count - 1
                    Dim rows = userCol.Table.Rows

                    If Not IsDBNull(rows(index)(col.Value)) Then

                        If (rows(index)(col.Value).ToUpper = "MANHATTAN") Or (rows(index)(col.Value).ToUpper = "MAN") Then
                            colValuesList.Add(1.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "QUEENS") Or (rows(index)(col.Value).ToUpper = "Queens") Then
                            colValuesList.Add(4.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "STATEN ISLAND") Or (rows(index)(col.Value).ToUpper = "SI") Then
                            colValuesList.Add(5.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "BRONX") Or (rows(index)(col.Value).ToUpper = "BX") Then
                            colValuesList.Add(2.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "BROOKLYN") Or (rows(index)(col.Value).ToUpper = "BK") Then
                            colValuesList.Add(3.ToString)
                        Else
                            colValuesList.Add(rows(index)(col.Value))
                        End If

                        If CheckBox1.Checked = True Then
                            If (rows(index)(col.Value).ToUpper = "1") Then
                                Session("normalizedBoroughs2").Add("Manhattan")
                            ElseIf (rows(index)(col.Value).ToUpper = "2") Then
                                Session("normalizedBoroughs2").Add("Bronx")
                            ElseIf (rows(index)(col.Value).ToUpper = "3") Then
                                Session("normalizedBoroughs2").Add("Brooklyn")
                            ElseIf (rows(index)(col.Value).ToUpper = "4") Then
                                Session("normalizedBoroughs2").Add("Queens")
                            ElseIf (rows(index)(col.Value).ToUpper = "5") Then
                                Session("normalizedBoroughs2").Add("Staten Island")
                            End If
                        End If
                    Else
                        If CheckBox1.Checked = True Then
                            Session("normalizedBoroughs2").Add("")
                        End If
                        colValuesList.Add(rows(index)(col.Value))
                    End If
                Next

            ElseIf key = "Borough 3" Then

                For index = 0 To rowCount - 1 'dataTable.Rows.Count - 1
                    Dim rows = userCol.Table.Rows
                    If Not IsDBNull(rows(index)(col.Value)) Then
                        'colValuesList.Add(userCol(index))
                        If (rows(index)(col.Value).ToUpper = "MANHATTAN") Or (rows(index)(col.Value).ToUpper = "MAN") Then
                            colValuesList.Add(1.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "QUEENS") Or (rows(index)(col.Value).ToUpper = "Queens") Then
                            colValuesList.Add(4.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "STATEN ISLAND") Or (rows(index)(col.Value).ToUpper = "SI") Then
                            colValuesList.Add(5.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "BRONX") Or (rows(index)(col.Value).ToUpper = "BX") Then
                            colValuesList.Add(2.ToString)
                        ElseIf (rows(index)(col.Value).ToUpper = "BROOKLYN") Or (rows(index)(col.Value).ToUpper = "BK") Then
                            colValuesList.Add(3.ToString)
                        Else
                            colValuesList.Add(rows(index)(col.Value))
                        End If

                        If CheckBox1.Checked = True Then
                            If (rows(index)(col.Value).ToUpper = "1") Then
                                Session("normalizedBoroughs3").Add("Manhattan")
                            ElseIf (rows(index)(col.Value).ToUpper = "2") Then
                                Session("normalizedBoroughs3").Add("Bronx")
                            ElseIf (rows(index)(col.Value).ToUpper = "3") Then
                                Session("normalizedBoroughs3").Add("Brooklyn")
                            ElseIf (rows(index)(col.Value).ToUpper = "4") Then
                                Session("normalizedBoroughs3").Add("Queens")
                            ElseIf (rows(index)(col.Value).ToUpper = "5") Then
                                Session("normalizedBoroughs3").Add("Staten Island")
                            End If
                        End If
                    Else
                        If CheckBox1.Checked = True Then
                            Session("normalizedBoroughs3").Add("")
                        End If
                        colValuesList.Add(rows(index)(col.Value))
                    End If
                Next

            ElseIf key = "Street" Or key = "Street 1" Or key = "On Street" Then

                For index = 0 To rowCount - 1 'dataTable.Rows.Count - 1
                    Dim rows = userCol.Table.Rows
                    If Not IsDBNull(rows(index)(col.Value)) Then
                        If CheckBox1.Checked = True Then

                            Dim mygeo As New geo
                            Dim mywa1 As New Wa1
                            mywa1.in_stname1 = rows(index)(col.Value)
                            mywa1.in_func_code = "N*"
                            mygeo.GeoCall(mywa1)

                            Session("normalizedStreets").Add(mywa1.out_stname1)
                        End If

                        colValuesList.Add(rows(index)(col.Value))
                    Else
                        If CheckBox1.Checked = True Then
                            Session("normalizedStreets").Add("")
                        End If
                        colValuesList.Add(rows(index)(col.Value))
                    End If

                Next

            ElseIf key = "Street 2" Then

                For index = 0 To rowCount - 1 'dataTable.Rows.Count - 1
                    Dim rows = userCol.Table.Rows
                    If Not IsDBNull(rows(index)(col.Value)) Then
                        If CheckBox1.Checked = True Then

                            Dim mygeo As New geo
                            Dim mywa1 As New Wa1
                            mywa1.in_stname1 = rows(index)(col.Value)
                            mywa1.in_func_code = "N*"
                            mygeo.GeoCall(mywa1)

                            Session("normalizedStreets2").Add(mywa1.out_stname1)
                        End If

                        colValuesList.Add(rows(index)(col.Value))
                    Else
                        If CheckBox1.Checked = True Then
                            Session("normalizedStreets2").Add("")
                        End If
                        colValuesList.Add(rows(index)(col.Value))
                    End If
                Next

            ElseIf key = "Street 3" Then

                For index = 0 To rowCount - 1 'dataTable.Rows.Count - 1
                    Dim rows = userCol.Table.Rows
                    If Not IsDBNull(rows(index)(col.Value)) Then
                        If CheckBox1.Checked = True Then

                            Dim mygeo As New geo
                            Dim mywa1 As New Wa1
                            mywa1.in_stname1 = rows(index)(col.Value)
                            mywa1.in_func_code = "N*"
                            mygeo.GeoCall(mywa1)

                            Session("normalizedStreets3").Add(mywa1.out_stname1)
                        Else
                            If CheckBox1.Checked = True Then
                                Session("normalizedStreets3").Add("")
                            End If
                        End If

                        colValuesList.Add(rows(index)(col.Value))

                    End If
                Next

            Else
                For index2 = 0 To rowCount - 1 'dataTable.Rows.Count - 1
                    Dim rows2 = userCol.Table.Rows
                    '  If Not IsDBNull(rows2(index2)(col.Value)) Then
                    colValuesList.Add(rows2(index2)(col.Value))
                    ' End If
                Next

            End If

            dictionary.Add(key, colValuesList)

        Next

        Session("userInputDictionary") = dictionary
    End Sub

#Region "Handle GUI Processing"

    Protected Sub AddOneButton0_Click(sender As Object, e As EventArgs) Handles AddOneButton0.Click
        If (ListBox1.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = ListBox1.SelectedItem
            ListBox1.Items.Remove(item)
            lbxOut1.SelectedIndex = -1
            lbxOut1.Items.Add(item)
        End If
    End Sub

    Protected Sub RemoveOneButton0_Click(sender As Object, e As EventArgs) Handles RemoveOneButton0.Click
        If (lbxOut1.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = lbxOut1.SelectedItem
            lbxOut1.Items.Remove(item)
            ListBox1.SelectedIndex = -1
            ListBox1.Items.Add(item)
        End If
    End Sub

    Protected Sub AddAllButton_Click(sender As Object, e As EventArgs) Handles AddAllButton.Click
        For i = 0 To ListBox1.Items.Count - 1
            lbxOut1.Items.Add(ListBox1.Items(i).ToString)
        Next
        ListBox1.Items.Clear()
    End Sub

    Protected Sub RemoveAllButton0_Click(sender As Object, e As EventArgs) Handles RemoveAllButton0.Click
        For i = 0 To lbxOut1.Items.Count - 1
            ListBox1.Items.Add(lbxOut1.Items(i).ToString)
        Next
        lbxOut1.Items.Clear()
    End Sub

    Protected Sub AddOneButton2_Click(sender As Object, e As EventArgs) Handles AddOneButton2.Click
        If (ListBox3.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = ListBox3.SelectedItem
            ListBox3.Items.Remove(item)
            lbxOut2.SelectedIndex = -1
            lbxOut2.Items.Add(item)
        End If
    End Sub

    Protected Sub RemoveOneButton3_Click(sender As Object, e As EventArgs) Handles RemoveOneButton3.Click
        If (lbxOut2.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = lbxOut2.SelectedItem
            lbxOut2.Items.Remove(item)
            ListBox3.SelectedIndex = -1
            ListBox3.Items.Add(item)
        End If
    End Sub

    Protected Sub AddAllButton1_Click(sender As Object, e As EventArgs) Handles AddAllButton1.Click
        For i = 0 To ListBox3.Items.Count - 1
            lbxOut2.Items.Add(ListBox3.Items(i).ToString)
        Next
        ListBox3.Items.Clear()
    End Sub

    Protected Sub RemoveAllButton_Click(sender As Object, e As EventArgs) Handles RemoveAllButton.Click
        For i = 0 To lbxOut2.Items.Count - 1
            ListBox3.Items.Add(lbxOut2.Items(i).ToString)
        Next
        lbxOut2.Items.Clear()
    End Sub

    Protected Sub AddOneButton4_Click(sender As Object, e As EventArgs) Handles AddOneButton4.Click
        If (ListBox5.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = ListBox5.SelectedItem
            ListBox5.Items.Remove(item)
            lbxOut3.SelectedIndex = -1
            lbxOut3.Items.Add(item)
        End If
    End Sub

    Protected Sub RemoveOneButton2_Click(sender As Object, e As EventArgs) Handles RemoveOneButton2.Click
        If (lbxOut3.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = lbxOut3.SelectedItem
            lbxOut3.Items.Remove(item)
            ListBox5.SelectedIndex = -1
            ListBox5.Items.Add(item)
        End If
    End Sub

    Protected Sub AddAllButton2_Click(sender As Object, e As EventArgs) Handles AddAllButton2.Click
        For i = 0 To ListBox5.Items.Count - 1
            lbxOut3.Items.Add(ListBox5.Items(i).ToString)
        Next
        ListBox5.Items.Clear()
    End Sub

    Protected Sub RemoveAllButton1_Click(sender As Object, e As EventArgs) Handles RemoveAllButton1.Click
        For i = 0 To lbxOut3.Items.Count - 1
            ListBox5.Items.Add(lbxOut3.Items(i).ToString)
        Next
        lbxOut3.Items.Clear()
    End Sub

    Protected Sub AddOneButton3_Click(sender As Object, e As EventArgs) Handles AddOneButton3.Click
        If (ListBox7.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = ListBox7.SelectedItem
            ListBox7.Items.Remove(item)
            lbxOut4.SelectedIndex = -1
            lbxOut4.Items.Add(item)
        End If
    End Sub

    Protected Sub RemoveOneButton4_Click(sender As Object, e As EventArgs) Handles RemoveOneButton4.Click
        If (lbxOut4.SelectedIndex = -1) Then
            RegMsgBox("please Select an item")
        Else
            Dim item As ListItem = lbxOut4.SelectedItem
            lbxOut4.Items.Remove(item)
            ListBox7.SelectedIndex = -1
            ListBox7.Items.Add(item)
        End If
    End Sub

    Protected Sub AddAllButton0_Click(sender As Object, e As EventArgs) Handles AddAllButton0.Click
        For i = 0 To ListBox7.Items.Count - 1
            lbxOut4.Items.Add(ListBox7.Items(i).ToString)
        Next
        ListBox7.Items.Clear()
    End Sub

    Protected Sub RemoveAllButton2_Click(sender As Object, e As EventArgs) Handles RemoveAllButton2.Click
        For i = 0 To lbxOut4.Items.Count - 1
            ListBox7.Items.Add(lbxOut4.Items(i).ToString)
        Next
        lbxOut4.Items.Clear()
    End Sub

    Public Function addListBoxItemsOfFunction1A()

        If Session("Flag") = "1A" Then
            Label1.Text = "Property Level information"
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Tax Block")
            ListBox1.Items.Add("Tax Lot")
            ListBox1.Items.Add("BBL")
            ListBox1.Items.Add("Block Faces")
            ListBox1.Items.Add("Sanborn Boro/Vol/Page")
            ListBox1.Items.Add("RPAD_SCC")
            ListBox1.Items.Add("RPAD_Building_Class")
            ListBox1.Items.Add("RPAD_Interior_Lot")
            ListBox1.Items.Add("RPAD_Irreg._Shaped")
            ListBox1.Items.Add("RPAD_Condo_Number")
            ListBox1.Items.Add("RPAD_Co-op_Number")
            ListBox1.Items.Add("X_Coordinates")
            ListBox1.Items.Add("Y_Coordinates")
            ListBox1.Items.Add("Latitude")
            ListBox1.Items.Add("Longitude")
            ListBox1.Items.Add("Vacant_Lot")
            ListBox1.Items.Add("Condo_Lot")
            ListBox1.Items.Add("Low_BBL_of_Condo")
            ListBox1.Items.Add("High_BBL_of_Condo")
            ListBox1.Items.Add("Tax Map/Section/Volume")
            ListBox1.Items.Add("BIN")
            ListBox1.Items.Add("BIN_Status")
            ListBox1.Items.Add("TPAD_BIN")
            ListBox1.Items.Add("TPAD_BIN_Status")
            ListBox1.Items.Add("TPAD_Conflict_Flag")
            ListBox1.Items.Add("Corner Code")
            ListBox1.Items.Add("Business Improvement District")
            ListBox1.Items.Add("Structures")

            'HideShowButton4.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            'Label4.Visible = False
            ListBox3.Visible = False
            lbxOut2.Visible = False
            ListBox5.Visible = False
            lbxOut3.Visible = False

            lbxOut4.Visible = False
            AddOneButton2.Visible = False
            RemoveOneButton3.Visible = False
            AddAllButton1.Visible = False
            RemoveAllButton.Visible = False
            AddOneButton4.Visible = False
            RemoveOneButton2.Visible = False
            AddAllButton2.Visible = False
            RemoveAllButton1.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            row3.Visible = False
            row4.Visible = False
            row5.Visible = False
            HideShowButton2.Visible = False
            HideShowButton3.Visible = False
            HideShowButton4.Visible = False

        End If
        Return Nothing
    End Function

    Public Function addListBoxItemsOfFunction1E()
        'Function 1E listbox Items
        If Session("Flag") = "1E" Then
            Label1.Text = "Geographic Information"
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("X Coordinate")
            ListBox1.Items.Add("Y Coordinate")
            ListBox1.Items.Add("Latitude")
            ListBox1.Items.Add("Longitude")
            ListBox1.Items.Add("Community District")
            ListBox1.Items.Add("Lion Face Code")
            ListBox1.Items.Add("Lion Sequence Number")
            ListBox1.Items.Add("Street Code B10SC")
            ListBox1.Items.Add("Alley/Cross Street Flag")
            ListBox1.Items.Add("Traffic Direction")
            ListBox1.Items.Add("Coincident Segment Count")
            ListBox1.Items.Add("Segment Type")
            ListBox1.Items.Add("2010 Census Tract")
            ListBox1.Items.Add("2010 Census Block")
            ListBox1.Items.Add("Number Of Park Lanes")
            ListBox1.Items.Add("Number Of Travel Lanes")
            ListBox1.Items.Add("Total Number Of Lanes")
            ListBox1.Items.Add("Atomic Polygon")
            ListBox1.Items.Add("2000 Census Tract")
            ListBox1.Items.Add("2000 Census Block")
            ListBox1.Items.Add("CD Eligibility")
            ListBox1.Items.Add("Curve Flag")
            ListBox1.Items.Add("Zip Code/USPS Preferred City Name")
            ListBox1.Items.Add("DCP Preferred B7SC/Street Name")
            ListBox1.Items.Add("From Node")
            ListBox1.Items.Add("From X Coordinate")
            ListBox1.Items.Add("From Y Coordinate")
            ListBox1.Items.Add("To Node")
            ListBox1.Items.Add("To X Coordinate")
            ListBox1.Items.Add("To Y Coordinate")
            ListBox1.Items.Add("Segment From Node")
            ListBox1.Items.Add("Segment From X Coordinate")
            ListBox1.Items.Add("Segment From Y Coordinate")
            ListBox1.Items.Add("Segment To Node")
            ListBox1.Items.Add("Segment To X Coordinate")
            ListBox1.Items.Add("Segment To Y Coordinate")
            ListBox1.Items.Add("Segment ID/Length")
            ListBox1.Items.Add("Feature Type")
            ListBox1.Items.Add("Roadway Type")
            ListBox1.Items.Add("Right Of Way Type")
            ListBox1.Items.Add("Bike Lane")
            ListBox1.Items.Add("Bike Lane Traffic Direction")
            ListBox1.Items.Add("Street Width Min/Max")
            ListBox1.Items.Add("Physical Id")
            ListBox1.Items.Add("Generic Id")
            ListBox1.Items.Add("Block Face ID")
            ListBox1.Items.Add("Special Address")
            ListBox1.Items.Add("Low house Number")
            ListBox1.Items.Add("High house Number")

            Label2.Text = "City Service Information"
            ListBox3.Items.Add("Police Patrol Borough")
            ListBox3.Items.Add("Police Precinct")
            ListBox3.Items.Add("Fire Division")
            ListBox3.Items.Add("Fire Battalion")
            ListBox3.Items.Add("Fire Company")
            ListBox3.Items.Add("Health Area")
            ListBox3.Items.Add("Health Center District")
            ListBox3.Items.Add("DOT Street Light Area")
            ListBox3.Items.Add("School District")
            ListBox3.Items.Add("Neighborhood Tabulation Area")
            ListBox3.Items.Add("Sanitatation District/Section")
            ListBox3.Items.Add("Sanitation Subsection")
            ListBox3.Items.Add("Regular Sanitation Pickup")
            ListBox3.Items.Add("Recycling Sanitation Pickup")
            ListBox3.Items.Add("Organics Recycling Pickup")
            ListBox3.Items.Add("Sanitation Bulk Pickup")
            ListBox3.Items.Add("DSNY Snow Priority")
            ListBox3.Items.Add("Hurricane Evac Zone")

            Label3.Text = "Political Information"
            ListBox5.Items.Add("City Council District")
            ListBox5.Items.Add("Assembly District")
            ListBox5.Items.Add("Congressional District")
            ListBox5.Items.Add("BOE Preferred B7SC/Street Name")
            ListBox5.Items.Add("Municipal Court District")
            ListBox5.Items.Add("Election District")
            ListBox5.Items.Add("State Senate District")
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            HideShowButton4.Visible = False
            Label4.Visible = False
            ListBox7.Visible = False
            lbxOut4.Visible = False
            row5.Visible = False

        End If
        Return Nothing
    End Function

    Public Function addListBoxItemsOfFunction1B()
        'Function 1B listbox Items
        If Session("Flag") = "1B" Then
            Label1.Text = "Geographic Information"
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Speed Limit")
            ListBox1.Items.Add("DCP Zoning Map")
            ListBox1.Items.Add("X, Y Coordinate")
            ListBox1.Items.Add("Latitude, Longitude")
            ListBox1.Items.Add("Community District")
            ListBox1.Items.Add("Lion Face Code")
            ListBox1.Items.Add("Lion Sequence Number")
            ListBox1.Items.Add("Street Code B10SC")
            ListBox1.Items.Add("Alley/Cross Street Flag")
            ListBox1.Items.Add("Traffic Direction")
            ListBox1.Items.Add("2010 Census Tract")
            ListBox1.Items.Add("2010 Census Block")
            ListBox1.Items.Add("Number Of Park Lanes")
            ListBox1.Items.Add("Number Of Travel Lanes")
            ListBox1.Items.Add("Total Number Of Lanes")
            ListBox1.Items.Add("Atomic Polygon")
            ListBox1.Items.Add("2000 Census Tract")
            ListBox1.Items.Add("2000 Census Block")
            ListBox1.Items.Add("CD Eligibility")
            ListBox1.Items.Add("Curve Flag")
            ListBox1.Items.Add("Zip Code/USPS Preferred City Name")
            ListBox1.Items.Add("DCP Preferred B7SC/Street Name")
            ListBox1.Items.Add("From Node")
            ListBox1.Items.Add("From X/Y Coordinate")
            ListBox1.Items.Add("To Node")
            ListBox1.Items.Add("To X/Y Coordinate")
            ListBox1.Items.Add("Segment From Node")
            ListBox1.Items.Add("Segment From X, Y Coordinate")
            ListBox1.Items.Add("Segment To Node")
            ListBox1.Items.Add("Segment To X,Y Coordinate")
            ListBox1.Items.Add("Coincident Segment Count")
            ListBox1.Items.Add("Segment ID/Length")
            ListBox1.Items.Add("Segment Type")
            ListBox1.Items.Add("Feature Type")
            ListBox1.Items.Add("Roadway Type")
            ListBox1.Items.Add("Right Of Way Type")
            ListBox1.Items.Add("Physical Id")
            ListBox1.Items.Add("Generic Id")
            ListBox1.Items.Add("Bike Lane")
            ListBox1.Items.Add("Bike Lane Traffic Direction")
            ListBox1.Items.Add("Street Width Min/Max")
            ListBox1.Items.Add("Special Address")
            ListBox1.Items.Add("Low house Number")
            ListBox1.Items.Add("High house Number")
            ListBox1.Items.Add("Block Face ID")
            ListBox1.Items.Add("Low End Cross Street(s)")
            ListBox1.Items.Add("High End Cross Street(s)")
            Label2.Text = "City Service Information"
            ListBox3.Items.Add("Police Patrol Borough")
            ListBox3.Items.Add("Police Precinct")
            ListBox3.Items.Add("Fire Division")
            ListBox3.Items.Add("Fire Battalion")
            ListBox3.Items.Add("Fire Company")
            ListBox3.Items.Add("Health Area")
            ListBox3.Items.Add("Health Center District")
            ListBox3.Items.Add("DOT Street Light Area")
            ListBox3.Items.Add("Sanitatation District/Section")
            ListBox3.Items.Add("Sanitation Subsection")
            ListBox3.Items.Add("Regular Sanitation Pickup")
            ListBox3.Items.Add("Recycling Sanitation Pickup")
            ListBox3.Items.Add("Organics Recycling Pickup")
            ListBox3.Items.Add("School District")
            ListBox3.Items.Add("DSNY Snow Priority")
            ListBox3.Items.Add("Hurricane Evac Zone")
            ListBox3.Items.Add("Neighborhood Tabulation Area")
            Label3.Text = "Political Information"
            ListBox5.Items.Add("City Council District")
            ListBox5.Items.Add("Assembly District")
            ListBox5.Items.Add("Congressional District")
            ListBox5.Items.Add("Municipal Court District")
            ListBox5.Items.Add("Election District")
            ListBox5.Items.Add("State Senate District")
            ListBox5.Items.Add("BOE Preferred B7SC/Street Name")
            Label4.Text = "Property Level information"
            ListBox7.Items.Add("Tax Block")
            ListBox7.Items.Add("Tax Lot")
            ListBox7.Items.Add("BBL")
            ListBox7.Items.Add("Block Faces")
            ListBox7.Items.Add("Sanborn Boro/Vol/Page")
            ListBox7.Items.Add("RPAD_SCC")
            ListBox7.Items.Add("RPAD_Building_Class")
            ListBox7.Items.Add("RPAD_Interior_Lot")
            ListBox7.Items.Add("RPAD_Irreg._Shaped")
            ListBox7.Items.Add("RPAD_Condo_Number")
            ListBox7.Items.Add("RPAD_Co-op_Number")
            ListBox7.Items.Add("Vacant_Lot")
            ListBox7.Items.Add("Condo_Lot")
            ListBox7.Items.Add("Low_BBL_of_Condo")
            ListBox7.Items.Add("High_BBL_of_Condo")
            ListBox7.Items.Add("Tax Map/Section/Volume")
            ListBox7.Items.Add("BIN")
            ListBox7.Items.Add("BIN_Status")
            ListBox7.Items.Add("TPAD_BIN")
            ListBox7.Items.Add("TPAD_BIN_Status")
            ListBox7.Items.Add("TPAD_Conflict_Flag")
            ListBox7.Items.Add("Corner Code")
            ListBox7.Items.Add("Business Improvement District")
            ListBox7.Items.Add("X_Y_Coordinates")
            ListBox7.Items.Add("Latitude_Longitude")
        End If
        Return Nothing
    End Function

    Public Function addListBoxItemsOfFunctionAP()
        'Geographic Information Items
        ListBox1.Items.Add("GRC")
        ListBox1.Items.Add("GRC2")
        ListBox1.Items.Add("X Coordinate")
        ListBox1.Items.Add("Y Coordinate")
        ListBox1.Items.Add("Latitude")
        ListBox1.Items.Add("Longitude")
        ListBox7.Items.Add("Tax Block")
        ListBox7.Items.Add("Tax Lot")
        ListBox7.Items.Add("BBL")
        ListBox1.Items.Add("Low_BBL_of_Condo")
        ListBox7.Items.Add("High_BBL_of_Condo")
        ListBox7.Items.Add("BIN")
        ListBox7.Items.Add("Structures")
        ListBox1.Items.Add("RPAD_Condo_Number")
        ListBox7.Items.Add("RPAD_Co-op_Number")
        ListBox7.Items.Add("Condo_Lot")

        Label4.Text = "Property Level Information"
        Label1.Text = "Geographic Information"

        HideShowButton3.Visible = False
        Label3.Visible = False
        AddOneButton4.Visible = False
        RemoveOneButton2.Visible = False
        AddAllButton2.Visible = False
        RemoveAllButton1.Visible = False
        lbxOut3.Visible = False
        ListBox5.Visible = False
        row4.Visible = False
        row3.Visible = False
        ListBox3.Visible = False
        lbxOut2.Visible = False
        AddOneButton2.Visible = False
        RemoveOneButton3.Visible = False
        AddAllButton1.Visible = False
        RemoveAllButton.Visible = False
        Label2.Visible = False
        HideShowButton2.Visible = False

        Return Nothing
    End Function

    Public Function addListBoxItemsOfFunctionD()
        Label1.Text = "Street Information"
        ListBox1.Items.Add("GRC")
        ListBox1.Items.Add("GRC2")
        ListBox1.Items.Add("Borough")
        ListBox1.Items.Add("B10SC")
        ListBox1.Items.Add("Street Name 1")
        ListBox1.Items.Add("Geographic Feature Type 1")
        ListBox1.Items.Add("Geographic Feature Type 2")
        ListBox1.Items.Add("Geographic Feature Type 3")
        Label2.Visible = False
        Label3.Visible = False
        Label4.Visible = False
        ListBox3.Visible = False
        lbxOut2.Visible = False
        ListBox5.Visible = False
        lbxOut3.Visible = False
        ListBox7.Visible = False
        lbxOut4.Visible = False
        AddOneButton2.Visible = False
        RemoveOneButton3.Visible = False
        AddAllButton1.Visible = False
        RemoveAllButton.Visible = False
        AddOneButton4.Visible = False
        RemoveOneButton2.Visible = False
        AddAllButton2.Visible = False
        RemoveAllButton1.Visible = False
        AddOneButton3.Visible = False
        RemoveOneButton4.Visible = False
        AddAllButton0.Visible = False
        RemoveAllButton2.Visible = False
        HideShowButton3.Visible = False
        HideShowButton4.Visible = False
        Label4.Visible = False
        HideShowButton2.Visible = False
        row3.Visible = False
        row4.Visible = False
        row5.Visible = False
    End Function

    Public Function addListBoxItemsOfFunction2()
        If Session("Flag") = "2" Then
            Label1.Text = "Geographic Information"
            'Geographic Information
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Zip Code")
            ListBox1.Items.Add("X,Y Coordinates")
            ListBox1.Items.Add("Community District")
            ListBox1.Items.Add("Latitude, Longitude")
            ListBox1.Items.Add("LION Node Number")
            ListBox1.Items.Add("DCP Preferred B7SC/Street Name For Street 1")
            ListBox1.Items.Add("DCP Preferred B7SC/Street Name For Street 2")
            ListBox1.Items.Add("2010 Census Tract")
            ListBox1.Items.Add("2000 Census Tract")
            ListBox1.Items.Add("Sanborn 1 Boro/Vol/Page")
            ListBox1.Items.Add("Sanborn 2 Boro/Vol/Page")
            ListBox1.Items.Add("Atomic Polygon")
            Label2.Text = "City Service Information"
            'City Service Information
            ListBox3.Items.Add("Police Patrol Borough")
            ListBox3.Items.Add("Police Precinct")
            ListBox3.Items.Add("Fire Division")
            ListBox3.Items.Add("Fire Battalion")
            ListBox3.Items.Add("Fire Company")
            ListBox3.Items.Add("Health Area")
            ListBox3.Items.Add("Health Center District")
            ListBox3.Items.Add("DOT Street Light Area")
            ListBox3.Items.Add("Sanitation District/Section")
            ListBox3.Items.Add("Sanitation Subsection")
            ListBox3.Items.Add("School District")
            ListBox3.Items.Add("CD Eligibility")
            Label3.Text = "Political Information"
            'Political Information
            ListBox5.Items.Add("City Council District")
            ListBox5.Items.Add("Assembly District")
            ListBox5.Items.Add("Congressional District")
            ListBox5.Items.Add("Municipal Court District")
            ListBox5.Items.Add("State Senate District")
            ListBox7.Visible = False
            lbxOut4.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            HideShowButton4.Visible = False
            row5.Visible = False
        End If
        Return Nothing
    End Function

    Public Function addListBoxItemsOfFunction3()
        If Session("Flag") = "3" Then
            Label1.Text = "Geographic Information"
            'Geographic Information
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("DCP Zoning Map")
            ListBox1.Items.Add("On Street B7SC/Name")
            ListBox1.Items.Add("LION Key")
            ListBox1.Items.Add("From Node")
            ListBox1.Items.Add("DOT Street Light Area")
            ListBox1.Items.Add("From X,Y Coordinate")
            ListBox1.Items.Add("Segment ID/Length")
            ListBox1.Items.Add("From Latitude, Longitude")
            ListBox1.Items.Add("Physical ID")
            ListBox1.Items.Add("To Node")
            ListBox1.Items.Add("Generic ID")
            ListBox1.Items.Add("To X,Y Coordinate")
            ListBox1.Items.Add("Location Status")
            ListBox1.Items.Add("To Latitude, Longitude")
            ListBox1.Items.Add("Bike Lane")
            ListBox1.Items.Add("Roadway Type")
            ListBox1.Items.Add("Bike Lane Traffic Direction")
            ListBox1.Items.Add("Street Width Min / Max")
            ListBox1.Items.Add("Number Of Park Lanes")
            ListBox1.Items.Add("Number Of Travel Lanes")
            ListBox1.Items.Add("Total Number Of Lanes")
            ListBox1.Items.Add("Curve Flag")
            ListBox1.Items.Add("Traffic Direction")
            ListBox1.Items.Add("Right Of Way Type")
            ListBox1.Items.Add("Segment Type")
            ListBox1.Items.Add("Feature Type")
            'TODO find these
            Label2.Text = "Left Side Of Street Information"
            'Left Side of Street Information
            ListBox3.Items.Add("Left Side Borough")
            ListBox3.Items.Add("Left Side Community District")
            ListBox3.Items.Add("Left Side Low House Number")
            ListBox3.Items.Add("Left Side High House Number")
            ListBox3.Items.Add("Left Side Zip Code")
            ListBox3.Items.Add("Left Side School District")
            ListBox3.Items.Add("Left Side Police Patrol Borough")
            ListBox3.Items.Add("Left Side Police Precinct")
            ListBox3.Items.Add("Left Side Health Area")
            ListBox3.Items.Add("Left Side Health Center District")
            ListBox3.Items.Add("Left Side Neighborhood Tabulation Area")
            ListBox3.Items.Add("Left Side 2010 Census Tract")
            ListBox3.Items.Add("Left Side 2010 Census Block")
            ListBox3.Items.Add("Left Side Atomic Polygon")
            ListBox3.Items.Add("Left Side 2000 Census Tract")
            ListBox3.Items.Add("Left Side 2000 Census Block")
            ListBox3.Items.Add("Left Side CD Eligibility")
            ListBox3.Items.Add("Left Side Fire Division")
            ListBox3.Items.Add("Left Side Fire Battalion")
            ListBox3.Items.Add("Left Side Fire Company")
            ListBox3.Items.Add("Left Side Block Face ID")
            Label3.Text = "Right Side Of Street Information"
            'Right Side of Street Information
            ListBox5.Items.Add("Right Side Borough")
            ListBox5.Items.Add("Right Side Community District")
            ListBox5.Items.Add("Right Side Low House Number")
            ListBox5.Items.Add("Right Side High House Number")
            ListBox5.Items.Add("Right Side ZIP Code")
            ListBox5.Items.Add("Right Side School District")
            ListBox5.Items.Add("Right Side Police Patrol Borough")
            ListBox5.Items.Add("Right Side Police Precinct")
            ListBox5.Items.Add("Right Side Health Area")
            ListBox5.Items.Add("Right Side Health Center District")
            ListBox5.Items.Add("Right Side Neighborhood Tabulation Area")
            ListBox5.Items.Add("Right Side 2010 Census Tract")
            ListBox5.Items.Add("Right Side 2010 Census Block")
            ListBox5.Items.Add("Right Side Atomic Polygon")
            ListBox5.Items.Add("Right Side 2000 Census Tract")
            ListBox5.Items.Add("Right Side 2000 Census Block")
            ListBox5.Items.Add("Right Side CD Eligibility")
            ListBox5.Items.Add("Right Side Fire Division")
            ListBox5.Items.Add("Right Side Fire Battalion")
            ListBox5.Items.Add("Right Side Fire Company")
            ListBox5.Items.Add("Right Side Block Face ID")
            ListBox7.Visible = False
            lbxOut4.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            HideShowButton4.Visible = False
            Label4.Visible = False
            row5.Visible = False
        End If
        Return Nothing
    End Function

    Public Function addListBoxItemsOfFunction3S()
        If Session("Flag") = "3S" Then
            Label1.Text = "Intersecting Streets"
            'Intersecting Streets
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Intersecting Street")
            ListBox1.Items.Add("2nd Intersecting Street (If any)")
            ListBox1.Items.Add("3Rd Intersecting Street (If any)")
            ListBox1.Items.Add("4th Intersecting Street (If any)")
            ListBox1.Items.Add("5th Intersecting Street (If any)")
            ListBox1.Items.Add("Cross Street Count")
            ListBox1.Items.Add("Number Of Ft. from Previous Intersection")
            ListBox1.Items.Add("Gap Flag")
            ListBox1.Items.Add("Node ID")
            'HideShowButton4.Visible = False
            Label2.Visible = False
            Label3.Visible = False
            'Label4.Visible = False
            ListBox3.Visible = False
            lbxOut2.Visible = False
            ListBox5.Visible = False
            lbxOut3.Visible = False
            ListBox7.Visible = False
            lbxOut4.Visible = False
            AddOneButton2.Visible = False
            RemoveOneButton3.Visible = False
            AddAllButton1.Visible = False
            RemoveAllButton.Visible = False
            AddOneButton4.Visible = False
            RemoveOneButton2.Visible = False
            AddAllButton2.Visible = False
            RemoveAllButton1.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            row3.Visible = False
            row4.Visible = False
            row5.Visible = False
            HideShowButton2.Visible = False
            HideShowButton3.Visible = False
            HideShowButton4.Visible = False

        End If
        Return Nothing
    End Function
    Function addListBoxItemsOfFunctionBL()
        If Session("Flag") = "BL" Then
            Label1.Text = "Property Level Information"
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Speed Limit")
            ListBox1.Items.Add("Tax Block")
            ListBox1.Items.Add("Tax Lot")
            ListBox1.Items.Add("BBL")
            ListBox1.Items.Add("Block Faces")
            ListBox1.Items.Add("Sanborn Boro/Vol/Page")
            ListBox1.Items.Add("X,Y Coordinate")
            ListBox1.Items.Add("Latitude, Longitude")
            ListBox1.Items.Add("Vacant Lot")
            ListBox1.Items.Add("Low BBL Of Condo")
            ListBox1.Items.Add("BIN")
            ListBox1.Items.Add("TPAD BIN")
            ListBox1.Items.Add("Corner Code")
            ListBox1.Items.Add("Structures")
            ListBox1.Items.Add("Business Improvement District")
            ListBox1.Items.Add("RPAD SCC")
            ListBox1.Items.Add("RPAD Building Class")
            ListBox1.Items.Add("RPAD Interior Lot")
            ListBox1.Items.Add("RPAD Irreg. Shaped Lot")
            ListBox1.Items.Add("RPAD Condo Number")
            ListBox1.Items.Add("RPAD Co-op Number")
            ListBox1.Items.Add("Condo Lot")
            ListBox1.Items.Add("Tax Map/Section/Volume")
            ListBox1.Items.Add("High BBL Of Condo")
            ListBox1.Items.Add("BIN Status")
            ListBox1.Items.Add("TPAD BIN Status")
            ListBox1.Items.Add("TPAD Conflict Flag")
            Label1.Visible = True
            Label2.Visible = False
            Label3.Visible = False
            ListBox3.Visible = False
            lbxOut2.Visible = False
            ListBox5.Visible = False
            lbxOut3.Visible = False
            ListBox7.Visible = False
            lbxOut4.Visible = False
            AddOneButton2.Visible = False
            RemoveOneButton3.Visible = False
            AddAllButton1.Visible = False
            RemoveAllButton.Visible = False
            AddOneButton4.Visible = False
            RemoveOneButton2.Visible = False
            AddAllButton2.Visible = False
            RemoveAllButton1.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            row3.Visible = False
            row4.Visible = False
            row5.Visible = False
            HideShowButton3.Visible = False
            HideShowButton4.Visible = False
            HideShowButton5.Visible = False
            HideShowButton2.Visible = False
            Label4.Visible = False
        End If
        Return Nothing
    End Function
    Public Function addListBoxItemsOfFunctionBN()
        If Session("Flag") = "BN" Then
            Label1.Text = "Property Level Information"

            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Speed Limit")
            ListBox1.Items.Add("Tax Block")
            ListBox1.Items.Add("Tax Lot")
            ListBox1.Items.Add("BBL")
            ListBox1.Items.Add("Block Faces")
            ListBox1.Items.Add("Sanborn Boro/Vol/Page")
            ListBox1.Items.Add("X,Y Coordinate")
            ListBox1.Items.Add("Latitude, Longitude")
            ListBox1.Items.Add("Vacant Lot")
            ListBox1.Items.Add("Low BBL Of Condo")
            ListBox1.Items.Add("BIN")
            ListBox1.Items.Add("TPAD BIN")
            ListBox1.Items.Add("Corner Code")
            ListBox1.Items.Add("Structures")
            ListBox1.Items.Add("Business Improvement District")
            ListBox1.Items.Add("RPAD SCC")
            ListBox1.Items.Add("RPAD Building Class")
            ListBox1.Items.Add("RPAD Interior Lot")
            ListBox1.Items.Add("RPAD Irreg. Shaped Lot")
            ListBox1.Items.Add("RPAD Condo Number")
            ListBox1.Items.Add("RPAD Co-op Number")
            ListBox1.Items.Add("Condo Lot")
            ListBox1.Items.Add("Tax Map/Section/Volume")
            ListBox1.Items.Add("High BBL Of Condo")
            ListBox1.Items.Add("BIN Status")
            ListBox1.Items.Add("TPAD BIN Status")
            ListBox1.Items.Add("TPAD Conflict Flag")
            Label2.Visible = False
            Label3.Visible = False
            ListBox3.Visible = False
            lbxOut2.Visible = False
            ListBox5.Visible = False
            lbxOut3.Visible = False
            ListBox7.Visible = False
            lbxOut4.Visible = False
            AddOneButton2.Visible = False
            RemoveOneButton3.Visible = False
            AddAllButton1.Visible = False
            RemoveAllButton.Visible = False
            AddOneButton4.Visible = False
            RemoveOneButton2.Visible = False
            AddAllButton2.Visible = False
            RemoveAllButton1.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            row3.Visible = False
            row4.Visible = False
            row5.Visible = False
            HideShowButton2.Visible = False
            HideShowButton3.Visible = False
            HideShowButton4.Visible = False
        End If
        Return Nothing
    End Function
    Function addListBoxItemsOfFunctionN()
        If Session("Flag") = "N" Then
            Label1.Text = "Outputs"
            'Street Information for Street Name
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Correct Street Name")
            Label2.Visible = False
            Label3.Visible = False
            'Label4.Visible = False
            ListBox3.Visible = False
            lbxOut2.Visible = False
            ListBox5.Visible = False
            lbxOut3.Visible = False
            ListBox7.Visible = False
            lbxOut4.Visible = False
            AddOneButton2.Visible = False
            RemoveOneButton3.Visible = False
            AddAllButton1.Visible = False
            RemoveAllButton.Visible = False
            AddOneButton4.Visible = False
            RemoveOneButton2.Visible = False
            AddAllButton2.Visible = False
            RemoveAllButton1.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            HideShowButton3.Visible = False
            HideShowButton4.Visible = False
            Label4.Visible = False
            HideShowButton2.Visible = False
            row3.Visible = False
            row4.Visible = False
            row5.Visible = False

        End If
        Return Nothing
    End Function

    Function addListBoxItemsOfFunction1N()
        If Session("Flag") = "1N" Then
            Label1.Text = "Outputs"
            'Street Information for Street Name
            ListBox1.Items.Add("GRC")
            ListBox1.Items.Add("GRC2")
            ListBox1.Items.Add("Borough")
            ListBox1.Items.Add("B10SC")
            ListBox1.Items.Add("Street Name")
            ListBox1.Items.Add("Geographic Feature Type")
            Label2.Visible = False
            Label3.Visible = False
            'Label4.Visible = False
            ListBox3.Visible = False
            lbxOut2.Visible = False
            ListBox5.Visible = False
            lbxOut3.Visible = False
            ListBox7.Visible = False
            lbxOut4.Visible = False
            AddOneButton2.Visible = False
            RemoveOneButton3.Visible = False
            AddAllButton1.Visible = False
            RemoveAllButton.Visible = False
            AddOneButton4.Visible = False
            RemoveOneButton2.Visible = False
            AddAllButton2.Visible = False
            RemoveAllButton1.Visible = False
            AddOneButton3.Visible = False
            RemoveOneButton4.Visible = False
            AddAllButton0.Visible = False
            RemoveAllButton2.Visible = False
            HideShowButton3.Visible = False
            HideShowButton4.Visible = False
            Label4.Visible = False
            HideShowButton2.Visible = False
            row3.Visible = False
            row4.Visible = False
            row5.Visible = False

        End If
        Return Nothing
    End Function

    Public Function hideShowButton()
        HideShowButton1.Text = "-"
        HideShowButton2.Text = "-"
        HideShowButton3.Text = "-"
        HideShowButton4.Text = "-"
        HideShowButton5.Text = "-"
        Return Nothing
    End Function


    Protected Sub BackImageButton_Click(sender As Object, e As ImageClickEventArgs) Handles BackImageButton.Click
        '--Clearing all arrays on back button click to start a new array builder when new values from dropdown's are selected
        Session("zip").Clear()
        Session("boro").Clear()
        Session("st").Clear()
        Session("addressNo").Clear()
        Session("bin").Clear()
        Session("block").Clear()
        Session("lot").Clear()
        Session("headerRowText").Clear()
        Session("boro1").Clear()
        Session("street1").Clear()
        Session("boro2").Clear()
        Session("street1").Clear()
        Session("boro3").Clear()
        Session("street3").Clear()
        Session("sideOfStreet").Clear()
        Session("outputSelectBackButtonFlag") = True
        Response.Redirect("GridViewInputPage.aspx")
    End Sub


    Public Function addExcelInputsToListBox()
        For i As Integer = 1 To Session("gridview1ColumnCount")
            lbxUserUploadedIn.Items.Add(Session("headerRowText")(i))
        Next

        Return Nothing
    End Function

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

    Protected Sub HideShowButton5_Click(sender As Object, e As EventArgs) Handles HideShowButton5.Click
        If row1.Visible = True Then
            row1.Visible = False
            HideShowButton5.Text = "+"
        Else
            row1.Visible = True
            HideShowButton5.Text = "-"
        End If
    End Sub

    Protected Sub HideShowButton1_Click(sender As Object, e As EventArgs) Handles HideShowButton1.Click
        If row2.Visible = True Then
            row2.Visible = False
            HideShowButton1.Text = "+"
        Else
            row2.Visible = True
            HideShowButton1.Text = "-"
        End If
    End Sub

    Protected Sub HideShowButton2_Click(sender As Object, e As EventArgs) Handles HideShowButton2.Click
        If row3.Visible = True Then
            row3.Visible = False
            HideShowButton2.Text = "+"
        Else
            row3.Visible = True
            HideShowButton2.Text = "-"
        End If
    End Sub

    Protected Sub HideShowButton3_Click(sender As Object, e As EventArgs) Handles HideShowButton3.Click
        If row4.Visible = True Then
            row4.Visible = False
            HideShowButton3.Text = "+"
        Else
            row4.Visible = True
            HideShowButton3.Text = "-"
        End If
    End Sub

    Protected Sub HideShowButton4_Click(sender As Object, e As EventArgs) Handles HideShowButton4.Click
        If row5.Visible = True Then
            row5.Visible = False
            HideShowButton4.Text = "+"
        Else
            row4.Visible = True
            HideShowButton4.Text = "-"
        End If
    End Sub


#End Region

#Region "Excel Input Add/Remove Buttons"

    Protected Sub AddOneExcelInput(sender As Object, e As EventArgs) Handles AddOneButton5.Click
        If (lbxUserUploadedIn.SelectedIndex = -1) Then
            RegMsgBox("please select an item")
        Else
            Dim item As ListItem = lbxUserUploadedIn.SelectedItem
            lbxUserUploadedIn.Items.Remove(item)
            lbxOut0.SelectedIndex = -1
            lbxOut0.Items.Add(item)
        End If
    End Sub

    Protected Sub RemoveOneExcelInput(sender As Object, e As EventArgs) Handles RemoveOneButton5.Click
        If (lbxOut0.SelectedIndex = -1) Then
            RegMsgBox("please select an item")
        Else
            Dim item As ListItem = lbxOut0.SelectedItem
            lbxOut0.Items.Remove(item)
            lbxUserUploadedIn.SelectedIndex = -1
            lbxUserUploadedIn.Items.Add(item)
        End If
    End Sub

    Protected Sub AddAllExcelInput(sender As Object, e As EventArgs) Handles AddAllButton3.Click
        For i = 0 To lbxUserUploadedIn.Items.Count - 1
            lbxOut0.Items.Add(lbxUserUploadedIn.Items(i).ToString)
        Next
        lbxUserUploadedIn.Items.Clear()
    End Sub

    Protected Sub RemoveAllExcelInput(sender As Object, e As EventArgs) Handles RemoveAllButton3.Click
        For i = 0 To lbxOut0.Items.Count - 1
            lbxUserUploadedIn.Items.Add(lbxOut0.Items(i).ToString)
        Next
        lbxOut0.Items.Clear()
    End Sub

#End Region

    'Excel Objects
    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim lbxUserOuts As New List(Of String)()
    Dim lbxOuts As New List(Of String)()


    Function GetValueOfListBoxOuts()

        lbxOuts.Add("ID")
        For i As Integer = 0 To lbxOut1.Items.Count - 1
            lbxOuts.Add(lbxOut1.Items(i).Value.ToString)
        Next

        For i As Integer = 0 To lbxOut2.Items.Count - 1
            lbxOuts.Add(lbxOut2.Items(i).Value.ToString)
        Next

        For i As Integer = 0 To lbxOut3.Items.Count - 1
            lbxOuts.Add(lbxOut3.Items(i).Value.ToString)
        Next

        For i As Integer = 0 To lbxOut4.Items.Count - 1
            lbxOuts.Add(lbxOut4.Items(i).Value.ToString)
        Next

        Return lbxOuts
    End Function

    Function GetSelectedColsFor3S()
        Dim lbx As New List(Of String)()
        For i As Integer = 0 To lbxOut1.Items.Count - 1
            lbx.Add(lbxOut1.Items(i).Value.ToString)
        Next
        Return lbx
    End Function

    'Box 02
    Function GetValueOfBox00()
        Dim lbxUserOut As New List(Of String)()
        For i As Integer = 0 To lbxOut0.Items.Count - 1
            lbxUserOut.Add(lbxOut0.Items(i).Value.ToString)
            Session("3SUserInputs").add(lbxOut0.Items(i).Value)
        Next
        Return lbxUserOut
    End Function

    Function CreateListBox00Dictionary()
        Dim lbxUserOut0 As New Dictionary(Of String, List(Of String))()
        Dim key = "Inputs"
        Dim value As List(Of String) = GetValueOfBox00()
        lbxUserOut0.Add(key, value)
        Return lbxUserOut0
    End Function
    'Box 01

    Function GetValueOfBox01()
        Dim lbxUserOut As New List(Of String)()
        lbxUserOut.Add("")
        For i As Integer = 0 To lbxOut1.Items.Count - 1
            lbxUserOut.Add(lbxOut1.Items(i).Value.ToString)
        Next
        Return lbxUserOut
    End Function
    Function CreateListBoxDictionary()

        Dim dic As New Dictionary(Of String, List(Of String))()

        Try

            Dim key = Label1.Text
            Dim list = New List(Of String)
            For i As Integer = 0 To lbxOut1.Items.Count - 1
                list.Add(lbxOut1.Items(i).Value.ToString)
            Next
            If list.Count > 0 Then
                dic.Add(key, list)
            End If

            key = Label2.Text
            list = New List(Of String)
            For i As Integer = 0 To lbxOut2.Items.Count - 1
                list.Add(lbxOut2.Items(i).Value.ToString)
            Next
            If list.Count > 0 Then
                dic.Add(key, list)
            End If

            key = Label3.Text
            list = New List(Of String)
            For i As Integer = 0 To lbxOut3.Items.Count - 1
                list.Add(lbxOut3.Items(i).Value.ToString)
            Next
            If list.Count > 0 Then
                dic.Add(key, list)
            End If

            key = Label4.Text
            list = New List(Of String)
            For i As Integer = 0 To lbxOut4.Items.Count - 1
                list.Add(lbxOut4.Items(i).Value.ToString)
            Next
            If list.Count > 0 Then
                dic.Add(key, list)
            End If

        Catch ex As Exception
            Response.Redirect("UploadFile.aspx")
        End Try

        Return dic
    End Function


    Sub ArrangeExcelFile()

        xlWorkBook = xlApp.Workbooks.Open(filePathData)
            xlWorkSheet = xlWorkBook.Worksheets(2)

            Dim lastCell = xlWorkSheet.UsedRange.Columns.Count

        xlWorkSheet.UsedRange.Columns.AutoFit()
            xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, lastCell)).Interior.Color = RGB(93, 123, 157)
            xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, lastCell)).Font.Color = RGB(255, 255, 255)
            xlWorkSheet.Range(xlWorkSheet.Cells(1, 1), xlWorkSheet.Cells(1, lastCell)).Font.FontStyle = "Bold"
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

    Protected Sub ButtonClick_ProcessingUserInput(sender As Object, e As EventArgs) Handles SubmitButton.Click
        filePathData = "C:\ExcelFiles\" + Session("Filename2")
        filePathError = "C:\ExcelFiles\" + Session("Filename1")

        lbxUserOuts = GetValueOfBox00()
        lbxOuts = GetValueOfListBoxOuts()

        PopulateFunctionInputs()

        If CheckBox1.Checked = True Then
            lbxUserOuts.Add("Normalized Borough")
            Session("3SUserInputs").add("Normalized Borough")
            If Session("normalizedBoroughs2").Count > 0 Then
                lbxUserOuts.Add("Normalized Borough 2")
            End If
            If Session("normalizedBoroughs3").Count > 0 Then
                lbxUserOuts.Add("Normalized Borough 3")
            End If
            If Not Session("flag") = "BL" Then
                If Not Session("flag") = "1N" Then
                    lbxUserOuts.Add("Normalized Street")
                End If
            End If

            Session("3SUserInputs").add("Normalized Street")
            If Session("normalizedStreets2").Count > 0 Then
                lbxUserOuts.Add("Normalized Street 2")
                Session("3SUserInputs").add("Normalized Street 2")
            End If
            If Session("normalizedStreets3").Count > 0 Then
                lbxUserOuts.Add("Normalized Street 3")
                Session("3SUserInputs").add("Normalized Street 3")
            End If

        End If

        GetFunctionData()

        SaveAs(filePathData)
        ArrangeExcelFile()

        Response.Redirect("Results.aspx", True)
    End Sub

    Private Sub SaveAs(filePath)
        '~~> Opens Source Workbook. Change path and filename as applicable
        xlWorkBook = xlApp.Workbooks.Open(filePath)

        '~~> Display Excel
        xlApp.Visible = False
        xlApp.DisplayAlerts = False
        '~~> Do some work

        '~~> Save the file
        xlWorkBook.SaveAs(filePath)

        '~~> Close the file
        xlWorkBook.Close()
    End Sub

    Sub CopyUserSelectedColsToTarget()

        Dim workBookSource As Excel.Workbook = GetWorkBook(filePathError)
        Dim sourceSheet As Excel.Worksheet = workBookSource.Worksheets(1)

        Dim workBookTarget As Excel.Workbook = GetWorkBook(filePathData)
        Dim targetSheet As Excel.Worksheet = workBookTarget.Worksheets(2)


        Dim range As Excel.Range = sourceSheet.UsedRange.Columns(1)
        range.Copy()

        targetSheet.Select()

        Dim range2 As Excel.Range = targetSheet.UsedRange.Columns(1)

        range2.Insert(Shift:=Excel.XlInsertShiftDirection.xlShiftToRight)

        workBookSource.Save()
        workBookTarget.Save()

        workBookSource.Close()
        workBookTarget.Close()

    End Sub


    Function GetWorkBook(fileName As String)
        'Excel Objects
        Dim xlApp As New Excel.Application

        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Open(fileName)

        Return xlWorkBook

    End Function


    Sub GetFunctionData()
        Dim filename1 = Session("Filename1")
        Dim filename2 = Session("Filename2")

        Dim functionType = Session("Flag")
        If functionType = "1B" Then
            Dim tpad As Boolean = Session("TPAD")
            Dim roadBed As Boolean = Session("Roadbed Specific Information")
            Dim f1B = New Function1B(filename1, filename2, lbxUserOuts, lbxOuts, dt, tpad, roadBed)
            f1B.PopulateExcel()
        ElseIf functionType = "1A" Then
            Dim tpad As Boolean = Session("TPAD")
            Dim f1B = New Function1A(filename1, filename2, lbxUserOuts, lbxOuts, dt, tpad)
            f1B.PopulateExcel()
        ElseIf functionType = "1E" Then
            Dim f1B = New Function1E(filename1, filename2, lbxUserOuts, lbxOuts, dt)
            f1B.PopulateExcel()
        ElseIf functionType = "1N" Then
            Dim f1B = New Function1N(filename1, filename2, lbxUserOuts, lbxOuts, dt)
            f1B.PopulateExcel()
        ElseIf functionType = "2" Then
            Dim f2 = New Function2(filename1, filename2, lbxUserOuts, lbxOuts, dt)
            f2.PopulateExcel()
        ElseIf functionType = "3" Then
            Dim f3 = New Function3(filename1, filename2, lbxUserOuts, lbxOuts, dt)
            f3.PopulateExcel()
        ElseIf functionType = "3S" Then
            Dim realStreet As Boolean = Session("realStreet")
            Dim f3s = New Function3S(filename1, filename2, lbxUserOuts, lbxOuts, dt, GetSelectedColsFor3S(), realStreet, Session("resultsPageVisited"))
            f3s.PopulateExcel()
        ElseIf functionType = "BL" Then
            Dim tpad As Boolean = Session("TPAD")
            Dim fbl = New FunctionBL(filename1, filename2, lbxUserOuts, lbxOuts, tpad, dt)
            fbl.PopulateExcel()
        ElseIf functionType = "BN" Then
            Dim tpad As Boolean = Session("TPAD")
            Dim fbn = New FunctionBN(filename1, filename2, lbxUserOuts, lbxOuts, tpad, dt)
            fbn.PopulateExcel()
        ElseIf functionType = "N" Then
            Dim fn = New FunctionN(filename1, filename2, lbxUserOuts, lbxOuts, dt)
            fn.PopulateExcel()
        ElseIf functionType = "AP" Then
            Dim fn = New FunctionAP(filename1, filename2, lbxUserOuts, lbxOuts, dt)
            fn.PopulateExcel()
        ElseIf functionType = "D" Then
            Dim fn = New FunctionDG(filename1, filename2, lbxUserOuts, lbxOuts, dt)
            fn.PopulateExcel()
        End If

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

End Class