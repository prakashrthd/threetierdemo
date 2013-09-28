using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalDemo
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            FinalDemo.PL.ContactsProperties objContacts = new PL.ContactsProperties();

          
            if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                objContacts.Id = Convert.ToInt32(Request.QueryString["Id"].ToString());
            }
            else
            {
                objContacts.Id = 0;
            }
            objContacts.FirstName = txtFirstName.Text.Trim();
            objContacts.LastName = txtLastName.Text.Trim();
            objContacts.Phone = txtPhone.Text.Trim();
            objContacts.Mobile = txtMobile.Text.Trim();
            objContacts.City = txtCity.Text.Trim();
            objContacts.Modified = DateTime.Now;

            if (fileupload1.FileName.Length > 0)
            {
                string str_Upload_File_Save_With_New_Name = System.Guid.NewGuid().ToString() + System.IO.Path.GetExtension(fileupload1.FileName);
                objContacts.ProfiePhoto = str_Upload_File_Save_With_New_Name;

                fileupload1.SaveAs(Server.MapPath("~/upload") + "/" + str_Upload_File_Save_With_New_Name);
            }
            

            FinalDemo.BAL.ContactsService proxy = new BAL.ContactsService();

            bool result = false;

            if (!String.IsNullOrEmpty(Request.QueryString["Id"]))
            {
                result = proxy.Update(objContacts);
                Response.Redirect("ViewAllContacts.aspx");
            }
            else
            {
                result = proxy.Insert(objContacts);
                Response.Redirect("ViewAllContacts.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControls();
        }

        private void ClearControls()
        {
            foreach (Control ctrl in this.form1.Controls)
            {
                if (ctrl.GetType().Name.Equals("TextBox"))
                {
                    TextBox txt = ctrl as TextBox;
                    txt.Text = "";
                }
            }
        }
    }
}