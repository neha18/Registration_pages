﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
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
public partial class _Default : Page
{
    MongoDatabase a1;
    protected void Page_Load(object sender, EventArgs e)
    {

        a1 = new MongoClient("mongodb://as:df@103.249.237.124:80").GetServer().GetDatabase("admin");
   
        // fun();
         
        //string s = "[ " +
        //           "['<div><input type=" + "text" + " id=" + "pass" + " value=" + "Hello" + " /></div>', 2, 2], " +
        //           "['<li></li>', 2, 2], " +
        //           "['<li>2</li>', 2, 2], " +
        //           "['<li>3</li>', 2, 2]," +
        //           "['<li>4</li>', 2, 2]," +
        //           "['<li>5</li>', 2, 2]," +
        //           "['<li>6</li>', 2, 2]," +
        //           "['<li>7</li>', 2, 2]," +
        //           "['<li>8</li>', 2, 2]," +
        //           "['<li>9</li>', 2, 2]," +
        //            "   ['<li>10</li>', 2, 2]," +
        //           "['<li>11</li>', 2, 2]," +
        //           "['<li>12</li>', 4, 2]," +
        //           "['<li>13</li>', 5, 2]," +

        //           "['<li>17</li>', 1, 9] ]";
        //ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myfunction", "cre(" + s + ");", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    public void fun()
    {
        // var qu = Query.EQ("FirstName", "Ankita");
        string s = "[";
        List<product> ab = a1.GetCollection<product>("admin").FindAll().SetFields(Fields.Include("SuaveID")).ToList();

        List<string> firstNames = ab.Select(product => product.SuaveID).ToList();
        foreach (string fn in firstNames)
        {
            s = s + " ['<div>" + fn + "</div>', 1, 2],";
        }
        s = s + "['<div><img src=" + "madushaonline.files.wordpress.com/2013/10/mongodb-logo.jpg" + " /></div>',5,3],";
        s = s + "]";
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "myfunction", "cre(" + s + ");", true);



         // GridView1.DataSource = ab;
        //GridView1.DataBind();

    }
    class product
    {
        public ObjectId Id { get; set; }
        public string textdata { get; set; }
        public string SuaveID { get; set; }

    }
    public class Book
    {
        /// Gets or sets the unique identifier generated by the dbms.
        [BsonId(IdGenerator = typeof(CombGuidGenerator))]
        public Guid id { get; set; }

        /// Gets or sets the name of the book.
        public string Name { get; set; }

        /// Gets or sets the content of the book.
        public string Content { get; set; }

        /// Gets or sets the data. Cover photo of the book represented as a byte array.
        /// Added the BsonIgnore annotation so that field will not be added to the collection when serialization
        [BsonIgnore]
        public byte[] Data { get; set; }

        /// Gets or sets the image unique identifier. Reference to the photo file which is saved in GridFS collections
        public ObjectId ImageId { get; set; }
    }
  
}