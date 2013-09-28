using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace FinalDemo
{
    public partial class ViewAllContacts : System.Web.UI.Page
    {
        //  Create a String to store our search results
        private string SearchString = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        public string HighlightText(string InputTxt)
        {
            string Search_Str = txtSearch.Text;
            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);
            // Highlight keywords by calling the 
            //delegate each time a keyword is found.
            return RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));
        }

        public string ReplaceKeyWords(Match m)
        {
            return ("<span class=highlight>" + m.Value + "</span>");
        }
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            //  Set the value of the SearchString so it gets
            SearchString = txtSearch.Text;
            BindSearchGrid(SearchString);
        }
        protected void btnClear_Click(object sender, ImageClickEventArgs e)
        {
            //  Simple clean up text to return the Gridview to it's default state
            txtSearch.Text = "";
            SearchString = "";
            BindGrid();
        }

        public void BindGrid()
        {
            FinalDemo.BAL.ContactsService proxy = new BAL.ContactsService();
            List<FinalDemo.PL.ContactsProperties> lstContacts = proxy.SelectAll();
            gvContacts.DataSource = lstContacts;
            gvContacts.DataBind();
        }

        public void BindSearchGrid(string Search)
        {
            FinalDemo.BAL.ContactsService proxy = new BAL.ContactsService();
            List<FinalDemo.PL.ContactsProperties> lstContacts = proxy.SelectAllSearch(Search);
            gvContacts.DataSource = lstContacts;
            gvContacts.DataBind();
        }

        protected void gvContacts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvContacts.PageIndex = e.NewPageIndex;
            BindGrid();
        }
    }
}