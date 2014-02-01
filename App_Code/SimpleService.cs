using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using System.IO;
using System.Drawing;
using System.Globalization;
using MongoDB.Bson.Serialization.IdGenerators;
using System.ComponentModel;
/// <summary>
/// Summary description for SimpleService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SimpleService : System.Web.Services.WebService
{
    MongoDatabase a1;
   

    
    public SimpleService()
   {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
        a1 = new MongoClient("mongodb://as:df@localhost:27017").GetServer().GetDatabase("admin");
        
    }
  
    [WebMethod]
    public string GetArrayStream()
    {
        List<product> ab = a1.GetCollection<product>("admin").FindAll().SetFields(Fields.Include("SuaveID")).ToList();
        string[] availableTags = ab.Select(product => product.SuaveID).ToArray();
        List<product> ab1 = a1.GetCollection<product>("admin").FindAll().SetFields(Fields.Include("Project")).ToList();
        string[] availableTags1 = ab1.Select(product => product.Project).ToArray();

        string returnStr = "";
        for (int index = 0; index < availableTags.Length; index++)
            returnStr += "@" + availableTags[index] + (index == availableTags.Length - 1 ? "" : "','");
        string returnStr1 = "";
        for (int index = 0; index < availableTags1.Length; index++)
            returnStr1 += "&" + availableTags1[index] + (index == availableTags1.Length - 1 ? "" : "','");
        string s = returnStr + "','" + returnStr1;
        return s;

    }
    class product
    {
        public ObjectId Id { get; set; }
        public string textdata { get; set; }
        public string SuaveID { get; set; }
        public string FirstName { get; set; }
        public string Project { get; set; }
    }
}