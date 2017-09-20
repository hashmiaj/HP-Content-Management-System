using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class AddRow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Submit_onClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.Connection = con;
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            cmd.CommandText = "INSERT INTO TopicList (ID, ProductSelection, Web, Intellifix, IssueSignature, UG, WLG, SRM, OnsiteInstallGuide, STR, WBT1_3, WBT4_6, Title, ConcentraID, Link, BrightcoveLink, ProductSource, DocumentSource, Core,"
                            + "DesignTeamNotes, ProjectManagerNotes, SMEPartnerNotes, ProLeEnterprise, Asset, DisclosureLevel, Status, OwnerPM) VALUES (" + "'" + GuidString + "'," + "'" + Box1.Text + "'," + "'" + Box2.Text + "'," + "'" 
                            + Box3.Text + "'," + "'" + Box4.Text + "'," + "'" + Box5.Text + "'," + "'" + Box6.Text + "'," + "'" + Box7.Text + "'," + "'" + Box8.Text + "'," + "'" + Box9.Text + "'," + "'" + Box10.Text + "'," + "'" + Box11.Text
                            + "'," + "'" + Box12.Text + "'," + "'" + Box13.Text + "'," + "'" + Box14.Text + "'," + "'" + Box15.Text + "'," + "'" + Box16.Text + "'," + "'" + Box17.Text + "'," + "'" + Box18.Text + "'," + "'" + Box19.Text + "',"
                            + "'" + Box20.Text + "'," + "'" + Box21.Text + "'," + "'" + Box22.Text + "'," + "'" + Box23.Text + "'," + "'" + Box24.Text + "'," + "'" + Box25.Text + "'," + "'" + Box26.Text + "')";

            sda = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            Response.Redirect("~/TList.aspx");
        }
        protected void Cancel_onClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Tlist.aspx");
        }
    }
}