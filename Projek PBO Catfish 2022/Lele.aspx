<%@ Page Title="Lele" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Lele.aspx.cs" Inherits="Projek_PBO_Catfish_2022._Lele" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="form" runat="server">
        <div>
            <asp:MultiView runat="server" ID="mv">
                <asp:View runat="server" ID="vLele">
                    <asp:Panel runat="server" ID="panel">
                        <h3>Daftar Lele</h3>
                        <div >
                            <asp:LinkButton runat="server" ID="tombolTambahData" OnClick="tombolTambahDataClick" CssClass="btn btn-primary mt-4"><i class="bi bi-plus-circle"></i>Tambah Data</asp:LinkButton>
                        </div>
                        <asp:GridView ID="GridView" CssClass="table table-striped mt-3" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id_lele,nama_lele" OnRowCommand="gridViewCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNomor" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNama" runat="server" Text='<%# Bind("nama_lele") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Aksi">
                                    <ItemTemplate>
                                        <asp:LinkButton CssClass="btn btn-warning" runat="server" ID="lbEdit" CommandName="ubah" CommandArgument="<%# Container.DataItemIndex %>"><i class="bi bi-pencil-square"></i></asp:LinkButton>
                                        <asp:LinkButton CssClass="btn btn-danger"  runat="server" ID="lbDelete" CommandName="hapus" CommandArgument="<%# Container.DataItemIndex %>" OnClientClick='return confirm("Kamu Yakin Ingin Menghapus?");'><i class="bi bi-trash3"></i></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                    <hr />


                    <asp:Panel runat="server" ID="panelForm" Visible="false">
                        <h3>Form Lele
                        </h3>
                        <table>
                          <div class="mb-3">
                            <label for="inputNama" class="form-label mt-5">Nama Lele</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputNama" Text=""></asp:TextBox>
                          </div>
                        </table>
                        <asp:Button runat="server" ID="tombolSimpan" CssClass="btn btn-success" Text="Simpan" OnClick="tombolSimpanClick" />
                        <asp:Button runat="server" ID="tombolUpdate" cssClass="btn btn-success" Text="Update" Visible="false" OnClick="tombolUpdateClick" />
                        <asp:Button runat="server" ID="tombolBatal"  CssClass="btn btn-secondary" Text="Batal" Visible="true" OnClick="tombolBatalClick" />
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</asp:Content>


