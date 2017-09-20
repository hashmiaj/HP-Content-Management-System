using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class Matrix : System.Web.UI.Page
    {
        List<DocMatrix> docMatrix = new List<DocMatrix>();


        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                populateDDL();
                BindData();
                lblMessage.Text = "Doc Matrix Data!";
            }
        }

        public void BindData()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();

            if ((DDL1.SelectedIndex == 0) && (DDL2.SelectedIndex == 0) && (DDL3.SelectedIndex == 0) && (DDL4.SelectedIndex == 0) && (DDL5.SelectedIndex == 0) && (DDL6.SelectedIndex == 0)
                && (DDL7.SelectedIndex == 0) && (DDL8.SelectedIndex == 0) && (DDL9.SelectedIndex == 0) && (DDL10.SelectedIndex == 0) && (DDL11.SelectedIndex == 0) && (DDL12.SelectedIndex == 0)
                && (DDL13.SelectedIndex == 0) && (DDL14.SelectedIndex == 0) && (DDL15.SelectedIndex == 0))
            {
                cmd.CommandText = "Select * from DocMatrix";
            }
            else
            {
                cmd.CommandText = "Select * from DocMatrix where DateFinal LIKE" + "'" + DDL1.SelectedValue + "'" + " and DocDiscipline LIKE" + "'" + DDL2.SelectedValue + "'" + " and DocumentType LIKE"
                                   + "'" + DDL3.SelectedValue + "'" + " and ProductNumber LIKE " + "'" + DDL4.SelectedValue + "'" + " and DocumentName LIKE" + "'" + DDL15.SelectedValue + "'" + " and DocPartNumber LIKE"
                                   + "'" + DDL5.SelectedValue + "'" + " and DocServiceLevel LIKE" + "'" + DDL6.SelectedValue + "'" + " and ServiceKitPart LIKE" + "'" + DDL7.SelectedValue + "'" + " and ConcentraPDFID LIKE"
                                   + "'" + DDL8.SelectedValue + "'" + " and Languages LIKE" + "'" + DDL9.SelectedValue + "'" + " and SupplyChainStrategy LIKE" + "'" + DDL10.SelectedValue + "'" + " and QRCodeURL LIKE"
                                   + "'" + DDL11.SelectedValue + "'" + " and LinkDocConcentraID LIKE" + "'" + DDL12.SelectedValue + "'" + " and VideoURL LIKE" + "'" + DDL13.SelectedValue + "'" + " and Comments LIKE"
                                   + "'" + DDL14.SelectedValue + "'" + " and ProductName LIKE" + "'" + ProdDDL.SelectedValue + "'";
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
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            string DocID = e.Item.Cells[2].Text;
            cmd.CommandText = "Delete from DocMatrix where MatrixID=" + "'" + DocID + "'";
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            dataGrid.EditItemIndex = -1;
            BindData();
        }

        protected void dataGrid_UpdateCommand(object source, DataGridCommandEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.Parameters.Add("@MatrixID", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[2].Controls[0]).Text;
            cmd.Parameters.Add("@DateFinal", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[3].Controls[0]).Text;
            cmd.Parameters.Add("@DocDiscipline", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[4].Controls[0]).Text;
            cmd.Parameters.Add("@DocumentType", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[5].Controls[0]).Text;
            cmd.Parameters.Add("@DocumentName", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[6].Controls[0]).Text;
            cmd.Parameters.Add("@ProductNumber", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[7].Controls[0]).Text;
            cmd.Parameters.Add("@DocPartNumber", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[8].Controls[0]).Text;
            cmd.Parameters.Add("@DocServiceLevel", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[9].Controls[0]).Text;
            cmd.Parameters.Add("@ServiceKitPart", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[10].Controls[0]).Text;
            cmd.Parameters.Add("@ConcentraPDFID", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[11].Controls[0]).Text;
            cmd.Parameters.Add("@Languages", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[12].Controls[0]).Text;
            cmd.Parameters.Add("@SupplyChainStrategy", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[13].Controls[0]).Text;
            cmd.Parameters.Add("@QRCodeURL", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[14].Controls[0]).Text;
            cmd.Parameters.Add("@LinkDocConcentraID", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[15].Controls[0]).Text;
            cmd.Parameters.Add("@VideoURL", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[16].Controls[0]).Text;
            cmd.Parameters.Add("@Comments", SqlDbType.Char).Value = ((TextBox)e.Item.Cells[17].Controls[0]).Text;

            string cID = ((TextBox)e.Item.Cells[15].Controls[0]).Text;
            string matID = ((TextBox)e.Item.Cells[2].Controls[0]).Text;

            cmd.CommandText = "Update DocMatrix set DateFinal=@DateFinal, DocDiscipline=@DocDiscipline, DocumentType=@DocumentType, "
                       + "DocumentName=@DocumentName, ProductNumber=@ProductNumber, DocPartNumber=@DocPartNumber, ServiceKitPart=@ServiceKitPart, ConcentraPDFID=@ConcentraPDFID, "
                       + "Languages=@Languages, SupplyChainStrategy=@SupplyChainStrategy, QRCodeURL=@QRCodeURL, LinkDocConcentraID=@LinkDocConcentraID, VideoURL=@VideoURL, "
                       + "Comments=@Comments where MatrixID=@MatrixID";


            cmd.Connection = conn;
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            updateFromCID(cID, matID);

            dataGrid.EditItemIndex = -1;
            BindData();


        }

        protected void updateFromCID(string cID, string matID)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlDataAdapter dA;
            DataSet dS = new DataSet();
            SqlCommand CMD = new SqlCommand();

            CMD.CommandText = "SELECT * from CTable WHERE DocumentName = " + "'" + cID + "'";
            CMD.Connection = conn;
            dA = new SqlDataAdapter(CMD);
            dA.Fill(dS);
            conn.Open();
            CMD.ExecuteNonQuery();
            conn.Close();

            SqlConnection nConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "Select * from TopicList where ConcentraID = " + "'" + cID + "'";
            cmd.Connection = nConn;
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            nConn.Open();
            cmd.ExecuteNonQuery();
            nConn.Close();


            if ((dS.Tables.Count > 0) && (dS.Tables[0].Rows.Count > 0))
            {
                DataRow dR = dS.Tables[0].Rows[0];
                string conID = dR["DocumentName"].ToString();
                string BDP = dR["BusinessDefinedProperties"].ToString();

                if (conID == cID)
                {
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    SqlCommand cmD = new SqlCommand();

                    cmD.Parameters.Add("@MatrixID", SqlDbType.Char).Value = matID;
                    cmD.Parameters.Add("@LinkDocConcentraID", SqlDbType.Char).Value = conID;
                    cmD.Parameters.Add("@BDP", SqlDbType.Char).Value = BDP;

                    cmD.CommandText = "Update DocMatrix set LinkDocConcentraID=@LinkDocConcentraID, BDP=@BDP where MatrixID=@MatrixID";

                    cmD.Connection = con;
                    cmD.Connection.Open();
                    cmD.ExecuteNonQuery();
                    cmD.Connection.Close();
                }
            }

            if ((ds.Tables.Count > 0) && (ds.Tables[0].Rows.Count > 0))
            {
                DataRow dr = ds.Tables[0].Rows[0];

                string concentraID = dr["ConcentraID"].ToString();
                string brightcoveLink = dr["BrightcoveLink"].ToString();

                if(concentraID == cID)
                {
                    SqlConnection NConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

                    SqlCommand CmD = new SqlCommand();

                    CmD.Parameters.Add("@MatrixID", SqlDbType.Char).Value = matID;
                    CmD.Parameters.Add("@LinkDocConcentraID", SqlDbType.Char).Value = concentraID;
                    CmD.Parameters.Add("@BrightcoveLink", SqlDbType.Char).Value = brightcoveLink;

                    CmD.CommandText = "Update DocMatrix set LinkDocConcentraID=@LinkDocConcentraID, BrightcoveLink=@BrightcoveLink where MatrixID=@MatrixID";

                    CmD.Connection = NConn;
                    CmD.Connection.Open();
                    CmD.ExecuteNonQuery();
                    CmD.Connection.Close();
                }
            }



        }

        protected void populateDDL()
        {
            Database1Entities db = new Database1Entities();
            docMatrix = db.DocMatrices.ToList();

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

            foreach(DocMatrix dm in docMatrix)
            {
                l1.Add(dm.DateFinal.ToString());
                l2.Add(dm.DocDiscipline.ToString());
                l3.Add(dm.DocumentType.ToString());
                l4.Add(dm.ProductNumber.ToString());
                l5.Add(dm.DocPartNumber.ToString());
                l6.Add(dm.DocServiceLevel.ToString());
                l7.Add(dm.ServiceKitPart.ToString());
                l8.Add(dm.ConcentraPDFID.ToString());
                l9.Add(dm.Languages.ToString());
                l10.Add(dm.SupplyChainStrategy.ToString());
                l11.Add(dm.QRCodeURL.ToString());
                l12.Add(dm.LinkDocConcentraID.ToString());
                l13.Add(dm.VideoURL.ToString());
                l14.Add(dm.Comments.ToString());
                l15.Add(dm.DocumentName.ToString());
                l16.Add(dm.ProductName.ToString());
            }


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

            ProdDDL.DataSource = l16.Distinct();
            ProdDDL.DataBind();
            ProdDDL.Items.Insert(0, new ListItem("Select All", "%"));
            for (int i = 1; i < ProdDDL.Items.Count; i++)
            {
                ProdDDL.Items[i].Value = ProdDDL.Items[i].Text;
            }

        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            SqlConnection nConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            SqlDataAdapter da;
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();


            da = new SqlDataAdapter(("Select * from DocMatrix where DateFinal LIKE" + "'" + DDL1.SelectedValue + "'" + " and DocDiscipline LIKE" + "'" + DDL2.SelectedValue + "'" + " and DocumentType LIKE"
                                   + "'" + DDL3.SelectedValue + "'" + " and ProductNumber LIKE " + "'" + DDL4.SelectedValue + "'" + " and DocumentName LIKE" + "'" + DDL15.SelectedValue + "'" + " and DocPartNumber LIKE" 
                                   + "'" + DDL5.SelectedValue + "'" + " and DocServiceLevel LIKE" + "'" + DDL6.SelectedValue + "'" + " and ServiceKitPart LIKE" + "'" + DDL7.SelectedValue + "'" + " and ConcentraPDFID LIKE"
                                   + "'" + DDL8.SelectedValue + "'" + " and Languages LIKE" + "'" + DDL9.SelectedValue + "'" + " and SupplyChainStrategy LIKE" + "'" + DDL10.SelectedValue + "'" + " and QRCodeURL LIKE"
                                   + "'" + DDL11.SelectedValue + "'" + " and LinkDocConcentraID LIKE" + "'" + DDL12.SelectedValue + "'" + " and VideoURL LIKE" + "'" + DDL13.SelectedValue + "'" + " and Comments LIKE"
                                   + "'" + DDL14.SelectedValue + "'" + " and ProductName LIKE" + "'" + ProdDDL.SelectedValue + "'"), nConn);
            
            da.Fill(ds);
            dataGrid.DataSource = ds;
            dataGrid.DataBind();
            nConn.Close();
            
           
        }

        protected void btnreset_Click(object sender, EventArgs e)
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
            BindData();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            /*
            SqlConnection nConn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
            nConn.Open();

            string sql = @"Delete from TopicList;";
            SqlCommand cmD = new SqlCommand(sql, nConn);
            cmD.ExecuteNonQuery();
            nConn.Close();
            */


            if (!(ProdName.Text.Length > 0))
            {
                Response.Write("<script>alert('Please enter a product name before uploading Doc Matrix!')</script>");
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

                    string query = "Select * from [Doc Matrix$]";


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
                            string docID = dr["Matrix ID"].ToString();
                            Guid id = Guid.NewGuid();
                            string GuidString = Convert.ToBase64String(id.ToByteArray());
                            GuidString = GuidString.Replace("=", "");
                            GuidString = GuidString.Replace("+", "");

                            var v = db.DocMatrices.Where(a => a.MatrixID.Equals(docID)).FirstOrDefault();
                            if (v != null)
                            {
                                //update here
                                v.DateFinal = dr["Date Final"].ToString();
                                v.DocDiscipline = dr["Doc Discipline"].ToString();
                                v.DocumentType = dr["Document Type"].ToString();
                                v.DocumentName = dr["Document Name"].ToString();
                                v.ProductNumber = dr["Product#"].ToString();
                                v.DocPartNumber = dr["Doc part number"].ToString();
                                v.DocServiceLevel = dr["Doc Service Level"].ToString();
                                v.ServiceKitPart = dr["Service Kit Part"].ToString();
                                v.ConcentraPDFID = dr["Concentra (PDF ID)"].ToString();
                                v.Languages = dr["Languages"].ToString();
                                v.SupplyChainStrategy = dr["Supply Chain Strategy"].ToString();
                                v.QRCodeURL = dr["QR Code URL"].ToString();
                                v.LinkDocConcentraID = dr["Linked Doc Concentra ID"].ToString();
                                v.VideoURL = dr["Video URL"].ToString();
                                v.Comments = dr["Comments"].ToString();
                                v.ProductName = ProdName.Text;
                            }
                            else if (dr["Matrix ID"].ToString().Length > 0)
                            {
                                db.DocMatrices.Add(new DocMatrix
                                {
                                    MatrixID = dr["Matrix ID"].ToString(),
                                    DateFinal = dr["Date Final"].ToString(),
                                    DocDiscipline = dr["Doc Discipline"].ToString(),
                                    DocumentType = dr["Document Type"].ToString(),
                                    DocumentName = dr["Document Name"].ToString(),
                                    ProductNumber = dr["Product#"].ToString(),
                                    DocPartNumber = dr["Doc part number"].ToString(),
                                    DocServiceLevel = dr["Doc Service Level"].ToString(),
                                    ServiceKitPart = dr["Service Kit Part"].ToString(),
                                    ConcentraPDFID = dr["Concentra (PDF ID)"].ToString(),
                                    Languages = dr["Languages"].ToString(),
                                    SupplyChainStrategy = dr["Supply Chain Strategy"].ToString(),
                                    QRCodeURL = dr["QR Code URL"].ToString(),
                                    LinkDocConcentraID = dr["Linked Doc Concentra ID"].ToString(),
                                    VideoURL = dr["Video URL"].ToString(),
                                    Comments = dr["Comments"].ToString(),
                                    ProductName = ProdName.Text,
                                });
                            }
                            else
                            {
                                db.DocMatrices.Add(new DocMatrix
                                {
                                    MatrixID = GuidString,
                                    DateFinal = dr["Date Final"].ToString(),
                                    DocDiscipline = dr["Doc Discipline"].ToString(),
                                    DocumentType = dr["Document Type"].ToString(),
                                    DocumentName = dr["Document Name"].ToString(),
                                    ProductNumber = dr["Product#"].ToString(),
                                    DocPartNumber = dr["Doc part number"].ToString(),
                                    DocServiceLevel = dr["Doc Service Level"].ToString(),
                                    ServiceKitPart = dr["Service Kit Part"].ToString(),
                                    ConcentraPDFID = dr["Concentra (PDF ID)"].ToString(),
                                    Languages = dr["Languages"].ToString(),
                                    SupplyChainStrategy = dr["Supply Chain Strategy"].ToString(),
                                    QRCodeURL = dr["QR Code URL"].ToString(),
                                    LinkDocConcentraID = dr["Linked Doc Concentra ID"].ToString(),
                                    VideoURL = dr["Video URL"].ToString(),
                                    Comments = dr["Comments"].ToString(),
                                    ProductName = ProdName.Text,
                                });
                            }

                        }



                        db.SaveChanges();
                    }

                    BindData();
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

        }

        protected void ProdName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}