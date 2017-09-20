using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataGridViewAutoFilter;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace TestApp
{
    public partial class TList : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds = new DataSet();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con;

        List<TopicList> topicList = new List<TopicList>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                populateDDL();
                BindData();
                lblMessage.Text = "Topic list data!";
            }
        }

        public void BindData()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            if(ColumnsDDL.SelectedIndex != 0)
            {
                cmd.CommandText = "SELECT * from TopicList WHERE " + ColumnsDDL.SelectedItem.Text + " LIKE " + "'" + searchColumn.Text + "'";
            }
            else if ((DDL1.SelectedIndex == 0) && (DDL2.SelectedIndex == 0) && (DDL3.SelectedIndex == 0) && (DDL4.SelectedIndex == 0) && (DDL5.SelectedIndex == 0) && (DDL6.SelectedIndex == 0)
                && (DDL7.SelectedIndex == 0) && (DDL8.SelectedIndex == 0) && (DDL9.SelectedIndex == 0) && (DDL10.SelectedIndex == 0) && (DDL11.SelectedIndex == 0) && (DDL12.SelectedIndex == 0)
                && (DDL13.SelectedIndex == 0) && (DDL14.SelectedIndex == 0) && (DDL15.SelectedIndex == 0) && (DDL16.SelectedIndex == 0) && (DDL17.SelectedIndex == 0) && (DDL18.SelectedIndex == 0)
                && (DDL19.SelectedIndex == 0) && (DDL20.SelectedIndex == 0) && (DDL21.SelectedIndex == 0) && (DDL22.SelectedIndex == 0) && (DDL23.SelectedIndex == 0) && (DDL24.SelectedIndex == 0)
                && (DDL25.SelectedIndex == 0) && (DDL26.SelectedIndex == 0) && (DDL27.SelectedIndex == 0) && (DDL28.SelectedIndex == 0))
            {
                cmd.CommandText = "Select * from TopicList";
            }
            else
            {
                cmd.CommandText = "Select * from TopicList where ProductSelection LIKE" + "'" + DDL1.SelectedItem.Value + "'"
                + " and Web LIKE" + "'" + DDL2.SelectedItem.Value + "'" + " and Intellifix LIKE" + "'" + DDL3.SelectedItem.Value + "'" + " and IssueSignature LIKE"
                + "'" + DDL4.SelectedItem.Value + "'" + " and UG LIKE" + "'" + DDL5.SelectedItem.Value + "'" + " and WLG LIKE" + "'" + DDL6.SelectedItem.Value + "'"
                + " and SRM LIKE" + "'" + DDL7.SelectedItem.Value + "'" + " and OnsiteInstallGuide LIKE" + "'" + DDL8.SelectedItem.Value + "'" + "and STR LIKE"
                + "'" + DDL9.SelectedItem.Value + "'" + "and WBT1_3 LIKE" + "'" + DDL10.SelectedItem.Value + "'" + " and WBT4_6 LIKE" + "'" + DDL11.SelectedItem.Value + "'"
                + " and Title LIKE" + "'" + DDL12.SelectedItem.Value + "'" + "and ConcentraID LIKE" + "'" + DDL13.SelectedItem.Value + "'" + " and Link LIKE" + "'" + DDL14.SelectedItem.Value + "'"
                + " and BrightcoveLink LIKE" + "'" + DDL15.SelectedItem.Value + "'" + " and ProductSource LIKE" + "'" + DDL16.SelectedItem.Value + "'" + " and DocumentSource LIKE"
                + "'" + DDL17.SelectedItem.Value + "'" + " and Core LIKE" + "'" + DDL18.SelectedItem.Value + "'" + " and DesignTeamNotes LIKE" + "'" + DDL19.SelectedItem.Value + "'"
                + " and ProjectManagerNotes LIKE" + "'" + DDL20.SelectedItem.Value + "'" + " and SMEPartnerNotes LIKE" + "'" + DDL21.SelectedItem.Value + "'" + " and ProLeEnterprise LIKE"
                + "'" + DDL22.SelectedItem.Value + "'" + " and Asset LIKE" + "'" + DDL23.SelectedItem.Value + "'" + " and DisclosureLevel LIKE" + "'" + DDL24.SelectedItem.Value + "'"
                + " and Status LIKE" + "'" + DDL25.SelectedItem.Value + "'" + " and OwnerPM LIKE" + "'" + DDL26.SelectedItem.Value + "'" + " and AquentGrouping LIKE" + "'" + DDL27.SelectedItem.Value + "'"
                + " and Onboarded LIKE" + "'" + DDL28.SelectedItem.Value + "'" + " and ProductTitle LIKE" + "'" + DDL29.SelectedItem.Value + "'";
            }
            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();
            dataGrid.DataSource = ds;
            dataGrid.DataBind();
            con.Close();
        }

        protected void dataGrid_Sorting(object sender, DataGridSortCommandEventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            cmd.CommandText = "Select * from TopicList";

            cmd.Connection = con;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            con.Open();
            cmd.ExecuteNonQuery();

            dataGrid.DataSource = ds;

            DataTable dt = new DataTable();
            dt = ds.Tables[0];
            DataView dv = new DataView(dt);

            dv.Sort = e.SortExpression;

            dataGrid.DataSource = dv;
            dataGrid.DataBind();
        }


        protected void dataGrid_EditCommand(object source, DataGridCommandEventArgs e)
        {
            dataGrid.EditItemIndex = e.Item.ItemIndex;
            BindData();
        }
        protected void dataGrid_CancelCommand(object source, DataGridCommandEventArgs e)
        {
            dataGrid.EditItemIndex = -1;
            BindData();
        }
        protected void dataGrid_DeleteCommand(object source, DataGridCommandEventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            cmd.Connection = con;
            string DocID = e.Item.Cells[0].Text;
            cmd.CommandText = "Delete from TopicList where ID=" + "'" + DocID + "'";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            dataGrid.EditItemIndex = -1;
            BindData();
        }

        protected void dataGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            cmd.Parameters.Add("@ID", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@ProductSelection", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
            cmd.Parameters.Add("@Web", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
            cmd.Parameters.Add("@Intellifix", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
            cmd.Parameters.Add("@IssueSignature", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
            cmd.Parameters.Add("@UG", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[7].Controls[0]).Text;
            cmd.Parameters.Add("@WLG", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[8].Controls[0]).Text;
            cmd.Parameters.Add("@SRM", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[9].Controls[0]).Text;
            cmd.Parameters.Add("@OnsiteInstallGuide", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[10].Controls[0]).Text;
            cmd.Parameters.Add("@STR", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[11].Controls[0]).Text;
            cmd.Parameters.Add("@WBT1_3", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[12].Controls[0]).Text;
            cmd.Parameters.Add("@WBT4_6", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[13].Controls[0]).Text;
            cmd.Parameters.Add("@Title", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[14].Controls[0]).Text;
            cmd.Parameters.Add("@ConcentraID", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[15].Controls[0]).Text;
            cmd.Parameters.Add("@Link", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[16].Controls[0]).Text;
            cmd.Parameters.Add("@BrightcoveLink", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[17].Controls[0]).Text;
            cmd.Parameters.Add("@ProductSource", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[18].Controls[0]).Text;
            cmd.Parameters.Add("@DocumentSource", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[19].Controls[0]).Text;
            cmd.Parameters.Add("@Core", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[20].Controls[0]).Text;
            cmd.Parameters.Add("@DesignTeamNotes", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[21].Controls[0]).Text;
            cmd.Parameters.Add("@ProjectManagerNotes", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[22].Controls[0]).Text;
            cmd.Parameters.Add("@SMEPartnerNotes", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[23].Controls[0]).Text;
            cmd.Parameters.Add("@ProLeEnterprise", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[24].Controls[0]).Text;
            cmd.Parameters.Add("@Asset", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[25].Controls[0]).Text;
            cmd.Parameters.Add("@DisclosureLevel", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[26].Controls[0]).Text;
            cmd.Parameters.Add("@Status", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[27].Controls[0]).Text;
            cmd.Parameters.Add("@OwnerPM", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[28].Controls[0]).Text;
            cmd.Parameters.Add("@AquentGrouping", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[29].Controls[0]).Text;
            cmd.Parameters.Add("@Onboarded", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[30].Controls[0]).Text;
            cmd.Parameters.Add("@EmbeddedLinks", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[31].Controls[0]).Text;
            cmd.Parameters.Add("@BDP", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[32].Controls[0]).Text;



            string cID = ((TextBox)e.Item.Cells[15].Controls[0]).Text;
            string docID = ((TextBox)e.Item.Cells[2].Controls[0]).Text;

            if(cID.Length > 4)
            {
                updateFromConcentra(cID, docID);
                cmd.CommandText = "Update TopicList set ProductSelection=@ProductSelection,Web=@Web,Intellifix=@Intellifix,IssueSignature=@IssueSignature, "
                + "UG=@UG, WLG=@WLG, SRM=@SRM, OnsiteInstallGuide=@OnsiteInstallGuide, STR=@STR, WBT1_3=@WBT1_3, WBT4_6=@WBT4_6, Title=@Title, ConcentraID=@ConcentraID, "
                + "Link=@Link, BrightcoveLink=@BrightcoveLink, ProductSource=@ProductSource, DocumentSource=@DocumentSource, Core=@Core, DesignTeamNotes=@DesignTeamNotes, "
                + "ProjectManagerNotes=@ProjectManagerNotes, SMEPartnerNotes=@SMEPartnerNotes, ProLeEnterprise=@ProLeEnterprise, Asset=@Asset, DisclosureLevel=@DisclosureLevel, "
                + "Status=@Status, OwnerPM=@OwnerPM, AquentGrouping=@AquentGrouping, Onboarded=@Onboarded, EmbeddedLinks=@EmbeddedLinks, BDP=@BDP where ConcentraID=@ConcentraID";
            }
            else
            {
                cmd.CommandText = "Update TopicList set ProductSelection=@ProductSelection,Web=@Web,Intellifix=@Intellifix,IssueSignature=@IssueSignature, "
                + "UG=@UG, WLG=@WLG, SRM=@SRM, OnsiteInstallGuide=@OnsiteInstallGuide, STR=@STR, WBT1_3=@WBT1_3, WBT4_6=@WBT4_6, Title=@Title, ConcentraID=@ConcentraID, "
                + "Link=@Link, BrightcoveLink=@BrightcoveLink, ProductSource=@ProductSource, DocumentSource=@DocumentSource, Core=@Core, DesignTeamNotes=@DesignTeamNotes, "
                + "ProjectManagerNotes=@ProjectManagerNotes, SMEPartnerNotes=@SMEPartnerNotes, ProLeEnterprise=@ProLeEnterprise, Asset=@Asset, DisclosureLevel=@DisclosureLevel, "
                + "Status=@Status, OwnerPM=@OwnerPM, AquentGrouping=@AquentGrouping, Onboarded=@Onboarded where ID=@ID";
            }

            //cmd.CommandText = "Update TopicList set F_Name=@F_Name,L_Name=@L_Name,City=@City,EmailId=@EmailId,EmpJoining=@EmpJoining where EmpId=@EmpId";
            //cmd.CommandText = "Update TopicList set ConcentraID=@ConcentraID";


            cmd.Connection = con;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            

            dataGrid.EditItemIndex = -1;
            BindData();
        }

        protected void AddRow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AddRow.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (ColumnsDDL.SelectedIndex != 0)
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                SqlDataAdapter da;
                DataSet ds = new DataSet();
                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "SELECT * from TopicList WHERE " + ColumnsDDL.SelectedItem.Text + " LIKE " + "'" + searchColumn.Text + "'";
                cmd.Connection = conn;
                da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                conn.Open();
                cmd.ExecuteNonQuery();
                dataGrid.DataSource = ds;
                dataGrid.DataBind();
                conn.Close();
            }
        }


        protected void updateFromConcentra(string concentraID, string docID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlDataAdapter dA;
            DataSet dS = new DataSet();
            SqlCommand CMD = new SqlCommand();

            CMD.CommandText = "SELECT * from CTable WHERE DocumentName = " + "'" + concentraID + "'";
            CMD.Connection = conn;
            dA = new SqlDataAdapter(CMD);
            dA.Fill(dS);
            conn.Open();
            CMD.ExecuteNonQuery();
            conn.Close();

            if ((dS.Tables.Count > 0) && (dS.Tables[0].Rows.Count > 0))
            {
                DataRow dr = dS.Tables[0].Rows[0];

                string cID = dr["DocumentName"].ToString();
                string title = dr["Title"].ToString();
                string disclosureLevel = dr["DisclosureLevel"].ToString();
                string embedded = dr["EmbeddedLinks"].ToString();
                string bdp = dr["BusinessDefinedProperties"].ToString();

                if (concentraID == cID)
                {
                    SqlConnection nConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    SqlCommand cmD = new SqlCommand();

                    cmD.Parameters.Add("@ID", SqlDbType.Char).Value = docID;
                    cmD.Parameters.Add("@ConcentraID", SqlDbType.Char).Value = cID;
                    cmD.Parameters.Add("@Title", SqlDbType.Char).Value = title;
                    cmD.Parameters.Add("@DisclosureLevel", SqlDbType.Char).Value = disclosureLevel;
                    cmD.Parameters.Add("@EmbeddedLinks", SqlDbType.Char).Value = embedded;
                    cmD.Parameters.Add("@BDP", SqlDbType.Char).Value = bdp;

                    cmD.CommandText = "Update TopicList set ConcentraID=@ConcentraID, Title=@Title, DisclosureLevel=@DisclosureLevel, EmbeddedLinks=@EmbeddedLinks, BDP=@BDP where ID=@ID";

                    cmD.Connection = nConn;
                    cmD.Connection.Open();
                    cmD.ExecuteNonQuery();
                    cmD.Connection.Close();

                }
            }

        }

        protected void populateDDL()
        {
            Database1Entities db = new Database1Entities();
            topicList = db.TopicLists.ToList();
            List<string> l1 = new List<string>();
            List<string> l2 = new List<string>();
            List<string> l3 = new List<string>();
            List<string> l4 = new List<string>();
            List<string> l5 = new List<string>();
            List<string> l6 = new List<string>();
            List<string> l7 = new List<string>();
            List<string> l8 = new List<string>();
            List<string> l9 = new List<string>();
            List<string> l10 = new List<string>();
            List<string> l11 = new List<string>();
            List<string> l12 = new List<string>();
            List<string> l13 = new List<string>();
            List<string> l14 = new List<string>();
            List<string> l15 = new List<string>();
            List<string> l16 = new List<string>();
            List<string> l17 = new List<string>();
            List<string> l18 = new List<string>();
            List<string> l19 = new List<string>();
            List<string> l20 = new List<string>();
            List<string> l21 = new List<string>();
            List<string> l22 = new List<string>();
            List<string> l23 = new List<string>();
            List<string> l24 = new List<string>();
            List<string> l25 = new List<string>();
            List<string> l26 = new List<string>();
            List<string> l27 = new List<string>();
            List<string> l28 = new List<string>();
            List<string> l29 = new List<string>();

            // populate all the dropdowns here
            foreach (TopicList li in topicList)
            {
                l1.Add(li.ProductSelection.ToString());
                l2.Add(li.Web.ToString());
                l3.Add(li.Intellifix.ToString());
                l4.Add(li.IssueSignature.ToString());
                l5.Add(li.UG.ToString());
                l6.Add(li.WLG.ToString());
                l7.Add(li.SRM.ToString());
                l8.Add(li.OnsiteInstallGuide.ToString());
                l9.Add(li.STR.ToString());
                l10.Add(li.WBT1_3.ToString());
                l11.Add(li.WBT4_6.ToString());
                l12.Add(li.Title.ToString());
                l13.Add(li.ConcentraID.ToString());
                l14.Add(li.Link.ToString());
                l15.Add(li.BrightcoveLink.ToString());
                l16.Add(li.ProductSource.ToString());
                l17.Add(li.DocumentSource.ToString());
                l18.Add(li.Core.ToString());
                l19.Add(li.DesignTeamNotes.ToString());
                l20.Add(li.ProjectManagerNotes.ToString());
                l21.Add(li.SMEPartnerNotes.ToString());
                l22.Add(li.ProLeEnterprise.ToString());
                l23.Add(li.Asset.ToString());
                l24.Add(li.DisclosureLevel.ToString());
                l25.Add(li.Status.ToString());
                l26.Add(li.OwnerPM.ToString());
                l27.Add(li.AquentGrouping.ToString());
                l28.Add(li.Onboarded.ToString());
                l29.Add(li.ProductTitle.ToString());
            }

            ColumnsDDL.Items.Insert(0, "Select Search Item");
            ColumnsDDL.Items.Add("ProductSelection");
            ColumnsDDL.Items.Add("Web");
            ColumnsDDL.Items.Add("Intellifix");
            ColumnsDDL.Items.Add("IssueSignature");
            ColumnsDDL.Items.Add("UG");
            ColumnsDDL.Items.Add("WLG");
            ColumnsDDL.Items.Add("SRM");
            ColumnsDDL.Items.Add("OnsiteInstallGuide");
            ColumnsDDL.Items.Add("STR");
            ColumnsDDL.Items.Add("WBT1-3");
            ColumnsDDL.Items.Add("WBT4-6");
            ColumnsDDL.Items.Add("Title");
            ColumnsDDL.Items.Add("ConcentraID");
            ColumnsDDL.Items.Add("Link");
            ColumnsDDL.Items.Add("BrightcoveLink");
            ColumnsDDL.Items.Add("ProductSource");
            ColumnsDDL.Items.Add("DocumentSource");
            ColumnsDDL.Items.Add("Core");
            ColumnsDDL.Items.Add("DesignTeamNotes");
            ColumnsDDL.Items.Add("ProjectManagerNotes");
            ColumnsDDL.Items.Add("SMEPartnerNotes");
            ColumnsDDL.Items.Add("ProLeEnterprise");
            ColumnsDDL.Items.Add("Asset");
            ColumnsDDL.Items.Add("DisclosureLevel");
            ColumnsDDL.Items.Add("Status");
            ColumnsDDL.Items.Add("OwnerPM");
            ColumnsDDL.Items.Add("AquentGrouping");
            ColumnsDDL.Items.Add("Onboarded");

            // bind all the dropdowns here
            DDL1.DataSource = l1.Distinct();
            DDL1.DataBind();
            DDL1.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL1.Items.Count; i++)
            {
                DDL1.Items[i].Value = DDL1.Items[i].Text;
            }

            DDL2.DataSource = l2.Distinct();
            DDL2.DataBind();
            DDL2.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL2.Items.Count; i++)
            {
                DDL2.Items[i].Value = DDL2.Items[i].Text;
            }

            DDL3.DataSource = l3.Distinct();
            DDL3.DataBind();
            DDL3.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL3.Items.Count; i++)
            {
                DDL3.Items[i].Value = DDL3.Items[i].Text;
            }

            DDL4.DataSource = l4.Distinct();
            DDL4.DataBind();
            DDL4.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL4.Items.Count; i++)
            {
                DDL4.Items[i].Value = DDL4.Items[i].Text;
            }

            DDL5.DataSource = l5.Distinct();
            DDL5.DataBind();
            DDL5.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL5.Items.Count; i++)
            {
                DDL5.Items[i].Value = DDL5.Items[i].Text;
            }

            DDL6.DataSource = l6.Distinct();
            DDL6.DataBind();
            DDL6.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL6.Items.Count; i++)
            {
                DDL6.Items[i].Value = DDL6.Items[i].Text;
            }

            DDL7.DataSource = l7.Distinct();
            DDL7.DataBind();
            DDL7.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL7.Items.Count; i++)
            {
                DDL7.Items[i].Value = DDL7.Items[i].Text;
            }

            DDL8.DataSource = l8.Distinct();
            DDL8.DataBind();
            DDL8.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL8.Items.Count; i++)
            {
                DDL8.Items[i].Value = DDL8.Items[i].Text;
            }

            DDL9.DataSource = l9.Distinct();
            DDL9.DataBind();
            DDL9.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL9.Items.Count; i++)
            {
                DDL9.Items[i].Value = DDL9.Items[i].Text;
            }

            DDL10.DataSource = l10.Distinct();
            DDL10.DataBind();
            DDL10.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL10.Items.Count; i++)
            {
                DDL10.Items[i].Value = DDL10.Items[i].Text;
            }

            DDL11.DataSource = l11.Distinct();
            DDL11.DataBind();
            DDL11.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL11.Items.Count; i++)
            {
                DDL11.Items[i].Value = DDL11.Items[i].Text;
            }

            DDL12.DataSource = l12.Distinct();
            DDL12.DataBind();
            DDL12.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL12.Items.Count; i++)
            {
                DDL12.Items[i].Value = DDL12.Items[i].Text;
            }

            DDL13.DataSource = l13.Distinct();
            DDL13.DataBind();
            DDL13.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL13.Items.Count; i++)
            {
                DDL13.Items[i].Value = DDL13.Items[i].Text;
            }

            DDL14.DataSource = l14.Distinct();
            DDL14.DataBind();
            DDL14.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL14.Items.Count; i++)
            {
                DDL14.Items[i].Value = DDL14.Items[i].Text;
            }

            DDL15.DataSource = l15.Distinct();
            DDL15.DataBind();
            DDL15.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL15.Items.Count; i++)
            {
                DDL15.Items[i].Value = DDL15.Items[i].Text;
            }

            DDL16.DataSource = l16.Distinct();
            DDL16.DataBind();
            DDL16.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL16.Items.Count; i++)
            {
                DDL16.Items[i].Value = DDL16.Items[i].Text;
            }

            DDL17.DataSource = l17.Distinct();
            DDL17.DataBind();
            DDL17.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL17.Items.Count; i++)
            {
                DDL17.Items[i].Value = DDL17.Items[i].Text;
            }

            DDL18.DataSource = l18.Distinct();
            DDL18.DataBind();
            DDL18.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL18.Items.Count; i++)
            {
                DDL18.Items[i].Value = DDL18.Items[i].Text;
            }
            DDL19.DataSource = l19.Distinct();
            DDL19.DataBind();
            DDL19.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL19.Items.Count; i++)
            {
                DDL19.Items[i].Value = DDL19.Items[i].Text;
            }

            DDL20.DataSource = l20.Distinct();
            DDL20.DataBind();
            DDL20.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL20.Items.Count; i++)
            {
                DDL20.Items[i].Value = DDL20.Items[i].Text;
            }

            DDL21.DataSource = l21.Distinct();
            DDL21.DataBind();
            DDL21.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL21.Items.Count; i++)
            {
                DDL21.Items[i].Value = DDL21.Items[i].Text;
            }

            DDL22.DataSource = l22.Distinct();
            DDL22.DataBind();
            DDL22.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL22.Items.Count; i++)
            {
                DDL22.Items[i].Value = DDL22.Items[i].Text;
            }

            DDL23.DataSource = l23.Distinct();
            DDL23.DataBind();
            DDL23.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL23.Items.Count; i++)
            {
                DDL23.Items[i].Value = DDL23.Items[i].Text;
            }

            DDL24.DataSource = l24.Distinct();
            DDL24.DataBind();
            DDL24.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL24.Items.Count; i++)
            {
                DDL24.Items[i].Value = DDL24.Items[i].Text;
            }

            DDL25.DataSource = l25.Distinct();
            DDL25.DataBind();
            DDL25.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL25.Items.Count; i++)
            {
                DDL25.Items[i].Value = DDL25.Items[i].Text;
            }

            DDL26.DataSource = l26.Distinct();
            DDL26.DataBind();
            DDL26.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL26.Items.Count; i++)
            {
                DDL26.Items[i].Value = DDL26.Items[i].Text;
            }

            DDL27.DataSource = l27.Distinct();
            DDL27.DataBind();
            DDL27.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL27.Items.Count; i++)
            {
                DDL27.Items[i].Value = DDL27.Items[i].Text;
            }

            DDL28.DataSource = l28.Distinct();
            DDL28.DataBind();
            DDL28.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL28.Items.Count; i++)
            {
                DDL28.Items[i].Value = DDL28.Items[i].Text;
            }

            DDL29.DataSource = l29.Distinct();
            DDL29.DataBind();
            DDL29.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < DDL29.Items.Count; i++)
            {
                DDL29.Items[i].Value = DDL29.Items[i].Text;
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection nConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            nConn.Open();



            /*
            SqlDataAdapter sda = new SqlDataAdapter(("Select * from TopicList where ProductSelection LIKE" + "'" + DDL1.SelectedItem.Value + "'"
                + " and Web LIKE" + "'" + DDL2.SelectedItem.Value + "'" + " and Intellifix LIKE" + "'" + DDL3.SelectedItem.Value + "'" + " and IssueSignature LIKE"
                + "'" + DDL4.SelectedItem.Value + "'" + " and UG LIKE" + "'" + DDL5.SelectedItem.Value + "'" + " and WLG LIKE" + "'" + DDL6.SelectedItem.Value + "'"
                + " and SRM LIKE" + "'" + DDL7.SelectedItem.Value + "'" + " and OnsiteInstallGuide LIKE" + "'" + DDL8.SelectedItem.Value + "'" + "and STR LIKE"
                + "'" + DDL9.SelectedItem.Value + "'" + "and WBT1_3 LIKE" + "'" + DDL10.SelectedItem.Value + "'" + " and WBT4_6 LIKE" + "'" + DDL11.SelectedItem.Value + "'"), nConn);
                
            */


            SqlDataAdapter sda = new SqlDataAdapter(("Select * from TopicList where ProductSelection LIKE" + "'" + DDL1.SelectedItem.Value + "'"
                + " and Web LIKE" + "'" + DDL2.SelectedItem.Value + "'" + " and Intellifix LIKE" + "'" + DDL3.SelectedItem.Value + "'" + " and IssueSignature LIKE"
                + "'" + DDL4.SelectedItem.Value + "'" + " and UG LIKE" + "'" + DDL5.SelectedItem.Value + "'" + " and WLG LIKE" + "'" + DDL6.SelectedItem.Value + "'"
                + " and SRM LIKE" + "'" + DDL7.SelectedItem.Value + "'" + " and OnsiteInstallGuide LIKE" + "'" + DDL8.SelectedItem.Value + "'" + "and STR LIKE"
                + "'" + DDL9.SelectedItem.Value + "'" + "and WBT1_3 LIKE" + "'" + DDL10.SelectedItem.Value + "'" + " and WBT4_6 LIKE" + "'" + DDL11.SelectedItem.Value + "'"
                + " and Title LIKE" + "'" + DDL12.SelectedItem.Value + "'" + "and ConcentraID LIKE" + "'" + DDL13.SelectedItem.Value + "'" + " and Link LIKE" + "'" + DDL14.SelectedItem.Value + "'"
                + " and BrightcoveLink LIKE" + "'" + DDL15.SelectedItem.Value + "'" + " and ProductSource LIKE" + "'" + DDL16.SelectedItem.Value + "'" + " and DocumentSource LIKE"
                + "'" + DDL17.SelectedItem.Value + "'" + " and Core LIKE" + "'" + DDL18.SelectedItem.Value + "'" + " and DesignTeamNotes LIKE" + "'" + DDL19.SelectedItem.Value + "'"
                + " and ProjectManagerNotes LIKE" + "'" + DDL20.SelectedItem.Value + "'" + " and SMEPartnerNotes LIKE" + "'" + DDL21.SelectedItem.Value + "'" + " and ProLeEnterprise LIKE"
                + "'" + DDL22.SelectedItem.Value + "'" + " and Asset LIKE" + "'" + DDL23.SelectedItem.Value + "'" + " and DisclosureLevel LIKE" + "'" + DDL24.SelectedItem.Value + "'"
                + " and Status LIKE" + "'" + DDL25.SelectedItem.Value + "'" + " and OwnerPM LIKE" + "'" + DDL26.SelectedItem.Value + "'" + " and AquentGrouping LIKE" + "'" + DDL27.SelectedItem.Value + "'"
                + " and Onboarded LIKE" + "'" + DDL28.SelectedItem.Value + "'" + " and ProductTitle LIKE" + "'" + DDL29.SelectedItem.Value + "'"), nConn);


            DataSet ds = new DataSet();
            sda.Fill(ds);
            dataGrid.DataSource = ds;
            dataGrid.DataBind();
            nConn.Close();
        }


        protected void btnReset_Click(object sender, EventArgs e)
        {
            DDL1.SelectedIndex = 0;
            DDL2.SelectedIndex = 0;
            DDL3.SelectedIndex = 0;
            DDL4.SelectedIndex = 0;
            DDL5.SelectedIndex = 0;
            DDL6.SelectedIndex = 0;
            DDL7.SelectedIndex = 0;
            DDL8.SelectedIndex = 0;
            DDL9.SelectedIndex = 0;
            DDL10.SelectedIndex = 0;
            DDL11.SelectedIndex = 0;
            DDL12.SelectedIndex = 0;
            DDL13.SelectedIndex = 0;
            DDL14.SelectedIndex = 0;
            DDL15.SelectedIndex = 0;
            DDL16.SelectedIndex = 0;
            DDL17.SelectedIndex = 0;
            DDL18.SelectedIndex = 0;
            DDL19.SelectedIndex = 0;
            DDL20.SelectedIndex = 0;
            DDL21.SelectedIndex = 0;
            DDL22.SelectedIndex = 0;
            DDL23.SelectedIndex = 0;
            DDL24.SelectedIndex = 0;
            DDL25.SelectedIndex = 0;
            DDL26.SelectedIndex = 0;
            DDL27.SelectedIndex = 0;
            DDL28.SelectedIndex = 0;
            ColumnsDDL.SelectedIndex = 0;
            searchColumn.Text = "";
            BindData();
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            /*
            SqlConnection nConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            nConn.Open();

            string sql = @"Delete from TopicList;";
            SqlCommand cmD = new SqlCommand(sql, nConn);
            cmD.ExecuteNonQuery();
            nConn.Close();
            */

            if (!(ProductName.Text.Length > 0))
            {
                Response.Write("<script>alert('Please enter a product name before uploading Topic List!')</script>");
                return;
            }


            if (FileUpload1.PostedFile.ContentType == "application/vnd.ms-excel" ||
                FileUpload1.PostedFile.ContentType == "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                try
                {
                    string fileName = Path.Combine(Server.MapPath("~/ImportDocument"), Guid.NewGuid().ToString() + Path.GetExtension(FileUpload1.PostedFile.FileName));
                    FileUpload1.PostedFile.SaveAs(fileName);

                    string conString = "";
                    string ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
                    if (ext.ToLower() == ".xls")
                    {
                        conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;MDR=Yes;IMEX=2\"";
                    }
                    else if (ext.ToLower() == ".xlsx")
                    {
                        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;MDR=Yes;IMEX=2\"";
                    }

                    string query = "Select * from [Topic List$]";

                    
                    OleDbConnection con = new OleDbConnection(conString);
                    if (con.State == System.Data.ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    OleDbCommand cmd = new OleDbCommand(query, con);
                    OleDbDataAdapter da = new OleDbDataAdapter(cmd);

                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    da.Dispose();
                    con.Close();
                    con.Dispose();





                    //Import to Database
                    using (Database1Entities db = new Database1Entities())
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string docID = dr["Document ID"].ToString();
                            Guid id = Guid.NewGuid();
                            string GuidString = Convert.ToBase64String(id.ToByteArray());
                            GuidString = GuidString.Replace("=", "");
                            GuidString = GuidString.Replace("+", "");

                            var v = db.TopicLists.Where(a => a.ID.Equals(docID)).FirstOrDefault();
                            if (v != null)
                            {
                                //Update here 
                                v.ProductSelection = dr["Product Selection"].ToString();
                                v.Web = dr["Web"].ToString();
                                v.Intellifix = dr["Intellifix"].ToString();
                                v.IssueSignature = dr["Issue Signature"].ToString();
                                v.UG = dr["UG"].ToString();
                                v.WLG = dr["WLG"].ToString();
                                v.SRM = dr["SRM"].ToString();
                                v.OnsiteInstallGuide = dr["Onsite Install Guide"].ToString();
                                v.STR = dr["STR"].ToString();
                                v.WBT1_3 = dr["WBT 1-3"].ToString();
                                v.WBT4_6 = dr["WBT 4-6"].ToString();
                                v.Title = dr["Title"].ToString();
                                v.ConcentraID = dr["Concentra ID"].ToString();
                                v.Link = dr["Link"].ToString();
                                v.BrightcoveLink = dr["Brightcove Link"].ToString();
                                v.ProductSource = dr["Product Source"].ToString();
                                v.DocumentSource = dr["Document Source"].ToString();
                                v.Core = dr["Core"].ToString();
                                v.DesignTeamNotes = dr["Design Team Notes"].ToString();
                                v.ProjectManagerNotes = dr["Project Manager notes"].ToString();
                                v.SMEPartnerNotes = dr["SME/Partner Notes"].ToString();
                                v.ProLeEnterprise = dr["Pro/LE or Enterprise"].ToString();
                                v.Asset = dr["Asset"].ToString();
                                v.DisclosureLevel = dr["Disclosure level"].ToString();
                                v.Status = dr["Status"].ToString();
                                v.OwnerPM = dr["Owner/PM"].ToString();
                                v.AquentGrouping = dr["Aquent Grouping"].ToString();
                                v.Onboarded = dr["Onboarded"].ToString();
                                v.ProductTitle = ProductName.Text;

                            }
                            else if ((dr["Concentra ID"].ToString().Length > 8) && (dr["Concentra ID"].ToString()[0].Equals('c')))
                            {
                                /*
                                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
                                SqlDataAdapter dA;
                                DataSet dS = new DataSet();
                                SqlCommand CMD = new SqlCommand();

                                CMD.CommandText = "SELECT * from CTable WHERE DocumentName = " + "'" + dr["Concentra ID"].ToString() + "'";
                                CMD.Connection = conn;
                                dA = new SqlDataAdapter(CMD);
                                dA.Fill(dS);
                                conn.Open();
                                CMD.ExecuteNonQuery();
                                conn.Close();
                                
                                if ((dS.Tables.Count > 0) && (dS.Tables[0].Rows.Count > 0))
                                {
                                    DataRow DR = dS.Tables[0].Rows[0];

                                    string cID = DR["DocumentName"].ToString();
                                    string title = DR["Title"].ToString();
                                    string disclosureLevel = DR["DisclosureLevel"].ToString();
                                    string embedded = DR["EmbeddedLinks"].ToString();
                                    string bdp = DR["BusinessDefinedProperties"].ToString();

                                    db.TopicLists.Add(new TopicList
                                    {
                                        ID = GuidString,
                                        ProductSelection = dr["Product Selection"].ToString(),
                                        Web = dr["Web"].ToString(),
                                        Intellifix = dr["Intellifix"].ToString(),
                                        IssueSignature = dr["Issue Signature"].ToString(),
                                        UG = dr["UG"].ToString(),
                                        WLG = dr["WLG"].ToString(),
                                        SRM = dr["SRM"].ToString(),
                                        OnsiteInstallGuide = dr["Onsite Install Guide"].ToString(),
                                        STR = dr["STR"].ToString(),
                                        WBT1_3 = dr["WBT 1-3"].ToString(),
                                        WBT4_6 = dr["WBT 4-6"].ToString(),
                                        Title = title,
                                        ConcentraID = dr["Concentra ID"].ToString(),
                                        Link = dr["Link"].ToString(),
                                        BrightcoveLink = dr["Brightcove Link"].ToString(),
                                        ProductSource = dr["Product Source"].ToString(),
                                        DocumentSource = dr["Document Source"].ToString(),
                                        Core = dr["Core"].ToString(),
                                        DesignTeamNotes = dr["Design Team Notes"].ToString(),
                                        ProjectManagerNotes = dr["Project Manager notes"].ToString(),
                                        SMEPartnerNotes = dr["SME/Partner Notes"].ToString(),
                                        ProLeEnterprise = dr["Pro/LE or Enterprise"].ToString(),
                                        Asset = dr["Asset"].ToString(),
                                        DisclosureLevel = disclosureLevel,
                                        Status = dr["Status"].ToString(),
                                        OwnerPM = dr["Owner/PM"].ToString(),
                                        AquentGrouping = dr["Aquent Grouping"].ToString(),
                                        Onboarded = dr["Onboarded"].ToString(),
                                        ProductTitle = ProductName.Text,
                                        EmbeddedLinks = embedded,
                                        BDP = bdp
                                    });
                                }
                                else
                                {*/
                                    db.TopicLists.Add(new TopicList
                                    {
                                        ID = GuidString,
                                        ProductSelection = dr["Product Selection"].ToString(),
                                        Web = dr["Web"].ToString(),
                                        Intellifix = dr["Intellifix"].ToString(),
                                        IssueSignature = dr["Issue Signature"].ToString(),
                                        UG = dr["UG"].ToString(),
                                        WLG = dr["WLG"].ToString(),
                                        SRM = dr["SRM"].ToString(),
                                        OnsiteInstallGuide = dr["Onsite Install Guide"].ToString(),
                                        STR = dr["STR"].ToString(),
                                        WBT1_3 = dr["WBT 1-3"].ToString(),
                                        WBT4_6 = dr["WBT 4-6"].ToString(),
                                        Title = dr["Title"].ToString(),
                                        ConcentraID = dr["Concentra ID"].ToString(),
                                        Link = dr["Link"].ToString(),
                                        BrightcoveLink = dr["Brightcove Link"].ToString(),
                                        ProductSource = dr["Product Source"].ToString(),
                                        DocumentSource = dr["Document Source"].ToString(),
                                        Core = dr["Core"].ToString(),
                                        DesignTeamNotes = dr["Design Team Notes"].ToString(),
                                        ProjectManagerNotes = dr["Project Manager notes"].ToString(),
                                        SMEPartnerNotes = dr["SME/Partner Notes"].ToString(),
                                        ProLeEnterprise = dr["Pro/LE or Enterprise"].ToString(),
                                        Asset = dr["Asset"].ToString(),
                                        DisclosureLevel = dr["Disclosure Level"].ToString(),
                                        Status = dr["Status"].ToString(),
                                        OwnerPM = dr["Owner/PM"].ToString(),
                                        AquentGrouping = dr["Aquent Grouping"].ToString(),
                                        Onboarded = dr["Onboarded"].ToString(),
                                        ProductTitle = ProductName.Text
                                    });
                                //}
                            }
                            else
                            {
                                db.TopicLists.Add(new TopicList
                                {
                                    ID = GuidString,
                                    ProductSelection = dr["Product Selection"].ToString(),
                                    Web = dr["Web"].ToString(),
                                    Intellifix = dr["Intellifix"].ToString(),
                                    IssueSignature = dr["Issue Signature"].ToString(),
                                    UG = dr["UG"].ToString(),
                                    WLG = dr["WLG"].ToString(),
                                    SRM = dr["SRM"].ToString(),
                                    OnsiteInstallGuide = dr["Onsite Install Guide"].ToString(),
                                    STR = dr["STR"].ToString(),
                                    WBT1_3 = dr["WBT 1-3"].ToString(),
                                    WBT4_6 = dr["WBT 4-6"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    ConcentraID = dr["Concentra ID"].ToString(),
                                    Link = dr["Link"].ToString(),
                                    BrightcoveLink = dr["Brightcove Link"].ToString(),
                                    ProductSource = dr["Product Source"].ToString(),
                                    DocumentSource = dr["Document Source"].ToString(),
                                    Core = dr["Core"].ToString(),
                                    DesignTeamNotes = dr["Design Team Notes"].ToString(),
                                    ProjectManagerNotes = dr["Project Manager notes"].ToString(),
                                    SMEPartnerNotes = dr["SME/Partner Notes"].ToString(),
                                    ProLeEnterprise = dr["Pro/LE or Enterprise"].ToString(),
                                    Asset = dr["Asset"].ToString(),
                                    DisclosureLevel = dr["Disclosure level"].ToString(),
                                    Status = dr["Status"].ToString(),
                                    OwnerPM = dr["Owner/PM"].ToString(),
                                    AquentGrouping = dr["Aquent Grouping"].ToString(),
                                    Onboarded = dr["Onboarded"].ToString(),
                                    ProductTitle = ProductName.Text
                                });
                            }

                        }



                        db.SaveChanges();
                    }

                    BindData();
                    ProductName.Text = "";
                    lblMessage.Text = "Data import was successful";

                }
                catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
                {
                    Exception raise = dbEx;
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string message = string.Format("{0}:{1}",
                                validationErrors.Entry.Entity.ToString(),
                                validationError.ErrorMessage);
                            // raise a new exception nesting
                            // the current instance as InnerException
                            raise = new InvalidOperationException(message, raise);
                        }
                    }
                    throw raise;
                }
            }

            populateDDL();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportToExcel(dataGrid , "TOPIC_LIST_EXPORT");
        }

        private void ExportToExcel(DataGrid gridview, string excelFilename)
        {
            Microsoft.Office.Interop.Excel.Application objexcelapp = new Microsoft.Office.Interop.Excel.Application();

            objexcelapp.Application.Workbooks.Add(Type.Missing);

            objexcelapp.Columns.ColumnWidth = 25;

            for (int i = 1; i < gridview.Columns.Count + 1; i++)

            {
                objexcelapp.Cells[1, i] = gridview.Columns[i - 1].HeaderText;
            }

            /*For storing Each row and column value to excel sheet*/

            for (int i = 0; i < gridview.Items.Count; i++)

            {

                for (int j = 0; j < gridview.Columns.Count; j++)

                {
                    if (!gridview.Items[i].Cells[j].Text.Equals("&nbsp;"))

                    {

                        objexcelapp.Cells[i + 2, j + 1] = gridview.Items[i].Cells[j].Text.ToString();

                    }

                }

            }


            objexcelapp.ActiveWorkbook.SaveCopyAs("C:\\" + excelFilename + ".xlsx");

            objexcelapp.ActiveWorkbook.Saved = true;
        }


    }
}