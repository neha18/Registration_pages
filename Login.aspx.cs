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
using MongoDB.Bson.Serialization.Attributes;
using System.Drawing;
using System.Globalization;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel;

public partial class Login : System.Web.UI.Page
{
    MongoDatabase a1;
    string s;

    protected void Page_Load(object sender, EventArgs e)
    {
        a1 = new MongoClient("mongodb://as:df@103.249.237.124:80").GetServer().GetDatabase("admin");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        var qu = Query.EQ("Emailid", Txtemailid.Text);
       // List<product> images = a1.GetCollection<product>("admin").Find(qu).ToList();
      var users2 = a1.GetCollection<product>("admin").Distinct("SuaveID", qu).ToList();

      foreach (string ab in users2)
      {
          s = ab;
      }
       Session["SuaveID"] = s; 
        Response.Redirect("Default.aspx");
      //  var users = a1.GetCollection<product>("admin").Find(qu).SetFields(Fields.Include("SuaveID"));
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
}