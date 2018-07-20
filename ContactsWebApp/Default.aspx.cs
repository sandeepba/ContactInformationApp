using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContactsWebApp.Models;


namespace ContactsWebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         if(!IsPostBack)
            {
                ShowData();
            }  
        }
        
        protected void gvContacts_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvContacts.EditIndex = -1;
            ShowData();
        }

        protected void gvContacts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvContacts.EditIndex = e.NewEditIndex;
            ShowData();
        }

        private void ShowData()
        {
            DAL.ContactEngine contractEngine = new DAL.ContactEngine();
            gvContacts.DataSource = contractEngine.GetAllContacts();
            gvContacts.DataBind();
        }

        protected void gvContacts_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            Label lblID = gvContacts.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
            TextBox txtFirstName = gvContacts.Rows[e.RowIndex].FindControl("txtFirstName") as TextBox;
            TextBox txtLastName = gvContacts.Rows[e.RowIndex].FindControl("txtLastName") as TextBox;
            TextBox txtEmail = gvContacts.Rows[e.RowIndex].FindControl("txtEmail") as TextBox;
            TextBox txtStatus = gvContacts.Rows[e.RowIndex].FindControl("txtStatus") as TextBox;
            Contact contact = new Contact();
            contact.ID = Convert.ToInt32(lblID.Text);
            contact.FirstName = txtFirstName.Text;
            contact.LastName = txtLastName.Text;
            contact.Email = txtEmail.Text;
            contact.Status = txtStatus.Text == "True" ? true : false;
            DAL.ContactEngine contractEngine = new DAL.ContactEngine();
            contractEngine.UpdateContact(contact);
            gvContacts.EditIndex = -1;
            ShowData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Contact contact = new Contact();
            contact.FirstName = txtAFirstName.Text;
            contact.LastName = txtALastName.Text;
            contact.Email = txtAEmail.Text;
            contact.Status = txtAStatus.Text == "True" ? true : false;
            DAL.ContactEngine contractEngine = new DAL.ContactEngine();
            contractEngine.AddContact(contact);
                ShowData();
        }
    }
}