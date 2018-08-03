﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="userguide.aspx.vb" Inherits="GBATExcel.userguide" %>
<asp:Content ID="UserGuide" ContentPlaceHolderID="MainContent" runat="server">
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title>GOAT &#8211; Geographic Online Address Translator</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="Content/stylesheet.css" media="screen" rel="stylesheet" type="text/css" />
    <link href="Content/stylesheet_print.css" media="print" rel="stylesheet" type="text/css" />
     <link href="/WebGbat/Content/bootstrap.css" rel="stylesheet" type="text/css" media="screen" runat="server" />

    <script src="extern/commons.js" type="text/javascript"></script>

    <script src="extern/google_analytics.js" type="text/javascript"></script>

</head>
<body>
    <div class="content">
        <div class="inputField">
            <h2 style="font-size:x-large; font-weight:bold;">
                GOAT User Guide
            </h2>
            <p>
                Welcome to the Geographic Online Address Translator (GOAT)! GOAT allows you to enter
                a New York City geographic location, such as an address or street intersection,
                and returns back related geographic information, such as cross streets, side of
                street, tax block and lot (AKA Parcel &#8211;ID), five-digit ZIP code, census tract
                and block, police precinct, community district and City Council district.</p>
            <div class="userguide">
                <p>
                    <span class="labels-header"><a name="menu"></a>General Instructions:</span></p>
                <p>
                    Click on any tab to begin using a function. Refer to the text below for further
                    information.</p>
                <p>
                    <a href="#intro">General Instructions</a><br />
                    <a href="#f1b">ADDRESS (Function 1B)</a><br />
                    <a href="#f2">INTERSECTION (Function 2)</a><br />
                    <a href="#f3">STREET SEGMENT (Function 3)</a>
                    <br />
                    <a href="#f3s">STREET STRETCH (Function 3S)</a><br />
                    <a href="#fbl">BLOCK &amp; LOT (Function BL)</a>
                    <br />
                    <a href="#fbn">BIN (Function BN)</a><br />
                    <a href="#fsc">STREET (Name / Code)</a></p>
                <dl>
                    <dd>
                        <p class="labels-bold">
                            <a name="intro"></a>General Information:</p>
                        <p>
                            GOAT is organized into individual functions; each identified by the type of input
                            required along with a one- or two-character function code. Each function requires
                            a separate set of input data, such as an address or place name, a street intersection
                            or a tax lot, and returns a set of related geographic data.</p>
                        <p>
                            To change to a different function at any time, select the appropriate tab at the
                            top of the page, and GOAT will present an input page formatted for that function.
                            Provide the appropriate input data (by filling in data boxes and making selections
                            from pull-down menus, check boxes and radio buttons as required), then press the
                            Submit button. If GOAT accepts the input data as valid, it returns output data.
                            Otherwise, GOAT displays an error message indicating why the input data were not
                            accepted. Sometimes GOAT will provide additional information with the output data
                            as a warning message. A complete list of Geosupport (the software behind GOAT) Return
                            Codes (GRCs) and Reason Codes can be found
                            <img src="gifs/pdf_icon.gif" alt="PDF Document" width="12" height="12" align="absmiddle" /><a
                                href="documents/grc_list.pdf">here</a>.
                        </p>
                        <p>
                            If an inquiry is rejected and you wish to modify your input data and re-submit the
                            inquiry, or if you wish to submit another inquiry using the same function, simply
                            type over your previous data entries as needed and then press the Submit button.
                            Remember to change the borough if necessary.</p>
                        <p>
                            If an inquiry is rejected and you believe the input to be valid, you may send feedback
                            by clicking on the &#8220;Send Feedback&#8221; link. Please note that you may also
                            send feedback when your inquiry is not rejected.
                        </p>
                        <p>
                            The glossary may be accessed by clicking on any of the label names in the output
                            or by clicking <a href="glossary.aspx">here</a>.
                        </p>
                        <p class="labels-tip">
                            Tips for Efficient Data Entry of Street Names</p>
                        <p>
                            To minimize typing when entering street names, take advantage of the following features
                            available with all GOAT functions:</p>
                        <p>
                            Street directional and street type words may be entered in abbreviated form, such
                            as ST for STREET, AV or AVE for AVENUE, E for EAST, BL or BLVD for BOULEVARD. For
                            example, READE STREET may be entered as READE ST. In general, abbreviations that
                            would be recognizable to a person are also recognizable to GOAT.
                        </p>
                        <p>
                            If the street name being entered has a word containing numeric digits, you need
                            not enter the ordinal suffix (the characters 'st', 'nd', 'rd' or 'th' that can follow
                            a numeric value). For example, WEST 23RD STREET may be entered as W 23 ST.
                        </p>
                        <p>
                            You may enter partial street names when they are unambiguous in a borough. For example,
                            in the borough of Queens, GOAT recognizes MADISON as a partial name for MADISON
                            STREET, since this is the only valid full name that begins with MADISON. However,
                            in Manhattan, MADISON is ambiguous and is not accepted as an input street name,
                            since both MADISON AVENUE and MADISON STREET are valid full names.
                        </p>
                        <p>
                            GOAT has three features to assist you with spelling street names and place names:
                        </p>
                        <p>
                            As you start to type, GOAT will pre-populate a dropdown list based on your entry.
                            For example, if you start to type &#8220;Broadway&#8221;, 10 names beginning with
                            &#8220;B&#8221; will appear. As you enter &#8220;BR&#8221;, the 10 names change
                            to entries beginning with &#8220;BR&#8221;. And as you type &#8220;BRO&#8221;, another
                            10 names will appear. At this point, &#8220;BROADWAY&#8221; will appear in the list
                            and you may select the name from the dropdown list or continue typing it in as you
                            choose.
                        </p>
                        <p>
                            If you are not sure how to spell a name, you can also use the STREET (Name / Code)
                            function and select an option to &#8216;Browse Street Name Dictionary&#8217; to
                            search through an alphabetical list of all the names that GOAT recognizes as valid.</p>
                        <p>
                            Finally, if GOAT rejects a name that you have entered, the message will sometimes
                            list one or more valid names that GOAT considers to be similar to the rejected input
                            name. These are suggestions only; your intended name may not be any of these names.
                            If you do recognize a similar name as your intended name, you may correct your input
                            name by clicking on the appropriate &#8216;Copy to&#8221; (input field) and re-submitting
                            your inquiry.
                        </p>
                        <p>
                            GOAT accepts the pseudo-street names BEND, DEAD END and CITY LIMIT as input street
                            names under certain circumstances. They may not serve as input names for ADDRESS
                            (Function 1B), but may serve as input names to INTERSECTION (Function 2). For STREET
                            SEGMENT (Functions 3) and STREET STRETCH (Function 3S), they may serve as input
                            cross street names only, not as the input 'on' street name.
                        </p>
                        <div class="text_bottomline">
                            <a href="#menu">Return to Menu</a>
                            <hr />
                        </div>
                        <p class="labels-bold">
                            <a name="f1b"></a>ADDRESS Help:</p>
                        <p>
                            This screen allows for two options.  A user can choose to
                            “Display Street and Property Information” or “Display Address Point Information.
                        </p>
                        <p class="labels-bold">
                           1.	Display Street and Property Information (Function 1B) </p>
                        <p>
                        <p>
                            The input data for Function 1B is an address or a place name. Two sets of geographic
                            information are returned; political geography associated with the entire block face
                            containing the input location, followed by property level and building specific
                            output.
                        </p>
                        <p>
                            The acceptance of an address by Function 1B does not necessarily signify that an
                            actual building exists having that address. You must check both sets of output.
                            The geographic and political information returned in the upper portions of the output
                            screen are related to an address range along a street block face. The information
                            toward the bottom of the screen is property-level specific. An address range along
                            a street block typically encompasses all possible addresses that could be assigned,
                            such as 2 &#8211; 98 (on the even side of the street). However, in reality, there
                            may only be buildings with the addresses 10, 34 and 76. Thus if another address
                            within that range is entered, it will get a &#8216;hit&#8217; on the street level
                            information, but not on the property level information.
                        </p>
                        <p>
                            If property level information is returned, it generally signifies that an actual
                            building exists having that address. However, the user should pay particular attention
                            to the &#8216;Type&#8217; column included in the Address Range List at the bottom
                            of the screen to see if an address is listed as a &#8216;Pseudo Address'. &#8216;Pseudo
                            Addresses' are addresses assigned by the Department of City Planning to some vacant
                            street frontages to enable a property to be accessed. These addresses have no &#8216;official'
                            status and should never be used outside of this system.
                        </p>
                        <p>
                            In addition to the &#8216;fixed' data returned, you have a choice of receiving a
                            list of addresses which applies to the property and/or a list of BINs (Building
                            Identification Numbers) that reside on the property identified by the input address.
                            You may also elect to receive BIN information related to the Transitional PAD file
                            (TPAD), and Roadbed Specific Information pertaining to the street level data. The
                            input street name may also be normalized in a variety of ways (see Street (Name
                            / Code) Help for more information.</p>
                        <p class="labels-tip">
                            Instructions for Entering Function 1B Input Data:</p>
                        <p>
                            As input data to Function 1B, you may enter an address, consisting of an address
                            number and a street name or an address number and a place name; or you may enter
                            a place name alone without an address number.
                        </p>
                        <p>
                            Some place names serve as street names in that they combine with address numbers
                            to form addresses. Some examples recognized by GOAT are: in Manhattan, CONFUCIUS
                            PLAZA, PENN PLAZA and WASHINGTON SQUARE VILLAGE; in the Bronx, BRONX TERMINAL MARKET
                            and FORDHAM PLAZA; in Brooklyn, METROTECH and FORT HAMILTON MANOR; and in Queens,
                            ASTORIA SQUARE. To make a Function 1B inquiry for 2 Penn Plaza, for example, select
                            Manhattan as the borough, enter 2 in the Address Number box, enter PENN PLAZA in
                            the Street or Place Name box and press the Submit button.
                        </p>
                        <p>
                            Most place names do not combine with address numbers to form addresses, but rather,
                            identify specific places by themselves. Some typical examples recognized by GOAT
                            are EMPIRE STATE BUILDING, CARNEGIE HALL, CITI FIELD, LA GUARDIA AIRPORT. To make
                            a Function 1B inquiry for a place name without an address number, first select the
                            borough, make sure the Address Number box is blank, and then enter the place name
                            in the Street or Place Name box. For example, to process EMPIRE STATE BUILDING,
                            select Manhattan as the borough, make sure that the Address Number box is empty,
                            and enter EMPIRE STATE BUILDING in the Street or Place Name box, and press the Submit
                            button.
                        </p>
                        <p>
                            When entering an address number that normally contains a hyphen, such as most address
                            numbers in Queens and a few address numbers in other boroughs, it is advisable to
                            include the hyphen.
                        </p>
                        <p>
                            When entering an address number for the Edgewater Park neighborhood of the Bronx,
                            make sure to include the proper section letter &#39;suffix&#39; after the numeric
                            address number (for example, 7A Edgewater Park). Valid suffixes for Edgewater Park
                            are A, B, C, D and E.
                        </p>
                        <p>
                            If you select &#8216;Complete BIN List', you will receive a list of BINs as part
                            of your output. If you do not select &#8216;BIN List', you will receive a list of
                            up to twenty one addresses which apply to the property. For some properties, there
                            are more than twenty one addresses. In these situations, in addition to the twenty
                            one addresses starting with your input address, you will receive a warning message
                            indicating that the lot has more addresses than are displayed.
                        </p>
                        <p>
                            The TPAD (Transitional Property Address Directory) option allows you to get up-to-date
                            property related information. The TPAD file is updated daily with new information
                            received from the Department of Buildings regarding job filings for new buildings
                            and demolition jobs. Information regarding activity and status is returned.
                        </p>
                        <p>
                            The Roadbed Specific Information option will return roadbed-specific geocodes, assuming
                            that the input street has multiple roadbeds. Examples of geocodes that would be
                            different include Segment ID, Physical ID, Segment Type, and X,Y coordinates. Some
                            City Service Information may vary as well.</p>
                        <p class="labels-bold">
                           2.	Display Address Point Information (Function AP)  </p>
                        <p>
                        <p>
                            Function AP returns Address Point information and some property level information of a 
                            given input address (house number and street name – there are no NAPs).  Returned items 
                            are the Address Point ID and X, Y coordinates of the Address Point.  Property level 
                            information such as the Borough-Block-Lot (BBL) of the input address are also returned.  
                        </p> 
                         <p class="labels-tip">
                            Instruction for Entering Function AP Input Data:</p>
                        <p>
                            As input data to Function AP, you may enter an address, consisting of an address number 
                            and a street name.  Non-Addressable-Placenames (NAPs) are not allowed.  
                        </p>  
                        <div class="text_bottomline">
                            <a href="#menu">Return to Menu</a>
                            <hr />
                        </div>
                        <p class="labels-bold">
                            <a name="f2"></a>INTERSECTION (Function 2) Help:</p>
                        <p>
                            The input data to INTERSECTION (Function 2) is a street intersection. Function 2
                            returns geographic information related to the intersection, including the names
                            of any additional streets that are at the intersection, and the administrative and
                            political district identifiers within which the intersection is located. If an intersection
                            lies on a boundary of two or more districts of a particular type, only one of those
                            districts is listed.</p>
                        <p class="labels-tip">
                            Instructions for Entering Function 2 Input Data:</p>
                            <p>
                                The INTERSECTION tab in the GOAT application offers two input options:</p>
                            <ol>
                                <li>Check "Enter Node ID" and enter a NODE ID in the NODE ID text box.<br />
                                </li>
								<br/>
                                <li>Uncheck "Enter Node ID" and follow the instructions below.<br />
                        <p>
                            Select the Borough of Street 1 or Intersection Name. GOAT automatically modifies
                            the Borough of Street 2 to coincide with the Borough of Street 1 or Intersection
                            Name. Enter the names of two streets at the intersection, in either order, in the
                            boxes labeled Street 1 or Intersection Name and Street 2. If there are more than
                            two streets at the intersection, you may identify the intersection by entering any
                            pair of those streets. Except for three special cases discussed below, you may now
                            submit your inquiry by pressing the Submit button or the ENTER key.
                        </p>
                        <p>
                            Special case 1: If the intersection you are submitting lies on a borough boundary,
                            and the two streets whose names you have entered lie in different boroughs, then
                            before pressing the Submit button or the ENTER key, but after selecting the Borough
                            of First Street Name, you must select the Borough of Second Street Name. For example,
                            the Brooklyn street Ridgewood Avenue intersects with the Queens street Rockaway
                            Boulevard at the Brooklyn-Queens border. To submit an Intersection (Function 2)
                            inquiry for this location, select Brooklyn as the Borough of Street 1 or Intersection
                            Name, enter RIDGEWOOD AVE as the Street 1 or Intersection Name, select Queens as
                            the Borough of Street 2, and then enter ROCKAWAY BLVD as Street 2. (If you enter
                            the two street names in the other order, select the two boroughs accordingly.) Then
                            press the Submit button or the ENTER key.
                        </p>
                        <p>
                            Special case 2: If the streets you have entered intersect at two different points,
                            you must select a compass direction to identify which of the two intersections you
                            are inquiring about. For example, to process the easternmost of the two intersections
                            of Cromwell Crescent and Alderton Street in Queens, select EAST as the compass direction.
                            If you submit an inquiry for a pair of streets that intersect twice without having
                            selected a compass direction, a message will inform you that a compass direction
                            is required. If, on the other hand, you submit an inquiry for a pair of streets
                            that intersect once and you have selected a compass direction, you will in addition
                            to the output receive a warning message indicating that the compass direction is
                            not required.
                        </p>
                        <p>
                            Special case 3: Certain street intersections have intersection names. For example,
                            the intersection of West 54 Street and Broadway is known as &quot;Big Apple Corner&quot;.
                            For these special cases, you supply the intersection name in the field labeled Street
                            1 or Intersection Name and leave the field labeled Street 2 blank. If the Street
                            2 field is populated, GOAT will validate that the 2nd street does intersect at the
                            named intersection. If yes, a warning message is returned (NON-INTERSECTION NAME
                            IGNORED). However, if the name entered in the 2nd street field does not intersect
                            at the named intersection the input is rejected (W 154 ST NOT PART OF BIG APPLE
                            CORNER). Please note that &quot;Times Square&quot; is not an intersection name,
                            because it refers to an area which includes several intersections.
                        </p>
                        <p>
                            The pseudo-street names BEND, DEAD END and CITY LIMIT can be used as input street
                            names to specify bending points of streets, dead ends, and intersections of streets
                            with the city limit, respectively.
                        </p>
                        <p>
                            Examples:
                        </p>
                        <dl>
                            <dd>
                                <p>
                                    To submit a Function 2 inquiry for the bending point of Commerce Street in Manhattan,
                                    enter COMMERCE STREET as one of the input street names and BEND as the other input
                                    street name.
                                </p>
                                <p>
                                    A dead end is a termination point of a street at which there are no cross streets.
                                    For example, Croes Avenue in the Bronx has a dead end near where it intersects with
                                    Watson Avenue. To submit a Function 2 inquiry for this dead end, enter CROES AVENUE
                                    as one of the input street names and DEAD END as the other input street name.
                                </p>
                                <p>
                                    Linden Boulevard in Queens intersects with the city limit (in this case, the Queens-Nassau
                                    County border). To submit a Function 2 inquiry for this intersection, enter LINDEN
                                    BOULEVARD as one of the input street names and CITY LIMIT as the other input street
                                    name.
                                </p>
                            </dd>
                        </dl>
                        <p>
                            Unlike ADDRESS (Function 1), INTERSECTION (Function 2) does not allow you to enter
                            a place name as input.</p>
                        <div class="text_bottomline">
                            <a href="#menu">Return to Menu</a>
                            <hr />
                        </div>					
                        </li>
                        </ol>
                        <p class="labels-bold">
                            <a name="f3"></a>STREET SEGMENT (Function 3) Help:</p>
                        <p>
                            STREET SEGMENT (Function 3) accepts an input street segment (the portion of a street
                            between two consecutive cross streets), and returns related geographic information.
                            If you are only interested in information for one side of the street segment (Block
                            Face), you must supply a compass direction. The information returned includes administrative
                            and political district identifiers for the left and/or right side of the segment
                            and the names of any additional cross streets that are present at the two endpoints
                            of the segment.</p>
                        <p class="labels-tip">
                            Instructions for Entering Function 3 Input Data:</p>
                        <p>
                            Select the Borough of the On Street Name. GOAT automatically modifies the Borough
                            of First Cross Street and Second Cross Street to coincide with the Borough of the
                            On Street. Enter the names of the three streets, which define the segment. The first
                            street name entered is the On Street and the next two represent one of the cross
                            streets at each end of the segment. Except for the special case discussed below,
                            you may now submit your inquiry by pressing the Submit button or the ENTER key.
                        </p>
                        <p>
                            If the segment you are submitting involves streets that are in two boroughs, then
                            before pressing the Submit button or the ENTER key, you will have to modify the
                            Borough information. If the street segment lies on a borough boundary and one or
                            both of the cross streets are in a different borough, then you will have to modify
                            the Borough for the First and/or Second Cross Street. An example of the situation
                            would be the street segment Eldert Lane in Queens with Cross Streets Etna Street
                            and Ridgewood Avenue in Brooklyn. In this case, you would set the Borough for the
                            On Street to Queens and the Borough for the First and Second Cross Streets to Brooklyn.
                            Then press the Submit button or the ENTER key.</p>
                        <p>
                            Another possibility is that one of the Cross Streets lies in a different borough.
                            An example of this would be the street segment Ridgewood Avenue in Brooklyn with
                            Cross Streets 90 Avenue in Queens and Grant Avenue in Brooklyn. In this case, you
                            would set the Borough for the &#8216;On' Street to Brooklyn, the Borough for the
                            First Cross Street to Queens and the Borough for the Second Cross Street to Brooklyn.
                            Then press the Submit button or the ENTER key.
                        </p>
                        <p>
                            The pseudo-street names BEND, DEAD END and CITY LIMIT can be used as cross street
                            names when defining a segment. In addition CITY LIMIT may be used as an &#8216;On'
                            Street name in Queens and the Bronx.
                        </p>
                        <p>
                            Examples:
                        </p>
                        <dl>
                            <dd>
                                <p>
                                    To submit a Function 3 inquiry that includes the bending point of Commerce Street
                                    in Manhattan, enter COMMERCE STREET as the &#8216;On' Street and BEND as one of
                                    the cross street names and either BEDFORD STREET or BARROW STREET as the other cross
                                    street name.
                                </p>
                                <p>
                                    A dead end is a termination point of a street at which there are no cross streets.
                                    For example, Croes Avenue in the Bronx has a dead end near where it intersects with
                                    Watson Avenue. To submit a Function 3 inquiry that includes the dead end, enter
                                    CROES AVENUE as the &#8216;On' street names and DEAD END as one of the other cross
                                    street names and WATSON AVENUE as the other cross street name.
                                </p>
                                <p>
                                    Linden Boulevard in Queens intersects with the city limit (in this case, the Queens-Nassau
                                    County border). To submit a Function 3 inquiry that includes the city boundary,
                                    enter LINDEN BOULEVARD as the On street name and CITY LIMIT as one of the cross
                                    street names and X ISLE PARKWAY ENTRANCE NB as the other street name.
                                </p>
                                <p>
                                    In Queens, CITY LIMIT may be specified as the On Street and 41 AVENUE and 41 DRIVE
                                    may be specified as the cross street names. The information returned will be only
                                    for the Queens side of the county border. No information will be returned for the
                                    Nassau side of the county border.
                                </p>
                            </dd>
                        </dl>
                        <p>
                            Place names may not be used for either On street or Cross Street names in a STREET
                            SEGMENT (Function 3) call.</p>
                        <div class="text_bottomline">
                            <a href="#menu">Return to Menu</a>
                            <hr />
                        </div>
                        <p class="labels-bold">
                            <a name="f3s"></a>STREET STRETCH (Function 3S) Help:</p>
                        <p>
                            Function 3S accepts as input a street stretch and returns the cross streets along
                            the stretch. You may supply an On Street alone or an On Street and two cross streets,
                            which will limit the amount of data returned. If you elect to supply cross streets
                            and if either or both cross streets intersect the On Street exactly twice, you must
                            supply a compass direction to determine which intersection you want selected. If
                            one or both of the cross streets intersect the On Street more than twice, an error
                            message will be returned indicating this problem and no data will be returned. If,
                            on the other hand, you supply a compass direction and the On Street and cross street
                            intersect once, in addition to the appropriate output, you will receive a warning
                            message indicating that the compass direction was not required.</p>
                        <p class="labels-tip">
                            Instructions for Entering STREET STRETCH (Function 3S) Input Data:</p>
                        <p>
                            All streets supplied must be in the same borough.</p>
                        <p>
                            Enter the names of the On Street and, if you choose, the two cross streets as well
                            as the relevant compass directions if either of the cross streets intersect the
                            On Street exactly twice. You may now submit your inquiry by pressing the Submit
                            button or the ENTER key.</p>
                        <p>
                            The pseudo-street names BEND and DEAD END cannot be used as the On Street in a Function
                            3S call, but they may be used as cross street names when defining a segment. CITY
                            LIMIT can be used as both an On Street and a cross street in Queens and the Bronx.
                        </p>
                        <p>
                            Examples:</p>
                        <dl>
                            <dd>
                                <p>
                                    To submit a Function 3S inquiry that includes the bending point of Commerce Street
                                    in Manhattan, enter COMMERCE STREET as the On Street and BEND as one of the cross
                                    street names and either BEDFORD STREET or BARROW STREET as the other cross street
                                    name. In general, using BEND as a cross street may be difficult because a street
                                    stretch may have more than two bending points.
                                </p>
                                <p>
                                    A dead end is a termination point of a street at which there are no cross streets.
                                    For example, Croes Avenue in the Bronx has a dead end near where it intersects with
                                    Watson Avenue. To submit a Function 3S inquiry that includes the dead end, enter
                                    CROES AVENUE as the On Street name and DEAD END as one of the cross street names
                                    and, say, STORY AVENUE as the other cross street name. Using DEAD END as a cross
                                    street may be hard since a street stretch may have multiple dead ends.
                                </p>
                                <p>
                                    Linden Boulevard in Queens intersects with the city limit (in this case, the Queens-Nassau
                                    County border). To submit a Function 3S inquiry that includes the city boundary,
                                    enter LINDEN BOULEVARD as the On Street name and CITY LIMIT as one of the cross
                                    streets and, say, FRANCIS LEWIS BOULEVARD as the other cross street.
                                </p>
                            </dd>
                        </dl>
                        <p>
                            Place names may not be used for either &#8216;On' street or Cross Street names in
                            a Function 3S call.
                        </p>
                        <p>
                            There is also an option to &#8216;Show Real Streets Only&#8217;, which is set by
                            default. This option returns the names of cross streets along a stretch, and will
                            not return items defined as &#8220;Non-Street Feature&#8221; or &#8220;Bend&#8221;.
                        </p>
                        <div class="text_bottomline">
                            <a href="#menu">Return to Menu</a>
                            <hr />
                        </div>
                        <p class="labels-bold">
                            <a name="fbl"></a>BLOCK &amp; LOT (Function BL) Help</p>
                        <p>
                            The input data to BLOCK &amp; LOT (Function BL) is a Borough, Tax Block and Tax
                            Lot. The information returned is property -specific and building -specific.</p>
                        <p>
                            In addition to the &#8216;fixed' data returned, you have a choice of receiving a
                            list of up to twenty one addresses which applies to the property and/or a list of
                            BINs (Building Identification Numbers) that reside on the property.</p>
                        <p>
                            The TPAD (Transitional Property Address Directory) option allows you to get up-to-date
                            property related information. The TPAD file is updated daily with new information
                            received from the Department of Buildings regarding job filings for new buildings
                            and demolition jobs. Information regarding activity and status is returned.</p>
                        <p class="labels-tip">
                            Instructions for Entering BLOCK &amp; LOT (Function BL) Input Data:</p>
                        <p>
                            As input data to Function BL, you must select a Borough, and enter the Tax Block
                            and the Tax Lot numbers. The Tax Block is a five digit number and the Tax Lot is
                            a four digit number. Leading zeros need not be entered. If you select &#8216;BIN
                            List', you will receive a list of BINs as part of your output. If you do not select
                            &#8216;BIN List', you will receive a list of up to twenty one addresses which apply
                            to the property. For some properties, there are more than twenty one addresses.
                            In these situations, in addition to the twenty one addresses, you will receive a
                            warning message indicating that the lot has more addresses than are displayed.</p>
                        <div class="text_bottomline">
                            <a href="#menu">Return to Menu</a>
                            <hr />
                        </div>
                        <p class="labels-bold">
                            <a name="fbn"></a>BIN (Function BN) Help:</p>
                        <p>
                            The input data to Function BN is a Building Identification Number (BIN). The information
                            returned is building-specific and property-specific and represents information about
                            the single building.
                        </p>
                        <p>
                            In addition to the &#8216;fixed' data returned, you will receive a list of addresses
                            which applies to the input BIN. The list of addresses should be complete because
                            at this time no single building has more than twenty one addresses.
                        </p>
                        <p>
                            The TPAD (Transitional Property Address Directory) option allows you to get up-to-date
                            property related information. The TPAD file is updated daily with new information
                            received from the Department of Buildings regarding job filings for new buildings
                            and demolition jobs. Information regarding activity and status is returned.</p>
                        <p class="labels-tip">
                            Instructions for Entering Function BN Input Data:</p>
                        <p>
                            As input data to Function BN, you must enter the building identification number
                            only. The building identification number is seven digits in length. The first digit
                            must either be 1, 2, 3, 4 or 5. The second digit must not be either an 8* or a 9**.
                            If you are looking for a BIN that only exists in the TPAD file, then you must select
                            the TPAD option.
                        </p>
                        <p>
                            *BINs with a second digit of 8 reference &#8216;dummy&#8217; BINs in the Department
                            of Buildings BIS (Building Information System) and are not retrievable through GOAT.
                        </p>
                        <p>
                            **BINs with a second digit of 9 refer to an obsolete BIN that was used to indicate
                            multiple structures. BINs with this numbering scheme are no longer assigned.</p>
                        <div class="text_bottomline">
                            <a href="#menu">Return to Menu</a>
                            <hr />
                        </div>
                        <p class="labels-bold">
                            <a name="fsc"></a>STREET (Name / Code) Help:</p>
                        <p>
                            This function allows for a variety of options. A user can enter a street name, a
                            street code, browse the Street Name Dictionary (SND), or normalize a street name.
                            The term &#8216;street name&#8217; is used generically to encompass not only names
                            of city streets, but also a wide variety of other New York City geographic feature
                            names including some tunnels, bridges, rail lines and place names. The terms &#8216;street
                            name&#8217; and &#8216;geographic feature name&#8217; are used interchangeably.
                        </p>
                        <p>
                            There are options to set the street name length, to choose Sort or Compact format,
                            and normalize the input street name to return the primary, principal or preferred
                            name. Output, depending on the options chosen, includes Borough, Street Name, Street
                            Code and Geographic Feature Type.</p>
                        <p class="labels-tip">
                            General Instructions and Information regarding Street Name / Code:</p>
                        <p>
                            The Department of City Planning maintains a set of names of geographic features
                            that Geosupport (the software behind GOAT) recognizes and considers valid. All of
                            these names are assigned Street Codes. Street codes enable street name aliases to
                            be grouped together in a meaningful way via the 5 digit or 7 digit street code.
                            Each 10 digit street code is unique to a specific spelling variation of a street.</p>
                            <p>
                                It is important to note that New York City geographic names are meaningful only
                                when the borough is identified, since features in different boroughs can have the
                                same name. For example, all five boroughs have a street named BROADWAY.</p>
                            <p>
                                All geographic feature names are stored in a standardized or &#8216;normalized&#8217;
                                format, but the software will interpret data entered and &#8220;normalize&#8221;
                                it for the user. The normalizing algorithm is quite complex and is beyond the scope
                                of this user guide, but some notable characteristics are as follows:</p>
                            <ul>
                                <li>Ordinal suffixes are absent. Ordinal suffixes are the endings &#8216;st&#8217;,
                                    &#8216;nd&#8217;, &#8216;rd&#8217; and &#8216;th&#8217; often used at the ends of
                                    numeric street names such as &#8216;71st&#8217;, &#8216;42nd&#8217;, &#8216;23rd&#8217;,
                                    and 108th&#8217;. </li>
                                <li>Standard street endings are abbreviated (such as ST for Street, RD for Road, E for
                                    East, etc.) only to the minimum extent necessary to enable names to fit within the
                                    Street Name Length specified by the user. The minimum Street Name Length is 4 and
                                    the maximum is 32. All geographic feature names in the system are normalized within
                                    the 32 byte limit.</li>
                                <li>The character set used for names consists of the letters of the alphabet, the numeric
                                    digits 0 through 9, and the characters dash ( - ), slash ( / ), ampersand ( &amp;
                                    ) and apostrophe ( &#8216; ). </li>
                            </ul>
                            <p>
                                The type of geographic feature associated with each name is identified by the geographic
                                feature type:</p>
                            <ul>
                                <li>The names of New York City's streets (including highways), tunnels and bridges</li>
                                <li>Certain pseudo-street names, including BEND, CITY LIMIT and DEAD END, and certain
                                    Duplicate Address Pseudo-Street names (DAPS&#8217;s), such as HILLSIDE AVENUE DOUGLASTON</li>
                                <li>The names of certain non-street features, including some rail lines and shorelines</li>
                                <li>Selected place names, of which there are three types:
                                    <dl>
                                        <dd>
                                            <ol>
                                                <li><i>Addressable place names</i> are place names that can be combined with address
                                                    numbers to form addresses. Examples: the Manhattan names FEDERAL PLAZA and PENN
                                                    PLAZA. Examples of the use of these names in addresses:
                                                    <br/>
                                                    <br/>
                                                    26 FEDERAL PLAZA, 2 PENN PLAZA.<br />
                                                    <br/>
                                                </li>
                                                <li><i>Non-Addressable Place names (NAPs)</i> are place names that historically could
                                                    not be combined with address numbers to form addresses. Typical NAPs include the
                                                    names of islands, parks, airports, bodies of water, building complexes, major named
                                                    individual buildings etc. Examples: the Manhattan names EMPIRE STATE BUILDING and
                                                    CITY HALL, and the Queens name LA GUARDIA AIRPORT. Note that some NAPs (such as
                                                    EMPIRE STATE BUILDING) refer to buildings that also have conventional street addresses.
                                                    <br />
                                                    <br />
                                                    In recent years, addresses have been assigned to buildings that use the NAP name,
                                                    often in a different location from the NAP itself. An example in Manhattan is the
                                                    NAP called &#8216;Bryant Park&#8217;. There is a building &#8216;One Bryant Park&#8217;
                                                    which users typically enter as &#8216;1 Bryant Park&#8217;. Another example is a
                                                    NAP in Brooklyn called &#8216;Grand Army Plaza&#8217;. A cooperative now exists
                                                    nearby and its address is &#8216;1 Grand Army Plaza&#8217;.
                                                    <br />
                                                    If a NAP name is entered into GOAT along with an address, the application will ignore
                                                    the house number if it does not exist in the underlying data.<br />
                                                    <br/>
                                                </li>
                                                <li><i>Intersection Names</i> are names given to the intersection of two or more streets
                                                    usually but not necessarily by the City Council. Intersection Names allow an intersection
                                                    to be identified using one input &#8220;street&#8221; name instead of two as is
                                                    currently required. BEN KIMMEL SQUARE in the Bronx is an example of an Intersection
                                                    Name.</li></ol>
                                        </dd>
                                    </dl>
                                </li>
                            </ul>
                            <p>
                                Many geographic features have two or more aliases, or alternate names, or spelling
                                variants of the same name. One common case of aliases is names containing a numeric
                                word between 1 and 10; these are all represented with two different spellings; with
                                the numeric word expressed in digits (such as 6 Avenue) and with the numeric word
                                spelled out alphabetically (Sixth Avenue).ue) and with the numeric word spelled
                                out alphabetically (Sixth Avenue).</p>
                            <p>
                                The following are examples of various types of aliases:</p>
                            <ul>
                                <li>SIXTH AVENUE and AVENUE OF THE AMERICAS are aliases, since they are alternative
                                    names for the same street.</li>
                                <li>SEVENTH AVENUE, FASHION AVENUE and ADAM POWELL JR BOULEVARD are aliases, since they
                                    are alternative names for the same street or (in the latter two cases) parts thereof.</li>
                                <li>SIXTH AVENUE and 6 AVENUE are aliases, since they are spelling variants of the same
                                    street name. Other examples of spelling variant aliases are MAC DOUGAL STREET, MC
                                    DOUGAL STREET and MCDOUGAL STREET; BEN-GURION PLACE, BEN GURION PLACE and BENGURION
                                    PLACE; ST MARKS PLACE, SAINT MARKS PLACE and SAINT MARK&#8217;S PLACE; and (in the
                                    Bronx) O&#8217;BRIEN AVENUE, OBRIEN AVENUE and O BRIEN AVENUE.</li>
                            </ul>
                            <p>
                                The existence of an alias relationship between two names stored in the system can
                                be readily identified from their street codes: <i>Two names are aliases if and only
                                    if the first six bytes of their B10SC&#8217;s, known as the Borough-and-5-digit
                                    Street Codes (B5SC&#8217;s), are identical</i>. It can also be readily determined
                                whether two aliases for a geographic feature are valid for the same part (possibly
                                all) of the feature: <i>Two names are valid for the same part (possibly all) of a feature
                                    if and only if the first eight bytes of their B10SC&#8217;s, known as the Borough-and-7-digit
                                    Street Codes (B7SC&#8217;s), are identical</i>.</p>
                            <p>
                                For example, SEVENTH AVENUE, 7 AVENUE, FASHION AVENUE and ADAM POWELL JR BOULEVARD
                                in Manhattan are all aliases, so their street codes all have the same B5SC value.
                                In addition, SEVENTH AVENUE and 7 AVENUE are valid for the same part of the street
                                (in this case, the entire street), so they have the same B7SC value. FASHION AVENUE
                                is valid for a different part of the street (the portion in the Garment District
                                of Midtown), so it has a different B7SC value. ADAM POWELL JR BOULEVARD is valid
                                for yet a different part of the street (the portion north of Central Park), so it
                                has yet a different B7SC value. In the case of a complex (such as Lincoln Center)
                                and its constituent entities, the assignment of street codes is structured analogously
                                to that just described for streets. The names of the entire complex and the names
                                of its constituent entities are all treated as aliases of each other, since they
                                are all names of the same geographic feature (the entire complex) or parts thereof
                                (the constituent entities of the complex). &#8220;Being treated as aliases&#8221;
                                means that the B10SC&#8217;s assigned to these names all have the same B5SC value.
                                Within the umbrella of this B5SC value, the entire complex has its own distinct
                                B7SC value and each constituent entity has its own distinct B7SC value. For example,
                                all of the names for Manhattan&#8217;s Lincoln Center complex and its constituent
                                entities have the same B5SC value. In addition, LINCOLN CENTER and LINCOLN CENTER
                                FOR THE PFMG ARTS are alternative names of the same part of the complex (in this
                                case the entire complex), so these two names have the same B7SC value. AVERY FISHER
                                HALL and PHILHARMONIC HALL are alternative names of the same part of the complex
                                (in this case, a particular building), so these two names have the same B7SC value,
                                which differs from the B7SC values assigned to the names of the entire complex and
                                to the names of the complex&#8217;s other constituent entities.</p>
                            <p>
                                Users should also understand the difference between SORT and COMPACT Format. The
                                sole difference between these two formats is the presence or absence of alignment
                                blanks for names containing numeric characters. A conventional method of displaying
                                streets names is called the Compact Format because it does not contain leading blanks
                                before numeric street names. The Sort Format is more suitable for listing street
                                names for display or in a report because street names will &#8216;sort&#8217; logically:
                                names will &#8216;sort&#8217; logically:</p>
                            <table border="0" cellspacing="0" cellpadding="0" class="labels-sort streetSort" width="600" align="center">
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">SORTED LIST IN COMPACT FORMAT</td>
                    <td width="273" valign="top">SORTED LIST IN SORT FORMAT</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">&nbsp;</td>
                    <td width="273" valign="top">&nbsp;</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST HOUSTON STREET</td>
                    <td width="273" valign="top"><span class="space_sort">bbb</span>5 AVENUE</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 1 STREET</td>
                    <td width="273" valign="top"><span class="space_sort">bb</span>10 AVENUE</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 10 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bbb</span>1 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 102 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bbb</span>2 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 129 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bbb</span>3 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 13 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bbb</span>9 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 167 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bb</span>10 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 2 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bb</span>13 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 20 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bb</span>20 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 201 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">bb</span>79 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 3 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">b</span>102 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 79 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">b</span>129 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">EAST 9 STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">b</span>167 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">FULTON STREET</td>
                    <td width="273" valign="top">EAST <span class="space_sort">b</span>201 STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">10 AVENUE</td>
                    <td width="273" valign="top">EAST HOUSTON STREET</td>
                  </tr>
                  <tr>
                    <td width="27" valign="top">&nbsp;</td>
                    <td width="327" valign="top">5 AVENUE</td>
                    <td width="273" valign="top">FULTON STREET</td>
                  </tr>
                </table>
                            <p>
                                As this example illustrates, in the compact format, normalized street names do not
                                sort appropriately. For example, EAST 10 STREET sorts in front of EAST 9 STREET,
                                and 10 AVENUE sorts in front of 5 AVENUE. In contrast, in the sort format, the presence
                                of the alignment blanks causes street names containing numeric characters to sort
                                appropriately. Notice that the presence of the alignment blanks in the sort format
                                (shown as <span class="space_sort">b</span> in the example), and their absence in
                                the compact format, causes a change to the sort order of numeric street names not
                                only relative to each other, but also relative to non-numeric street names. For
                                example, in the compact format, FULTON STREET sorts in front of street names that
                                begin with a numeric character, such as 10 AVENUE, while in the sort format it sorts
                                behind them. Similarly, in the compact format, EAST HOUSTON STREET sorts in front
                                of the street names that start with the word EAST followed by a numeric word, while
                                in the sort format, it sorts behind those street names.</p>
                            <p>
                                For more information regarding street names and street codes, please refer to our
                                <img src="gifs/pdf_icon.gif" alt="PDF Document" width="12" height="12" align="absmiddle" /><a
                                    href="documents/upg.pdf#page=31" target="_blank">User Programming Guide (Chapters
                                    III and IV)</a>.</p>
                            <p class="labels-tip">
                                Instructions for Entering STREET (Name / Code) data:</p>
                            <p>
                                The STREET (Name / Code) tab in the GOAT application offers a variety of options:</p>
                            <ol>
                                <li>Convert Street Name to Street Code: Select a Borough from the dropdown list and
                                    enter a street name. You have the additional options of selecting a Street Name
                                    Length between 4 and 32 (the default is 32), or specifying Sort vs. Compact Format
                                    (the default is Sort). Hit the Submit button. The information returned is the Street
                                    Name in normalized format, the Borough 10 digit street code (B10SC) and the Geographic
                                    Feature Type.<br />
                                    <br />
                                </li>
                                <li>Convert Street Code to Street Name (D, DG, DN): Enter up to 3 street codes (B5SC,
                                    B7SC or B10SC). You have the additional options of selecting a Street Name Length
                                    between 4 and 32 (the default is 32), or specifying Sort vs. Compact Format (the
                                    default is Sort). Hit the Submit button. The information returned is the Borough,
                                    the Street Name in normalized format, the Borough 10 digit street code (B10SC) and
                                    the Geographic Feature Type.<br />
                                    <br />
                                    Note that if you choose to enter up to 3 street codes, they all must be the same
                                    format; you must enter either all B5SCs, allB7SCs or all B10SCs. If you enter an
                                    optional second or third street code, the software expects those to be in the same
                                    format that you entered the first street code. Therefore, if you enter a B5SC in
                                    the first field and a B7SC in the second field, GOAT will ignore the last two digits
                                    supplied in the B7SC. If on the other hand you enter a B7SC in the first field and
                                    a B5SC in the second or third field, GOAT will treat this as an error.<br />
                                    <br />
                                </li>
                                <li>Normalize Input Street Name (N*): Enter up to 3 street names that are not necessarily
                                    recognized by the system (i.e. either do not exist or have not been assigned street
                                    codes). You have the additional options of selecting a Street Name Length between
                                    4 and 32 (the default is 32), or specifying Sort vs. Compact Format (the default
                                    is Sort). Hit the Submit button. The information returned is the street name(s)
                                    in normalized format.<br />
                                    <br />
                                </li>
                                <li>Browse Street Name Dictionary (BB, BF): Select a borough from the dropdown list
                                    and enter a street name. You have the additional option to normalize the input street
                                    name as the input street, the primary street name (as per the B5SC), the principal
                                    street name (as per the B7SC) or the preferred street name. Hit the Submit button.
                                    Please note that there is no Sort vs. Compact option available in this function.
                                    The output will always be in sort forma.
                                    <div class="text_bottomline">
                                        <a href="#menu">Return to Menu</a></div>
                                </li>
                            </ol>
                    </dd>
                </dl>
            </div>
        </div>
    </div>
</body>
</html>

</asp:Content>
