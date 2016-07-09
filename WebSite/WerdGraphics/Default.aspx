<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_WerdDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>247Coding.com</title>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" >
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<link rel="icon" href="http://247coding.com/favicon.ico" type="image/x-icon"> 
<link rel="shortcut icon" href="http://www.247coding.com/favicon.ico" type="image/x-icon"> 
<meta http-equiv="X-UA-Compatible" content="IE=edge" /> 

<link rel="icon" href="http://247coding.com/favicon.ico" type="image/x-icon"/> 
        <style>

         ._PanelRounded {
			box-shadow: 3px 4px 5px #888888;	
		color:#333;
		border-top-left-radius: 8px;
        border-top-right-radius: 8px;
        border-bottom-right-radius: 8px;
        border-bottom-left-radius: 8px;
		border-width:1px;
        border-style: solid;
        border-color:silver;
        text-align: left;
        border-image-source: none;
        margin:4px 4px 4px 4px;
        padding:4px 4px 4px 4px;
   
}
      
  ._PanelRounded:hover {
border-color: silver gray silver gray;
      }
       
    </style>
</head>
<body style="background-color:#8D8B8B;padding:8px"><center>
    <script async src="//pagead2.googlesyndication.com/pagead/js/adsbygoogle.js"></script>
<!-- 247CodingBanner -->
<ins class="adsbygoogle"
     style="display:inline-block;width:728px;height:90px"
     data-ad-client="ca-pub-7662367708563852"
     data-ad-slot="5964280043"></ins>
<script>
(adsbygoogle = window.adsbygoogle || []).push({});
</script>
    <form id="form1" runat="server"><asp:ScriptManager ID="ScriptManager1" runat="server">
         </asp:ScriptManager>
     <div style="">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
            <asp:UpdateProgress ID="uprog1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
                <ProgressTemplate><div class="_PanelRounded" style="background-color:white">
                    <img src="WerdGraphics/WerdWait.gif" /></div>
         </ProgressTemplate></asp:UpdateProgress>
            <div style="width:100%; background-color:silver" class="_PanelRounded"><br />
         <asp:Panel ID="pnlWerd" runat="server" CssClass="_PanelRounded" Style="float:left;background-color:Black;width:98%;background-image:url('/werdgraphics/247codingclock2med.png');background-repeat:no-repeat">
                         <asp:Button ID="Button1" runat="server" CssClass="_PanelRounded" OnClick="Button1_Click" Text="Reload" style="float:right" />
                         <span style="font-size:x-large;color:white;background-color:#5B5B5B" class="_PanelRounded">247Coding validation...

                         </span><br /><br /><br /><br /><br />
<span style="color:white;font-size:large;padding-top:20px;float:none">Welcome...<br />
                         Please select the item with the most valid words: <asp:Label ID="lblMsg" runat="server" style="color:yellow"></asp:Label>
                         <hr /></span>

<asp:RadioButtonList ID="rblWords" runat="server" AutoPostBack="True" CssClass="_PanelRounded" OnSelectedIndexChanged="rblWords_SelectedIndexChanged" Style="margin-left: 0px;background-color:GhostWhite;float:left;margin-left:50px">
</asp:RadioButtonList>
<asp:DropDownList ID="ddlWords" AutoPostBack="true"  OnSelectedIndexChanged="ddlWords_SelectedIndexChanged" CssClass="_PanelRounded" runat="server" Style="margin-left: 0px;background-color:GhostWhite;float:left;font-size:large;margin-left:50px" Visible="False">
</asp:DropDownList>
                         <br />
         </asp:Panel>
         <asp:Panel ID="pnlLogin" runat="server" Visible="False" Style="width:98%">
             <div class="_PanelRounded" style="float:left;width:100%;background-color:white;min-height:300px">
                 <asp:Label ID="lblWerd" runat="server" Width="100%"></asp:Label>
             <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                 </div>

         </asp:Panel>
        <div class="_PanelRounded" style="width:98%;background-color:White"><a href="Werd.aspx" style="text-decoration:none">
            <span style="color:gold;font-size:small;text-decoration:overline;float:left">Lovingly wrapped in</span> 
            <img alt="Werd" class="_PanelRounded" src="WerdGraphics/WerdSoloSmall.png" style="background-color:white;height:15px;width:15px;;float:left;vertical-align:top"  />
            <span style="color:gold;font-size:small;text-decoration:overline;float:left">ERD</span> </a><asp:Label ID="lblWarn" runat="server" style="color: #CC0000"></asp:Label></div>
            &nbsp;
                <br />
                </div>

                
       </ContentTemplate></asp:UpdatePanel>

    </div>
    </form></center><span style="color:#999999">Werd App V1.1 ©Copyright 2016 247Coding.com/WebMeToo.com</span>
</body>
</html>
