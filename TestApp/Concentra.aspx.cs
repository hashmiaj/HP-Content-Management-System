using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestApp
{
    public partial class Concentra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //this.BindGrid();
                //PopulateData();
                lblMessage.Text = "Current database content";
            }
        }

        /*
        protected void PopulateData()
        {
            using (Database1Entities dc = new Database1Entities())
            {
                grid.DataSource = dc.CTables.ToList();
                grid.DataBind();
            }
        }

            */
        /*
        private void BindGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))

            {

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM CTable"))

                {

                    using (SqlDataAdapter sda = new SqlDataAdapter())

                    {

                        cmd.Connection = con;

                        sda.SelectCommand = cmd;

                        using (DataTable dt = new DataTable())

                        {

                            sda.Fill(dt);

                            grid.DataSource = dt;

                            grid.DataBind();

                        }

                    }

                }

            }
        }
        */

        protected void btn_Click(object sender, EventArgs e)
        {
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
                        conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties=\"Excel 8.0;MDR=Yes;IMEX=2\""; ;
                    }
                    else if (ext.ToLower() == ".xlsx")
                    {
                        conString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=\"Excel 12.0;MDR=Yes;IMEX=2\"";
                    }

                    string query = "Select * from [Sheet1$]";
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
                    using (Database1Entities dc = new Database1Entities())
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            string empID = dr["Document Name"].ToString();
                            var v = dc.CTables.Where(a => a.DocumentName.Equals(empID)).FirstOrDefault();
                            if (v != null)
                            {
                                //Update here
                                v.Title = dr["Title"].ToString();
                                v.CollectionType = dr["Collection Type"].ToString();
                                v.Language = dr["Language"].ToString();
                                v.CollectionID = dr["Collection ID"].ToString();
                                v.CMG = dr["Content Management Group (CMG)"].ToString();
                                v.DisclosureLevel = dr["Disclosure Level"].ToString();
                                v.DocumentType = dr["Document Type"].ToString();
                                v.DocumentTypeDetail = dr["Document Type Detail"].ToString();
                                v.Regions = dr["Regions"].ToString();
                                v.TopicCategories = dr["Topic Categories"].ToString();
                                v.PublicationCode = dr["Publication Code"].ToString();
                                v.ContentTopic = dr["Content Topic"].ToString();
                                v.SearchKeywords = dr["Search Keywords"].ToString();
                                v.EmbeddedLinks = dr["Embedded Links"].ToString();
                                v.PublicationDestinations = dr["Publication Destinations"].ToString();
                                v.ProductLines = dr["Product Lines"].ToString();
                                v.OriginalFilename = dr["Original Filename"].ToString();
                                v.BusinessDefinedProperties = dr["Business Defined Properties"].ToString();
                                v.Authors = dr["Authors"].ToString();
                                v.ContentVersion = dr["Content Version"].ToString();
                                v.VersionLabel = dr["Version Label"].ToString();
                                v.ProjectName = dr["Project Name"].ToString();
                                v.CollectionMasterID = dr["Collection Master ID"].ToString();
                                v.CreationDate = dr["Creation Date"].ToString();
                                v.ContentUpdateDate = dr["Content Update Date"].ToString();



                            }
                            else
                            {
                                //Insert
                                dc.CTables.Add(new CTable
                                {
                                    DocumentName = dr["Document Name"].ToString(),
                                    Title = dr["Title"].ToString(),
                                    CollectionType = dr["Collection Type"].ToString(),
                                    Language = dr["Language"].ToString(),
                                    CollectionID = dr["Collection ID"].ToString(),
                                    CMG = dr["Content Management Group (CMG)"].ToString(),
                                    DisclosureLevel = dr["Disclosure Level"].ToString(),
                                    DocumentType = dr["Document Type"].ToString(),
                                    DocumentTypeDetail = dr["Document Type Detail"].ToString(),
                                    Regions = dr["Regions"].ToString(),
                                    TopicCategories = dr["Topic Categories"].ToString(),
                                    PublicationCode = dr["Publication Code"].ToString(),
                                    ContentTopic = dr["Content Topic"].ToString(),
                                    SearchKeywords = dr["Search Keywords"].ToString(),
                                    EmbeddedLinks = dr["Embedded Links"].ToString(),
                                    PublicationDestinations = dr["Publication Destinations"].ToString(),
                                    ProductLines = dr["Product Lines"].ToString(),
                                    OriginalFilename = dr["Original Filename"].ToString(),
                                    BusinessDefinedProperties = dr["Business Defined Properties"].ToString(),
                                    Authors = dr["Authors"].ToString(),
                                    ContentVersion = dr["Content Version"].ToString(),
                                    VersionLabel = dr["Version Label"].ToString(),
                                    ProjectName = dr["Project Name"].ToString(),
                                    CollectionMasterID = dr["Collection Master ID"].ToString(),
                                    CreationDate = dr["Creation Date"].ToString(),
                                    ContentUpdateDate = dr["Content Update Date"].ToString(),

                                });

                            }

                        }
                        dc.SaveChanges();

                        //PopulateData();
                        lblMessage.Text = "Data import was successful";
                    }

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
    }
}