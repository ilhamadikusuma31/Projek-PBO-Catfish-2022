<%@ Page Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="Pembibitan.aspx.cs" Inherits="Projek_PBO_Catfish_2022._Pembibitan" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <form id="form" runat="server">
        <div>
            <asp:MultiView runat="server" ID="mv">
                <asp:View runat="server" ID="vPembibitan">
                    <asp:Panel runat="server" ID="panel">
                        <h3>Daftar Pembibitan</h3>
                        <div >
                            <asp:LinkButton runat="server" ID="tombolTambahData" OnClick="tombolTambahDataClick" CssClass="btn btn-primary mt-4"><i class="bi bi-plus-circle"></i>Tambah Data</asp:LinkButton>
                        </div>
                        <asp:Label ID="pesan" runat="server" Text="ini pesan"></asp:Label>
                        <asp:GridView ID="GridView" CssClass="table table-striped mt-3" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="id_aktivitas,tanggal,id_karyawan,id_kolam,nama_karyawan,nama_kolam" OnRowCommand="perintahGridView">
                            <Columns>
                                <asp:TemplateField HeaderText="No">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNomor" runat="server" Text='<%# Container.DataItemIndex + 1 %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tanggal">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTanggal" runat="server" Text='<%# Bind("tanggal") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama Karyawan">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNamaKaryawan" runat="server" Text='<%# Bind("nama_karyawan") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nama Kolam">
                                    <ItemTemplate>
                                        <asp:Label ID="lblNamaKolam" runat="server" Text='<%# Bind("nama_kolam") %>'></asp:Label>
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
                        <h3>Form Pembibitan
                        </h3>
                        <table>
                          <div class="container">
                              <div class="row justify-content-end">
                                  <div class="col-md-8"></div>
                                  <div class="col-md-2">
                                        <asp:Button runat="server" ID="tombolSimpan" CssClass="btn btn-success mt-1" Text="Simpan" OnClick="tombolSimpanClick" />
                                        <asp:Button runat="server" ID="tombolUpdate" cssClass="btn btn-success mt-1" Text="Update" Visible="false" OnClick="tombolUpdateClick" />
                                        <asp:Button runat="server" ID="tombolBatal"  CssClass="btn btn-secondary mt-1" Text="Batal" Visible="true" OnClick="tombolBatalClick" />
                                  </div>
                              </div>
                                <div class="row">
                                    <label for="DropDownListKaryawan" class="form-label">Nama Kolam</label>
                                    <asp:DropDownList ID="DropDownListKaryawan" runat="server" CssClass="btn btn-primary"></asp:DropDownList>  
                                </div>
                                <div class="row">
                                    <label for="DropDownListKolam" class="form-label">Nama Kolam</label>
                                    <asp:DropDownList ID="DropDownListKolam" runat="server" CssClass="btn btn-primary"></asp:DropDownList> 
                                </div>
                                <div class="row">
                                    <label for="inputTanggal" class="form-label">Tanggal</label>
                                    <asp:Calendar ID="inputTanggal" CssClass="form-control" runat="server"></asp:Calendar>
                                </div>
                            </div>
                        </table>
                    </asp:Panel>
                </asp:View>
            </asp:MultiView>
        </div>
    </form>
</asp:Content>
