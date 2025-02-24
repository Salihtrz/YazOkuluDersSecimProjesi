<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Kontenjanlar.aspx.cs" Inherits="YazOkuluDersler.Kontenjanlar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <form id="Form1" runat="server">

        <div class="form-group">

            <div>
                <strong>
                    <asp:Label for="DersAd" runat="server" Text="Ders Adı:"></asp:Label>
                </strong>
                <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"
                    AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                    <asp:ListItem Text="Ders Seçiniz" Value="" />
                </asp:DropDownList>
            </div>
            <br />
            <div>
                <strong>
                    <asp:Label for="KayitliOgrenci" runat="server" Text="Kayıtlı Öğrenciler"></asp:Label>
                </strong>
                <br />
                <table class="table table-bordered table-hover">
                    <tr>
                        <th>Öğrenci Ad</th>
                        <th>Öğrenci Soyad</th>
                    </tr>
            </div>
            <tbody>
                <asp:Repeater ID="Repeater2" runat="server" OnItemDataBound="Repeater2_ItemDataBound">
                    <ItemTemplate>
                        <tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="LiteralAd" runat="server"></asp:Literal></td>
                                <td>
                                    <asp:Literal ID="LiteralSoyad" runat="server"></asp:Literal></td>
                            </tr>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            </table>
        </div>
    </form>
</asp:Content>
