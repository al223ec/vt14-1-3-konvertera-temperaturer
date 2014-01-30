<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Temperature.Default" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="~/Content/style.css" rel="stylesheet" />
    <title>Anton Ledström, 1.3 - Konvertera temperaturen</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Panel ID="MainPanel" runat="server">
            <p class="heading">1-3 Konvertera Temperaturer</p>
            <h1>Konvertera Temperaturer</h1>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="error" />
            <div class="left">
                <%-- Starttemp input --%>
                <div>
                    <p class="label">Starttemperatur</p>
                    <asp:TextBox ID="StartTempTextBox" runat="server"></asp:TextBox>
                    <%--Validering--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Detta fällt måste vara ifyllt" ControlToValidate="StartTempTextBox" Text="*"
                        CssClass="error" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Detta fällt måste vara ett tal" ControlToValidate="StartTempTextBox"
                        Operator="DataTypeCheck" Type="Integer" Text="*" CssClass="error" Display="Dynamic">
                    </asp:CompareValidator>
                </div>
                <%-- Sluttemp input --%>
                <div>
                    <p class="label">Sluttemperatur</p>
                    <asp:TextBox ID="EndTempTextBox" runat="server"></asp:TextBox>
                    <%--Validering--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Detta fällt måste vara ifyllt" ControlToValidate="EndTempTextBox" Text="*"
                        CssClass="error" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Detta fällt måste vara ett tal och större än StartTempfältet"
                        ControlToValidate="EndTempTextBox" Operator="GreaterThan" ControlToCompare="StartTempTextBox" Text="*" CssClass="error" Display="Dynamic"
                        Type="Integer"></asp:CompareValidator>
                </div>
                <%-- Temperatursteg --%>
                <div>
                    <p class="label">Temperatursteg</p>
                    <asp:TextBox ID="StepTextBox" runat="server"></asp:TextBox>
                    <%--Validering--%>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Detta fällt måste vara ifyllt" ControlToValidate="StepTextBox" Text="*"
                        CssClass="error" Display="Dynamic">
                    </asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Talet måste var mellan 1-100" MaximumValue="100" MinimumValue="1" Type="Integer"
                        ControlToValidate="StepTextBox" Display="Dynamic" Text="*" CssClass="error"></asp:RangeValidator>
                </div>
                <%-- Radioknappar --%>
                <div>
                    <p class="label">Typ av konvertering</p>
                    <p class="buttonLabel">
                        <asp:RadioButton ID="CelsiusRadioButton" runat="server" GroupName="Type" Checked="True" />
                        Celsius till Fahrenheit
                    </p>
                    <p class="buttonLabel">
                        <asp:RadioButton ID="FahrenheitRadioButton" runat="server" GroupName="Type" />
                        Fahrenheit till Celsius
                    </p>
                </div>
                <asp:Button ID="SubmitButton" runat="server" Text="Konvertera" OnClick="SubmitButton_Click" />
            </div>
            <%--Output--%>
            <asp:Panel ID="OutputPanel" runat="server" CssClass="right" Visible="false">
                <asp:Table ID="OutputTable" runat="server">
                </asp:Table>
            </asp:Panel>
            <%-- Footer --%>
            <p class="footer">
                Anton Ledström
            </p>
        </asp:Panel>
    </form>
</body>
</html>
