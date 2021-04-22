<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VistaCategoria.aspx.cs" Inherits="WebProducto.VistaCategoria" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 383px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <table class="auto-style1">
            <tr>
                <td class="auto-style2">ID</td>
                <td>
                    <asp:Label ID="lblID" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">Nombre</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:Button ID="btnInsertarCategoria" runat="server" Height="22px" OnClick="btnInsertarCategoria_Click" Text="Insertar" Width="85px" />
                    <asp:Label ID="lblCheck" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">&nbsp;</td>
                <td>
                    <asp:DropDownList ID="ComboCategoria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ComboCategoria_SelectedIndexChanged">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                    Lista de Categoria</td>
                <td>
                    <asp:GridView ID="GridView2" runat="server" OnSelectedIndexChanged="GridView2_SelectedIndexChanged">
                    </asp:GridView>
                    <br />
                    Lista de Productos por Categoria</td>
            </tr>
        </table>
    </form>
</body>
</html>
