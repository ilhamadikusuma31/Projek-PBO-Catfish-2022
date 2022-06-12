<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Kolam.aspx.cs" Inherits="Projek_PBO_Catfish_2022._Kolam" %>

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
                <asp:View runat="server" ID="vKolam">

                    <asp:Panel runat="server" ID="panelUser">
                        <h3 style="text-align: left;">Daftar Kolam
                        </h3>
                        <div style="padding: 10px; max-width: 500px; text-align: right;">
                            <asp:LinkButton runat="server" ID="lbTambah" OnClick="lbTambah_Click">Tambah Data</asp:LinkButton>
                        </div>
                        <div style="clear: right;"></div>
                        <asp:GridView ID="GridView2" CssClass="table" runat="server" AutoGenerateColumns="False" Width="500px"
                            DataKeyNames="id_kolam,nama_kolam,jumlah_lele,nama_lele" OnRowCommand="GridView1_RowCommand" CellPadding="3" ForeColor="Black" GridLines="Vertical" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText="No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNomor" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNama" runat="server" Text='<%# Bind("nama_kolam") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Jumlah">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJumlah" runat="server" Text='<%# Bind("jumlah_lele") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
<%--                                <asp:TemplateField HeaderText="IdLele">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdLele" runat="server" Text='<%# Bind("id_lele") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="nama Lele">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNamaLele" runat="server" Text='<%# Bind("nama_lele") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                           <%--     <asp:TemplateField HeaderText="Jumlah">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="lblidL"runat="server"> </asp:DropDownList>
                                    </ItemTemplate>
                                    
                                </asp:TemplateField>--%>


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

                        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>  
    
                        <br />
                    </asp:Panel>
                    <hr />


                    <asp:Panel runat="server" ID="panelForm" Visible="false">
                        <h3>Form Kolam
                        </h3>
                        <table>
                            <tr>
                                <td>Nama</td>
                                <td>
                                    <asp:TextBox runat="server" ID="tbNama" Text=""></asp:TextBox>
                                </td>
                                <td>Jumlah</td>
                                <td>
                                    <asp:TextBox runat="server" ID="tbJumlah" Text=""></asp:TextBox>
                                </td>
                                <td>Nama Lele</td>
                                <td>
                                    <asp:DropDownList ID="DropDownListLele" runat="server" Width="100px"></asp:DropDownList>  
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