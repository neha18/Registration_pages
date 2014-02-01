using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MongoDB.Bson;
using MongoDB.Driver;
using System.IO;
using System.Collections;
using MongoDB.Driver.GridFS;
using System.Text;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using ASPTokenInputLib;
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;
using System.Globalization;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel;


public partial class Regis1 : System.Web.UI.Page
{
    bool p = true;
    bool p2 = true;
    MongoDatabase a1;
    string eco="";
    string[] namesplit;
    string[] listid;
    string s1;
    string proid;

    protected void Page_Load(object sender, EventArgs e)
    {
        //connection with mongodb
        a1 = new MongoClient("mongodb://as:df@103.249.237.124:80").GetServer().GetDatabase("admin");
      //client side(javascript) validation for password textbox
         txtRePwd.Attributes.Add("onchange", "myFunction(this)");
       
    }
    //button to get code aftr enter email id
    protected void BtnGetcode_Click(object sender, EventArgs e)
    {

    }
    //first next button
    protected void BtnNext_Click(object sender, EventArgs e)
    {
        if (TxtEmailcode.Text == "")
        {
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert('Please insert code from your email');", true);
        }
        else
        {
            Panel2.Attributes.Add("style", "display:block");
            Panel1.Attributes.Add("style", "display:none");
            Panel3.Attributes.Add("style", "display:none");
         
        }
    }
    //second next button
    protected void BtnNext2_Click(object sender, EventArgs e)
    {
        //fetching all data from database
      List<product> ab = a1.GetCollection<product>("admin").FindAll().ToList();
        //here we are checking that current suaveid is exist in database or not,because it should be unique
       if (ab.Exists(x => x.SuaveID == TxtSuaveid.Text))
      {
          ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert('SuaveID already exist');", true);
      }
      else
      {
          Panel2.Attributes.Add("style", "display:none");
          Panel1.Attributes.Add("style", "display:none");
          Panel3.Attributes.Add("style", "display:block");
           //here we setting values on profile box panel
          LblFLName.Text = TxtFirstname.Text + ' ' + Txtlastname.Text;
          LblSuaveid.Text = Label2.Text + TxtSuaveid.Text;
          LblEmailId.Text = TxtEmailid.Text;
          LblUni.Text = TxtUniversity.Text;
          LblCourse.Text = TxtCourse.Text;
          LblYear.Text = DdlYear.SelectedValue;
          LblCity.Text = TxtLocation.Text;
      }
    }
    class product
    {
        public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string University { get; set; }
        public string Course { get; set; }
        public string Year { get; set; }
        public string Location { get; set; }
        public string SuaveID { get; set; }
        public string About { get; set; }
        public string FollowPpl { get; set; }
        public string Project { get; set; }
        public string Emailid { get; set; }

  }
    class project
    {
          public ObjectId Id { get; set; }
           public string Project { get; set; }
           public string ProjectId { get; set; }
           public string SuaveID { get; set; }
    }
    public class image
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string SuaveID { get; set; }
        [BsonIgnore]
        public byte[] Data { get; set; }

