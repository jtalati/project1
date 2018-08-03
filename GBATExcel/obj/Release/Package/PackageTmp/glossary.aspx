<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="glossary.aspx.vb" Inherits="GBATExcel.glossary1" %>
<asp:Content ID="WebGBATGlossary" ContentPlaceHolderID="MainContent" runat="server">
<html xmlns="http://www.w3.org/1999/xhtml">
<%--<head id="Head1" runat="server">--%>
<head id="Head1">
    <title>WebGBAT &#8211;</title>
    <meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
    <link href="/WebGbat/Content/bootstrap.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <link href="Content/stylesheet.css" rel="stylesheet" type="text/css" />


    <script src="extern/commons.js" type="text/javascript"></script>

    <script src="extern/google_analytics.js" type="text/javascript"></script>

    <style type="text/css">
        .style1
        {
            width: 189px;
        }
        .style2
        {
            width: 16%;
        }
        .style3
        {
            width: 23%;
        }
        .style4
        {
            width: 19%;
        }
        .style5
        {
            width: 22%;
        }
        .style6
        {
            width: 28%;
        }
        .style8
        {
            width: 21%;
        }
        .style9
        {
            width: 20%;
        }
        .style12
        {
            width: 48px;
        }
        .style13
        {
            width: 129px;
        }
        .style14
        {
            width: 18%;
        }
        .style15
        {
            width: 22%;
            height: 20px;
        }
        .style16
        {
            height: 20px;
        }
    </style>
