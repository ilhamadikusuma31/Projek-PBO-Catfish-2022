<%@ Page Title="Kolam" Language="C#"  MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Kolam.aspx.cs" Inherits="Projek_PBO_Catfish_2022._Kolam" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="form" runat="server">
        <div>
            <asp:MultiView runat="server" ID="mv">
                <asp:View runat="server" ID="vKolam">
                    <asp:Panel runat="server" ID="panel">
                        <h3>Daftar Kolam</h3>
                        <div >
                            <asp:LinkButton runat="server" ID="tombolTambahData" OnClick="tombolTambahDataClick" CssClass="btn btn-primary mt-4"><i class="bi bi-plus-circle"></i>Tambah Data</asp:LinkButton>
                        </div>
                        <asp:GridView ID="GridView" CssClass="table table-striped mt-3" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id_kolam,nama_kolam,jumlah_lele,nama_lele" OnRowCommand="perintahGridView">
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
                                <asp:TemplateField HeaderText="nama Lele">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNamaLele" runat="server" Text='<%# Bind("nama_lele") %>'></asp:Label>
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
                        <h3>Form Kolam
                        </h3>
                        <table>
                          <div class="mb-3">
                            <label for="inputNamaKolam" class="form-label mt-5">Nama Kolam</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputNamaKolam" Text=""></asp:TextBox>
                          </div>
                            <div class="mb-3">
                            <label for="inputJumlahLele" class="form-label mt-1">Jumlah Lele</label>
                            <asp:TextBox runat="server" CssClass="form-control" ID="inputJumlahLele" Text="" TextMode="Number"></asp:TextBox>
                          </div>
                            <div class="mb-3">
                            <label for="inputNamaLele" class="form-label mt-1">Nama Lele</label>
                            <asp:DropDownList ID="DropDownListLele" runat="server" CssClass="btn btn-primary"></asp:DropDownList>  
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

