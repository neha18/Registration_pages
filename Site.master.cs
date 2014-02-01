using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
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
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;
using System.Globalization;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel;

public partial class SiteMaster : MasterPage
{
    private const string AntiXsrfTokenKey = "__AntiXsrfToken";
    private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
    private string _antiXsrfTokenValue;
    MongoDatabase a1;

    protected void Page_Init(object sender, EventArgs e)
    {
        // The code below helps to protect against XSRF attacks
        var requestCookie = Request.Cookies[AntiXsrfTokenKey];
        Guid requestCookieGuidValue;
        if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
        {
            // Use the Anti-XSRF token from the cookie
            _antiXsrfTokenValue = requestCookie.Value;
            Page.ViewStateUserKey = _antiXsrfTokenValue;
        }
        else
        {
            // Generate a new Anti-XSRF token and save to the cookie
            _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
            Page.ViewStateUserKey = _antiXsrfTokenValue;

            var responseCookie = new HttpCookie(AntiXsrfTokenKey)
            {
                HttpOnly = true,
                Value = _antiXsrfTokenValue
            };
            if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
            {
                responseCookie.Secure = true;
            }
            Response.Cookies.Set(responseCookie);
        }

        Page.PreLoad += master_Page_PreLoad;
    }

    void master_Page_PreLoad(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // Set Anti-XSRF token
            ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
            ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
        }
        else
        {
            // Validate the Anti-XSRF token
            if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
            {
                throw new InvalidOperationException("Validation of Anti-XSRF token failed.");
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        a1 = new MongoClient("mongodb://as:df@localhost:27017").GetServer().GetDatabase("admin");
        string empid = (string)(Session["SuaveID"]);
       
        var qu = Query.EQ("SuaveID", empid);
     

        List<image> images = a1.GetCollection<image>("ProfilePic3").Find(qu).ToList();
            //a1.GetCollection<image>("ProfilePic1").FindAll().ToList(); 
        
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

        List<product> info = a1.GetCollection<product>("admin").Find(qu).ToList();
        foreach (var userinfo in info)
        {
            LblFLName.Text = userinfo.FirstName+' '+ userinfo.LastName;
            LblSuaveid.Text = userinfo.SuaveID;
            LblEmailId.Text = userinfo.Emailid;
            TxtAbout.Text = userinfo.About;
            LblUni.Text = userinfo.University;
            LblCourse.Text = userinfo.Course;
            LblYear.Text = userinfo.Year;
            LblCity.Text = userinfo.Location;

        }
    }
    public class image
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string SuaveID { get; set; }
        [BsonIgnore]
        public byte[] Data { get; set; }

        // Gets or sets the image unique identifier. Reference to the photo file which is saved in GridFS collections
        public ObjectId ImageId { get; set; }
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

        // public BsonBinaryData id { get; set; }
        // public string Data { get; set; }

    }
}