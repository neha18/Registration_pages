using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;

public partial class ItemList : System.Web.UI.Page
{
    string type1 , list,qry;
    string [] type;
    string connStr;
    MongoDatabase a1;

    public string GetFollowPpl(string filter)
    {
       
        ArrayList myAL = new ArrayList();
        var connectionString = "mongodb://as:df@103.249.237.124:80";
        var server = MongoServer.Create(connectionString);
        var db = server.GetDatabase("admin");
        db.GetCollection("admin");

        var collection = db.GetCollection("admin");

        List<product> ab = a1.GetCollection<product>("admin").FindAll().SetFields(Fields.Include("SuaveID","FirstName")).ToList();

        List<string> firstNames = ab.Select(product => product.SuaveID+'('+ product.FirstName + ')').ToList();
     
      var query =
            from c in
                firstNames.Select((item, index) => new { id = index, name = item })
                .Where(p => p.name.IndexOf(filter, StringComparison.InvariantCultureIgnoreCase) == 0)
            select new { id = Convert.ToString(c.id), name = c.name };
        return new JavaScriptSerializer().Serialize(query);
    }
    class product
    {
       public ObjectId Id { get; set; }
        public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Password { get; set; }
        //public string University { get; set; }
        //public string Course { get; set; }
        //public string Year { get; set; }
        //public string Location { get; set; }
       public string SuaveID { get; set; }
        //public string About { get; set; }
        //public string FollowPpl { get; set; }
        //public string Project { get; set; }

        // public string DocName { get; set; }
        //  public ObjectId DocId { get; set; }

    }
    protected void Page_Load(object sender, EventArgs e)
    {
         a1 = new MongoClient("mongodb://as:df@localhost:27017").GetServer().GetDatabase("admin"); 
        type1 = Request.QueryString["type"];
        type = type1.Split('|');
        string filter = this.Request.QueryString["q"];
        if (String.IsNullOrEmpty(filter))
            this.Response.Redirect("Regis1.aspx");
       
        if (type[0] == "FollowPpl")
        {
            list = this.GetFollowPpl(filter);            
        }
      
      
         Response.Clear();
        Response.ContentType = "text/plain";
        Response.Write(list);
        Response.End();

    }
   
}