        /// Gets or sets the image unique identifier. Reference to the photo file which is saved in GridFS collections
        public ObjectId ImageId { get; set; }
    }
    //First name textbox
    protected void TxtFirstname_TextChanged(object sender, EventArgs e)
    {
        if (TxtFirstname.Text != "")
        {
            //after entering firstname it should become suaveid of current user,then user can add more alphanumeric value after firstname
             Label2.Text = TxtFirstname.Text;

        }
        else
        {
            TxtSuaveid.Text = "";
        }
    }
    //done button to insert values in database
    protected void Btndone_Click(object sender, EventArgs e)
    {
        //here we are getting follow people values(asptokeninput) from ItemList.aspx page,it can be multiple so we are entering multiple values by '/'
        for (int i = 0; i <= lbList2.Items.Count - 1; i++)
        {
            listid = lbList2.Items[i].Value.Split('-');
            string name = listid[0];
            eco += listid[0] + "/";
        }
        if (eco != "")
        {
            eco = eco.Remove(eco.Length - 1);
        }
         namesplit = LblFLName.Text.Split(' ');
            if (p)
            {
                var pp = new product
                  {
                      
                      FirstName = namesplit[0],
                      LastName=namesplit[1],
                      Password = Hiddpass.Value,
                      University = LblUni.Text,
                      Course = LblCourse.Text,
                      Year = LblYear.Text,
                      Location = LblCity.Text,
                      SuaveID =  Label2.Text + TxtSuaveid.Text,
                      About = TxtAbout.Text,
                      FollowPpl = eco,
                      Project = TxtCreateproj.Text,
                     Emailid=TxtEmailid.Text
                  };
                //inserting user details in table admin
                var hh = a1.GetCollection<product>("admin");
                hh.Insert(pp);
                //here we are creating projectid,it is a combination of suaveid+first 3 letters of project name
                proid = TxtCreateproj.Text.Substring(0,3);
                  var pp2 = new project
                  {
                       Project = TxtCreateproj.Text,
                       ProjectId=Label2.Text + TxtSuaveid.Text+proid,
                       SuaveID = Label2.Text + TxtSuaveid.Text
                  };
                //inserting project details in table ProjectDet
                var hh2 = a1.GetCollection<project>("ProjectDet");
                hh2.Insert(pp2);
               
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert('Inserted ');", true);
                //here we move forward for dash board page by passing suaveid as a parameter
                string su=Label2.Text + TxtSuaveid.Text;
                Session["SuaveID"] = su;
                Response.Redirect("Default.aspx");

                TxtFirstname.Text = "";
                Txtlastname.Text = "";
                txtPwd.Text = "";
                txtRePwd.Text = "";
                TxtUniversity.Text = "";
                TxtCourse.Text = "";
                DdlYear.Items.Clear();
                TxtLocation.Text = "";
                TxtSuaveid.Text = "";
                TxtAbout.Text = "";
                tiTest2.Items.Clear();
                TxtCreateproj.Text = "";
               
        }
    }
    //asptokeninput list
    protected void tiTest2_ListChanged(object sender, ASPTokenInput.ListChangedEventArgs e)
    {
        if (e.Action == ASPTokenInput.ListChangeActions.Add)
            lbList2.Items.Add(e.Item.name);
        else
        {
            for (int n = lbList2.Items.Count - 1; n >= 0; --n)
            {
                string removelistitem = e.Item.name;
                if (lbList2.Items[n].ToString().Contains(removelistitem))
                {
                    lbList2.Items.RemoveAt(n);
                }
            }
        }
    }
    //button to upload profile pic
    protected void BtnProfileimg_Click(object sender, EventArgs e)
    {
       if (FileUpload1.HasFile)
        {
            var fileName = Path.GetFileName(FileUpload1.FileName);
            var contentLength = FileUpload1.PostedFile.ContentLength;
            var contentType = FileUpload1.PostedFile.ContentType;
            //length limitation 1 mb
            if (contentLength < 1048576)
            {
                // Get file data
                byte[] data = new byte[] { };
                using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    data = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                }
               image img = new image()
                {
                    Name = TxtFirstname.Text,
                    SuaveID = Label2.Text+ TxtSuaveid.Text,
                    Data = data//new byte[fileSize]
                };
                //table ProfilePic3 to send image details
                MongoCollection collection = a1.GetCollection("ProfilePic3");
                Stream memoryStream = new MemoryStream(img.Data);
                MongoGridFSFileInfo gfsi = a1.GridFS.Upload(memoryStream, img.Name);
                BsonDocument photoMetadata = new BsonDocument
                                         { { "FileName", fileName},
                                         { "Type", contentType},
                                         { "Width", 35 },
                                         { "Height", 45 }};
                a1.GridFS.SetMetadata(gfsi, photoMetadata);
                img.ImageId = gfsi.Id.AsObjectId;
                //inserting details
                collection.Insert(img);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "Alert", "alert('File size should not be more than 1 MB');", true);
            }
        }
       //here we are retrieving image and display it as a profile picture
       string Suave= Label2.Text+ TxtSuaveid.Text;
       var qu = Query.EQ("SuaveID", Suave);
       List<image> images = a1.GetCollection<image>("ProfilePic3").Find(qu).ToList();
       
        foreach (var pic in images)
        {
            ObjectId id = new ObjectId(pic.ImageId.ToString());
            MongoGridFSFileInfo file = a1.GridFS.FindOne(Query.EQ("_id", id));
            using (var stream = file.OpenRead())
            {
                var bytes = new byte[stream.Length];
                stream.Read(bytes, 0, (int)stream.Length);
                pic.Data = bytes;
                string imgString = Convert.ToBase64String(pic.Data);
                //Set the source with data:image/bmp
                ProfileImg.Src = String.Format("data:image/Bmp;base64,{0}\"", imgString);
               
              
            }
        }
    }
  
}
