Imports GBATExcel._Default
Imports Excel = Microsoft.Office.Interop.Excel


Public Class WebForm1
    Inherits System.Web.UI.Page
    'Dim dt As New DataTable()
    'Dim DtSet As New System.Data.DataSet("TaskTable")
    Dim submitButtonClicked As Boolean = False
    Dim rowUpdated As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            If Session("Filename1") = "" Then
                Response.Redirect("uploadfile.aspx")
                RegMsgBox("Invalid File Format")
            Else
                Session("boroPlace") = 0
                Session("onstPlace") = 0
                Session("compDirect1") = 0
                Session("compDirect2") = 0
                Session("CompassDirection1Selected") = False
                Session("CompassDirection2Selected") = False
                'Session.Remove("TaskTable")
                Session("gridviewInputBackButtonFlag") = False
                'shows label for information depending on Function selected
                label1TextForFunctionSelected()
                GridView1.DataSource = Nothing
                'Load Excel File on Page Load 
                BindData()
                'adds dropdowns depending on the number of columns in a gridview
                getDropDownsPerGVColumn()
                'adds drop down items depending on function selected
                addDropDowns()

            End If
        End If
    End Sub


    Public Function label1TextForFunctionSelected()
        label1.ForeColor = System.Drawing.Color.White
        If Session("Flag") = "1B" Then
            label1.Text = "FOR FUNCTION 1B: Please Select Either (Borough or Zip Code) from the Drop Down's as well as Address No, and Street with the corresponding column. Unit(Optional)"
        ElseIf Session("Flag") = "1A" Then
            label1.Text = "FOR FUNCTION 1A: Please Select Either (Borough or Zip Code) from the Drop Down's as well as Address No, and Street with the corresponding column. Unit(Optional)"
        ElseIf Session("Flag") = "1E" Then
            label1.Text = "FOR FUNCTION 1E: Please Select Either (Borough or Zip Code) from the Drop Down's as well as Address No, and Street with the corresponding column. Unit(Optional)"
        ElseIf Session("Flag") = "2" Then
            label1.Text = "FOR FUNCTION 2: Please Select Borough 1, Street 1, Borough 2, and Street 2 from the Drop Down's with the corresponding column. Compass Direction (Optional)"
        ElseIf Session("Flag") = "3" Then
            label1.Text = "FOR FUNCTION 3: Please Select Borough 1, Street 1, Borough 2, Street 2, Borough 3, and Street 3 from the Drop Down's with the corresponding column. Side Of Street (Optional)"
        ElseIf Session("Flag") = "3S" Then
            label1.Text = "FOR FUNCTION 3S: Please Select Borough, and On Street from the Drop Down's with the corresponding column. Compass Direction 1 (Optional), Compass Direction 2 (Optional), First Cross Street (Optional), and Second Cross Street (Optional)"
        ElseIf Session("Flag") = "BL" Then
            label1.Text = "FOR FUNCTION BL: Please Select Borough, Address No, and Street from the Drop Down's with the corresponding column"
        ElseIf Session("Flag") = "BN" Then
            label1.Text = "FOR FUNCTION BN: Please Select Bin from one of the Drop Down's with the corresponding column"
        ElseIf Session("Flag") = "N" Then
            label1.Text = "FOR FUNCTION N: Please Select Street Name from on of the Drop Down's with the corresponding column"
        ElseIf Session("Flag") = "1N" Then
            label1.Text = "FOR FUNCTION N: Please Select Street Name and Borough from one of the Drop Down's with the corresponding column"
        Else
            label1.Text = " "
        End If

        Return Nothing
    End Function

    Function CheckForValidationN()
        Dim y As Integer

        If Session("Flag") = "N" Then
            For x As Integer = Session("startPage") To GridView1.PageCount - 1
                GridView1.SetPageIndex(x)

                For i As Integer = Session("startState") To GridView1.Rows.Count - 1
                    If DropDownList1.SelectedItem.ToString = "Street Name" Then
                        y = 1
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList2.SelectedItem.ToString = "Street Name" Then
                        y = 2
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList3.SelectedItem.ToString = "Street Name" Then
                        y = 3
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList4.SelectedItem.ToString = "Street Name" Then
                        y = 4
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList5.SelectedItem.ToString = "Street Name" Then
                        y = 5
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList6.SelectedItem.ToString = "Street Name" Then
                        y = 6
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList7.SelectedItem.ToString = "Street Name" Then
                        y = 7
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList8.SelectedItem.ToString = "Street Name" Then
                        y = 8
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList9.SelectedItem.ToString = "Street Name" Then
                        y = 9
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList10.SelectedItem.ToString = "Street Name" Then
                        y = 10
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList11.SelectedItem.ToString = "Street Name" Then
                        y = 11
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList12.SelectedItem.ToString = "Street Name" Then
                        y = 12
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList13.SelectedItem.ToString = "Street Name" Then
                        y = 13
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList14.SelectedItem.ToString = "Street Name" Then
                        y = 14
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList15.SelectedItem.ToString = "Street Name" Then
                        y = 15
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList16.SelectedItem.ToString = "Street Name" Then
                        y = 16
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList17.SelectedItem.ToString = "Street Name" Then
                        y = 17
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList18.SelectedItem.ToString = "Street Name" Then
                        y = 18
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList19.SelectedItem.ToString = "Street Name" Then
                        y = 19
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList20.SelectedItem.ToString = "Street Name" Then
                        y = 20
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList21.SelectedItem.ToString = "Street Name" Then
                        y = 21
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList22.SelectedItem.ToString = "Street Name" Then
                        y = 22
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList23.SelectedItem.ToString = "Street Name" Then
                        y = 23
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    ElseIf DropDownList24.SelectedItem.ToString = "Street Name" Then
                        y = 24
                        If GridView1.Rows(i).Cells(y).Text.ToString() = "" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    End If
                Next

            Next
        End If
        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Public Function CheckForValidationBN()

        Dim y As Integer


        If Session("Flag") = "BN" Then

            For x As Integer = Session("startPage") To GridView1.PageCount - 1

                GridView1.SetPageIndex(x)

                For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                    If DropDownList1.SelectedItem.ToString = "BIN" Then
                        y = 1
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList2.SelectedItem.ToString = "BIN" Then
                        y = 2
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList3.SelectedItem.ToString = "BIN" Then
                        y = 3
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList4.SelectedItem.ToString = "BIN" Then
                        y = 4
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList5.SelectedItem.ToString = "BIN" Then
                        y = 5
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList6.SelectedItem.ToString = "BIN" Then
                        y = 6
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList7.SelectedItem.ToString = "BIN" Then
                        y = 7
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList8.SelectedItem.ToString = "BIN" Then
                        y = 8
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList9.SelectedItem.ToString = "BIN" Then
                        y = 9
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList10.SelectedItem.ToString = "BIN" Then
                        y = 10
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList11.SelectedItem.ToString = "BIN" Then
                        y = 11
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList12.SelectedItem.ToString = "BIN" Then
                        y = 12
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList13.SelectedItem.ToString = "BIN" Then
                        y = 13
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList14.SelectedItem.ToString = "BIN" Then
                        y = 14
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList15.SelectedItem.ToString = "BIN" Then
                        y = 15
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList16.SelectedItem.ToString = "BIN" Then
                        y = 16
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList17.SelectedItem.ToString = "BIN" Then
                        y = 17
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList18.SelectedItem.ToString = "BIN" Then
                        y = 18
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList19.SelectedItem.ToString = "BIN" Then
                        y = 19
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList20.SelectedItem.ToString = "BIN" Then
                        y = 20
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList21.SelectedItem.ToString = "BIN" Then
                        y = 21
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList22.SelectedItem.ToString = "BIN" Then
                        y = 22
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList23.SelectedItem.ToString = "BIN" Then
                        y = 23
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList24.SelectedItem.ToString = "BIN" Then
                        y = 24
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList25.SelectedItem.ToString = "BIN" Then
                        y = 25
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If

                    ElseIf DropDownList26.SelectedItem.ToString = "BIN" Then
                        y = 26
                        If Not Regex.IsMatch(GridView1.Rows(i).Cells(y).Text.ToString(), "^[0-9 ]+$") Or GridView1.Rows(i).Cells(y).Text.ToString() = "&nbsp;" Or GridView1.Rows(i).Cells(y).Text.ToString().Count < 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Count > 7 Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) > "5" Or GridView1.Rows(i).Cells(y).Text.ToString().Substring(0, 1) < "1" Then
                            ManageErrors(x, i, y)
                            Exit Function
                        End If
                    End If
                Next
            Next
        End If

        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Function CheckForValidation3()
        Dim borough1DropDownListNumber As Integer
        Dim borough2DropDownListNumber As Integer
        Dim borough3DropDownListNumber As Integer
        Dim street1DropDownListNumber As Integer
        Dim street2DropDownListNumber As Integer
        Dim street3DropDownListNumber As Integer


        If DropDownList1.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 26

        End If

        If DropDownList1.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 1

        ElseIf DropDownList2.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 26
        End If


        If DropDownList1.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Borough 3" Then
            borough3DropDownListNumber = 26
        End If


        If DropDownList1.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 26
        End If

        If DropDownList1.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 26
        End If

        If DropDownList1.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Street 3" Then
            street3DropDownListNumber = 26
        End If


        For x As Integer = 0 To GridView1.PageCount - 1

            GridView1.SetPageIndex(x)

            For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                If GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "MN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BK" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "SI" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "THE BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BX" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "QUEENS" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "QN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "1" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "2" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "3" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "4" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "5" Then
                Else
                    ManageErrors(x, i, borough1DropDownListNumber)
                    Exit Function
                End If

                If GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "MN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BK" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "SI" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "THE BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BX" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "QUEENS" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "QN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "1" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "2" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "3" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "4" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "5" Then
                Else
                    ManageErrors(x, i, borough2DropDownListNumber)
                    Exit Function
                End If

                If GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "MN" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "BK" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "SI" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "THE BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "BX" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "QUEENS" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "QN" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "1" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "2" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "3" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "4" Then
                ElseIf GridView1.Rows(i).Cells(borough3DropDownListNumber).Text.ToUpper = "5" Then
                Else
                    ManageErrors(x, i, borough3DropDownListNumber)
                    Exit Function
                End If


                If DropDownList1.SelectedItem.ToString = "Street 1" Then
                    If GridView1.Rows(i).Cells(street1DropDownListNumber).Text.Length < 30 Then
                    Else
                        ManageErrors(x, i, street1DropDownListNumber)
                        Exit Function
                    End If
                End If

                If DropDownList1.SelectedItem.ToString = "Street 2" Then
                    If GridView1.Rows(i).Cells(street2DropDownListNumber).Text.Length < 30 Then
                    Else
                        ManageErrors(x, i, street2DropDownListNumber)
                        Exit Function
                    End If
                End If


                If DropDownList1.SelectedItem.ToString = "Street 3" Then
                    If GridView1.Rows(i).Cells(street3DropDownListNumber).Text.Length < 30 Then
                    Else
                        ManageErrors(x, i, street3DropDownListNumber)
                        Exit Function
                    End If
                End If
            Next
        Next


        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Private Sub BindData()

        GridView1.DataSource = Session("TaskTable")

        GridView1.DataBind()

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

    Protected Sub InputPageSubmitButton_Click(sender As Object, e As EventArgs) Handles InputPageSubmitButton.Click

        If Session("Flag") = "1B" Then
            submitButtonClicked = True
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf1BListItemsSelectedOnceOrMore()

        ElseIf Session("Flag") = "1A" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf1AListItemsSelectedOnceOrMore()

        ElseIf Session("Flag") = "1E" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf1EListItemsSelectedOnceOrMore()

        ElseIf Session("Flag") = "2" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf2ListItemsSelectedOnceOrMore()

        ElseIf Session("Flag") = "3" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf3ListItemsSelectedOnceOrMore()

        ElseIf Session("Flag") = "3S" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf3SDdListItemsSelectedOnceOrMore()

        ElseIf Session("Flag") = "BN" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIfBinSelectedOnceOrMore()

        ElseIf Session("Flag") = "BL" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIfBLSelectedOnceOrMore()

        ElseIf Session("Flag") = "N" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIfNameCodeNSelectedOnceOrMore()

        ElseIf Session("Flag") = "AP" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf1BListItemsSelectedOnceOrMore()


        ElseIf Session("Flag") = "1N" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIf1NListItemsSelectedOnceOrMore()

        ElseIf Session("Flag") = "D" Then
            submitButtonClicked = True
            checkDdItemSelectedTwice()
            Session("UserSelectedCol") = GetUserSelectedColDictionary()
            checkIfDListItemsSelectedOnceOrMore()
        End If

    End Sub


    Function GetUserSelectedColDictionary()
        Dim dictionary As New Dictionary(Of String, Integer)
        Dim dataTable As DataTable = Session("TaskTable").Tables(0)
        Dim colCount = dataTable.Columns.Count
        For i = 0 To colCount
            Dim drop = GetDropDownList(i)

            If Not IsNothing(drop.SelectedItem) Then

                If drop.SelectedItem.value = "Borough" Then
                    Session("boroPlace") = i
                End If

                If drop.SelectedItem.value = "On Street" Then
                    Session("onstPlace") = i
                End If

                If drop.SelectedItem.value = "Compass Direction 1" Then
                    Session("compDirect1") = i
                End If

                If drop.SelectedItem.value = "Compass Direction 2" Then
                    Session("compDirect2") = i
                End If

                If Not String.IsNullOrEmpty(drop.SelectedItem.Text) Then
                        Dim key = drop.SelectedItem.Text
                        Dim value = i - 1
                        dictionary.Add(key, value)
                    End If

                End If

        Next
        Return dictionary
    End Function

    Function GetDropDownList(i As Integer)

        Dim drop As DropDownList

        Select Case i
            Case 0
                drop = DropDownList0
            Case 1
                drop = DropDownList1
            Case 2
                drop = DropDownList2
            Case 3
                drop = DropDownList3
            Case 4
                drop = DropDownList4
            Case 5
                drop = DropDownList5
            Case 6
                drop = DropDownList6
            Case 7
                drop = DropDownList7

            Case 8
                drop = DropDownList8
            Case 9
                drop = DropDownList9
            Case 10
                drop = DropDownList10
            Case 11
                drop = DropDownList11
            Case 12
                drop = DropDownList12
            Case 13
                drop = DropDownList13
            Case 14
                drop = DropDownList14
            Case 15
                drop = DropDownList15
            Case 16
                drop = DropDownList16
            Case 17
                drop = DropDownList17
            Case 18
                drop = DropDownList18
            Case 19
                drop = DropDownList19
            Case 20
                drop = DropDownList20
            Case 21
                drop = DropDownList21
            Case 22
                drop = DropDownList22
            Case 23
                drop = DropDownList23
            Case 24
                drop = DropDownList24
            Case 25
                drop = DropDownList25
            Case 26
                drop = DropDownList26
            Case Else
                drop = New DropDownList()
        End Select

        Return drop

    End Function


    Public Sub checkIfBinSelectedOnceOrMore()
        Dim ddlist As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "BIN" Then
            ddlist.Add(1)
        End If


        If ddlist.Count = 0 Then
            RegMsgBox("Please Select BIN from the Drop Downs associated with the appropriate column")
            Session("bin").Clear()
        ElseIf ddlist.Count > 1 Then
            RegMsgBox("BIN Selected Multiple Times From Drop Down Boxes. Please Select BIN only ONE* time and Click Submit Again")
            Session("bin").Clear()
        Else
            getGridviewHeaderName()
            getGridviewColumnCount()
            CheckForValidationBN()

        End If

    End Sub

    Function checkIfBLSelectedOnceOrMore()
        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList
        Dim ddlist3 As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Block" Then
            ddlist2.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Lot" Then
            ddlist3.Add(1)
        End If

        If ddlist.Count = 0 Then
            RegMsgBox("Please Select Borough from the Drop Downs associated with the appropriate column")

        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select Block from the Drop Downs associated with the appropriate column")

        ElseIf ddlist3.Count = 0 Then
            RegMsgBox("Please Select Lot from the Drop Downs associated with the appropriate column")

        Else
            If Session("boroSelectedTwice") = False And Session("blockSelectedTwice") = False And Session("lotSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()

                CheckForValidationBL()
            Else
                If Session("boroSelectedTwice") = True Then
                    RegMsgBox("Borough Selected Multiple Times From Drop Down Boxes. Please Select Borough only ONE* time and Click Submit Again")
                ElseIf Session("blockSelectedTwice") = True Then
                    RegMsgBox("Block Selected Multiple Times From Drop Down Boxes. Please Select Block only ONE* time and Click Submit Again")
                ElseIf Session("lotSelectedTwice") = True Then
                    RegMsgBox("Lot Selected Multiple Times From Drop Down Boxes. Please Select Lot only ONE* time and Click Submit Again")
                End If
            End If
        End If
        Return Nothing
    End Function


    Public Sub checkIf3SDdListItemsSelectedOnceOrMore()
        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList
        Dim ddlist3 As ArrayList = New ArrayList
        Dim ddlist4 As ArrayList = New ArrayList
        Dim ddlist5 As ArrayList = New ArrayList
        Dim ddlist6 As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Compass Direction 1" Then
            ddlist5.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Compass Direction 2 " Then
            ddlist6.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Compass Direction 2" Then
            ddlist6.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "On Street" Then
            ddlist2.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "First Cross Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Second Cross Street" Then
            ddlist4.Add(1)
        End If

        If ddlist.Count = 0 Then
            RegMsgBox("Please Select Borough from the Drop Downs associated with the appropriate column")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist3.Clear()
            ddlist4.Clear()
            ddlist5.Clear()
            ddlist6.Clear()
        ElseIf ddlist.Count > 1 Then
            RegMsgBox("Borough Selected Multiple Times From Drop Down Boxes. Please Select Borough only ONE* time and Click Submit Again")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist3.Clear()
            ddlist4.Clear()
            ddlist5.Clear()
            ddlist6.Clear()
        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select On Street from the Drop Downs associated with the appropriate column")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist3.Clear()
            ddlist4.Clear()
            ddlist5.Clear()
            ddlist6.Clear()
        ElseIf ddlist5.Count > 1 Then
            RegMsgBox("Compass Direction 1 selected more than once")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist5.Clear()
            ddlist6.Clear()
        ElseIf ddlist6.Count > 1 Then
            RegMsgBox("Compass Direction 2 selected more than once")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist5.Clear()
            ddlist6.Clear()
        ElseIf ddlist2.Count > 1 Then
            RegMsgBox("On Street Selected Multiple Times From Drop Down Boxes. Please Select On Street only ONE* time and Click Submit Again")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist5.Clear()
            ddlist6.Clear()
        ElseIf ddlist3.Count > 1 Then
            RegMsgBox("First Cross Street Selected Multiple Times From Drop Down Boxes. Please Select First Cross Street only ONE* time and Click Submit Again")
            'ElseIf ddlist2.Count = 0 Then
            '    RegMsgBox("Please Select Second Cross Street from the Drop Downs associated with the appropriate column")
        ElseIf ddlist4.Count > 1 Then
            RegMsgBox("Second Cross Street Selected Multiple Times From Drop Down Boxes. Please Select Second Cross Street only ONE* time and Click Submit Again")
        Else
            getGridviewHeaderName()
            getGridviewColumnCount()

            CheckForValidation3S()
        End If

    End Sub

    Function checkIf3ListItemsSelectedOnceOrMore()

        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList
        Dim ddlist3 As ArrayList = New ArrayList
        Dim ddlist4 As ArrayList = New ArrayList
        Dim ddlist5 As ArrayList = New ArrayList
        Dim ddlist6 As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough 3" Then
            ddlist5.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street 3" Then
            ddlist6.Add(1)
        End If

        If ddlist.Count = 0 Then
            RegMsgBox("Please Select Borough 1 From the Drop Downs associated with the appropriate column")
        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select Street 1 from the Drop Downs associated with the appropriate column")
        ElseIf ddlist3.Count = 0 Then
            RegMsgBox("Please Select Borough 2 From the Drop Downs associated with the appropriate column")
        ElseIf ddlist4.Count = 0 Then
            RegMsgBox("Please Select Street 2 from the Drop Downs associated with the appropriate column")
        ElseIf ddlist5.Count = 0 Then
            RegMsgBox("Please Select Borough 3 From the Drop Downs associated with the appropriate column")
        ElseIf ddlist6.Count = 0 Then
            RegMsgBox("Please Select Street 3 from the Drop Downs associated with the appropriate column")
        Else
            If Session("boro1SelectedTwice") = False And Session("boro2SelectedTwice") = False And Session("street1SelectedTwice") = False And Session("street2SelectedTwice") = False And Session("boro3SelectedTwice") = False And Session("street3SelectedTwice") = False And Session("sideOfStreetSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()

                CheckForValidation3()
            Else
                If Session("boro1SelectedTwice") = True Then
                    RegMsgBox("Borough 1 Selected Multiple Times From Drop Down Boxes. Please Select Borough 1 only ONE* time and Click Submit Again")
                ElseIf Session("street1SelectedTwice") = True Then
                    RegMsgBox("Street 1 Selected Multiple Times From Drop Down Boxes. Please Select Street 1 only ONE* time and Click Submit Again")
                ElseIf Session("boro2SelectedTwice") = True Then
                    RegMsgBox("Borough 2 Selected Multiple Times From Drop Down Boxes. Please Select Borough 2 only ONE* time and Click Submit Again")
                ElseIf Session("street2SelectedTwice") = True Then
                    RegMsgBox("Street 2 Selected Multiple Times From Drop Down Boxes. Please Select Street 2 only ONE* time and Click Submit Again")
                ElseIf Session("boro3SelectedTwice") = True Then
                    RegMsgBox("Borough 3 Selected Multiple Times From Drop Down Boxes. Please Select Borough 3 only ONE* time and Click Submit Again")
                ElseIf Session("street3SelectedTwice") = True Then
                    RegMsgBox("Street 3 Selected Multiple Times From Drop Down Boxes. Please Select Street 3 only ONE* time and Click Submit Again")
                ElseIf Session("sideOfStreetSelectedTwice") = True Then
                    RegMsgBox("Side Of Street Selected Multiple Times From Drop Down Boxes. Please Select Side Of Street only ONE* time and Click Submit Again")
                End If
            End If
        End If

        Return Nothing
    End Function

    Function checkIf1NListItemsSelectedOnceOrMore()
        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList0.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList1.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
            ddlist2.Add(1)
        End If

        If ddlist.Count = 0 Then
            RegMsgBox("Please Select Street Code From the Drop Downs associated with the appropriate column")
        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select Borough From the Drop Downs associated with the appropriate column")
        Else
            If Session("streetCodeSelectedTwice") = False Then
                If Session("BoroughSelectedTwice") = False Then
                    getGridviewHeaderName()
                    getGridviewColumnCount()

                    Response.Redirect("OutputSelectPage.aspx", True)
                Else
                    RegMsgBox("Borough Selected Multiple Times From Drop Down Boxes. Please Select Street Code only ONE* time and Click Submit Again")
                End If
            Else
                RegMsgBox("Street Code Selected Multiple Times From Drop Down Boxes. Please Select Street Code only ONE* time and Click Submit Again")
            End If
        End If
        Return Nothing
    End Function

    Function checkIfDListItemsSelectedOnceOrMore()
        Dim ddlist As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street Code" Then
            ddlist.Add(1)
        End If

        If ddlist.Count = 0 Then
            RegMsgBox("Please Select Street Code From the Drop Downs associated with the appropriate column")
        Else
            If Session("streetCodeSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()

                Response.Redirect("OutputSelectPage.aspx", True)
            Else
                RegMsgBox("Street Code Selected Multiple Times From Drop Down Boxes. Please Select Street Code only ONE* time and Click Submit Again")
            End If
        End If
        Return Nothing
    End Function

    Function checkIf1EListItemsSelectedOnceOrMore()

        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList
        Dim ddlist3 As ArrayList = New ArrayList
        Dim ddlist4 As ArrayList = New ArrayList
        Dim ddlist6 As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If

        If ddlist.Count > 1 Then
            Session("boroSelectedTwice") = True
        End If

        If ddlist2.Count > 1 Then
            Session("addressNoSelectedTwice") = True
        End If

        If ddlist3.Count > 1 Then
            Session("streetSelectedTwice") = True
        End If

        If ddlist4.Count > 1 Then
            Session("zipSelectedTwice") = True
        End If

        If ddlist6.Count > 1 Then
            Session("unitNoSelectedTwice") = True
        End If


        If ddlist.Count = 0 And ddlist4.Count = 0 Then
            RegMsgBox("Please Select Zip Code or Borough From the Drop Downs associated with the appropriate column")

        ElseIf ddlist.Count > 0 And ddlist4.Count > 0 Then
            RegMsgBox("Please Select either one of the two (Zip Code or Borough) from the Drop Downs associated with the appropriate column")

        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select AddressNo from the Drop Downs associated with the appropriate column")
        ElseIf ddlist3.Count = 0 Then
            RegMsgBox("Please Select Street from the Drop Downs associated with the appropriate column")
        Else
            If Session("boroSelectedTwice") = False And Session("zipSelectedTwice") = False And Session("addressNoSelectedTwice") = False And Session("streetSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()

                CheckForValidation1E()
            Else
                If Session("boroSelectedTwice") = True Then
                    RegMsgBox("Borough Selected Multiple Times From Drop Down Boxes. Please Select Borough only ONE* time and Click Submit Again")
                ElseIf Session("zipSelectedTwice") = True Then
                    RegMsgBox("Zip Code Selected Multiple Times From Drop Down Boxes. Please Select Zip Code only ONE* time and Click Submit Again")
                ElseIf Session("addressNoSelectedTwice") = True Then
                    RegMsgBox("Address No Selected Multiple Times From Drop Down Boxes. Please Select Address No only ONE* time and Click Submit Again")
                ElseIf Session("streetSelectedTwice") = True Then
                    RegMsgBox("Street Selected Multiple Times From Drop Down Boxes. Please Select Street only ONE* time and Click Submit Again")
                End If
            End If
        End If
        Return Nothing
    End Function

    Function checkIf1AListItemsSelectedOnceOrMore()

        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList
        Dim ddlist3 As ArrayList = New ArrayList
        Dim ddlist4 As ArrayList = New ArrayList
        Dim ddlist6 As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If

        If ddlist.Count > 1 Then
            Session("boroSelectedTwice") = True
        End If

        If ddlist2.Count > 1 Then
            Session("addressNoSelectedTwice") = True
        End If

        If ddlist3.Count > 1 Then
            Session("streetSelectedTwice") = True
        End If

        If ddlist4.Count > 1 Then
            Session("zipSelectedTwice") = True
        End If

        If ddlist6.Count > 1 Then
            Session("unitNoSelectedTwice") = True
        End If


        If ddlist.Count = 0 And ddlist4.Count = 0 Then
            RegMsgBox("Please Select Zip Code or Borough From the Drop Downs associated with the appropriate column")

        ElseIf ddlist.Count > 0 And ddlist4.Count > 0 Then
            RegMsgBox("Please Select either one of the two (Zip Code or Borough) from the Drop Downs associated with the appropriate column")

        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select AddressNo from the Drop Downs associated with the appropriate column")
        ElseIf ddlist3.Count = 0 Then
            RegMsgBox("Please Select Street from the Drop Downs associated with the appropriate column")
        Else
            If Session("boroSelectedTwice") = False And Session("zipSelectedTwice") = False And Session("addressNoSelectedTwice") = False And Session("streetSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()

                CheckForValidation1A()
            Else
                If Session("boroSelectedTwice") = True Then
                    RegMsgBox("Borough Selected Multiple Times From Drop Down Boxes. Please Select Borough only ONE* time and Click Submit Again")
                ElseIf Session("zipSelectedTwice") = True Then
                    RegMsgBox("Zip Code Selected Multiple Times From Drop Down Boxes. Please Select Zip Code only ONE* time and Click Submit Again")
                ElseIf Session("addressNoSelectedTwice") = True Then
                    RegMsgBox("Address No Selected Multiple Times From Drop Down Boxes. Please Select Address No only ONE* time and Click Submit Again")
                ElseIf Session("streetSelectedTwice") = True Then
                    RegMsgBox("Street Selected Multiple Times From Drop Down Boxes. Please Select Street only ONE* time and Click Submit Again")
                End If
            End If
        End If
        Return Nothing
    End Function

    Function checkIf1BListItemsSelectedOnceOrMore()

        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList
        Dim ddlist3 As ArrayList = New ArrayList
        Dim ddlist4 As ArrayList = New ArrayList
        Dim ddlist6 As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough" Then
            ddlist.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Address No" Then
            ddlist2.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street" Then
            ddlist3.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Zip Code" Then
            ddlist4.Add(1)
        End If
        If DropDownList0.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Unit Number" Then
            ddlist6.Add(1)
        End If

        If ddlist.Count > 1 Then
            Session("boroSelectedTwice") = True
        End If

        If ddlist2.Count > 1 Then
            Session("addressNoSelectedTwice") = True
        End If

        If ddlist3.Count > 1 Then
            Session("streetSelectedTwice") = True
        End If

        If ddlist4.Count > 1 Then
            Session("zipSelectedTwice") = True
        End If

        If ddlist6.Count > 1 Then
            Session("unitNoSelectedTwice") = True
        End If


        If ddlist.Count = 0 And ddlist4.Count = 0 Then
            RegMsgBox("Please Select Zip Code or Borough From the Drop Downs associated with the appropriate column")

        ElseIf ddlist.Count > 0 And ddlist4.Count > 0 Then
            RegMsgBox("Please Select either one of the two (Zip Code or Borough) from the Drop Downs associated with the appropriate column")

        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select AddressNo from the Drop Downs associated with the appropriate column")
        ElseIf ddlist3.Count = 0 Then
            RegMsgBox("Please Select Street from the Drop Downs associated with the appropriate column")
        Else
            If Session("boroSelectedTwice") = False And Session("zipSelectedTwice") = False And Session("addressNoSelectedTwice") = False And Session("streetSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()

                CheckForValidation1B()
            Else
                If Session("boroSelectedTwice") = True Then
                    RegMsgBox("Borough Selected Multiple Times From Drop Down Boxes. Please Select Borough only ONE* time and Click Submit Again")
                ElseIf Session("zipSelectedTwice") = True Then
                    RegMsgBox("Zip Code Selected Multiple Times From Drop Down Boxes. Please Select Zip Code only ONE* time and Click Submit Again")
                ElseIf Session("addressNoSelectedTwice") = True Then
                    RegMsgBox("Address No Selected Multiple Times From Drop Down Boxes. Please Select Address No only ONE* time and Click Submit Again")
                ElseIf Session("streetSelectedTwice") = True Then
                    RegMsgBox("Street Selected Multiple Times From Drop Down Boxes. Please Select Street only ONE* time and Click Submit Again")
                End If
            End If
        End If
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

    'took out gridview rows function
    Public Function checkDdItemSelectedTwice()

#Region "1B"
        If Session("Flag") = "1B" Then
            Session("boroSelectedOnce") = False
            Session("boroSelectedTwice") = False
            Session("zipSelectedOnce") = False
            Session(".zipSelectedTwice") = False
            Session("addressNoSelectedOnce") = False
            Session("addressNoSelectedTwice") = False
            Session("streetSelectedOnce") = False
            Session("streetSelectedTwice") = False

            If DropDownList1.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList1.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList1.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList1.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            Else
            End If

        ElseIf Session("Flag") = "N" Then

            If DropDownList1.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Street Name" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            Else
            End If

#End Region

#Region "2"
        ElseIf Session("Flag") = "2" Then
            Session("boro1SelectedOnce") = False
            Session("boro1SelectedTwice") = False
            Session("street1SelectedOnce") = False
            Session("street1SelectedTwice") = False
            Session("boro2SelectedOnce") = False
            Session("boro2SelectedTwice") = False
            Session("street2SelectedOnce") = False
            Session("street2SelectedTwice") = False
            Session("compassDirSelectedOnce") = False
            Session("compassDirSelectedTwice") = False
            If DropDownList1.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Compass Direction" Then
                If Session("compassDirSelectedOnce") = False Then
                    Session("compassDirSelectedOnce") = True
                Else
                    Session("compassDirSelectedTwice") = True
                End If
            End If
#End Region

#Region "3"
        ElseIf Session("Flag") = "3" Then
            Session("boro1SelectedOnce") = False
            Session("boro1SelectedTwice") = False
            Session("street1SelectedOnce") = False
            Session("street1SelectedTwice") = False
            Session("boro2SelectedOnce") = False
            Session("boro2SelectedTwice") = False
            Session("street2SelectedOnce") = False
            Session("street2SelectedTwice") = False
            Session("boro3SelectedOnce") = False
            Session("boro3SelectedTwice") = False
            Session("street3SelectedOnce") = False
            Session("street3SelectedTwice") = False
            Session("sideOfStreetSelectedOnce") = False
            Session("sideOfStreetSelectedTwice") = False
            If DropDownList1.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Borough 1" Then
                If Session("boro1SelectedOnce") = False Then
                    Session("boro1SelectedOnce") = True
                Else
                    Session("boro1SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Street 1" Then
                If Session("street1SelectedOnce") = False Then
                    Session("street1SelectedOnce") = True
                Else
                    Session("street1SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If
            Else
            End If
            If DropDownList2.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Borough 2" Then
                If Session("boro2SelectedOnce") = False Then
                    Session("boro2SelectedOnce") = True
                Else
                    Session("boro2SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Street 2" Then
                If Session("street2SelectedOnce") = False Then
                    Session("street2SelectedOnce") = True
                Else
                    Session("street2SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Borough 3" Then
                If Session("boro3SelectedOnce") = False Then
                    Session("boro3SelectedOnce") = True
                Else
                    Session("boro3SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Street 3" Then
                If Session("street3SelectedOnce") = False Then
                    Session("street3SelectedOnce") = True
                Else
                    Session("street3SelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Side Of Street" Then
                If Session("sideOfStreetSelectedOnce") = False Then
                    Session("sideOfStreetSelectedOnce") = True
                Else
                    Session("sideOfStreetSelectedTwice") = True
                End If
            End If

#End Region

#Region "3S"

        ElseIf Session("Flag") = "3S" Then
            Session("boro3SSelectedOnce") = False
            Session("boro3SSelectedTwice") = False
            Session("onStreet3SSelectedOnce") = False
            Session("onStreet3SSelectedTwice") = False
            Session("firstXStreet3SSelectedOnce") = False
            Session("firstXStreet3SSelectedTwice") = False
            Session("secondXStreet3SSelectedOnce") = False
            Session("secondXStreet3SSelectedTwice") = False
            If DropDownList1.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
                If Session("boro3SSelectedOnce") = False Then
                    Session("boro3SSelectedOnce") = True
                Else
                    Session("boro3SSelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "On Street" Then
                If Session("onStreet3SSelectedOnce") = False Then
                    Session("onStreet3SSelectedOnce") = True
                Else
                    Session("onStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "First Cross Street" Then
                If Session("firstXStreet3SSelectedOnce") = False Then
                    Session("firstXStreet3SSelectedOnce") = True
                Else
                    Session("firstXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If


            ElseIf DropDownList12.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Second Cross Street" Then
                If Session("secondXStreet3SSelectedOnce") = False Then
                    Session("secondXStreet3SSelectedOnce") = True
                Else
                    Session("secondXStreet3SSelectedTwice") = True
                End If
            End If

#End Region

#Region "BN"

        ElseIf Session("Flag") = "BN" Then
            Session("binSelectedOnce") = False
            Session("binSelectedTwice") = False

            If DropDownList1.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If
            ElseIf DropDownList3.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If
            ElseIf DropDownList23.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "BIN" Then
                If Session("binSelectedOnce") = False Then
                    Session("binSelectedOnce") = True
                Else
                    Session("binSelectedTwice") = True
                End If
            End If


#End Region

#Region "BL"

        ElseIf Session("Flag") = "BL" Then
            Session("boroSelectedOnce") = False
            Session("boroSelectedTwice") = False
            Session("blockSelectedOnce") = False
            Session("blockSelectedTwice") = False
            Session("lotSelectedOnce") = False
            Session("lotSelectedTwice") = False
            If DropDownList1.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If

            ElseIf DropDownList1.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If


            ElseIf DropDownList20.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If
            Else
            End If
            If DropDownList24.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Block" Then
                If Session("blockSelectedOnce") = False Then
                    Session("blockSelectedOnce") = True
                Else
                    Session("blockSelectedTwice") = True
                End If


            ElseIf DropDownList1.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Lot" Then
                If Session("lotSelectedOnce") = False Then
                    Session("lotSelectedOnce") = True
                Else
                    Session("lotSelectedTwice") = True
                End If
            End If


#End Region

#Region "N"

        ElseIf Session("Flag") = "N" Then

            Session("streetSelectedOnce") = False
            Session("streetSelectedTwice") = False


            If DropDownList1.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            Else
            End If


#End Region

#Region "AP"

        ElseIf Session("Flag") = "AP" Then
            Session("boroSelectedOnce") = False
            Session("boroSelectedTwice") = False
            Session("zipSelectedOnce") = False
            Session(".zipSelectedTwice") = False
            Session("addressNoSelectedOnce") = False
            Session("addressNoSelectedTwice") = False
            Session("streetSelectedOnce") = False
            Session("streetSelectedTwice") = False

            If DropDownList1.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Borough" Then
                If Session("boroSelectedOnce") = False Then
                    Session("boroSelectedOnce") = True
                Else
                    Session("boroSelectedTwice") = True
                End If
            End If

            If DropDownList1.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Zip Code" Then
                If Session("zipSelectedOnce") = False Then
                    Session("zipSelectedOnce") = True
                Else
                    Session(".zipSelectedTwice") = True
                End If
            End If

            If DropDownList1.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Address No" Then
                If Session("addressNoSelectedOnce") = False Then
                    Session("addressNoSelectedOnce") = True
                Else
                    Session("addressNoSelectedTwice") = True
                End If
            End If

            If DropDownList1.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList2.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList3.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList4.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList5.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList6.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList7.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList8.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList9.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList10.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList11.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList12.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList13.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList14.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList15.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList16.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList17.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList18.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList19.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList20.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList21.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList22.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList23.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList24.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList25.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            End If

            If DropDownList26.SelectedItem.ToString = "Street" Then
                If Session("streetSelectedOnce") = False Then
                    Session("streetSelectedOnce") = True
                Else
                    Session("streetSelectedTwice") = True
                End If
            Else
            End If

#End Region

#Region "D"
        ElseIf Session("Flag") = "D" Then

            Session("streetCodeSelectedOnce") = False
            Session("streetCodeSelectedTwice") = False


            If DropDownList1.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList2.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList3.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList4.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList5.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList6.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList7.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList8.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList9.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList10.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList11.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList12.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList13.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList14.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList15.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList16.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList17.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList18.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList19.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList20.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList21.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList22.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList23.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList24.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList25.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If

            ElseIf DropDownList26.SelectedItem.ToString = "Street Code" Then
                If Session("streetCodeSelectedOnce") = False Then
                    Session("streetCodeSelectedOnce") = True
                Else
                    Session("streetCodeSelectedTwice") = True
                End If
            Else
            End If
        End If
#End Region

        Return Nothing
    End Function

    Public Function checkIfNameCodeNSelectedOnceOrMore()

        Dim ddlist As ArrayList = New ArrayList

        If DropDownList0.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street Name" Then
            ddlist.Add(1)
        End If


        If ddlist.Count = 0 Then
            RegMsgBox("Please Select Street Name from the Drop Downs associated with the appropriate column")
            ddlist.Clear()
        Else
            If Session("streetSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()
                CheckForValidationN()
            Else
                If ddlist.Count > 1 Then
                    RegMsgBox("Street Name Selected Multiple Times From Drop Down Boxes. Please Select Borough only ONE* time And Click Submit Again")
                End If
            End If
        End If

        Return Nothing
    End Function

    Protected Sub BackImageButton_Click(sender As Object, e As ImageClickEventArgs) Handles BackImageButton.Click
        '--Clearing all arrays on back button click to start a new array builder when new values from dropdown's are selected
        Response.Redirect("UploadFile.aspx")
    End Sub
    Public Function addDropDowns()
        If Session("Flag") = "AP" Then
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough")
            DropDownList1.Items.Add("Zip Code")
            DropDownList1.Items.Add("Address No")
            DropDownList1.Items.Add("Street")
            DropDownList1.Items.Add("Unit Number")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough")
            DropDownList2.Items.Add("Zip Code")
            DropDownList2.Items.Add("Address No")
            DropDownList2.Items.Add("Street")
            DropDownList2.Items.Add("Unit Number")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough")
            DropDownList3.Items.Add("Zip Code")
            DropDownList3.Items.Add("Address No")
            DropDownList3.Items.Add("Street")
            DropDownList3.Items.Add("Unit Number")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough")
            DropDownList4.Items.Add("Zip Code")
            DropDownList4.Items.Add("Address No")
            DropDownList4.Items.Add("Street")
            DropDownList4.Items.Add("Unit Number")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough")
            DropDownList5.Items.Add("Zip Code")
            DropDownList5.Items.Add("Address No")
            DropDownList5.Items.Add("Street")
            DropDownList5.Items.Add("Unit Number")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough")
            DropDownList6.Items.Add("Zip Code")
            DropDownList6.Items.Add("Address No")
            DropDownList6.Items.Add("Street")
            DropDownList6.Items.Add("Unit Number")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough")
            DropDownList7.Items.Add("Zip Code")
            DropDownList7.Items.Add("Address No")
            DropDownList7.Items.Add("Street")
            DropDownList7.Items.Add("Unit Number")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough")
            DropDownList8.Items.Add("Zip Code")
            DropDownList8.Items.Add("Address No")
            DropDownList8.Items.Add("Street")
            DropDownList8.Items.Add("Unit Number")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough")
            DropDownList9.Items.Add("Zip Code")
            DropDownList9.Items.Add("Address No")
            DropDownList9.Items.Add("Street")
            DropDownList9.Items.Add("Unit Number")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough")
            DropDownList10.Items.Add("Zip Code")
            DropDownList10.Items.Add("Address No")
            DropDownList10.Items.Add("Street")
            DropDownList10.Items.Add("Unit Number")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough")
            DropDownList11.Items.Add("Zip Code")
            DropDownList11.Items.Add("Address No")
            DropDownList11.Items.Add("Street")
            DropDownList11.Items.Add("Unit Number")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough")
            DropDownList12.Items.Add("Zip Code")
            DropDownList12.Items.Add("Address No")
            DropDownList12.Items.Add("Street")
            DropDownList12.Items.Add("Unit Number")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough")
            DropDownList13.Items.Add("Zip Code")
            DropDownList13.Items.Add("Address No")
            DropDownList13.Items.Add("Street")
            DropDownList13.Items.Add("Unit Number")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough")
            DropDownList14.Items.Add("Zip Code")
            DropDownList14.Items.Add("Address No")
            DropDownList14.Items.Add("Street")
            DropDownList14.Items.Add("Unit Number")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough")
            DropDownList15.Items.Add("Zip Code")
            DropDownList15.Items.Add("Address No")
            DropDownList15.Items.Add("Street")
            DropDownList15.Items.Add("Unit Number")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough")
            DropDownList16.Items.Add("Zip Code")
            DropDownList16.Items.Add("Address No")
            DropDownList16.Items.Add("Street")
            DropDownList16.Items.Add("Unit Number")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough")
            DropDownList17.Items.Add("Zip Code")
            DropDownList17.Items.Add("Address No")
            DropDownList17.Items.Add("Street")
            DropDownList17.Items.Add("Unit Number")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough")
            DropDownList18.Items.Add("Zip Code")
            DropDownList18.Items.Add("Address No")
            DropDownList18.Items.Add("Street")
            DropDownList18.Items.Add("Unit Number")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough")
            DropDownList19.Items.Add("Zip Code")
            DropDownList19.Items.Add("Address No")
            DropDownList19.Items.Add("Street")
            DropDownList19.Items.Add("Unit Number")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough")
            DropDownList20.Items.Add("Zip Code")
            DropDownList20.Items.Add("Address No")
            DropDownList20.Items.Add("Street")
            DropDownList20.Items.Add("Unit Number")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough")
            DropDownList21.Items.Add("Zip Code")
            DropDownList21.Items.Add("Address No")
            DropDownList21.Items.Add("Street")
            DropDownList21.Items.Add("Unit Number")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough")
            DropDownList22.Items.Add("Zip Code")
            DropDownList22.Items.Add("Address No")
            DropDownList22.Items.Add("Street")
            DropDownList22.Items.Add("Unit Number")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough")
            DropDownList23.Items.Add("Zip Code")
            DropDownList23.Items.Add("Address No")
            DropDownList23.Items.Add("Street")
            DropDownList23.Items.Add("Unit Number")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough")
            DropDownList24.Items.Add("Zip Code")
            DropDownList24.Items.Add("Address No")
            DropDownList24.Items.Add("Street")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough")
            DropDownList25.Items.Add("Zip Code")
            DropDownList25.Items.Add("Address No")
            DropDownList25.Items.Add("Street")
            DropDownList25.Items.Add("Unit Number")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough")
            DropDownList26.Items.Add("Zip Code")
            DropDownList26.Items.Add("Address No")
            DropDownList26.Items.Add("Street")
            DropDownList26.Items.Add("Unit Number")

        ElseIf Session("Flag") = "1B" Then
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough")
            DropDownList1.Items.Add("Zip Code")
            DropDownList1.Items.Add("Address No")
            DropDownList1.Items.Add("Street")
            'DropDownList1.Items.Add("Unit Number")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough")
            DropDownList2.Items.Add("Zip Code")
            DropDownList2.Items.Add("Address No")
            DropDownList2.Items.Add("Street")
            'DropDownList2.Items.Add("Unit Number")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough")
            DropDownList3.Items.Add("Zip Code")
            DropDownList3.Items.Add("Address No")
            DropDownList3.Items.Add("Street")
            'DropDownList3.Items.Add("Unit Number")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough")
            DropDownList4.Items.Add("Zip Code")
            DropDownList4.Items.Add("Address No")
            DropDownList4.Items.Add("Street")
            'DropDownList4.Items.Add("Unit Number")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough")
            DropDownList5.Items.Add("Zip Code")
            DropDownList5.Items.Add("Address No")
            DropDownList5.Items.Add("Street")
            'DropDownList5.Items.Add("Unit Number")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough")
            DropDownList6.Items.Add("Zip Code")
            DropDownList6.Items.Add("Address No")
            DropDownList6.Items.Add("Street")
            'DropDownList6.Items.Add("Unit Number")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough")
            DropDownList7.Items.Add("Zip Code")
            DropDownList7.Items.Add("Address No")
            DropDownList7.Items.Add("Street")
            ' DropDownList7.Items.Add("Unit Number")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough")
            DropDownList8.Items.Add("Zip Code")
            DropDownList8.Items.Add("Address No")
            DropDownList8.Items.Add("Street")
            ' DropDownList8.Items.Add("Unit Number")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough")
            DropDownList9.Items.Add("Zip Code")
            DropDownList9.Items.Add("Address No")
            DropDownList9.Items.Add("Street")
            'DropDownList9.Items.Add("Unit Number")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough")
            DropDownList10.Items.Add("Zip Code")
            DropDownList10.Items.Add("Address No")
            DropDownList10.Items.Add("Street")
            ' DropDownList10.Items.Add("Unit Number")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough")
            DropDownList11.Items.Add("Zip Code")
            DropDownList11.Items.Add("Address No")
            DropDownList11.Items.Add("Street")
            ' DropDownList11.Items.Add("Unit Number")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough")
            DropDownList12.Items.Add("Zip Code")
            DropDownList12.Items.Add("Address No")
            DropDownList12.Items.Add("Street")
            '  DropDownList12.Items.Add("Unit Number")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough")
            DropDownList13.Items.Add("Zip Code")
            DropDownList13.Items.Add("Address No")
            DropDownList13.Items.Add("Street")
            ' DropDownList13.Items.Add("Unit Number")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough")
            DropDownList14.Items.Add("Zip Code")
            DropDownList14.Items.Add("Address No")
            DropDownList14.Items.Add("Street")
            ' DropDownList14.Items.Add("Unit Number")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough")
            DropDownList15.Items.Add("Zip Code")
            DropDownList15.Items.Add("Address No")
            DropDownList15.Items.Add("Street")
            ' DropDownList15.Items.Add("Unit Number")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough")
            DropDownList16.Items.Add("Zip Code")
            DropDownList16.Items.Add("Address No")
            DropDownList16.Items.Add("Street")
            '  DropDownList16.Items.Add("Unit Number")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough")
            DropDownList17.Items.Add("Zip Code")
            DropDownList17.Items.Add("Address No")
            DropDownList17.Items.Add("Street")
            ' DropDownList17.Items.Add("Unit Number")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough")
            DropDownList18.Items.Add("Zip Code")
            DropDownList18.Items.Add("Address No")
            DropDownList18.Items.Add("Street")
            ' DropDownList18.Items.Add("Unit Number")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough")
            DropDownList19.Items.Add("Zip Code")
            DropDownList19.Items.Add("Address No")
            DropDownList19.Items.Add("Street")
            ' DropDownList19.Items.Add("Unit Number")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough")
            DropDownList20.Items.Add("Zip Code")
            DropDownList20.Items.Add("Address No")
            DropDownList20.Items.Add("Street")
            ' DropDownList20.Items.Add("Unit Number")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough")
            DropDownList21.Items.Add("Zip Code")
            DropDownList21.Items.Add("Address No")
            DropDownList21.Items.Add("Street")
            ' DropDownList21.Items.Add("Unit Number")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough")
            DropDownList22.Items.Add("Zip Code")
            DropDownList22.Items.Add("Address No")
            DropDownList22.Items.Add("Street")
            ' DropDownList22.Items.Add("Unit Number")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough")
            DropDownList23.Items.Add("Zip Code")
            DropDownList23.Items.Add("Address No")
            DropDownList23.Items.Add("Street")
            ' DropDownList23.Items.Add("Unit Number")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough")
            DropDownList24.Items.Add("Zip Code")
            DropDownList24.Items.Add("Address No")
            DropDownList24.Items.Add("Street")
            'DropDownList25.Items.Add("Unit Number")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough")
            DropDownList25.Items.Add("Zip Code")
            DropDownList25.Items.Add("Address No")
            DropDownList25.Items.Add("Street")
            '  DropDownList25.Items.Add("Unit Number")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough")
            DropDownList26.Items.Add("Zip Code")
            DropDownList26.Items.Add("Address No")
            DropDownList26.Items.Add("Street")
            '  DropDownList26.Items.Add("Unit Number")

        ElseIf Session("Flag") = "1E" Then
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough")
            DropDownList1.Items.Add("Zip Code")
            DropDownList1.Items.Add("Address No")
            DropDownList1.Items.Add("Street")
            'DropDownList1.Items.Add("Unit Number")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough")
            DropDownList2.Items.Add("Zip Code")
            DropDownList2.Items.Add("Address No")
            DropDownList2.Items.Add("Street")
            'DropDownList2.Items.Add("Unit Number")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough")
            DropDownList3.Items.Add("Zip Code")
            DropDownList3.Items.Add("Address No")
            DropDownList3.Items.Add("Street")
            'DropDownList3.Items.Add("Unit Number")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough")
            DropDownList4.Items.Add("Zip Code")
            DropDownList4.Items.Add("Address No")
            DropDownList4.Items.Add("Street")
            'DropDownList4.Items.Add("Unit Number")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough")
            DropDownList5.Items.Add("Zip Code")
            DropDownList5.Items.Add("Address No")
            DropDownList5.Items.Add("Street")
            'DropDownList5.Items.Add("Unit Number")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough")
            DropDownList6.Items.Add("Zip Code")
            DropDownList6.Items.Add("Address No")
            DropDownList6.Items.Add("Street")
            'DropDownList6.Items.Add("Unit Number")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough")
            DropDownList7.Items.Add("Zip Code")
            DropDownList7.Items.Add("Address No")
            DropDownList7.Items.Add("Street")
            ' DropDownList7.Items.Add("Unit Number")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough")
            DropDownList8.Items.Add("Zip Code")
            DropDownList8.Items.Add("Address No")
            DropDownList8.Items.Add("Street")
            ' DropDownList8.Items.Add("Unit Number")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough")
            DropDownList9.Items.Add("Zip Code")
            DropDownList9.Items.Add("Address No")
            DropDownList9.Items.Add("Street")
            'DropDownList9.Items.Add("Unit Number")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough")
            DropDownList10.Items.Add("Zip Code")
            DropDownList10.Items.Add("Address No")
            DropDownList10.Items.Add("Street")
            ' DropDownList10.Items.Add("Unit Number")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough")
            DropDownList11.Items.Add("Zip Code")
            DropDownList11.Items.Add("Address No")
            DropDownList11.Items.Add("Street")
            ' DropDownList11.Items.Add("Unit Number")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough")
            DropDownList12.Items.Add("Zip Code")
            DropDownList12.Items.Add("Address No")
            DropDownList12.Items.Add("Street")
            '  DropDownList12.Items.Add("Unit Number")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough")
            DropDownList13.Items.Add("Zip Code")
            DropDownList13.Items.Add("Address No")
            DropDownList13.Items.Add("Street")
            ' DropDownList13.Items.Add("Unit Number")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough")
            DropDownList14.Items.Add("Zip Code")
            DropDownList14.Items.Add("Address No")
            DropDownList14.Items.Add("Street")
            ' DropDownList14.Items.Add("Unit Number")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough")
            DropDownList15.Items.Add("Zip Code")
            DropDownList15.Items.Add("Address No")
            DropDownList15.Items.Add("Street")
            ' DropDownList15.Items.Add("Unit Number")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough")
            DropDownList16.Items.Add("Zip Code")
            DropDownList16.Items.Add("Address No")
            DropDownList16.Items.Add("Street")
            '  DropDownList16.Items.Add("Unit Number")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough")
            DropDownList17.Items.Add("Zip Code")
            DropDownList17.Items.Add("Address No")
            DropDownList17.Items.Add("Street")
            ' DropDownList17.Items.Add("Unit Number")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough")
            DropDownList18.Items.Add("Zip Code")
            DropDownList18.Items.Add("Address No")
            DropDownList18.Items.Add("Street")
            ' DropDownList18.Items.Add("Unit Number")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough")
            DropDownList19.Items.Add("Zip Code")
            DropDownList19.Items.Add("Address No")
            DropDownList19.Items.Add("Street")
            ' DropDownList19.Items.Add("Unit Number")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough")
            DropDownList20.Items.Add("Zip Code")
            DropDownList20.Items.Add("Address No")
            DropDownList20.Items.Add("Street")
            ' DropDownList20.Items.Add("Unit Number")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough")
            DropDownList21.Items.Add("Zip Code")
            DropDownList21.Items.Add("Address No")
            DropDownList21.Items.Add("Street")
            ' DropDownList21.Items.Add("Unit Number")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough")
            DropDownList22.Items.Add("Zip Code")
            DropDownList22.Items.Add("Address No")
            DropDownList22.Items.Add("Street")
            ' DropDownList22.Items.Add("Unit Number")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough")
            DropDownList23.Items.Add("Zip Code")
            DropDownList23.Items.Add("Address No")
            DropDownList23.Items.Add("Street")
            ' DropDownList23.Items.Add("Unit Number")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough")
            DropDownList24.Items.Add("Zip Code")
            DropDownList24.Items.Add("Address No")
            DropDownList24.Items.Add("Street")
            'DropDownList25.Items.Add("Unit Number")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough")
            DropDownList25.Items.Add("Zip Code")
            DropDownList25.Items.Add("Address No")
            DropDownList25.Items.Add("Street")
            '  DropDownList25.Items.Add("Unit Number")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough")
            DropDownList26.Items.Add("Zip Code")
            DropDownList26.Items.Add("Address No")
            DropDownList26.Items.Add("Street")
            '  DropDownList26.Items.Add("Unit Number")

        ElseIf Session("Flag") = "1A" Then
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough")
            DropDownList1.Items.Add("Zip Code")
            DropDownList1.Items.Add("Address No")
            DropDownList1.Items.Add("Street")
            'DropDownList1.Items.Add("Unit Number")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough")
            DropDownList2.Items.Add("Zip Code")
            DropDownList2.Items.Add("Address No")
            DropDownList2.Items.Add("Street")
            'DropDownList2.Items.Add("Unit Number")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough")
            DropDownList3.Items.Add("Zip Code")
            DropDownList3.Items.Add("Address No")
            DropDownList3.Items.Add("Street")
            'DropDownList3.Items.Add("Unit Number")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough")
            DropDownList4.Items.Add("Zip Code")
            DropDownList4.Items.Add("Address No")
            DropDownList4.Items.Add("Street")
            'DropDownList4.Items.Add("Unit Number")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough")
            DropDownList5.Items.Add("Zip Code")
            DropDownList5.Items.Add("Address No")
            DropDownList5.Items.Add("Street")
            'DropDownList5.Items.Add("Unit Number")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough")
            DropDownList6.Items.Add("Zip Code")
            DropDownList6.Items.Add("Address No")
            DropDownList6.Items.Add("Street")
            'DropDownList6.Items.Add("Unit Number")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough")
            DropDownList7.Items.Add("Zip Code")
            DropDownList7.Items.Add("Address No")
            DropDownList7.Items.Add("Street")
            ' DropDownList7.Items.Add("Unit Number")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough")
            DropDownList8.Items.Add("Zip Code")
            DropDownList8.Items.Add("Address No")
            DropDownList8.Items.Add("Street")
            ' DropDownList8.Items.Add("Unit Number")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough")
            DropDownList9.Items.Add("Zip Code")
            DropDownList9.Items.Add("Address No")
            DropDownList9.Items.Add("Street")
            'DropDownList9.Items.Add("Unit Number")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough")
            DropDownList10.Items.Add("Zip Code")
            DropDownList10.Items.Add("Address No")
            DropDownList10.Items.Add("Street")
            ' DropDownList10.Items.Add("Unit Number")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough")
            DropDownList11.Items.Add("Zip Code")
            DropDownList11.Items.Add("Address No")
            DropDownList11.Items.Add("Street")
            ' DropDownList11.Items.Add("Unit Number")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough")
            DropDownList12.Items.Add("Zip Code")
            DropDownList12.Items.Add("Address No")
            DropDownList12.Items.Add("Street")
            '  DropDownList12.Items.Add("Unit Number")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough")
            DropDownList13.Items.Add("Zip Code")
            DropDownList13.Items.Add("Address No")
            DropDownList13.Items.Add("Street")
            ' DropDownList13.Items.Add("Unit Number")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough")
            DropDownList14.Items.Add("Zip Code")
            DropDownList14.Items.Add("Address No")
            DropDownList14.Items.Add("Street")
            ' DropDownList14.Items.Add("Unit Number")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough")
            DropDownList15.Items.Add("Zip Code")
            DropDownList15.Items.Add("Address No")
            DropDownList15.Items.Add("Street")
            ' DropDownList15.Items.Add("Unit Number")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough")
            DropDownList16.Items.Add("Zip Code")
            DropDownList16.Items.Add("Address No")
            DropDownList16.Items.Add("Street")
            '  DropDownList16.Items.Add("Unit Number")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough")
            DropDownList17.Items.Add("Zip Code")
            DropDownList17.Items.Add("Address No")
            DropDownList17.Items.Add("Street")
            ' DropDownList17.Items.Add("Unit Number")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough")
            DropDownList18.Items.Add("Zip Code")
            DropDownList18.Items.Add("Address No")
            DropDownList18.Items.Add("Street")
            ' DropDownList18.Items.Add("Unit Number")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough")
            DropDownList19.Items.Add("Zip Code")
            DropDownList19.Items.Add("Address No")
            DropDownList19.Items.Add("Street")
            ' DropDownList19.Items.Add("Unit Number")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough")
            DropDownList20.Items.Add("Zip Code")
            DropDownList20.Items.Add("Address No")
            DropDownList20.Items.Add("Street")
            ' DropDownList20.Items.Add("Unit Number")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough")
            DropDownList21.Items.Add("Zip Code")
            DropDownList21.Items.Add("Address No")
            DropDownList21.Items.Add("Street")
            ' DropDownList21.Items.Add("Unit Number")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough")
            DropDownList22.Items.Add("Zip Code")
            DropDownList22.Items.Add("Address No")
            DropDownList22.Items.Add("Street")
            ' DropDownList22.Items.Add("Unit Number")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough")
            DropDownList23.Items.Add("Zip Code")
            DropDownList23.Items.Add("Address No")
            DropDownList23.Items.Add("Street")
            ' DropDownList23.Items.Add("Unit Number")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough")
            DropDownList24.Items.Add("Zip Code")
            DropDownList24.Items.Add("Address No")
            DropDownList24.Items.Add("Street")
            'DropDownList25.Items.Add("Unit Number")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough")
            DropDownList25.Items.Add("Zip Code")
            DropDownList25.Items.Add("Address No")
            DropDownList25.Items.Add("Street")
            '  DropDownList25.Items.Add("Unit Number")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough")
            DropDownList26.Items.Add("Zip Code")
            DropDownList26.Items.Add("Address No")
            DropDownList26.Items.Add("Street")
            '  DropDownList26.Items.Add("Unit Number")

        ElseIf Session("Flag") = "2" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough 1")
            DropDownList1.Items.Add("Street 1")
            DropDownList1.Items.Add("Borough 2")
            DropDownList1.Items.Add("Street 2")
            DropDownList1.Items.Add("Compass Direction")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough 1")
            DropDownList2.Items.Add("Street 1")
            DropDownList2.Items.Add("Borough 2")
            DropDownList2.Items.Add("Street 2")
            DropDownList2.Items.Add("Compass Direction")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough 1")
            DropDownList3.Items.Add("Street 1")
            DropDownList3.Items.Add("Borough 2")
            DropDownList3.Items.Add("Street 2")
            DropDownList3.Items.Add("Compass Direction")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough 1")
            DropDownList4.Items.Add("Street 1")
            DropDownList4.Items.Add("Borough 2")
            DropDownList4.Items.Add("Street 2")
            DropDownList4.Items.Add("Compass Direction")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough 1")
            DropDownList5.Items.Add("Street 1")
            DropDownList5.Items.Add("Borough 2")
            DropDownList5.Items.Add("Street 2")
            DropDownList5.Items.Add("Compass Direction")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough 1")
            DropDownList6.Items.Add("Street 1")
            DropDownList6.Items.Add("Borough 2")
            DropDownList6.Items.Add("Street 2")
            DropDownList6.Items.Add("Compass Direction")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough 1")
            DropDownList7.Items.Add("Street 1")
            DropDownList7.Items.Add("Borough 2")
            DropDownList7.Items.Add("Street 2")
            DropDownList7.Items.Add("Compass Direction")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough 1")
            DropDownList8.Items.Add("Street 1")
            DropDownList8.Items.Add("Borough 2")
            DropDownList8.Items.Add("Street 2")
            DropDownList8.Items.Add("Compass Direction")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough 1")
            DropDownList9.Items.Add("Street 1")
            DropDownList9.Items.Add("Borough 2")
            DropDownList9.Items.Add("Street 2")
            DropDownList9.Items.Add("Compass Direction")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough 1")
            DropDownList10.Items.Add("Street 1")
            DropDownList10.Items.Add("Borough 2")
            DropDownList10.Items.Add("Street 2")
            DropDownList10.Items.Add("Compass Direction")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough 1")
            DropDownList11.Items.Add("Street 1")
            DropDownList11.Items.Add("Borough 2")
            DropDownList11.Items.Add("Street 2")
            DropDownList11.Items.Add("Compass Direction")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough 1")
            DropDownList12.Items.Add("Street 1")
            DropDownList12.Items.Add("Borough 2")
            DropDownList12.Items.Add("Street 2")
            DropDownList12.Items.Add("Compass Direction")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough 1")
            DropDownList13.Items.Add("Street 1")
            DropDownList13.Items.Add("Borough 2")
            DropDownList13.Items.Add("Street 2")
            DropDownList13.Items.Add("Compass Direction")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough 1")
            DropDownList14.Items.Add("Street 1")
            DropDownList14.Items.Add("Borough 2")
            DropDownList14.Items.Add("Street 2")
            DropDownList14.Items.Add("Compass Direction")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough 1")
            DropDownList15.Items.Add("Street 1")
            DropDownList15.Items.Add("Borough 2")
            DropDownList15.Items.Add("Street 2")
            DropDownList15.Items.Add("Compass Direction")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough 1")
            DropDownList16.Items.Add("Street 1")
            DropDownList16.Items.Add("Borough 2")
            DropDownList16.Items.Add("Street 2")
            DropDownList16.Items.Add("Compass Direction")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough 1")
            DropDownList17.Items.Add("Street 1")
            DropDownList17.Items.Add("Borough 2")
            DropDownList17.Items.Add("Street 2")
            DropDownList17.Items.Add("Compass Direction")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough 1")
            DropDownList18.Items.Add("Street 1")
            DropDownList18.Items.Add("Borough 2")
            DropDownList18.Items.Add("Street 2")
            DropDownList18.Items.Add("Compass Direction")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough 1")
            DropDownList19.Items.Add("Street 1")
            DropDownList19.Items.Add("Borough 2")
            DropDownList19.Items.Add("Street 2")
            DropDownList19.Items.Add("Compass Direction")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough 1")
            DropDownList20.Items.Add("Street 1")
            DropDownList20.Items.Add("Borough 2")
            DropDownList20.Items.Add("Street 2")
            DropDownList20.Items.Add("Compass Direction")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough 1")
            DropDownList21.Items.Add("Street 1")
            DropDownList21.Items.Add("Borough 2")
            DropDownList21.Items.Add("Street 2")
            DropDownList21.Items.Add("Compass Direction")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough 1")
            DropDownList22.Items.Add("Street 1")
            DropDownList22.Items.Add("Borough 2")
            DropDownList22.Items.Add("Street 2")
            DropDownList22.Items.Add("Compass Direction")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough 1")
            DropDownList23.Items.Add("Street 1")
            DropDownList23.Items.Add("Borough 2")
            DropDownList23.Items.Add("Street 2")
            DropDownList23.Items.Add("Compass Direction")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough 1")
            DropDownList24.Items.Add("Street 1")
            DropDownList24.Items.Add("Borough 2")
            DropDownList24.Items.Add("Street 2")
            DropDownList24.Items.Add("Compass Direction")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough 1")
            DropDownList25.Items.Add("Street 1")
            DropDownList25.Items.Add("Borough 2")
            DropDownList25.Items.Add("Street 2")
            DropDownList25.Items.Add("Compass Direction")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough 1")
            DropDownList26.Items.Add("Street 1")
            DropDownList26.Items.Add("Borough 2")
            DropDownList26.Items.Add("Street 2")
            DropDownList26.Items.Add("Compass Direction")

        ElseIf Session("Flag") = "N" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Street Name")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Street Name")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Street Name")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Street Name")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Street Name")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Street Name")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Street Name")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Street Name")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Street Name")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Street Name")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Street Name")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Street Name")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Street Name")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Street Name")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Street Name")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Street Name")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Street Name")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Street Name")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Street Name")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Street Name")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Street Name")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Street Name")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Street Name")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Street Name")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Street Name")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Street Name")

        ElseIf Session("Flag") = "1N" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Street Name")
            DropDownList1.Items.Add("Borough")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Street Name")
            DropDownList2.Items.Add("Borough")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Street Name")
            DropDownList3.Items.Add("Borough")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Street Name")
            DropDownList4.Items.Add("Borough")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Street Name")
            DropDownList5.Items.Add("Borough")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Street Name")
            DropDownList6.Items.Add("Borough")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Street Name")
            DropDownList7.Items.Add("Borough")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Street Name")
            DropDownList8.Items.Add("Borough")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Street Name")
            DropDownList9.Items.Add("Borough")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Street Name")
            DropDownList10.Items.Add("Borough")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Street Name")
            DropDownList11.Items.Add("Borough")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Street Name")
            DropDownList12.Items.Add("Borough")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Street Name")
            DropDownList13.Items.Add("Borough")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Street Name")
            DropDownList14.Items.Add("Borough")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Street Name")
            DropDownList15.Items.Add("Borough")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Street Name")
            DropDownList16.Items.Add("Borough")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Street Name")
            DropDownList17.Items.Add("Borough")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Street Name")
            DropDownList18.Items.Add("Borough")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Street Name")
            DropDownList19.Items.Add("Borough")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Street Name")
            DropDownList20.Items.Add("Borough")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Street Name")
            DropDownList21.Items.Add("Borough")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Street Name")
            DropDownList22.Items.Add("Borough")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Street Name")
            DropDownList23.Items.Add("Borough")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Street Name")
            DropDownList24.Items.Add("Borough")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Street Name")
            DropDownList25.Items.Add("Borough")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Street Name")
            DropDownList26.Items.Add("Borough")

        ElseIf Session("Flag") = "D" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Street Code")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Street Code")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Street Code")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Street Code")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Street Code")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Street Code")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Street Code")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Street Code")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Street Code")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Street Code")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Street Code")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Street Code")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Street Code")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Street Code")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Street Code")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Street Code")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Street Code")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Street Code")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Street Code")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Street Code")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Street Code")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Street Code")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Street Code")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Street Code")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Street Code")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Street Code")

        ElseIf Session("Flag") = "3" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough 1")
            DropDownList1.Items.Add("Street 1")
            DropDownList1.Items.Add("Borough 2")
            DropDownList1.Items.Add("Street 2")
            DropDownList1.Items.Add("Borough 3")
            DropDownList1.Items.Add("Street 3")
            DropDownList1.Items.Add("Side Of Street")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough 1")
            DropDownList2.Items.Add("Street 1")
            DropDownList2.Items.Add("Borough 2")
            DropDownList2.Items.Add("Street 2")
            DropDownList2.Items.Add("Borough 3")
            DropDownList2.Items.Add("Street 3")
            DropDownList2.Items.Add("Side Of Street")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough 1")
            DropDownList3.Items.Add("Street 1")
            DropDownList3.Items.Add("Borough 2")
            DropDownList3.Items.Add("Street 2")
            DropDownList3.Items.Add("Borough 3")
            DropDownList3.Items.Add("Street 3")
            DropDownList3.Items.Add("Side Of Street")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough 1")
            DropDownList4.Items.Add("Street 1")
            DropDownList4.Items.Add("Borough 2")
            DropDownList4.Items.Add("Street 2")
            DropDownList4.Items.Add("Borough 3")
            DropDownList4.Items.Add("Street 3")
            DropDownList4.Items.Add("Side Of Street")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough 1")
            DropDownList5.Items.Add("Street 1")
            DropDownList5.Items.Add("Borough 2")
            DropDownList5.Items.Add("Street 2")
            DropDownList5.Items.Add("Borough 3")
            DropDownList5.Items.Add("Street 3")
            DropDownList5.Items.Add("Side Of Street")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough 1")
            DropDownList6.Items.Add("Street 1")
            DropDownList6.Items.Add("Borough 2")
            DropDownList6.Items.Add("Street 2")
            DropDownList6.Items.Add("Borough 3")
            DropDownList6.Items.Add("Street 3")
            DropDownList6.Items.Add("Side Of Street")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough 1")
            DropDownList7.Items.Add("Street 1")
            DropDownList7.Items.Add("Borough 2")
            DropDownList7.Items.Add("Street 2")
            DropDownList7.Items.Add("Borough 3")
            DropDownList7.Items.Add("Street 3")
            DropDownList7.Items.Add("Side Of Street")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough 1")
            DropDownList8.Items.Add("Street 1")
            DropDownList8.Items.Add("Borough 2")
            DropDownList8.Items.Add("Street 2")
            DropDownList8.Items.Add("Borough 3")
            DropDownList8.Items.Add("Street 3")
            DropDownList8.Items.Add("Side Of Street")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough 1")
            DropDownList9.Items.Add("Street 1")
            DropDownList9.Items.Add("Borough 2")
            DropDownList9.Items.Add("Street 2")
            DropDownList9.Items.Add("Borough 3")
            DropDownList9.Items.Add("Street 3")
            DropDownList9.Items.Add("Side Of Street")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough 1")
            DropDownList10.Items.Add("Street 1")
            DropDownList10.Items.Add("Borough 2")
            DropDownList10.Items.Add("Street 2")
            DropDownList10.Items.Add("Borough 3")
            DropDownList10.Items.Add("Street 3")
            DropDownList10.Items.Add("Side Of Street")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough 1")
            DropDownList11.Items.Add("Street 1")
            DropDownList11.Items.Add("Borough 2")
            DropDownList11.Items.Add("Street 2")
            DropDownList11.Items.Add("Borough 3")
            DropDownList11.Items.Add("Street 3")
            DropDownList11.Items.Add("Side Of Street")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough 1")
            DropDownList12.Items.Add("Street 1")
            DropDownList12.Items.Add("Borough 2")
            DropDownList12.Items.Add("Street 2")
            DropDownList12.Items.Add("Borough 3")
            DropDownList12.Items.Add("Street 3")
            DropDownList12.Items.Add("Side Of Street")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough 1")
            DropDownList13.Items.Add("Street 1")
            DropDownList13.Items.Add("Borough 2")
            DropDownList13.Items.Add("Street 2")
            DropDownList13.Items.Add("Borough 3")
            DropDownList13.Items.Add("Street 3")
            DropDownList13.Items.Add("Side Of Street")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough 1")
            DropDownList14.Items.Add("Street 1")
            DropDownList14.Items.Add("Borough 2")
            DropDownList14.Items.Add("Street 2")
            DropDownList14.Items.Add("Borough 3")
            DropDownList14.Items.Add("Street 3")
            DropDownList14.Items.Add("Side Of Street")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough 1")
            DropDownList15.Items.Add("Street 1")
            DropDownList15.Items.Add("Borough 2")
            DropDownList15.Items.Add("Street 2")
            DropDownList15.Items.Add("Borough 3")
            DropDownList15.Items.Add("Street 3")
            DropDownList15.Items.Add("Side Of Street")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough 1")
            DropDownList16.Items.Add("Street 1")
            DropDownList16.Items.Add("Borough 2")
            DropDownList16.Items.Add("Street 2")
            DropDownList16.Items.Add("Borough 3")
            DropDownList16.Items.Add("Street 3")
            DropDownList16.Items.Add("Side Of Street")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough 1")
            DropDownList17.Items.Add("Street 1")
            DropDownList17.Items.Add("Borough 2")
            DropDownList17.Items.Add("Street 2")
            DropDownList17.Items.Add("Borough 3")
            DropDownList17.Items.Add("Street 3")
            DropDownList17.Items.Add("Side Of Street")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough 1")
            DropDownList18.Items.Add("Street 1")
            DropDownList18.Items.Add("Borough 2")
            DropDownList18.Items.Add("Street 2")
            DropDownList18.Items.Add("Borough 3")
            DropDownList18.Items.Add("Street 3")
            DropDownList18.Items.Add("Side Of Street")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough 1")
            DropDownList19.Items.Add("Street 1")
            DropDownList19.Items.Add("Borough 2")
            DropDownList19.Items.Add("Street 2")
            DropDownList19.Items.Add("Borough 3")
            DropDownList19.Items.Add("Street 3")
            DropDownList19.Items.Add("Side Of Street")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough 1")
            DropDownList20.Items.Add("Street 1")
            DropDownList20.Items.Add("Borough 2")
            DropDownList20.Items.Add("Street 2")
            DropDownList20.Items.Add("Borough 3")
            DropDownList20.Items.Add("Street 3")
            DropDownList20.Items.Add("Side Of Street")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough 1")
            DropDownList21.Items.Add("Street 1")
            DropDownList21.Items.Add("Borough 2")
            DropDownList21.Items.Add("Street 2")
            DropDownList21.Items.Add("Borough 3")
            DropDownList21.Items.Add("Street 3")
            DropDownList21.Items.Add("Side Of Street")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough 1")
            DropDownList22.Items.Add("Street 1")
            DropDownList22.Items.Add("Borough 2")
            DropDownList22.Items.Add("Street 2")
            DropDownList22.Items.Add("Borough 3")
            DropDownList22.Items.Add("Street 3")
            DropDownList22.Items.Add("Side Of Street")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough 1")
            DropDownList23.Items.Add("Street 1")
            DropDownList23.Items.Add("Borough 2")
            DropDownList23.Items.Add("Street 2")
            DropDownList23.Items.Add("Borough 3")
            DropDownList23.Items.Add("Street 3")
            DropDownList23.Items.Add("Side Of Street")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough 1")
            DropDownList24.Items.Add("Street 1")
            DropDownList24.Items.Add("Borough 2")
            DropDownList24.Items.Add("Street 2")
            DropDownList24.Items.Add("Borough 3")
            DropDownList24.Items.Add("Street 3")
            DropDownList24.Items.Add("Side Of Street")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough 1")
            DropDownList25.Items.Add("Street 1")
            DropDownList25.Items.Add("Borough 2")
            DropDownList25.Items.Add("Street 2")
            DropDownList25.Items.Add("Borough 3")
            DropDownList25.Items.Add("Street 3")
            DropDownList25.Items.Add("Side Of Street")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough 1")
            DropDownList26.Items.Add("Street 1")
            DropDownList26.Items.Add("Borough 2")
            DropDownList26.Items.Add("Street 2")
            DropDownList26.Items.Add("Borough 3")
            DropDownList26.Items.Add("Street 3")
            DropDownList26.Items.Add("Side Of Street")
        ElseIf Session("Flag") = "3S" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough")
            DropDownList1.Items.Add("On Street")
            DropDownList1.Items.Add("First Cross Street")
            DropDownList1.Items.Add("Second Cross Street")
            DropDownList1.Items.Add("Compass Direction 1")
            DropDownList1.Items.Add("Compass Direction 2")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough")
            DropDownList2.Items.Add("On Street")
            DropDownList2.Items.Add("First Cross Street")
            DropDownList2.Items.Add("Second Cross Street")
            DropDownList2.Items.Add("Compass Direction 1")
            DropDownList2.Items.Add("Compass Direction 2")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough")
            DropDownList3.Items.Add("On Street")
            DropDownList3.Items.Add("First Cross Street")
            DropDownList3.Items.Add("Second Cross Street")
            DropDownList3.Items.Add("Compass Direction 1")
            DropDownList3.Items.Add("Compass Direction 2")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough")
            DropDownList4.Items.Add("On Street")
            DropDownList4.Items.Add("First Cross Street")
            DropDownList4.Items.Add("Second Cross Street")
            DropDownList4.Items.Add("Compass Direction 1")
            DropDownList4.Items.Add("Compass Direction 2")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough")
            DropDownList5.Items.Add("On Street")
            DropDownList5.Items.Add("First Cross Street")
            DropDownList5.Items.Add("Second Cross Street")
            DropDownList5.Items.Add("Compass Direction 1")
            DropDownList5.Items.Add("Compass Direction 2")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough")
            DropDownList6.Items.Add("On Street")
            DropDownList6.Items.Add("First Cross Street")
            DropDownList6.Items.Add("Second Cross Street")
            DropDownList6.Items.Add("Compass Direction 1")
            DropDownList6.Items.Add("Compass Direction 2")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough")
            DropDownList7.Items.Add("On Street")
            DropDownList7.Items.Add("First Cross Street")
            DropDownList7.Items.Add("Second Cross Street")
            DropDownList7.Items.Add("Compass Direction 1")
            DropDownList7.Items.Add("Compass Direction 2")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough")
            DropDownList8.Items.Add("On Street")
            DropDownList8.Items.Add("First Cross Street")
            DropDownList8.Items.Add("Second Cross Street")
            DropDownList8.Items.Add("Compass Direction 1")
            DropDownList8.Items.Add("Compass Direction 2")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough")
            DropDownList9.Items.Add("On Street")
            DropDownList9.Items.Add("First Cross Street")
            DropDownList9.Items.Add("Second Cross Street")
            DropDownList9.Items.Add("Compass Direction 1")
            DropDownList9.Items.Add("Compass Direction 2")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough")
            DropDownList10.Items.Add("On Street")
            DropDownList10.Items.Add("First Cross Street")
            DropDownList10.Items.Add("Second Cross Street")
            DropDownList10.Items.Add("Compass Direction 1")
            DropDownList10.Items.Add("Compass Direction 2")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough")
            DropDownList11.Items.Add("On Street")
            DropDownList11.Items.Add("First Cross Street")
            DropDownList11.Items.Add("Second Cross Street")
            DropDownList11.Items.Add("Compass Direction 1")
            DropDownList11.Items.Add("Compass Direction 2")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough")
            DropDownList12.Items.Add("On Street")
            DropDownList12.Items.Add("First Cross Street")
            DropDownList12.Items.Add("Second Cross Street")
            DropDownList12.Items.Add("Compass Direction 1")
            DropDownList12.Items.Add("Compass Direction 2")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough")
            DropDownList13.Items.Add("On Street")
            DropDownList13.Items.Add("First Cross Street")
            DropDownList13.Items.Add("Second Cross Street")
            DropDownList13.Items.Add("Compass Direction 1")
            DropDownList13.Items.Add("Compass Direction 2")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough")
            DropDownList14.Items.Add("On Street")
            DropDownList14.Items.Add("First Cross Street")
            DropDownList14.Items.Add("Second Cross Street")
            DropDownList14.Items.Add("Compass Direction 1")
            DropDownList14.Items.Add("Compass Direction 2")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough")
            DropDownList15.Items.Add("On Street")
            DropDownList15.Items.Add("First Cross Street")
            DropDownList15.Items.Add("Second Cross Street")
            DropDownList15.Items.Add("Compass Direction 1")
            DropDownList15.Items.Add("Compass Direction 2")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough")
            DropDownList16.Items.Add("On Street")
            DropDownList16.Items.Add("First Cross Street")
            DropDownList16.Items.Add("Second Cross Street")
            DropDownList16.Items.Add("Compass Direction 1")
            DropDownList16.Items.Add("Compass Direction 2")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough")
            DropDownList17.Items.Add("On Street")
            DropDownList17.Items.Add("First Cross Street")
            DropDownList17.Items.Add("Second Cross Street")
            DropDownList17.Items.Add("Compass Direction 1")
            DropDownList17.Items.Add("Compass Direction 2")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough")
            DropDownList18.Items.Add("On Street")
            DropDownList18.Items.Add("First Cross Street")
            DropDownList18.Items.Add("Second Cross Street")
            DropDownList18.Items.Add("Compass Direction 1")
            DropDownList18.Items.Add("Compass Direction 2")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough")
            DropDownList19.Items.Add("On Street")
            DropDownList19.Items.Add("First Cross Street")
            DropDownList19.Items.Add("Second Cross Street")
            DropDownList19.Items.Add("Compass Direction 1")
            DropDownList19.Items.Add("Compass Direction 2")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough")
            DropDownList20.Items.Add("On Street")
            DropDownList20.Items.Add("First Cross Street")
            DropDownList20.Items.Add("Second Cross Street")
            DropDownList20.Items.Add("Compass Direction 1")
            DropDownList20.Items.Add("Compass Direction 2")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough")
            DropDownList21.Items.Add("On Street")
            DropDownList21.Items.Add("First Cross Street")
            DropDownList21.Items.Add("Second Cross Street")
            DropDownList21.Items.Add("Compass Direction 1")
            DropDownList21.Items.Add("Compass Direction 2")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough")
            DropDownList22.Items.Add("On Street")
            DropDownList22.Items.Add("First Cross Street")
            DropDownList22.Items.Add("Second Cross Street")
            DropDownList22.Items.Add("Compass Direction 1")
            DropDownList22.Items.Add("Compass Direction 2")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough")
            DropDownList23.Items.Add("On Street")
            DropDownList23.Items.Add("First Cross Street")
            DropDownList23.Items.Add("Second Cross Street")
            DropDownList23.Items.Add("Compass Direction 1")
            DropDownList23.Items.Add("Compass Direction 2")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough")
            DropDownList24.Items.Add("On Street")
            DropDownList24.Items.Add("First Cross Street")
            DropDownList24.Items.Add("Second Cross Street")
            DropDownList24.Items.Add("Compass Direction 1")
            DropDownList24.Items.Add("Compass Direction 2")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough")
            DropDownList25.Items.Add("On Street")
            DropDownList25.Items.Add("First Cross Street")
            DropDownList25.Items.Add("Second Cross Street")
            DropDownList25.Items.Add("Compass Direction 1")
            DropDownList25.Items.Add("Compass Direction 2")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough")
            DropDownList26.Items.Add("On Street")
            DropDownList26.Items.Add("First Cross Street")
            DropDownList26.Items.Add("Second Cross Street")
            DropDownList26.Items.Add("Compass Direction 1")
            DropDownList26.Items.Add("Compass Direction 2")
        ElseIf Session("Flag") = "BN" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("BIN")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("BIN")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("BIN")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("BIN")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("BIN")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("BIN")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("BIN")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("BIN")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("BIN")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("BIN")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("BIN")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("BIN")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("BIN")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("BIN")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("BIN")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("BIN")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("BIN")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("BIN")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("BIN")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("BIN")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("BIN")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("BIN")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("BIN")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("BIN")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("BIN")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("BIN")
        ElseIf Session("Flag") = "BL" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough")
            DropDownList1.Items.Add("Block")
            DropDownList1.Items.Add("Lot")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough")
            DropDownList2.Items.Add("Block")
            DropDownList2.Items.Add("Lot")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough")
            DropDownList3.Items.Add("Block")
            DropDownList3.Items.Add("Lot")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough")
            DropDownList4.Items.Add("Block")
            DropDownList4.Items.Add("Lot")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough")
            DropDownList5.Items.Add("Block")
            DropDownList5.Items.Add("Lot")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough")
            DropDownList6.Items.Add("Block")
            DropDownList6.Items.Add("Lot")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough")
            DropDownList7.Items.Add("Block")
            DropDownList7.Items.Add("Lot")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough")
            DropDownList8.Items.Add("Block")
            DropDownList8.Items.Add("Lot")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough")
            DropDownList9.Items.Add("Block")
            DropDownList9.Items.Add("Lot")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough")
            DropDownList10.Items.Add("Block")
            DropDownList10.Items.Add("Lot")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough")
            DropDownList11.Items.Add("Block")
            DropDownList11.Items.Add("Lot")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough")
            DropDownList12.Items.Add("Block")
            DropDownList12.Items.Add("Lot")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough")
            DropDownList13.Items.Add("Block")
            DropDownList13.Items.Add("Lot")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough")
            DropDownList14.Items.Add("Block")
            DropDownList14.Items.Add("Lot")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough")
            DropDownList15.Items.Add("Block")
            DropDownList15.Items.Add("Lot")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough")
            DropDownList16.Items.Add("Block")
            DropDownList16.Items.Add("Lot")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough")
            DropDownList17.Items.Add("Block")
            DropDownList17.Items.Add("Lot")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough")
            DropDownList18.Items.Add("Block")
            DropDownList18.Items.Add("Lot")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough")
            DropDownList19.Items.Add("Block")
            DropDownList19.Items.Add("Lot")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough")
            DropDownList20.Items.Add("Block")
            DropDownList20.Items.Add("Lot")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough")
            DropDownList21.Items.Add("Block")
            DropDownList21.Items.Add("Lot")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough")
            DropDownList22.Items.Add("Block")
            DropDownList22.Items.Add("Lot")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough")
            DropDownList23.Items.Add("Block")
            DropDownList23.Items.Add("Lot")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough")
            DropDownList24.Items.Add("Block")
            DropDownList24.Items.Add("Lot")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough")
            DropDownList25.Items.Add("Block")
            DropDownList25.Items.Add("Lot")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough")
            DropDownList26.Items.Add("Block")
            DropDownList26.Items.Add("Lot")
        ElseIf Session("Flag") = "1N" Then
            DropDownList0.Items.Add("")
            DropDownList1.Items.Add("")
            DropDownList1.Items.Add("Borough")
            DropDownList1.Items.Add("Street")
            DropDownList2.Items.Add("")
            DropDownList2.Items.Add("Borough")
            DropDownList2.Items.Add("Street")
            DropDownList3.Items.Add("")
            DropDownList3.Items.Add("Borough")
            DropDownList3.Items.Add("Street")
            DropDownList4.Items.Add("")
            DropDownList4.Items.Add("Borough")
            DropDownList4.Items.Add("Street")
            DropDownList5.Items.Add("")
            DropDownList5.Items.Add("Borough")
            DropDownList5.Items.Add("Street")
            DropDownList6.Items.Add("")
            DropDownList6.Items.Add("Borough")
            DropDownList6.Items.Add("Street")
            DropDownList7.Items.Add("")
            DropDownList7.Items.Add("Borough")
            DropDownList7.Items.Add("Street")
            DropDownList8.Items.Add("")
            DropDownList8.Items.Add("Borough")
            DropDownList8.Items.Add("Street")
            DropDownList9.Items.Add("")
            DropDownList9.Items.Add("Borough")
            DropDownList9.Items.Add("Street")
            DropDownList10.Items.Add("")
            DropDownList10.Items.Add("Borough")
            DropDownList10.Items.Add("Street")
            DropDownList11.Items.Add("")
            DropDownList11.Items.Add("Borough")
            DropDownList11.Items.Add("Street")
            DropDownList12.Items.Add("")
            DropDownList12.Items.Add("Borough")
            DropDownList12.Items.Add("Street")
            DropDownList13.Items.Add("")
            DropDownList13.Items.Add("Borough")
            DropDownList13.Items.Add("Street")
            DropDownList14.Items.Add("")
            DropDownList14.Items.Add("Borough")
            DropDownList14.Items.Add("Street")
            DropDownList15.Items.Add("")
            DropDownList15.Items.Add("Borough")
            DropDownList15.Items.Add("Street")
            DropDownList16.Items.Add("")
            DropDownList16.Items.Add("Borough")
            DropDownList16.Items.Add("Street")
            DropDownList17.Items.Add("")
            DropDownList17.Items.Add("Borough")
            DropDownList17.Items.Add("Street")
            DropDownList18.Items.Add("")
            DropDownList18.Items.Add("Borough")
            DropDownList18.Items.Add("Street")
            DropDownList19.Items.Add("")
            DropDownList19.Items.Add("Borough")
            DropDownList19.Items.Add("Street")
            DropDownList20.Items.Add("")
            DropDownList20.Items.Add("Borough")
            DropDownList20.Items.Add("Street")
            DropDownList21.Items.Add("")
            DropDownList21.Items.Add("Borough")
            DropDownList21.Items.Add("Street")
            DropDownList22.Items.Add("")
            DropDownList22.Items.Add("Borough")
            DropDownList22.Items.Add("Street")
            DropDownList23.Items.Add("")
            DropDownList23.Items.Add("Borough")
            DropDownList23.Items.Add("Street")
            DropDownList24.Items.Add("")
            DropDownList24.Items.Add("Borough")
            DropDownList24.Items.Add("Street")
            DropDownList25.Items.Add("")
            DropDownList25.Items.Add("Borough")
            DropDownList25.Items.Add("Street")
            DropDownList26.Items.Add("")
            DropDownList26.Items.Add("Borough")
            DropDownList26.Items.Add("Street")
        End If

        Return Nothing
    End Function
    Public Function getDropDownsPerGVColumn()
        If GridView1.Rows(0).Cells.Count - 1 = 1 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 2 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 3 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 4 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 5 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 6 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 7 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 8 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 9 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 10 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 11 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 12 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 13 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 14 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 15 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 16 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 17 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 18 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 19 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 20 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
            DropDownList20.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 21 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
            DropDownList20.Visible = True
            DropDownList21.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 22 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
            DropDownList20.Visible = True
            DropDownList21.Visible = True
            DropDownList22.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 23 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
            DropDownList20.Visible = True
            DropDownList21.Visible = True
            DropDownList22.Visible = True
            DropDownList23.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 24 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
            DropDownList20.Visible = True
            DropDownList21.Visible = True
            DropDownList22.Visible = True
            DropDownList23.Visible = True
            DropDownList24.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 25 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
            DropDownList20.Visible = True
            DropDownList21.Visible = True
            DropDownList22.Visible = True
            DropDownList23.Visible = True
            DropDownList24.Visible = True
            DropDownList25.Visible = True
        ElseIf GridView1.Rows(0).Cells.Count - 1 = 26 Then
            DropDownList0.Visible = True
            DropDownList1.Visible = True
            DropDownList2.Visible = True
            DropDownList3.Visible = True
            DropDownList4.Visible = True
            DropDownList5.Visible = True
            DropDownList6.Visible = True
            DropDownList7.Visible = True
            DropDownList8.Visible = True
            DropDownList9.Visible = True
            DropDownList10.Visible = True
            DropDownList11.Visible = True
            DropDownList12.Visible = True
            DropDownList13.Visible = True
            DropDownList14.Visible = True
            DropDownList15.Visible = True
            DropDownList16.Visible = True
            DropDownList17.Visible = True
            DropDownList18.Visible = True
            DropDownList19.Visible = True
            DropDownList20.Visible = True
            DropDownList21.Visible = True
            DropDownList22.Visible = True
            DropDownList23.Visible = True
            DropDownList24.Visible = True
            DropDownList25.Visible = True
            DropDownList26.Visible = True
        End If
        Return Nothing
    End Function
    Public Function getGridviewHeaderName()
        Session("headerRowText").Clear()

        For a As Integer = GridView1.PageIndex To GridView1.PageIndex
            For i As Integer = 0 To GridView1.Rows(0).Cells.Count - 1
                Dim headerRowText As String = GridView1.HeaderRow.Cells(i).Text
                If headerRowText = "&nbsp;" Then
                    headerRowText = ""
                End If
                Session("headerRowText").Add(headerRowText)
            Next
        Next
        Return Nothing
    End Function
    Protected Sub GridView1_PageIndexChanging(ByVal sender As Object, ByVal e As GridViewPageEventArgs)
        GridView1.PageIndex = e.NewPageIndex
        BindData()
    End Sub
    Protected Sub GridView1_RowEditing(ByVal sender As Object, ByVal e As GridViewEditEventArgs)
        'Set the edit index.

        GridView1.EditIndex = e.NewEditIndex

        Dim pixels = (e.NewEditIndex * 21)

        'Bind data to the GridView control.
        BindData()
        'TEST javascript code below 
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "scrollToRow(" + pixels.ToString + ");", True)

    End Sub
    Protected Sub GridView1_RowCancelingEdit()
        'Reset the edit index.
        GridView1.EditIndex = -1
        'Bind data to the GridView control.
        BindData()
    End Sub

    Protected Sub GridView1_RowUpdating(ByVal sender As Object, ByVal e As GridViewUpdateEventArgs)
        rowUpdated = True

        Dim column As Integer = GridView1.HeaderRow.Cells.Count - 1
        Dim row = GridView1.Rows(e.RowIndex)

        Dim xlsApp As Excel.Application = Nothing
        Dim xlsWorkBooks As Excel.Workbooks = Nothing
        Dim xlsWB As Excel.Workbook = Nothing
        Dim activeWorksheet As Excel.Worksheet = Nothing
        Dim fullFilePath = "C:\ExcelFiles\" + Session("Filename1").ToString

        xlsApp = New Excel.Application
        ' xlsApp.Visible = True
        xlsWorkBooks = xlsApp.Workbooks
        xlsWB = xlsWorkBooks.Open(fullFilePath)

        activeWorksheet = xlsWB.Sheets("Sheet1")

        For i As Integer = 1 To column
            Session("TaskTable").Tables(0).Rows(row.DataItemIndex)(GridView1.HeaderRow.Cells(i).Text) = (CType((row.Cells(i).Controls(0)), TextBox)).Text.ToString
            activeWorksheet.Cells(row.DataItemIndex + 2, i) = (CType((row.Cells(i).Controls(0)), TextBox)).Text.ToString

        Next
        xlsApp.DisplayAlerts = False
        xlsWB.Save()
        GridView1.EditIndex = -1

        BindData()

        xlsWB.Close()
        xlsWB = Nothing
        xlsApp.Quit()
        xlsApp = Nothing

    End Sub

    Function CheckForValidationAP()
        Dim y As Integer

        If Session("Flag") = "AP" Then
            Dim boroughDropDownListNumber As Integer
            Dim addressNumberDropDownListNumber As Integer
            Dim streetNumberDropDownListNumber As Integer
            Dim zipCodeDropDownListNumber As Integer


            If DropDownList1.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 1
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 2
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 3
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 4
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 5
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 6
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 7
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 8
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 9
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 10
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 11
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 12
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 13
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 14
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 15
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 16
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 17
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 18
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 19
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 20
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 21
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 22
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 23
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 24
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 25
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 26
                Session("BoroughSelectedOverZip") = True
            End If

            If DropDownList1.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 26
            End If


            If DropDownList1.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 26
            End If

            If DropDownList1.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 26
            End If


            For x As Integer = Session("startPage") To GridView1.PageCount - 1

                GridView1.SetPageIndex(x)



                For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                    If Session("BoroughSelectedOverZip") = True Then

                        If GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BK" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "SI" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "THE BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QUEENS" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "1" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "2" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "3" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "4" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "5" Then
                        Else

                            ManageErrors(x, i, boroughDropDownListNumber)
                            Exit Function
                        End If
                    End If

                    If Regex.IsMatch(GridView1.Rows(i).Cells(addressNumberDropDownListNumber).Text.ToString, "^[0-9 \-]+$") Then
                    Else

                        ManageErrors(x, i, addressNumberDropDownListNumber)
                        Exit Function
                    End If


                    If Session("BoroughSelectedOverZip") = False Then

                        If Regex.IsMatch(GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString, "^[0-9 \-]+$") And GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString.Length < 6 Then
                        Else

                            ManageErrors(x, i, zipCodeDropDownListNumber)
                            Exit Function
                        End If
                    End If


                    If GridView1.Rows(i).Cells(streetNumberDropDownListNumber).Text.Length < 30 Then
                    Else

                        ManageErrors(x, i, streetNumberDropDownListNumber)
                        Exit Function
                    End If

                Next
            Next
        End If
        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function


    Function CheckForValidation1E()
        Dim y As Integer

        If Session("Flag") = "1E" Then

            Dim boroughDropDownListNumber As Integer
            Dim addressNumberDropDownListNumber As Integer
            Dim streetNumberDropDownListNumber As Integer
            Dim zipCodeDropDownListNumber As Integer


            If DropDownList1.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 1
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 2
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 3
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 4
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 5
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 6
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 7
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 8
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 9
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 10
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 11
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 12
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 13
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 14
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 15
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 16
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 17
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 18
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 19
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 20
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 21
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 22
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 23
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 24
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 25
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 26
                Session("BoroughSelectedOverZip") = True
            End If

            If DropDownList1.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 26
            End If


            If DropDownList1.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 26
            End If

            If DropDownList1.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 26
            End If


            For x As Integer = Session("startPage") To GridView1.PageCount - 1

                GridView1.SetPageIndex(x)


                For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                    If Session("BoroughSelectedOverZip") = True Then

                        If GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BK" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "SI" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "THE BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QUEENS" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "1" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "2" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "3" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "4" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "5" Then
                        Else

                            ManageErrors(x, i, boroughDropDownListNumber)
                            Exit Function
                        End If
                    End If

                    If Regex.IsMatch(GridView1.Rows(i).Cells(addressNumberDropDownListNumber).Text.ToString, "^[0-9 \-]+$") Then
                    Else

                        ManageErrors(x, i, addressNumberDropDownListNumber)
                        Exit Function
                    End If


                    If Session("BoroughSelectedOverZip") = False Then

                        If Regex.IsMatch(GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString, "^[0-9 \-]+$") And GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString.Length < 6 Then
                        Else

                            ManageErrors(x, i, zipCodeDropDownListNumber)
                            Exit Function
                        End If
                    End If


                    If GridView1.Rows(i).Cells(streetNumberDropDownListNumber).Text.Length < 30 Then
                    Else

                        ManageErrors(x, i, streetNumberDropDownListNumber)
                        Exit Function
                    End If

                Next
            Next
        End If
        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Function CheckForValidation1A()
        Dim y As Integer

        If Session("Flag") = "1A" Then

            Dim boroughDropDownListNumber As Integer
            Dim addressNumberDropDownListNumber As Integer
            Dim streetNumberDropDownListNumber As Integer
            Dim zipCodeDropDownListNumber As Integer


            If DropDownList1.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 1
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 2
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 3
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 4
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 5
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 6
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 7
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 8
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 9
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 10
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 11
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 12
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 13
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 14
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 15
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 16
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 17
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 18
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 19
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 20
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 21
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 22
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 23
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 24
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 25
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 26
                Session("BoroughSelectedOverZip") = True
            End If

            If DropDownList1.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 26
            End If


            If DropDownList1.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 26
            End If

            If DropDownList1.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 26
            End If


            For x As Integer = Session("startPage") To GridView1.PageCount - 1

                GridView1.SetPageIndex(x)


                For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                    If Session("BoroughSelectedOverZip") = True Then

                        If GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BK" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "SI" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "THE BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QUEENS" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "1" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "2" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "3" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "4" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "5" Then
                        Else

                            ManageErrors(x, i, boroughDropDownListNumber)
                            Exit Function
                        End If
                    End If

                    If Regex.IsMatch(GridView1.Rows(i).Cells(addressNumberDropDownListNumber).Text.ToString, "^[0-9 \-]+$") Then
                    Else

                        ManageErrors(x, i, addressNumberDropDownListNumber)
                        Exit Function
                    End If


                    If Session("BoroughSelectedOverZip") = False Then

                        If Regex.IsMatch(GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString, "^[0-9 \-]+$") And GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString.Length < 6 Then
                        Else

                            ManageErrors(x, i, zipCodeDropDownListNumber)
                            Exit Function
                        End If
                    End If


                    If GridView1.Rows(i).Cells(streetNumberDropDownListNumber).Text.Length < 30 Then
                    Else

                        ManageErrors(x, i, streetNumberDropDownListNumber)
                        Exit Function
                    End If

                Next
            Next
        End If
        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Function CheckForValidation1B()
        Dim y As Integer

        If Session("Flag") = "1B" Then

            Dim boroughDropDownListNumber As Integer
            Dim addressNumberDropDownListNumber As Integer
            Dim streetNumberDropDownListNumber As Integer
            Dim zipCodeDropDownListNumber As Integer


            If DropDownList1.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 1
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 2
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 3
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 4
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 5
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 6
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 7
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 8
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 9
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 10
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 11
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 12
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 13
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 14
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 15
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 16
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 17
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 18
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 19
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 20
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 21
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 22
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 23
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 24
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 25
                Session("BoroughSelectedOverZip") = True
            ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
                boroughDropDownListNumber = 26
                Session("BoroughSelectedOverZip") = True
            End If

            If DropDownList1.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Zip Code" Then
                zipCodeDropDownListNumber = 26
            End If


            If DropDownList1.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Address No" Then
                addressNumberDropDownListNumber = 26
            End If

            If DropDownList1.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 1
            ElseIf DropDownList2.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 2
            ElseIf DropDownList3.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 3
            ElseIf DropDownList4.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 4
            ElseIf DropDownList5.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 5
            ElseIf DropDownList6.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 6
            ElseIf DropDownList7.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 7
            ElseIf DropDownList8.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 8
            ElseIf DropDownList9.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 9
            ElseIf DropDownList10.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 10
            ElseIf DropDownList11.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 11
            ElseIf DropDownList12.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 12
            ElseIf DropDownList13.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 13
            ElseIf DropDownList14.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 14
            ElseIf DropDownList15.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 15
            ElseIf DropDownList16.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 16
            ElseIf DropDownList17.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 17
            ElseIf DropDownList18.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 18
            ElseIf DropDownList19.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 19
            ElseIf DropDownList20.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 20
            ElseIf DropDownList21.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 21
            ElseIf DropDownList22.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 22
            ElseIf DropDownList23.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 23
            ElseIf DropDownList24.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 24
            ElseIf DropDownList25.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 25
            ElseIf DropDownList26.SelectedItem.ToString = "Street" Then
                streetNumberDropDownListNumber = 26
            End If


            For x As Integer = Session("startPage") To GridView1.PageCount - 1

                GridView1.SetPageIndex(x)


                For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                    If Session("BoroughSelectedOverZip") = True Then

                        If GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BK" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "SI" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "THE BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QUEENS" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "1" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "2" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "3" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "4" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "5" Then
                        Else

                            ManageErrors(x, i, boroughDropDownListNumber)
                            Exit Function
                        End If
                    End If

                    If Regex.IsMatch(GridView1.Rows(i).Cells(addressNumberDropDownListNumber).Text.ToString, "^[0-9 \-]+$") Then
                    Else

                        ManageErrors(x, i, addressNumberDropDownListNumber)
                        Exit Function
                    End If


                    If Session("BoroughSelectedOverZip") = False Then

                        If Regex.IsMatch(GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString, "^[0-9 \-]+$") And GridView1.Rows(i).Cells(zipCodeDropDownListNumber).Text.ToString.Length < 6 Then
                        Else

                            ManageErrors(x, i, zipCodeDropDownListNumber)
                            Exit Function
                        End If
                    End If


                    If GridView1.Rows(i).Cells(streetNumberDropDownListNumber).Text.Length < 30 Then
                    Else

                        ManageErrors(x, i, streetNumberDropDownListNumber)
                        Exit Function
                    End If

                Next
            Next
        End If
        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Function CheckForValidation2()

        Dim borough1DropDownListNumber As Integer
        Dim borough2DropDownListNumber As Integer
        Dim street1DropDownListNumber As Integer
        Dim street2DropDownListNumber As Integer


        If DropDownList1.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Borough 1" Then
            borough1DropDownListNumber = 26
        End If

        If DropDownList1.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Borough 2" Then
            borough2DropDownListNumber = 26
        End If


        If DropDownList1.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Street 1" Then
            street1DropDownListNumber = 26
        End If


        If DropDownList1.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Street 2" Then
            street2DropDownListNumber = 26
        End If




        For x As Integer = 0 To GridView1.PageCount - 1

            GridView1.SetPageIndex(x)

            For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                If GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "MN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BK" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "SI" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "THE BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "BX" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "QUEENS" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "QN" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "1" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "2" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "3" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "4" Then
                ElseIf GridView1.Rows(i).Cells(borough1DropDownListNumber).Text.ToUpper = "5" Then
                Else

                    ManageErrors(x, i, borough1DropDownListNumber)
                    Exit Function
                End If


                If GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "MN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BK" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "SI" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "THE BRONX" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "BX" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "QUEENS" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "QN" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "1" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "2" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "3" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "4" Then
                ElseIf GridView1.Rows(i).Cells(borough2DropDownListNumber).Text.ToUpper = "5" Then
                Else

                    ManageErrors(x, i, borough2DropDownListNumber)
                    Exit Function
                End If



                If DropDownList1.SelectedItem.ToString = "Street 1" Then
                    If GridView1.Rows(i).Cells(street1DropDownListNumber).Text.Length < 30 Then
                    Else

                        ManageErrors(x, i, street1DropDownListNumber)
                        Exit Function
                    End If
                End If


                If DropDownList1.SelectedItem.ToString = "Street 2" Then
                    If GridView1.Rows(i).Cells(street2DropDownListNumber).Text.Length < 30 Then
                    Else

                        ManageErrors(x, i, street2DropDownListNumber)
                        Exit Function
                    End If
                End If
            Next
        Next


        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function


    Function CheckForValidationNameCode()

        Dim boroughDropDownListNumber As Integer
        Dim streetNumberDropDownListNumber As Integer


        If DropDownList1.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 26
        End If

        If DropDownList1.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Street" Then
            streetNumberDropDownListNumber = 26
        End If


        For x As Integer = 0 To GridView1.PageCount - 1

            GridView1.SetPageIndex(x)

            For i As Integer = Session("startState") To GridView1.Rows.Count - 1


                If GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BK" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "SI" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BRONX" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "THE BRONX" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BX" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QUEENS" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "1" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "2" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "3" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "4" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "5" Then
                Else

                    ManageErrors(x, i, boroughDropDownListNumber)
                    Exit Function
                End If


                If GridView1.Rows(i).Cells(streetNumberDropDownListNumber).Text.Length < 30 Then
                Else

                    ManageErrors(x, i, streetNumberDropDownListNumber)
                    Exit Function
                End If

            Next
        Next


        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Function CheckForValidationBL()

        Dim boroughDropDownListNumber As Integer
        Dim blockDropDownListNumber As Integer
        Dim lotDropDownListNumber As Integer

        If DropDownList1.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 26
        End If

        If DropDownList1.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Block" Then
            blockDropDownListNumber = 26
        End If

        If DropDownList1.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Lot" Then
            lotDropDownListNumber = 26

        End If


        For x As Integer = 0 To GridView1.PageCount - 1

            GridView1.SetPageIndex(x)

            For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                If GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BK" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "SI" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BRONX" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "THE BRONX" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BX" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QUEENS" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QN" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "1" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "2" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "3" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "4" Then
                ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "5" Then
                Else

                    ManageErrors(x, i, boroughDropDownListNumber)
                    Exit Function
                End If


                If DropDownList1.SelectedItem.ToString = "Block" Then

                    If Regex.IsMatch(GridView1.Rows(i).Cells(blockDropDownListNumber).Text.ToString, "^[0-9 ]+$") Then
                    Else

                        ManageErrors(x, i, blockDropDownListNumber)
                        Exit Function
                    End If
                End If


                If DropDownList1.SelectedItem.ToString = "Lot" Then

                    If Regex.IsMatch(GridView1.Rows(i).Cells(lotDropDownListNumber).Text.ToString, "^[0-9 ]+$") Then
                    Else

                        ManageErrors(x, i, lotDropDownListNumber)
                        Exit Function
                    End If
                End If

            Next
        Next


        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function


    Function CheckForValidation3S()


        Dim boroughDropDownListNumber As Integer
        Dim onStreetDropDownListNumber As Integer
        Dim compassDirection1ListNumber As Integer
        Dim compassDirection2ListNumber As Integer


        If DropDownList1.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 1
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList2.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 2
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList3.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 3
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList4.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 4
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList5.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 5
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList6.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 6
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList7.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 7
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList8.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 8
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList9.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 9
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList10.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 10
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList11.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 11
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList12.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 12
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList13.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 13
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList14.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 14
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList15.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 15
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList16.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 16
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList17.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 17
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList18.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 18
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList19.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 19
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList20.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 20
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList21.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 21
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList22.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 22
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList23.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 23
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList24.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 24
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList25.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 25
            Session("BoroughSelectedOverZip") = True
        ElseIf DropDownList26.SelectedItem.ToString = "Borough" Then
            boroughDropDownListNumber = 26
            Session("BoroughSelectedOverZip") = True
        End If

        If DropDownList1.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "On Street" Then
            onStreetDropDownListNumber = 26
        End If


        If DropDownList1.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Compass Direction 1" Then
            Session("CompassDirection1Selected") = True
            compassDirection1ListNumber = 26
        End If

        If DropDownList1.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 1
        ElseIf DropDownList2.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 2
        ElseIf DropDownList3.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 3
        ElseIf DropDownList4.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 4
        ElseIf DropDownList5.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 5
        ElseIf DropDownList6.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 6
        ElseIf DropDownList7.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 7
        ElseIf DropDownList8.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 8
        ElseIf DropDownList9.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 9
        ElseIf DropDownList10.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 10
        ElseIf DropDownList11.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 11
        ElseIf DropDownList12.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 12
        ElseIf DropDownList13.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 13
        ElseIf DropDownList14.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 14
        ElseIf DropDownList15.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 15
        ElseIf DropDownList16.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 16
        ElseIf DropDownList17.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 17
        ElseIf DropDownList18.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 18
        ElseIf DropDownList19.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 19
        ElseIf DropDownList20.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 20
        ElseIf DropDownList21.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 21
        ElseIf DropDownList22.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 22
        ElseIf DropDownList23.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 23
        ElseIf DropDownList24.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 24
        ElseIf DropDownList25.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 25
        ElseIf DropDownList26.SelectedItem.ToString = "Compass Direction 2" Then
            Session("CompassDirection2Selected") = True
            compassDirection2ListNumber = 26
        End If

        Dim y As Integer


        If Session("Flag") = "3S" Then

            For x As Integer = 0 To GridView1.PageCount - 1

                GridView1.SetPageIndex(x)

                For i As Integer = Session("startState") To GridView1.Rows.Count - 1

                    If Session("BoroughSelectedOverZip") = True Then

                        If GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MANHATTAN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "MN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BROOKLYN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BK" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "STATEN ISLAND" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "SI" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "THE BRONX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "BX" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QUEENS" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "QN" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "1" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "2" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "3" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "4" Then
                        ElseIf GridView1.Rows(i).Cells(boroughDropDownListNumber).Text.ToUpper = "5" Then
                        Else

                            ManageErrors(x, i, boroughDropDownListNumber)
                            Exit Function
                        End If
                    End If




                    If GridView1.Rows(i).Cells(onStreetDropDownListNumber).Text.Length < 30 Then
                    Else
                        ManageErrors(x, i, onStreetDropDownListNumber)
                        Exit Function
                    End If


                    If Session("CompassDirection1Selected") = True Then
                        If GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "NORTH" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "N" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "SOUTH" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "S" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "WEST" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "W" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "EAST" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection1ListNumber).Text.ToUpper = "E" Then
                        Else
                            ManageErrors(x, i, compassDirection1ListNumber)
                            Exit Function
                        End If
                    End If



                    If Session("CompassDirection2Selected") = True Then
                        If GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "NORTH" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "N" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "SOUTH" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "S" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "WEST" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "W" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "EAST" Then
                        ElseIf GridView1.Rows(i).Cells(compassDirection2ListNumber).Text.ToUpper = "E" Then
                        Else
                            ManageErrors(x, i, compassDirection1ListNumber)
                            Exit Function
                        End If
                    End If



                Next
            Next
        End If

        Response.Redirect("OutputSelectPage.aspx", True)
        Return Nothing
    End Function

    Function checkIf2ListItemsSelectedOnceOrMore()


        Dim ddlist As ArrayList = New ArrayList
        Dim ddlist2 As ArrayList = New ArrayList
        Dim ddlist3 As ArrayList = New ArrayList
        Dim ddlist4 As ArrayList = New ArrayList


        If DropDownList0.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough 1" Then
            ddlist.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street 1" Then
            ddlist2.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Borough 2" Then
            ddlist3.Add(1)
        End If

        If DropDownList0.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList1.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList2.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList3.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList4.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList5.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList6.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList7.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList8.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList9.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList10.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList11.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList12.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList13.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList14.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList15.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList16.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList17.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList18.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList19.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList20.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList21.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList22.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList23.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList24.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If
        If DropDownList25.SelectedItem.ToString = "Street 2" Then
            ddlist4.Add(1)
        End If

        If ddlist.Count = 0 Then
            RegMsgBox("Please Select Borough 1 From the Drop Downs associated with the appropriate column")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist3.Clear()
            ddlist4.Clear()
        ElseIf ddlist2.Count = 0 Then
            RegMsgBox("Please Select Street 1 from the Drop Downs associated with the appropriate column")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist3.Clear()
            ddlist4.Clear()
        ElseIf ddlist3.Count = 0 Then
            RegMsgBox("Please Select Borough 2 From the Drop Downs associated with the appropriate column")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist3.Clear()
            ddlist4.Clear()
        ElseIf ddlist4.Count = 0 Then
            RegMsgBox("Please Select Street 2 from the Drop Downs associated with the appropriate column")
            ddlist.Clear()
            ddlist2.Clear()
            ddlist3.Clear()
            ddlist4.Clear()
        Else
            If Session("boro1SelectedTwice") = False And Session("boro2SelectedTwice") = False And Session("street1SelectedTwice") = False And Session("street2SelectedTwice") = False And Session("compassDirSelectedTwice") = False Then
                getGridviewHeaderName()
                getGridviewColumnCount()

                CheckForValidation2()
            Else
                If ddlist.Count > 1 Then
                    RegMsgBox("Borough 1 Selected Multiple Times From Drop Down Boxes. Please Select Borough 1 only ONE* time and Click Submit Again")
                ElseIf ddlist2.Count > 1 Then
                    RegMsgBox("Street 1 Selected Multiple Times From Drop Down Boxes. Please Select Street 1 only ONE* time and Click Submit Again")
                ElseIf ddlist3.Count > 1 Then
                    RegMsgBox("Borough 2 Selected Multiple Times From Drop Down Boxes. Please Select Borough 2 only ONE* time and Click Submit Again")
                ElseIf ddlist3.Count > 1 Then
                    RegMsgBox("Street 2 Selected Multiple Times From Drop Down Boxes. Please Select Street 2 only ONE* time and Click Submit Again")
                ElseIf ddlist4.Count > 1 Then
                    RegMsgBox("Compass Direction Selected Multiple Times From Drop Down Boxes. Please Select Compass Direction only ONE* time and Click Submit Again")
                End If
            End If
        End If
        Return Nothing
    End Function


    Function ManageErrors(x, i, y)

        RegMsgBox("There are errors in the input data. Please review them and click the Submit button again. Otherwise click the Skip Errors Button")
        SkipErrorsButton.Visible = True
        GridView1.SetPageIndex(x)
        Session("startPage") = x
        Session("startState") = i

        GridView1.Rows(i).BackColor = Drawing.Color.Red
        Dim pixels = (i * 21)
        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "scrollToRow(" + pixels.ToString + ");", True)

        Return Nothing
    End Function

    Public Function getGridviewColumnCount()
        Session("gridview1ColumnCount") = GridView1.Rows(0).Cells.Count - 1
        Return Nothing
    End Function

    'removed addGridViewRowsToArray function

    Protected Sub SkipErrorsButton_Click(sender As Object, e As EventArgs) Handles SkipErrorsButton.Click
        Response.Redirect("OutputSelectPage.aspx", True)
    End Sub
End Class