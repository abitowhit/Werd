<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Werd_Default.aspx.cs" Inherits="_WerdDefault" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Forum Validation</title>
<meta http-equiv="content-type" content="text/html; charset=UTF-8" >
<meta name="viewport" content="width=device-width, initial-scale=1.0">
<link rel="icon" href="/favicon.ico" type="image/x-icon"> 
<link rel="shortcut icon" href="favicon.ico" type="image/x-icon"> 
<link rel="icon" href="favicon.ico" type="image/x-icon"/> 
<meta http-equiv="X-UA-Compatible" content="IE=edge" /> 

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
       
            .auto-style1 {
                width: 22px;
                height: 21px;
            }
       
    </style>
</head>
<body style="padding:8px;background-color:#C4D4C9;vertical-align:central">
    <form id="formWerd" runat="server"><asp:ScriptManager ID="WerdScriptManager" runat="server">
         </asp:ScriptManager>
     <div style="float:left">
        <asp:UpdatePanel ID="WerdUpdatePanel" runat="server"><ContentTemplate>
            <asp:UpdateProgress ID="WerdUpdateProgress" runat="server" AssociatedUpdatePanelID="WerdUpdatePanel">
                <ProgressTemplate>
                    <div class="_PanelRounded" style="background-color:white">
                    <img alt="Please Wait.." class="auto-style1" src="WerdGraphics/WerdWait.gif" />
                    </div>
         </ProgressTemplate></asp:UpdateProgress>

            <div style="width:80%; background-color:black;min-width:300px;float:left" class="_PanelRounded">
                <br />
         <asp:Panel ID="pnlWerd" runat="server" CssClass="_PanelRounded" Style="float:left;background-color:black;width:96%;background-image:url('werdgraphics/WerdSplash.png');background-repeat:no-repeat">
                         <asp:Button ID="Button1" runat="server" CssClass="_PanelRounded" OnClick="Button1_Click" Text="Reload" style="float:right" />
                         <span style="font-size:x-large;color:white;margin-left:10px" class=""><i>Site Validation...

                         <asp:Label ID="lblMsg" runat="server" style="color: white"></asp:Label>
                             </i>
                         </span><br /><br /><br />
<span  class="_PanelRounded" style="font-size:large;padding-top:20px;float:right;width:50%;background-image:url('werdgraphics/GrassFill.png');color:white">Please validate..<br />
    Look over the list of words and select the one that appears to contain the most valid words</span>

<asp:RadioButtonList ID="rblWords" runat="server" AutoPostBack="True" CssClass="_PanelRounded" OnSelectedIndexChanged="rblWords_SelectedIndexChanged" Style="margin-left: 0px;background-color:GhostWhite;float:left;margin-left:100px">
</asp:RadioButtonList>
<asp:DropDownList ID="ddlWords" AutoPostBack="true" CssClass="_PanelRounded" runat="server" Style="margin-left: 0px;background-color:GhostWhite;float:left;font-size:large;margin-left:100px" Visible="False" OnSelectedIndexChanged="ddlWords_SelectedIndexChanged">
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
            <span style="color:#A28932;font-size:small;text-decoration:overline;float:left">Lovingly wrapped in</span> 
            <img alt="Werd" class="_PanelRounded" src="WerdGraphics/WerdSoloSmall.png" style="background-color:white;height:15px;width:15px;;float:left;vertical-align:top"  />
            <span style="color:#A28932;font-size:small;text-decoration:overline;float:left">ERD</span> </a><asp:Label ID="lblWarn" runat="server" style="color: #CC0000"></asp:Label></div>
            &nbsp;
                <br />
                </div>

                
       </ContentTemplate></asp:UpdatePanel>

    </div>
    </form>
    <span style="color:#999999">Werd App V1.0 ©Copyright 2016 247Coding.com/WebMeToo.com</span>
</body>
</html>