</head>
<body>
    <%--<form id="form_goat_f1b_output" runat="server">--%>
    <%--<form id="form_goat_f1b_output">--%>
    <div class="container">
        <div class="content">
        <div class="inputField">
            <h2 style="font-size:x-large; font-weight:bold;">
                WebGBAT Glossary
            </h2>
            <p>
                This is the Glossary Page for WebGBAT &#8211;. It 
                contains definitions for the fields displayed for the various function calls 
                available in WebGBAT. A list of expected field values and their meaning accompanies 
                the definitions.</p>
            <div class="glossary">
                <dl>
                    <dt><a name="add_valid"></a><strong>Additional Valid B7SC/Street Name:</strong></dt>
                    <dd>
                        <p>
                            Identifies additional local group of street names at the given location.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="addr_id"></a><strong>Address Point ID:</strong></dt>
                    <dd>
                        <p>
                            The Address Point ID is a unique nine digit identifier for each address point. 
                            Address Points are items in a CSCL feature class that represent point locations 
                            (approximately five feet inside a building (identified by BIN)) along the 
                            corresponding street frontage. Initially these were based on DCP&#8217;s Property 
                            Address Directory (PAD). Please note that whereas addresses in PAD reflect an 
                            administrative address range for a building, the Address Points usually only 
                            reflect the posted address. For example, PAD shows 14 &#8211; 32 Reade Street as the 
                            address for DCP&#8217;s former headquarters. The Address Point only shows 22 &#8211; 22 
                            Reade Street (the posted address).
                         </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="add_range"></a><strong>Address Range List:</strong></dt>
                    <dd>
                        <p>
                            An input address number is often part of a larger address range that is valid 
                            for a tax lot. A location may also have additional address ranges on street 
                            names that differ from the input, particularly when the input address is located 
                            on a corner lot or a through lot. The address range list includes the Address 
                            Type, Low and High Address Numbers, Street Name, BIN and TPAD BIN Status.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="addr_type"></a><strong>Address Type:</strong></dt>
                    <dd>
                        <p>
                            Various geographic identifiers related to the property functions in Geosupport 
                            (1B, BL, BN).</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    blank
                                </td>
                                <td>
                                    Address Range
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    A
                                </td>
                                <td>
                                    Addressable Place Name
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    B
                                </td>
                                <td>
                                    Non-Addressable Unnamed Building
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    F
                                </td>
                                <td>
                                    Vacant Street Frontage
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    G
                                </td>
                                <td>
                                    Name of NAP Complex
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    H
                                </td>
                                <td>
                                    Hyphenated Address Range
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    M
                                </td>
                                <td>
                                    Mixed Hyphenation Address Range
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    N
                                </td>
                                <td>
                                    Non-Addressable Place Name
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    O
                                </td>
                                <td>
                                    Out of Sequence Address
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Q
                                </td>
                                <td>
                                    Pseudo Address
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    R
                                </td>
                                <td>
                                    Real Address for Vanity Address
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    T
                                </td>
                                <td>
                                   Bridge/Tunnel 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    U
                                </td>
                                <td>
                                    Subway - Railway Station
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    V
                                </td>
                                <td>
                                    Vanity Address
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    W
                                </td>
                                <td>
                                    Non-Addressable Building Frontage
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    X
                                </td>
                                <td>
                                    Constituent NAP of Complex
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="alx"></a><strong>Alley/Cross Street Flag:</strong></dt>
                    <dd>
                        <p>
                            This indicates if the cross streets returned have been modified.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style1">
                                    XStrts Changed
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    No Split/Change</td>
                                    <td>
                                        &nbsp;
                                    </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="ad"></a><strong>Assembly District:</strong></dt>
                    <dd>
                        <p>
                            New York State Assembly District. A district of the lower house of the New York 
                            State legislature.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="ap"></a><strong>Atomic Polygon (formerly called Dynamic Block):</strong></dt>
                    <dd>
                        <p>
                            A minimal polygon formed by most segments in the underlying data. 'Minimal' 
                            means the polygon is not subdivided by other segments into a smaller polygon. 
                            Atomic Polygon numbers are unique within 2010 Census Tracts and are used as 
                            building blocks for many higher geographies.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="auxseg_count"></a><strong>Auxiliary Segment Count:</strong></dt>
                    <dd>
                        <p>
                            Represents the number of segments that were combined to create a generated 
                            record.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="auxseg_id_list"></a><strong>Auxiliary Segment ID List:</strong></dt>
                    <dd>
                        <p>
                            List of Segment ID's associated with a generated record.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="b7sc"></a><strong>B5SC, B7SC, B10SC (Street Codes):</strong></dt>
                    <dd>
                        <p>
                            Numeric street codes are assigned to represent the city&#8217;s street names and other 
                            geographic feature names. A borough code combined with a 5-digit street code 
                            (B5SC) corresponds to the primary name for a given piece of geography and 
                            encodes the alias relationships between street names. A borough code combined 
                            with a 7-digit street code (B7SC) corresponds to the preferred name for a 
                            specific location on a street whereas a 10-digit street code (B10SC) corresponds 
                            to a specific spelling of a specific street name in the given borough.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="bbl"></a><strong>BBL (Borough, Block, Lot):</strong></dt>
                    <dd>
                        <p>
                            Identifies a parcel of real property in New York City, called a tax lot. The BBL 
                            contains a 1 byte Borough Code, a 5-byte Tax Block, and a 4-byte tax lot. The 
                            tax block and tax lot are both right justified, zero filled.
                            <br>
                            In a condominium, each condominium unit is a separate tax lot and has its own 
                            BBL. WebGBAT will return both the low and high BBL associated with the condo. Users 
                            should also note than if a condo lot is entered as input into a Block &amp; Lot 
                            (Function BL), the tax lot returned in WebGBAT is a Billing BBL, generally 
                            associated with the management company for the condo instead of an individual 
                            owner.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="bike_lane"></a><strong>Bike Lane:</strong></dt>
                    <dd>
                        <p>
                            Defines which street segments are part of the bicycle network as defined by the 
                            Department of Transportation.
                        </p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style2">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    1 Class I:
                                </td>
                                <td>
                                    &nbsp;Separated Greenway
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    2 Class II:
                                </td>
                                <td>
                                    &nbsp;Striped Bike Lane
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    3 Class III:
                                </td>
                                <td>
                                    Signed Bicycle Route
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    4 Links:
                                </td>
                                <td>
                                    Connecting Segments
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    5 Class I, II:
                                </td>
                                <td>
                                    Combination of Class I and II
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    6 Class II, III:
                                </td>
                                <td>
                                    Combination of Class II and III
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    7 Stairs:
                                </td>
                                <td>
                                    Step streets, bridge stairs, etc.
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    8 Class I, III:
                                </td>
                                <td>
                                    Combination of Class I and III (Class I with segment and Class III against)
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    9 Class II, I:
                                </td>
                                <td>
                                    Combination of Class II and I (Class II with segment and Class I against)
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    10 Class III, I:
                                </td>
                                <td>
                                    Combination of Class III and I (Class III with segment and Class I against)
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    11 Class III, II:
                                </td>
                                <td>
                                    Combination of Class III and II (Class III with segment and Class II against)
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="bike_lane_travel_direction"></a><strong>Bike Lane Traffic Direction:</strong></dt>
                    <dd>
                        <p>
                        </p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    FT
                                </td>
                                <td>
                                    With
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    TF
                                </td>
                                <td>
                                    Against
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    TW
                                </td>
                                <td>
                                    Two-Way
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    NV
                                </td>
                                <td>
                                    Non-Vehicular
                                </td>
                            </tr>
                             
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="bin"></a><strong>BIN:</strong></dt>
                    <dd>
                        <p>
                            Building Identification Number (BIN) is a seven-digit numerical identifier 
                            unique to each building in the City of New York. The first digit is the Borough 
                            Code. If the borough code is followed by all zeroes (commonly referred to as a 
                            &#8216;million BIN&#8217;, this indicates that a BIN has not been assigned, either because 
                            the address associated with the building has not yet been built, an address is 
                            assigned as a potential valid range where there is no building (vacant lot or 
                            vacant street frontage), or it is associated with a constituent entity of a 
                            Complex NAP but does not indicate a building or structure that would have a BIN 
                            assignment (such as the Children&#8217;s Zoo Spider Web within Central Park).</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="bin_status"></a><strong>BIN Status:</strong> See <a href="#tpad_bin_status">
                        TPAD BIN Status</a></dt>
                </dl>
                <dl>
                    <dt><a name="block_face"></a><strong>Block Face:</strong><dd>
                        <p>
                            A block face is generally described as one side of a street between two 
                            consecutive intersections, or one side a city block. This field returns the 
                            number of block faces that border the tax lot.</p>
                    </dd>
                    </dt>
                </dl>
                <dl>
                    <dt><a name="block_face_id"></a><strong>Block Face ID:</strong><dd>
                        <p>
                            Left Blockface ID is a ten digit number identifying the block face on the left 
                            hand side of a segment. Correspondingly, Right Blockface ID identifies the block 
                            face on the right hand side of a segment. Block Face is defined as one 
                            continuous side of a physical block that is intersected on that side by two 
                            other physical through streets. Blockface IDs were established by DoITT&#8217;s 
                            consultants working on the planimetric feature classes for NYC and are not 
                            maintained by the Department of City Planning.</p>
                    </dd>
                    </dt>
                </dl>
                <dl>
                    <dt><a name="boe_preferred"></a><strong>BOE Preferred B7SC / Street Name:</strong></dt>
                    <dd>
                        <p>
                            Identifies the local group of street names used by the Board of Elections as 
                            'preferred' for a specific location on a street. The last two digits of the B7SC 
                            (Borough + 7 Digit Street Code) represents the valid name(s) for a given 
                            location.
                    </dd>
                </dl>
                <dl>
                    <dt><a name="sani_bulk_pickup"></a><strong>Sanitation Bulk Pickup:</strong></dt>
                    <dd>
                        <p>
                            Indicates which days of the week the Department of Sanitation will pick up Bulk Items on a scheduled basis.  Scheduled Bulk Items pickup is currently a pilot program</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    M
                                </td>
                                <td>
                                    Monday 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    T
                                </td>
                                <td>
                                    Tuesday 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    W
                                </td>
                                <td>
                                    Wednesday 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    TH
                                </td>
                                <td>
                                    Thursday 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    F
                                </td>
                                <td>
                                    Friday 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    S
                                </td>
                                <td>
                                    Saturday 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    E
                                </td>
                                <td>
                                    ‘E’ is used in combination with a day of the week (as noted above) to indicate that collection occurs ‘every’ week on that day. 
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Z
                                </td>
                                <td>
                                    Recycling is collected privately  
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="boro"></a><strong>Borough:</strong></dt>
                    <dd>
                        <p>
                            New York City is composed of five boroughs</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    Manhattan
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    Bronx
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    Brooklyn
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4
                                </td>
                                <td>
                                    Queens
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    5
                                </td>
                                <td>
                                    Staten Island
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="bid_id"></a><strong>Business Improvement District:</strong></dt>
                    <dd>
                        <p>
                            Business Improvement Districts are a public / private partnership in which 
                            property and business owners elect to make a collective contribution to the 
                            maintenance, development, and promotion of their commercial district.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="cd_eligible"></a><strong>CD Eligibility:</strong></dt>
                    <dd>
                        <p>
                            Indicates whether the input location is in a census tract that is eligible for 
                            Community Development Block Grant funds.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style3">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    CD Eligible
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    Not CD Eligible
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="census_block_2000"></a><strong>2000 Census Block: </strong></dt>
                        <dd>
                            <p>
                                Geographic area defined by the U.S. Census Bureau for the 2000 decennial census.</p>
                        </dd>
                </dl>
                <dl>
                    <dt><a name="census_block_2010"></a><strong>2010 Census Block:</strong></dt>
                    <dd>
                        <p>
                            Geographic area defined by the U.S. Census Bureau for the 2010 decennial census.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="census_tract_2000"></a><strong>2000 Census Tract:</strong></dt>
                    <dd>
                        <p>
                            Geographic area defined by the U.S. Census Bureau for the 2000 decennial census.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="census_tract_2010"></a><strong>2010 Census Tract:</strong></dt>
                    <dd>
                        <p>
                            Geographic area defined by the U.S. Census Bureau for the 2010 decennial census.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="cco"></a><strong>City Council District:</strong></dt>
                    <dd>
                        <p>
                            A district represented by a member of the New York City Council. Consists of an 
                            aggregation of Election Districts.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="coincident_seg_cnt"></a><strong>Coincident Segment Count:</strong></dt>
                    <dd>
                        <p>
                            Indicates situations where geography is stacked and therefore more than one 
                            segment. An example would be a portion of the Williamsburg Bridge which is 
                            located directly above a subway line . In this case, the Coincident Segment 
                            Count would be equal to 2.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="com_dist"></a><strong>Community District:</strong></dt>
                    <dd>
                        <p>
                            Definition: Community District. The first byte is a borough code and the second 
                            and third bytes are the community district number. There are 59 community 
                            districts in the city of New York, as well as 12 Joint Interest Areas (JIAs). 
                            The JIAs are major parks and airports that are not contained within any 
                            community districts.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="condo_flag"></a><strong>Condo Lot: </strong></dt>
                    <dd>
                        <p>
                            Indicates whether or not this property is a condominium.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style4">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Condominium
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Non-Condo<td>
                                    </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="cd"></a><strong>Congressional District:</strong></dt>
                    <dd>
                        <p>
                            A district of the U.S. House of Representatives. Consists of an aggregation of 
                            Election Districts.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="compass"></a><strong>Compass Direction:</strong></dt>
                    <dd>
                        <p>
                            In the case of Function 2 (Intersection), the compass direction identifies, for 
                            a pair of input streets that intersect at two distinct locations, which of those 
                            two intersections is to be processed. In the case of Function 3 (Street 
                            Segment), the compass direction may be set to indicate the side of the street to 
                            be processed. The compass direction can also be indicated on Function 3S (Street 
                            Stretch) for one or both of the cross streets if they intersect at two distinct 
                            locations.</p>
                        <table>
                            <tr>
                                <td class="style12">
                                    <strong>Value</strong>
                                </td>
                                <td class="style13">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style12">
                                    E
                                </td>
                                <td class="style13">
                                    East
                                </td>
                            </tr>
                            <tr>
                                <td class="style12">
                                    N
                                </td>
                                <td class="style13">
                                    North
                                </td>
                            </tr>
                            <tr>
                                <td class="style12">
                                    S
                                </td>
                                <td class="style13">
                                    South
                                </td>
                            </tr>
                            <tr>
                                <td class="style12">
                                    W
                                </td>
                                <td class="style13">
                                    West
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="corner_code"></a><strong>Corner Code:</strong></dt>
                    <dd>
                        <p>
                            Indicates if the input is located on a corner property of the physical block.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="cross_street"></a><strong>Cross Street:</strong></dt>
                    <dd>
                        <p>
                            A street intersecting another street. In WebGBAT, Cross Streets used as input for a 
                            street segment (Function 3) must be consecutive. WebGBAT also returns cross streets 
                            at the low and high address ends of street segments.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="cross_street_cnt"></a><strong>Cross Street Count:</strong></dt>
                    <dd>
                        <p>
                            The number of streets that intersect at this intersection.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="curve_flag"></a><strong>Curve Flag:</strong></dt>
                    <dd>
                        <p>
                            This flag indicates whether the given geographic feature segment is in reality 
                            curved. If so, the curve may be an arc of a circle or an irregular curve. When 
                            the segment specified by the input data is an arc of a circle, Functions 1 and 
                            1E return Spatial Coordinates that are positioned relative to this arc rather 
                            than to the segment&#8217;s chord (the imaginary straight line joining the curved 
                            feature&#8217;s endpoints). When the segment specified by the input data is an 
                            irregular curve, Functions 1 and 1E return blanks in the Spatial Coordinate 
                            fields (q.v.), and issue a warning with Reason Code value &#8216;P&#8217;. In the case of 
                            Functions 3 and 3C, if the input data define a street stretch encompassing more 
                            than one segment (because of a T-intersection or bend), the Curve Flag is set 
                            &#8216;on&#8217; (non-blank) if at least one of the constituent segments of the stretch is 
                            curved. See also discussion of Segment Length.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style5">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    Blank
                                </td>
                                <td>
                                    None: segment is not curved
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    I
                                </td>
                                <td>
                                    Segment is an irregular curve, i.e., it is curved but it is not an arc of a 
                                    circle
                                </td>
                            </tr>
                            <tr>
                                <td class="style5">
                                    L
                                </td>
                                <td>
                                    Segment is an arc of a circle on the left side of the line joining the segment&#8217;s 
                                    FROM and TO nodes
                                </td>
                            </tr>
                             
                            <tr>
                                <td>
                                    R
                                </td>
                                <td>
                                    Segment is an arc of a circle on the right side of the line joining the 
                                    segment&#8217;s FROM and TO nodes
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                
                <dl>
                    <dt><a name="dcp_pref"></a><strong>DCP Preferred B7SC / Street Name:</strong></dt>
                    <dd>
                        <p>
                            Identifies the local group of street names designated by the Department of City 
                            Planning as 'preferred' for a specific location on a street. The last two digits 
                            of the B7SC (Borough + 7 Digit Street Code) represents the valid name(s) for a 
                            given location.</p>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="dog_leg"></a><strong>Dog Leg:</strong></dt>
                    <dd>
                        <p>
                            In NYC, a dog leg refers to an offset intersection.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="dot_street_light_contract_area"></a><strong>DOT Street Light Area:</strong></dt>
                    <dd>
                        <p>
                            Determination of which borough contractors are responsible for servicing the 
                            street light.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="dsny_snow_priority"></a><strong>DSNY Snow Priority:</strong></dt>
                    <dd>
                        <p>
                            The DSNY (Department of Sanitation) Snow Priority indicates the priority of the 
                            street with respect to snow removal.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style15">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%" class="style16">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style5" valign="top">
                                    C - Critical  
                                </td>
                                <td>
                                                                        These routes are comprised of highways (main beds, entrances, exits interchanges), arterial roadways, main travel thoroughfares (single lane and multi-lane), bus routes, that contain emergency services & first responder facilities (Hospitals, EMS, FDNY, NYPD) and schools  
                                </td>
                            </tr>
                            <tr>
                                <td class="style5" valign="top">
                                    S - Sector
                                </td>
                                <td>
                                                                        Designed to encompass all streets that are not classified as Critical Streets and are wide enough to accommodate a full size DSNY collection truck with a plow attached.
                                </td>
                            </tr>
                            <tr>
                                <td class="style5" valign="top">
                                    H - Haulster
                                </td>
                                <td>
                                    Designed to service dead ends and streets that cannot be serviced with a collection truck or salt spreader with a plow attached due to narrow street width or tight turning radius (either entering or exiting the street).
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    V 
                                </td>
                                <td>
                                    Non-DSNY responsible segment
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="ed"></a><strong>Election District:</strong></dt>
                    <dd>
                        <p>
                            Defined by the NYC Board of Elections to conduct elections. Each ED is numbered
                            uniquely within its Assembly District. All of NYC's higher-level political districts
                            are defined as aggregates of EDs.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="feature_type"></a><strong>Feature Type:</strong></dt>
                    <dd>
                        <p>
                            Identifies the type of geographic feature represented.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style6">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Street
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Railroad
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Shoreline
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Census Boundary
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Private Street
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Physical Bndy
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Walking Path
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style6">
                                    Possible CCO
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="fire_bat"></a><strong>Fire Battalion:</strong></dt>
                    <dd>
                        <p>
                            Administrative Fire district composed of Fire Companies.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="fire_co_num"></a><a name="fire_co_type"></a><strong>Fire Company:</strong></dt>
                    <dd>
                        <p>
                            Fire companies are characterized by the type the type of apparatus they use to fight
                            fires (Engine or Ladder) or as a Squad, along with a number (i.e. Engine 220. Ladder
                            4, Squad 1). These are the smallest kind of administrative fire districts defined
                            by the Fire Department.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="fire_div"></a><strong>Fire Division:</strong></dt>
                    <dd>
                        <p>
                            Administrative Fire district composed of Fire Battalions.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="from_node"></a><strong>From Node:</strong> See <a href="#lion_node_num">
                        LION Node Number</a></dt>
                </dl>
                <dl>
                    <dt><a name="from_st"></a><strong>From Street:</strong></dt><dd>
                        <p>
                            Refers to the cross street where the lowest house numbers of the on-street begins.
                            For streets where there are no addresses at all, the From Street is assigned arbitrarily,
                            but consistently, along the street&#8217;s full extent.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="from_xy"></a><strong>From X, Y Coordinate:</strong> See <a href="#x_coord">
                        X, Y Coordinate</a></dt>
                </dl>
                <dl>
                    <dt><a name="gap_flag"></a><strong>Gap Flag:</strong></dt>
                    <dd>
                        <p>
                            This indicates whether or not a gap exists along the 'on' street between a particular
                            intersection and its predecessor.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style2">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    blank
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    Combined Seg
                                </td>
                                <td>
                                    Segments with intervening nodes that do not result in cross streets have been combined
                                    when the &#8216;Show Real Streets Only&#8217; box is checked.
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                Dog Leg</td>
                                <td>
                                Dogleg</td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    Gap
                                </td>
                                <td>
                                Gap in Stretch
                            </tr>
                            <tr>
                                <td class="style2">
                                    New
                                </td>
                                <td>
                                New Stretch Started
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="generic_id"></a><strong>Generic ID:</strong></dt>
                    <dd>
                        <p>
                            A unique ID assigned in order to aggregate granular geometry to represent a Generic
                            View of the city's street network. Streets that contain multiple carriageways or
                            roadbeds (such as Queens Boulevard in Queens and Park Ave in Manhattan) are represented
                            by multiple centerlines corresponding to each roadbed as well as an imaginary 'single
                            generic centerline.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="gft"></a><strong>Geographic Feature Type:</strong></dt>
                    <dd>
                        <p>
                            This item indicates the type of geographic feature, an attribute of the geographic
                            feature or the type of geographic feature name represented.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style14">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Unhypenated
                                </td>
                                <td>
                                    Street with unhyphenated addresses
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Addressable Pl
                                </td>
                                    <td>
                                        Addressable Placename
                                    </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Bridge
                                </td>
                                <td>
                                    Bridge
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    BID
                                </td>
                                <td>
                                    Business Improvement District
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    DAPs Street
                                </td>
                                <td>
                                    Duplicate address pseudo-street name (DAPS)
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Entirely within Edgewater Park
                                </td>
                                <td>
                                    Street is entirely within Edgewater Park
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Partially within Edgewater Park
                                </td>
                                <td>
                                    Street is partially within Edgewater Park
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    NAP Complex
                                </td>
                                <td>
                                    Name of a complex
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Hyphenated
                                </td>
                                <td>
                                    Street with hyphenated addresses
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Intersection
                                </td>
                                <td>
                                    Intersection name
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Boundary
                                </td>
                                <td>
                                    Non-Physical boundary feature
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Mixed Hyphen
                                </td>
                                <td>
                                    Street with both unhyphenated and hyphenated addresses
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    NAP Name
                                </td>
                                <td>
                                    Non-Addressable Placename (NAP)
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Shoreline
                                </td>
                                <td>
                                    Shoreline
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Pseudo name
                                </td>
                                <td>
                                    Pseudo Street Name
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Rail line
                                </td>
                                <td>
                                    Rail line
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Tunnel
                                </td>
                                <td>
                                    Tunnel
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Misc Structure
                                </td>
                                <td>
                                    Miscellaneous structure
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Constituent NAP
                                </td>
                                <td>
                                    Constituent NAP, part of a complex
                                </td>
                            </tr>
                            <tr>
                                <td class="style14">
                                    Ramp
                                </td>
                                <td>
                                    Exit or Entrance Ramp
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="health_area"></a><strong>Health Area:</strong></dt>
                    <dd>
                        <p>
                            Districts defined by the NYC Department of Health for administrative purposes. Health
                            Areas are aggregates of Census Tracts.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="health_center_dist"></a><strong>Health Center District:</strong></dt>
                    <dd>
                        <p>
                            Districts defined by the NYC Department of Health for administrative purposes. Health
                            Center Districts are aggregates of Health Areas.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="hi_x_b7sc_list"></a><strong>High BBL of Condo:</strong> See <a href="#bbl">
                        BBL (Borough, Block, and Lot)</a></dt>
                </dl>
                <dl>
                    <dt><a name="hi_end_cross"></a><strong>High End Cross Streets (B7SC/Name):</strong></dt>
                    <dd>
                        <p>
                            A list of up to 5 cross streets at the high address end.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="hi_house_no"></a><strong>High House Number:</strong> See <a href="#hhnd">
                        House Number</a></dt>
                </dl>
                <dl>
                    <dt><a name="hhnd"></a><strong>House Number:</strong></dt>
                    <dd>
                        <p>
                            Synonymous with Address Number. The low or high value for the numeric address range
                            (display format).
                        </p>
                    </dd>
                </dl>

                <dl>
                    <dt><a name="hurricane_zone"></a><strong>Hurricane Evacuation Zone:</strong></dt>
                    <dd>
                        <p>
                            New York City’s hurricane contingency plans are based on six evacuation zones. 
                            More information on Hurricane Evacuation Zones can be found at
                            <a href="http://www.nyc.gov/html/oem/html/hazards/storms_evaczones.shtml">Evacuation Zone Finder at OEM of New York City
                                </a>.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    0
                                </td>
                                <td>
                                    Coastal Water Polygon
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    1-6
                                </td>
                                <td>
                                    Hurricane Evacuation Zone designation
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    X
                                </td>
                                <td>
                                    Land not part of an evacuation zone 
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="intersecting_st"></a><strong>Intersecting Streets:</strong></dt>
                    <dd>
                        <p>
                            For &#8220;INTERSECTION (Function 2)&#8221;, these are the streets that intersect
                            at the node in the underlying data. For &#8220;STREET STRETCH (Function 3S)&#8221;,
                            these are the streets that intersect the 'On Street' for a given street stretch
                            .
                        </p>
                    </dd>
                </dl>
                 <dl>
                    <dt><a name="latitude"></a><strong>Latitude, Longitude:</strong></dt>
                    <dd>
                        <p>
                            Spatial coordinates based on the lines of latitude and longitude. Lines of latitude 
							measure the north-south position between the poles with the equator defined as 0 degrees. 
							Lines of longitude (or meridians) measure the east-west position, with the prime 
							meridian running through Greenwich, England.  For NYC, Latitude is always positive and 
							Longitude is always negative.
                            <br>
                            <br>
                            The values of the latitude and longitude of a location are based on the x,y coordinate of
                            the location. As a result, the values in the Geographic Information portion of the Address 
                            function will be different from the values in the Property Level Information portion. See <a href="#x_coord">
                            X,Y Coordinate</a>
							</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="lion_face"></a><strong>LION Face Code:</strong> See <a href="#lion_key">
                        LION Key</a></dt>
                </dl>
                <dl>
                    <dt><a name="lion_key"></a><strong>LION Key: </strong></dt>
                        <dd>
                            <p>
                                The LION key consists of a borough code, a 4-digit face code and a 5-digit sequence
                                number. A Face code is assigned to each linear geographic feature.</p>
                        </dd>
                </dl>
                <dl>
                    <dt><a name="lion_node_num"></a><strong>LION Node Number:</strong></dt>
                    <dd>
                        <p>
                            A node occurs wherever two or more linear features cross regardless of whether a
                            physical intersection occurs at that point. Nodes also occur where a feature terminates
                            and can also occur when a feature bends. The nodes returned in WebGBAT tend to be those
                            corresponding with 'real' intersections.
                            <br/>
                            <br/>
                            The From Node is the Node identifier at the low address end, or beginning of a street
                            segment.
                            <br/>
                            The To Node is the node identifier at the high address end, or end of a street segment.
                        </p>
                    </dd>
                    <dt><a name="lion_seq_num"></a><strong>LION Sequence Number:</strong> See <a href="#lion_key">
                        LION Key</a></dt>
                </dl>
                <dl>
                    <dt><a name="loc_status"></a><strong>Location Status:</strong></dt>
                    <dd>
                        <p>
                            Indicates locational status of street segments.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    blank
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    H
                                </td>
                                <td>
                                    Segment internal to a block but not a Dead End
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    I
                                </td>
                                <td>
                                    Dead End Segment
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    X
                                </td>
                                <td>
                                    Tract boundary segment
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    Segment bordering Manhattan
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    Segment bordering Bronx
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    Segment bordering Brooklyn
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4
                                </td>
                                <td>
                                    Segment bordering Queens
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    5
                                </td>
                                <td>
                                    Segment bordering Staten Island
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    9
                                </td>
                                <td>
                                    Segment bordering City Limits
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="low_bbl_c"></a><strong>Low BBL of Condo:</strong> See <a href="#bbl">BBL
                        (Borough, Block, and Lot)</a></dt>
                </dl>
                <dl>
                    <dt><a name="low_end_cross"></a><strong>Low End Cross Streets (B7SC/Name):</strong></dt>
                    <dd>
                        <p>
                            A list of up to 5 cross streets at the low address end.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="low_house_no"></a><strong>Low House Number:</strong> See <a href="#hhnd">
                        House Number</a></dt>
                </dl>
                <dl>
                    <dt><a name="mc"></a><strong>Municipal Court District:</strong></dt>
                    <dd>
                        <p>
                            A district from which a Civil Court judge is elected. Consists of an aggregation
                            of Election Districts.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="nta"></a><strong>Neighborhood Tabulation Area:</strong></dt>
                    <dd>
                        <p>
                            Neighborhood Tabulation Areas (NTAs) were created by the Department of City Planning
                            to project populations at a small area level for PlaNYC, the long-term sustainability
                            plan for New York City. These are now being used to present data from the Decennial
                            Census and American Community Survey.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="node_num"></a><strong>Node ID:</strong></dt>
                    <dd>
                        <p>
                            A 7 byte numeric ID. A node is an endpoint of a geographic feature segment represented
                            in the base CSCL data. Most nodes are points where a feature bends or terminates
                            or where two features intersect. Node IDs are unique and permanent identifiers.
                            <a href="#lion_node_num">Also see LION Node Number</a>.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="num_of_addrs"></a><strong>Number of Addresses:</strong></dt>
                    <dd>
                        <p>
                            Number of Addresses in the List of Alternative Addresses for the BBL.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="num_of_intersections"></a><strong>Number of Intersections:</strong></dt>
                    <dd>
                        <p>
                            A numerical count of the number of intersections returned for a Function 3S (Street
                            Stretch).</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="num_of_bldgs"></a><strong>Number of Structures:</strong></dt>
                    <dd>
                        <p>
                            Indicates the number of building structures on the lot.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="num_of_park_lanes"></a><strong>Number of Parking Lanes:</strong></dt>
                    <dd>
                        <p>
                            The number of lanes in a carriageway (roadway) that are reserved for parking of vehicles.  
                            The number of parking lanes were determined by DoITT’s consultants working on the planimetric feature classes for NYC.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="total_num_of_lanes"></a><strong>Number of Total Lanes:</strong></dt>
                    <dd>
                        <p>
                            The total number of lanes in a carriageway (roadway) including travel lanes and parking lanes.  
                            The total number of lanes were determined by DoITT’s consultants working on the planimetric feature classes for NYC.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="num_of_travel_lanes"></a><strong>Number of Travel Lanes:</strong></dt>
                    <dd>
                        <p>
                            The number of lanes in a carriageway (roadway) that are designated for the movement of vehicles traveling from one 
                            destination to another.  The number of travel lanes were determined by DoITT’s consultants working on the planimetric 
                            feature classes for NYC.</p>
                    </dd>
                </dl>
                
                <dl>
                    <dt><a name="on_street"></a><strong>On Street:</strong></dt>
                    <dd>
                        <p>
                            Street Segments are defined in WebGBAT by an &#8216;On&#8217; Street and two consecutive
                            cross streets (without or without a compass direction). Street Stretches are defined
                            by an &#8216;On&#8217; Street and the optional entry of two cross streets that do
                            not have to be consecutive.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="on_street_add_valid_names"></a><strong>On-Street Additional Valid Names:</strong></dt>
                    <dd>
                        <p>
                            An additional valid name (corresponding to a different Local Group Code (LGC) for
                            a given street segment. For example, the preferred name for 7th Ave in Manhattan
                            for a specific street is Adam C Powell Boulevard, but the name 7 Ave is also a valid
                            name for the same street.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="san_org_pick_up"></a><strong>Organics Sanitation Pickup:</strong> </dt>
                    <dd>
                        <p>
                            Indicates which days of the week the Department of Sanitation will pick up compostable 
                            waste at the given address. Organics recycling is currently only available in 
							pilot areas.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    M
                                </td>
                                <td>
                                    Monday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    T
                                </td>
                                <td>
                                    Tuesday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    W
                                </td>
                                <td>
                                    Wednesday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    TH
                                </td>
                                <td>
                                    Thursday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    F
                                </td>
                                <td>
                                    Friday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    S
                                </td>
                                <td>
                                    Saturday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    E
                                </td>
                                <td>
                                    &#8216;E&#8217; is used in combination with a day of the week (as noted above) to
                                    indicate that collection occurs &#8216;every&#8217; week on that day.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Z
                                </td>
                                <td>
                                    Recycling is collected privately
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="physical_id"></a><strong>Physical ID:</strong></dt>
                    <dd>
                        <p>
                            A unique ID assigned in order to aggregate granular geometry to represent a Physical
                            View of the city's street network. The raw data has very granular segmentation in
                            order to accommodate many types of physical and non-physical geometry.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="police_boro_com"></a><strong>Police Patrol Borough:</strong></dt>
                    <dd>
                        <p>
                            These are sub-borough geographic areas defined by the Police Department. They are
                            composed of Police Precincts.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="81%">
                                    <strong>Value</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Manhattan South
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Manhattan North
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bronx
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Brooklyn South
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Brooklyn North
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Queens North
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Staten Island
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Queens South
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="police_pct"></a><strong>Police Precinct: </strong></dt>
                    <p>
                        Service areas defined by the Police Department</p>
                </dl>
                <dl>
                    <dt><a name="rec_san_pickup"></a><strong>Recycling Sanitation Pickup:</strong> </dt>
                    <dd>
                        <p>
                            Indicates which days of the week the Department of Sanitation will pick up recycling
                            waste at the given address</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    M
                                </td>
                                <td>
                                    Monday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    T
                                </td>
                                <td>
                                    Tuesday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    W
                                </td>
                                <td>
                                    Wednesday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    TH
                                </td>
                                <td>
                                    Thursday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    F
                                </td>
                                <td>
                                    Friday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    S
                                </td>
                                <td>
                                    Saturday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    E
                                </td>
                                <td>
                                    &#8216;E&#8217; is used in combination with a day of the week (as noted above) to
                                    indicate that collection occurs &#8216;every&#8217; week on that day.
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Z
                                </td>
                                <td>
                                    Recycling is collected privately
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="reg_san_pickup"></a><strong>Regular Sanitation Pickup: </strong></dt>
                    <dd>
                        <p>
                            Indicates which days of the week the Department of Sanitation will pick up non-recycling
                            waste at the given address</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    M
                                </td>
                                <td>
                                    Monday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    T
                                </td>
                                <td>
                                    Tuesday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    W
                                </td>
                                <td>
                                    Wednesday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    TH
                                </td>
                                <td>
                                    Thursday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    F
                                </td>
                                <td>
                                    Friday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    S
                                </td>
                                <td>
                                    Saturday
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    NONE
                                </td>
                                <td>
                                    Refuse is collected privately
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    6X
                                </td>
                                <td>
                                    Refuse pick-up Monday, Tuesday, Wednesday, Thursday, Friday and Saturday
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="right_of_way_type"></a><strong>Right of Way Type:</strong></dt>
                    <dd>
                        <p>
                            Defines the right-of-way type for subway and rail segments returned in WebGBAT.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    blank
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    Subterranean
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    Elevated
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    Surface
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4
                                </td>
                                <td>
                                    Hidden
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    5
                                </td>
                                <td>
                                    Open Cut Depression
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    6
                                </td>
                                <td>
                                    Embankment
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    7
                                </td>
                                <td>
                                    Viaduct
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    8
                                </td>
                                <td>
                                    Subterranean Coincident with Boundary
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="roadway_type"></a><strong>Roadway Type:</strong></dt>
                    <dd>
                        <p>
                            Defines the type of roadway.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="81%">
                                    <strong>Value</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Street
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Highway
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Bridge
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Boardwalk
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Path/Trail
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Step Street
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Driveway
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ramp
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Alley
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Unknown
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Ferry Route
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="rpad_bldg_class"></a><strong>RPAD Building Class:</strong></dt>
                    <dd>
                        <p>
                            RPAD Building Classification Code is a set of land use/building classification codes
                            defined b the Real Property Assessment Division (RPAD) of the Department of Finance.
                            If a tax lot has more than one building or land use, RPAD assigns the building class
                            code they deem to describe best the principal building or the predominant land use
                            on the tax lot. <a href="http://www1.nyc.gov/assets/finance/jump/hlpbldgcode.html">View
                                Building Classification Codes of the City of New York</a>.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="rpad_condo_no"></a><strong>RPAD Condo Number:</strong> </dt>
                    <dd>
                        <p>
                            An identification number assigned by the Department of Finance to each condominium
                            in the city.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="rpad_coop_no"></a><strong>RPAD Co-op Number:</strong> </dt>
                    <dd>
                        <p>
                            An identification number assigned by the Department of Finance to each co-op in
                            the city.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="rpad_int_lot"></a><strong>RPAD Interior Lot:</strong></dt>
                        <dd>
                            <p>
                                This indicates whether a tax lot is interior to a physical block, i.e., it has no
                                street frontages.</p>
                            <table width="620" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="style5">
                                        <strong>Value</strong>
                                    </td>
                                </tr>
                                <tr>
                                   <td class="style5">
                                        Not Interior Lot
                                    </td>
                                </tr>
                                    <tr>
                                        <td class="style5">
                                            Interior Lot
                                        </td>
                                    </tr>
                            </table>
                        </dd>
                </dl>
                <dl>
                    <dt><a name="rpad_ireg_lot"></a><strong>RPAD Irreg. Shaped lot:</strong></dt>
                    <dd>
                        <p>
                            Indicates whether a tax lot is rectangular or irregularly shaped.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style8">
                                    <strong>Value</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                                    Not Irregular Lot
                                </td>
                            </tr>
                            <tr>
                                <td class="style8">
                                    Irregularly-shaped Lot
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="rpad_scc"></a><strong>RPAD SCC:</strong></dt>
                    <dd>
                        <p>
                            For each BBL value, the Department of Finance has computed a Self-Check Code (SCC).
                            This is a one-digit number computed from the BBL value using an algorithm chosen
                            by DOF. The purpose of the SCC is to assist in validating key-entered BBLs.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="sanborn"></a><strong>Sanborn Boro/Vol/Page:</strong></dt>
                    <dd>
                        <p>
                            Sanborn Borough, Volume and Page. The Sanborn Map Company maintains a 79 volume
                            atlas of New York City geography that is widely used by New York City agencies.
                            <br/>
                            <br/>
                            Sanborn 1 Boro/Vol/Page corresponds to the first input street of Function 2 (Intersection).
                            <br/>
                            <br/>
                            Sanborn 2 Boro/Volume/Page corresponds to the second input street of Function 2
                            (Intersection).</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="san_dist"></a><strong>Sanitation District/Section:</strong></dt>
                    <dd>
                        <p>
                            Districts defined by the Department of Sanitation for waste collection.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="san_sub_section"></a><strong>Sanitation Subsection:</strong></dt>
                    <dd>
                        <p>
                            Subareas of Sanitation Districts. Please note that a value is only returned in areas
                            where the City has responsibility for refuse pick-up.
                        </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="school_dist"></a><strong>School District:</strong></dt>
                    <dd>
                        <p>
                            Administrative areas defined by the Department of Education</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="segment_id"></a><strong>Segment ID:</strong></dt>
                    <dd>
                        <p>
                            Segment IDs are seven digit numbers (right justified, zero filled) that represent
                            the minimal segmentation of a street or non-street feature.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="segment_len"></a><strong>Segment Length:</strong></dt>
                    <dd>
                        <p>
                            The length of a street segment represented in feet.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="segment_type"></a><strong>Segment Type:</strong></dt>
                    <dd>
                        <p>
                            Segment Type defines the segment's status in relation to horizontal topology. The
                            various segment types are used to define generic or multi-roadbed views of the street
                            network.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="81%">
                                    <strong>Value</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Undivided
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Generic
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Both generic and roadbed
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Roadbed
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Connector
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Exit/Entrance Ramp
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Terminator
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Faux Segment
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="seg_from_node"></a><strong>Segment From Node:</strong> </dt>
                     <dd>
                        <p>
                            Refers to the Node associated with the “from” end of segment that the input address belongs to.  
                            When there is only one segment for the block, this will be identical to the From Node. 
                            <a href="#lion_node_num">LION Node Number</a></p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="seg_to_node"></a><strong>Segment To Node:</strong> </dt>
                     <dd>
                        <p>
                            Refers to the Node associated with the “to” end of segment that the input address belongs to. 
                            When there is only one segment for the block, this will be identical to the To Node.   
                            <a href="#lion_node_num">LION Node Number</a></p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="seg_from_xy"></a><strong>Segment From X,Y Coordinates:</strong> </dt>
                     <dd>
                        <p>
                             Refers to the X,Y Coordinates associated with the Segment From Node.  
                             When there is only one segment for the block, these will be identical to the From X,Y Coordinate.
                            <a href="#x_coord"> X,Y Coordinates</a></p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="seg_to_xy"></a><strong>Segment To X,Y Coordinates:</strong> </dt>
                     <dd>
                        <p>
                             Refers to the X,Y Coordinates associated with the Segment To Node.  
                             When there is only one segment for the block, these will be identical to the To X,Y Coordinate.
                            <a href="#x_coord"> X,Y Coordinates</a></p>
                    </dd>
                </dl>
                
                <dl>
                    <dt><a name="spec_addr_flag"></a><strong>Special Address:</strong></dt>
                    <dd>
                        <p>
                            These represent special addressing situations</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td class="style9">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Alternate Addr
                                </td>
                                <td>
                                    Address range is alternative to the address range that is stored in LION for this
                                    block face
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Alternate St
                                </td>
                                <td>
                                    The input street name or five-digit street code is different from that stored in
                                    LION for this block face
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Ruby St
                                </td>
                                <td>
                                    The input address pertains to Ruby Street along the Brooklyn-Queens boundary
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Duplicate Addr
                                </td>
                                <td>
                                    The input address involves a duplicate address situation
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Nhood as Street
                                </td>
                                <td>
                                    The input address is in one of the neighborhoods in which the name of the neighborhood
                                    can serve as an alternative street name for the streets in that neighborhood. Edgewater
                                    Park or Harding Park in the Bronx.
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    NAP Complex
                                </td>
                                <td>
                                    The input name or street code corresponds to a non-addressable place name of a complex
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    NAP Name
                                </td>
                                <td>
                                    The input street name or street code corresponds to a non-addressable place name
                                    of a 'stand-alone' geographic feature
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Addr out of Seq
                                </td>
                                <td>
                                    The block face contains out-of-sequence and/or opposite-parity addresses
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Place Name
                                </td>
                                <td>
                                    The input address contains an addressable place name
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Suffix
                                </td>
                                <td>
                                    The input address contains a house number suffix and is either the first or last
                                    address on this block face
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Vanity Address
                                </td>
                                <td>
                                    The input address is a 'vanity address'.
                                </td>
                            </tr>
                            <tr>
                                <td class="style9">
                                    Constituent NAP
                                </td>
                                <td>
                                    The input data specify a non-addressable place name of a constituent entity of a
                                    complex
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="ssd"></a><strong>State Senate District:</strong></dt>
                    <dd>
                        <p>
                            A district of the upper house of the New York State legislature. Consists of an
                            aggregation of Election Districts.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="stname"></a><strong>Street Name:</strong></dt>
                    <dd>
                        <p>
                            The Street or non-street feature name for a given location. WebGBAT normalizes street
                            names so that users have considerable leeway in data entry. For example, WebGBAT allows
                            many commonly used abbreviations for street endings and &#8216;normalizes&#8217;
                            the name to the one stored in the software. Users have a choice of two formats for
                            normalizing street names, called the compact and sort formats. The sort format includes
                            spacing to allow the proper sorting of numerical street names for reporting purposes,
                            and compact removes the spaces. A more complete explanation regarding street names
                            and their associated street codes is beyond the scope of this document. For more
                            information, please refer to Chapters III and IV of the
                            <img src="gifs/pdf_icon.gif" alt="PDF Document" width="12" height="12" align="absmiddle" /><a
                                href="documents/upg.pdf#page=31" target="_blank">User Programming Guide</a>
                        .</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="street_width_reg_max"></a><strong>Street Width Min / Max:</strong></dt>
                    <dd>
                        <p>
                        Street Width Minimum - Contains the minimum width, in feet, of the paved area of a street. 
                        
                        Street Width Maximum - Contains the maximum width, in feet, of the paved area of a street.
                         </p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="structures"></a><strong>Structures:</strong> See <a href="#num_of_bldgs">
                        Number of Structures</a>.</dt>
                </dl>
                <dl>
                    <dt><a name="tax_block"></a><strong>Tax Block:</strong> See <a href="#bbl">BBL (BoroughBBL
                        (Borough, Block, and Lot)</a>.</dt>
                </dl>
                <dl>
                    <dt><a name="tax_lot"></a><strong>Tax Lot: </strong>See <a href="#bbl">BBL (BoroughBBL
                        (Borough, Block, and Lot)</a>.</dt>
                </dl>
                <dl>
                    <dt><a name="tax_map_sec_vol"></a><strong>Tax Map / Section / Volume:</strong></dt>
                    <dd>
                        <p>
                        The Department of Finance real property tax maps were previously organized in sections;
                        each section was organized into volumes; and each volume consisted of pages. Volumes
                        were unique within a borough. Although the DOF now maintains the tax maps digitally,
                        this data item has been retained.
                    </dd>
                </dl>
                <dl>
                    <dt><a name="to_node"></a><strong>To Node:</strong>See <a href="#lion_node_num">LION
                        Node Number</a></dt>
                </dl>
                <dl>
                    <dt><a name="to_st"></a><strong>To Street:</strong></dt>
                    <dd>
                        <p>
                        Refers to the cross street where the highest house numbers of the on-street ends.
                        For streets where there are no addresses at all, the To Street is assigned arbitrarily,
                        but consistently, along the street’s full extent.
                    </dd>
                </dl>
                <dl>
                    <dt><a name="to_xy"></a><strong>To X,Y Coordinate: </strong><a href="#x_coord">X,Y Coordinate</a></dt>
                </dl>
                <dl>
                    <dt><a name="tpad_bin"></a><strong>TPAD BIN: </strong>See <a href="#tpad_new_bin">TPAD
                        New BIN</a></dt>
                </dl>
                <dl>
                    <dt><a name="tpad_bin_status"></a><strong>TPAD BIN Status:</strong></dt>
                    <dd>
                        <p>
                            Corresponds to BIN that has been assigned in the Transitional PAD file.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    blank
                                </td>
                                <td>
                                    No activity for this BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    0
                                </td>
                                <td>
                                    New BIN issued for DOB, no NB application filed at this time
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    NB application filed and paid for at DOB
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    NB application signed-off on by DOB
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    New BIN issued for HPD, no NB application filed at this time
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    5
                                </td>
                                <td>
                                    DM application filed and paid for
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    6
                                </td>
                                <td>
                                    DM application signed-off on by DOB
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="tpad_conflict_flag"></a><strong>TPAD Conflict Flag:</strong></dt>
                    <dd>
                        <p>
                            On occasion, there will be conflicts between the data in the PAD and the TPAD record.
                            These are reported via the TPAD Conflict Flag.</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    blank
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    0
                                </td>
                                <td>
                                    TPAD data found, no conflicts with PAD data
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    1
                                </td>
                                <td>
                                    PAD data found, no TPAD data found
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    2
                                </td>
                                <td>
                                    TPAD BBL used, no existing PAD BBL
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    3
                                </td>
                                <td>
                                    TPAD BBL used, PAD pseudo-address on different BBL than TPAD NB BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    4
                                </td>
                                <td>
                                    TPAD BBL used, existing PAD BIN of Input Address on different BBL than TPAD NB BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    5
                                </td>
                                <td>
                                    (not implemented)
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    6
                                </td>
                                <td>
                                    TPAD BBL used, existing PAD BIN of Input Address with DM 5 on different BBL than
                                    TPAD NB BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    7
                                </td>
                                <td>
                                    TPAD BBL used, existing PAD BIN of Input Address with DM 6 on different BBL than
                                    TPAD NB BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    8
                                </td>
                                <td>
                                    PAD BBL used, TPAD NB BIN with NB-0 on different BBL than PAD BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    9
                                </td>
                                <td>
                                    PAD BBL used, TPAD NB BIN with NB-1 on different BBL than PAD BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    A
                                </td>
                                <td>
                                    PAD BBL used, TPAD NB BIN with NB-2 on different BBL than PAD BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    B
                                </td>
                                <td>
                                    PAD BBL used, TPAD NB BIN with NB-3 on different BBL than PAD BIN
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    C
                                </td>
                                <td>
                                    TPAD data found, TPAD address overlaps PAD address
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    D
                                </td>
                                <td>
                                    Address found in TPAD, not found in PAD
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    E
                                </td>
                                <td>
                                    BIN found in TPAD, not found in PAD
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="tpad_new_bin"></a><strong>TPAD New BIN:</strong></dt>
                    <dd>
                        <p>
                            A new BIN assigned in the Transitional PAD file</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="traffic_direction"></a><strong>Traffic Direction:</strong></dt>
                    <dd>
                        <p>
                            This code indicates the flow of traffic relative to the
                            street segment's directionality (as defined by the From and To nodes and in the
                            direction of increasing addresses).</p>
                        <table width="620" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="11%">
                                    <strong>Value</strong>
                                </td>
                                <td width="81%">
                                    <strong>Description</strong>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    A
                                </td>
                                <td>
                                    One-way Street, flow is against direction of increasing addresses
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    P
                                </td>
                                <td>
                                    Pedestrian Path, non-vehicular
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    T
                                </td>
                                <td>
                                    Two-way Street
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    W
                                </td>
                                <td>
                                    One-way Street, flow is with direction of increasing addresses
                                </td>
                            </tr>
                        </table>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="USPS_city_name"></a><strong>USPS Preferred City Name:</strong></dt>
                    <dd>
                        <p>
                            The USPS (United States Postal Service) Preferred City Name (.e.g. Astoria, Jackson 
							Heights) is based on the ZIP code associated with the input address, and of 
							particular importance for Queens addresses.&nbsp; Unless there is a special ZIP code, 
							the following holds true for the other boroughs:  For Manhattan, the USPS Preferred 
							City Name is New York; for all other boroughs the USPS Preferred City Name is the 
							borough name, viz. Bronx, Brooklyn, and Staten Island.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="vacant_flag"></a><strong>Vacant Lot:</strong></dt>
                    <dd>
                        <p>
                            Indicates whether or not a tax lot is vacant</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="x_coord"></a><strong>X,Y Coordinate:</strong></dt>
                    <dd>
                        <p>
                            Spatial coordinates (New York Long Island State Plane). Spatial coordinates are a pair of numbers
                            that specify a location on the earth’s surface. The X, Y location returned in the
                            geographic information section of an Address (Function 1B) call are imprecise and
                            based on an algorithm that approximates the location based on the address range.
                            In the property level information of an address call, the X, Y coordinate is an
                            internal centroid derived from the tax lot. This same property level X, Y is returned
                            in a Block & Lot (Function BL) and BIN (Function BN) call. The X, Y returned in
                            an Intersection (Function 2) call corresponds to the node at that location.
                            <br/>
                            <br/>
                            WebGBAT also returns X, Y coordinates for the 'From Node' or end of the street segment
                            and for the 'To Node' or end of the street segment.</p>
                    </dd>
                </dl>
                <dl>
                    <dt><a name="zip_code"></a><strong>ZIP Code:</strong></dt>
                    <dd>
                        <p>
                        U.S. Postal Service 5-digit zip code
                    </dd>
                </dl>
            </div>
        </div>
    </div>
  </div>
    <%--</form>--%>
</body>
</html>
</asp:Content>
