using ContactsWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class ContactEngine
    {
        private SqlConnection con;
        public ContactEngine()
        {
              con= new SqlConnection("Data Source=localhost;integrated Security=sspi;initial catalog=test;");
        }
        
        
        public void UpdateContact(Contact contact)
        {
            con.Open();
            SqlCommand stmt = new SqlCommand("sp_Contact_UpdateContact", con);
            stmt.CommandType = System.Data.CommandType.StoredProcedure;
            stmt.Parameters.AddWithValue("@ContactID",DbType.Int32).Value=contact.ID;
            stmt.Parameters.AddWithValue("@FirstName",DbType.String).Value=contact.FirstName;
            stmt.Parameters.AddWithValue("@LastName",DbType.String).Value=contact.LastName;
            stmt.Parameters.AddWithValue("@Email",DbType.String).Value=contact.Email;
            stmt.Parameters.AddWithValue("@ContactStatus",DbType.Boolean).Value=contact.Status;
            stmt.ExecuteNonQuery();
        }

        public DataTable GetAllContacts()
        {
            con.Open();
            DataTable dt = new DataTable();
            IDataReader result = null;
             SqlCommand stmt = new SqlCommand("sp_Contact_GetAllContacts", con);
                stmt.CommandType = System.Data.CommandType.StoredProcedure;
                result = stmt.ExecuteReader();
            dt.Load(result);
            con.Close();
            return dt;
        }

        public void AddContact(Contact contact)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_Contact_InsertContact",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@FirstName", DbType.String).Value = contact.FirstName;
            cmd.Parameters.AddWithValue("@LastName", DbType.String).Value = contact.LastName;
            cmd.Parameters.AddWithValue("@Email", DbType.String).Value = contact.Email;
            cmd.Parameters.AddWithValue("@ContactStatus", DbType.Boolean).Value = contact.Status;
            cmd.ExecuteScalar();
        }

        public List<Contact> MapDataToContact(IDataReader record)
        {
            List<Contact> lstContact = new List<Contact>();
            if (record != null)
            {
                while (record.Read())
                {
                    Contact contact = new Contact();
                    contact.ID = int.Parse(record["ID"].ToString());
                    contact.FirstName = record["FirstName"].ToString();
                    contact.LastName = record["LastName"].ToString();
                    contact.Email = record["Email"].ToString();
                    contact.Status = Convert.ToBoolean(record["ContactStatus"].ToString());
                    lstContact.Add(contact);
                }
            }
            return lstContact;
        }
    }
}
