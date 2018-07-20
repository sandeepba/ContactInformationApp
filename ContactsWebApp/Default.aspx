<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ContactsWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="gvContacts" runat="server" AutoGenerateColumns="false" OnRowUpdating="gvContacts_RowUpdating"  OnRowCancelingEdit="gvContacts_RowCancelingEdit" OnRowEditing="gvContacts_RowEditing" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
         <Columns>
             <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="Edit_Contact" runat="server" Text="Alter" CommandName="Edit"/>
                        </itemtemplate>
                    <EditItemTemplate>
                        <asp:Button ID="Update_Contact" runat="server" Text="Update" CommandName="Update"/>
                        <asp:Button ID="Cancel_Contact" runat="server" Text="Cancel" CommandName="Cancel"/>
                        </EditItemTemplate>
                 </asp:TemplateField>
            <asp:TemplateField Visible="false">
                    <Itemtemplate>
                        <asp:Label ID="lbl_ID" runat="server" Text ='<%#Eval("ID")%>' />
                    </Itemtemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name">
                    <Itemtemplate>
                        <asp:Label runat="server" Text ='<%#Eval("FirstName")%>'/>
                    </Itemtemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFirstName" runat="server" Text ='<%#Eval("FirstName")%>'/>
                        </EditItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Last Name">
                    <Itemtemplate>
                        <asp:Label runat="server" Text ='<%#Eval("LastName")%>' />
                    </Itemtemplate>
                 <EditItemTemplate>
                        <asp:TextBox ID="txtLastName" runat="server" Text ='<%#Eval("LastName")%>'/>
                        </EditItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Email">
                    <Itemtemplate>
                        <asp:Label runat="server" Text ='<%#Eval("Email")%>' />
                    </Itemtemplate>
                 <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text ='<%#Eval("Email")%>'/>
                        </EditItemTemplate>
                </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                    <Itemtemplate>
                        <asp:Label runat="server" Text ='<%#Eval("ContactStatus")%>' />
                    </Itemtemplate>
                 <EditItemTemplate>
                        <asp:TextBox ID="txtStatus" runat="server" Text ='<%#Eval("ContactStatus")%>'/>
                        </EditItemTemplate>
                </asp:TemplateField>
            
        </Columns>
            
        
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099"></FooterStyle>

        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC"></HeaderStyle>

        <PagerStyle HorizontalAlign="Center" BackColor="#FFFFCC" ForeColor="#330099"></PagerStyle>

        <RowStyle BackColor="White" ForeColor="#330099"></RowStyle>

        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399"></SelectedRowStyle>

        <SortedAscendingCellStyle BackColor="#FEFCEB"></SortedAscendingCellStyle>

        <SortedAscendingHeaderStyle BackColor="#AF0101"></SortedAscendingHeaderStyle>

        <SortedDescendingCellStyle BackColor="#F6F0C0"></SortedDescendingCellStyle>

        <SortedDescendingHeaderStyle BackColor="#7E0000"></SortedDescendingHeaderStyle>
    </asp:GridView>
     
    <table>
            <tr>
                <th> First Name </th>
                <th> Last Name </th>
                <th> Email </th>
                <th> Status </th>
                <th></th>
                </tr>
            <tr>
              <td>  <asp:TextBox ID="txtAFirstName" runat="server" CssClass="text"/> </td>
               <td> <asp:TextBox ID="txtALastName" runat="server" CssClass="text"/> </td>
               <td> <asp:TextBox ID="txtAEmail" runat="server" CssClass="text"/> </td>
               <td> <asp:TextBox ID="txtAStatus" runat="server" CssClass="text"/> </td>
               <td> <asp:Button ID="btnAdd" runat="server" CommandName="Footer" Text ="Add New Contact" CssClass="Gridbutton" OnClick="btnAdd_Click" /> </td>
            </tr>
            </table>
</asp:Content>
