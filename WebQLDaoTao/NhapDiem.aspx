<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NhapDiem.aspx.cs" Inherits="WebQLDaoTao.QLDiem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <h2>Nhập Điểm</h2>
    <hr />
    <div class="form-inline" style="margin-bottom: 10px">
        Chọn Môn
    <asp:DropDownList ID="ddlMaMh" runat="server" AutoPostBack="true"
        DataSourceID="odsMonHoc" DataTextField="TenMH" DataValueField="MaMH" CssClass="form-control" Width="300px">
    </asp:DropDownList>
    </div>
    <asp:GridView ID="gvKetQua" runat="server" CssClass="table table-bordered" AutoGenerateColumns="False" DataSourceID="odsKetQua" Width="70%" DataKeyNames="Id" ShowFooter="True" OnSelectedIndexChanged="gvKetQua_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="MaSV" HeaderText="MaSV" SortExpression="MaSV" />
            <asp:BoundField DataField="hotensv" HeaderText="Ho Ten Sinh Vien" />
            <%--cho phép sửa tất cả điểm cùng 1 lúc--%>
            <asp:TemplateField HeaderText="Điểm">
                <ItemTemplate>
                    <asp:TextBox ID="txtDiem" runat="server" Text='<%# Eval("Diem") %>' CssClass="form-control" Width="150px"></asp:TextBox>
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btluu" runat="server" Text="Lưu"  CssClass="btn btn-success" OnClick="btLuu_Click"/>              
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Chọn xóa">
                <HeaderTemplate>
                    <asp:CheckBox ID="ckAll" runat="server" Text="Chọn Tất Cả"  AutoPostBack ="true" OnCheckedChanged="ckAll_CheckedChanged"/>  
                </HeaderTemplate>
                <ItemTemplate>
                        <asp:CheckBox ID="ckChon" runat="server"  />
                </ItemTemplate>
                <FooterTemplate>
                         <asp:Button ID="btxoa" runat="server" Text="Xóa" CssClass="btn btn-success" OnClick="btxoa_Click"/>  
                </FooterTemplate>
            </asp:TemplateField>

        </Columns>
        <EmptyDataTemplate>
            <div class="alert alert-warning" role="alert">
                <strong>Không có dữ liệu!</strong> Vui lòng chọn môn học khác hoặc nhập dữ liệu mới.
            </div>
        </EmptyDataTemplate>

    </asp:GridView>
    <asp:ObjectDataSource ID="odsMonHoc" runat="server" SelectMethod="getAll" TypeName="WebQLDaoTao.Models.MonHocDao"></asp:ObjectDataSource>

    <asp:ObjectDataSource ID="odsKetQua" runat="server" SelectMethod="getByMaMH" TypeName="WebQLDaoTao.Models.KetQuaDAO">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlMaMh" Name="mamh" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>

</asp:Content>

