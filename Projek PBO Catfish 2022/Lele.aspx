<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Lele.aspx.cs" Inherits="Projek_PBO_Catfish_2022._Lele" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>

    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.18/css/jquery.dataTables.min.css" />
    <script src="https://cdn.datatables.net/1.10.18/js/jquery.dataTables.min.js"></script>
    <link rel="stylesheet" href="//use.fontawesome.com/releases/v5.0.7/css/all.css">
</head>
<body>


<form id="form1" runat="server">
        <div style="padding: 50px;">

            <%--<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="HOME" NavigateUrl="~/Default.aspx" Selected="true" />
                    <asp:MenuItem Text="HTML" NavigateUrl="~/HTML.aspx">
                        <asp:MenuItem Text="HtmlTagList" NavigateUrl="~/HtmlTagList.aspx" />
                    </asp:MenuItem>
                    <asp:MenuItem Text="CSS" NavigateUrl="~/CSS.aspx">
                        <asp:MenuItem Text="CssSelectors" NavigateUrl="~/CssSelectors.aspx" />
                    </asp:MenuItem>
                </Items>
            </asp:Menu>--%>


           <%-- <asp:RadioButtonList runat="server" ID="rblData"
                OnSelectedIndexChanged="rblData_SelectedIndexChanged"
                AutoPostBack="true">
                <asp:ListItem Text="User" Value="user" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Sinkronisasi" Value="sync"></asp:ListItem>
            </asp:RadioButtonList>--%>

            <asp:MultiView runat="server" ID="mvMain">
                <asp:View runat="server" ID="vLele">

                    <asp:Panel runat="server" ID="panelUser">
                        <h3 style="text-align: left;">Daftar Lele
                        </h3>
                        <div style="padding: 10px; max-width: 500px; text-align: right;">
                            <asp:LinkButton runat="server" ID="lbTambah" OnClick="lbTambah_Click">Tambah Data</asp:LinkButton>
                        </div>
                        <div style="clear: right;"></div>
                        <asp:GridView ID="GridView1" CssClass="table" runat="server" AutoGenerateColumns="False" Width="500px"
                            DataKeyNames="id_lele,nama_lele" OnRowCommand="GridView1_RowCommand" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNomor" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNama" runat="server" Text='<%# Bind("nama_lele") %>'></asp:Label>
                                        <asp:Label ID="lblNamaa" runat="server" Text='bedanya kalo di aspx ga di looping kayak di html'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="lbEdit" CommandName="ubah" CommandArgument="<%# Container.DataItemIndex %>">Edit</asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lbDelete" CommandName="hapus" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick='return confirm("Are you sure you want to delete this item?");'>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>

                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>

                        <br />
                    </asp:Panel>
                    <hr />


                    <asp:Panel runat="server" ID="panelForm" Visible="false">
                        <h3>Form User
                        </h3>
                        <table>
                            <tr>
                                <td>Nama</td>
                                <td>
                                    <asp:TextBox runat="server" ID="tbNama" Text=""></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <br />
                        <asp:Button runat="server" ID="btSimpan" Text="Simpan" OnClick="tombolSimpan_Click" />
                        <asp:Button runat="server" ID="btUpdate" Text="Update" Visible="false" OnClick="tombolUpdate_Click" />
                        <asp:Button runat="server" ID="btBatal" Text="Batal" Visible="true" OnClick="btBatal_Click" />
                    </asp:Panel>

                </asp:View>
            </asp:MultiView>


        </div>
    </form>
</body>
</html>