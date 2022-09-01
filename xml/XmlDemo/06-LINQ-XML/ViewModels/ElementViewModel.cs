﻿using System.Drawing;
using System.Xml.Linq;
using _06_LINQ_XML.EntityClasses;
using _06_LINQ_XML.HelperClasses;

namespace _06_LINQ_XML.ViewModels {
  /// <summary>
  /// Demos of using element-based XML documents
  /// </summary>
  public class ElementViewModel {
    public ElementViewModel() {
      XmlFileName = FileNameHelper.ProductsFile;
    }

    private readonly string XmlFileName;

    #region GetAllXDocument Method
    /// <summary>
    /// When loading an XML document using XDocument, you use Descendants() to get all product nodes
    /// </summary>
    public List<XElement> GetAllXDocument() {
      XDocument doc = XDocument.Load(XmlFileName);
      List<XElement> list = new();

      list = (from prod in doc.Descendants("Product")
          select prod).ToList();
      

      foreach (XElement prod in list) {
        Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
        Console.WriteLine($"   Product Id: {prod.GetAs<int>("ProductID")}");
      }

      Console.WriteLine();
      Console.WriteLine($"Total Products: {list.Count}");

      return list;
    }
    #endregion

    #region GetAllXElement Method
    /// <summary>
    /// When loading an XML document using XElement, you use Elements() to get all product nodes
    /// </summary>
    public List<XElement> GetAllXElement() {
      XElement elem = XElement.Load(XmlFileName);
      List<XElement> list = new();

      list = (from ele in elem.Elements("Product") select ele).ToList();



      foreach (XElement prod in list) {
        Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
        Console.WriteLine($"   Product Id: {prod.GetAs<int>("ProductID")}");
      }

      Console.WriteLine();
      Console.WriteLine($"Total Products: {list.Count}");

      return list;
    }
    #endregion

    #region WhereClause Method
    /// <summary>
    /// Write a LINQ query to get a set of orders using a where clause from the XML file
    /// </summary>
    public List<XElement> WhereClause() {
      XElement elem = XElement.Load(XmlFileName);
      List<XElement> list = new();

      // TODO: Write Query Here
      list = elem.Elements("Product").Where(x => x.GetAs<string>("Color") == "Silver").ToList();

      foreach (XElement prod in list) {
        Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
        Console.WriteLine($"   Product Id: {prod.GetAs<int>("ProductID")}");
        Console.WriteLine($"   Color: {prod.GetAs<string>("Color")}");
        Console.Write($"   Cost: {prod.GetAs<decimal>("StandardCost", 0):c}");
        Console.WriteLine($"   Price: {prod.GetAs<decimal>("ListPrice", 0):c}");
      }

      Console.WriteLine();
      Console.WriteLine($"Total Products: {list.Count}");

      return list;
    }
    #endregion

    #region GetASingleNode Method
    /// <summary>
    /// Write a LINQ query to get a single product from the XML file
    /// </summary>
    public XElement GetASingleNode() {
      XElement elem = XElement.Load(XmlFileName);
      XElement product = null;

      product = (from prod in elem.Elements("Product")
          where prod.GetAs<int>("ProductID") == 706
          select prod).SingleOrDefault();


            if (product != null) {
        Console.WriteLine($"Product Name: {product.GetAs<string>("Name")}");
        Console.WriteLine($"   Product Id: {product.GetAs<int>("ProductID")}");
        Console.WriteLine($"   Color: {product.GetAs<string>("Color")}");
        Console.Write($"   Cost: {product.GetAs<decimal>("StandardCost", 0):c}");
        Console.WriteLine($"   Price: {product.GetAs<decimal>("ListPrice", 0):c}");
      } else {
        Console.WriteLine("Product Not Found");
      }

      return product;
    }
    #endregion

    #region OrderBy Method
    /// <summary>
    /// Write a LINQ query to get all products ordering by Color, ListPrice
    /// </summary>
    public List<XElement> OrderBy() {
      XElement elem = XElement.Load(XmlFileName);
      List<XElement> list = new();

      // TODO: Write Query Here
      list = elem.Descendants().OrderBy(x => x.GetAs<string>("Color"))
          .ThenBy(x => x.GetAs<Decimal>("ListPrice")).ToList();


      foreach (XElement prod in list) {
        Console.WriteLine($"Product Name: {prod.GetAs<string>("Name")}");
        Console.WriteLine($"   Color: {prod.GetAs<string>("Color")}");
        Console.WriteLine($"   Price: {prod.GetAs<decimal>("ListPrice", 0):c}");
      }

      Console.WriteLine();
      Console.WriteLine($"Total Products: {list.Count}");

      return list;
    }
    #endregion

    #region AddToClass Method
    /// <summary>
    /// Write a LINQ query to get all elements and build a collection of Product objects
    /// </summary>
    public List<Product> AddToClass() {
      XElement elem = XElement.Load(XmlFileName);
      List<Product> list = new();

      list = (from prod in elem.Elements("Product")
          orderby prod.GetAs<string>("Name")
          select new Product
          {
              ProductID = prod.GetAs<int>("ProductID"),
              Name = prod.GetAs<string>("Name", "n/a"),
              Color = prod.GetAs<string>("Color"),
              StandardCost = prod.GetAs<decimal>("StandardCost", 0),
              ListPrice = prod.GetAs<decimal>("ListPrice", 0),
              Size = prod.GetAs<string>("SalesPerson", "n/a"),
          }).ToList();


            // Display products
            foreach (Product prod in list) {
        Console.Write(prod);
      }

      Console.WriteLine();
      Console.WriteLine($"Total Products: {list.Count}");

      return list;
    }
    #endregion

    #region Join Method
    /// <summary>
    /// Write code load two XML files to join products and orders and create a new XML document with a different shape.
    /// </summary>
    public XElement Join() {
      XElement prodElem;
      XElement detailElem;

      // Load products XML File
      prodElem = XElement.Load(XmlFileName);
      // Load Sales Order Detail XML File
      detailElem = XElement.Load(FileNameHelper.SalesOrderDetailsFile);

      // TODO: Write Query Here
      XElement newDoc = new XElement("SalesOrderWithProductInfo",
          from prod in prodElem.Elements("Product")
          join order in detailElem.Elements("SalesOrderDetail")
               on prod.GetAs<int>("ProductID") equals
      order.GetAs<int>("ProductID")
      select new XElement("Order",
          new XElement("ProductID", prod.GetAs<int>("ProductID")),
          new XElement("Name", prod.GetAs<string>("Name")),
          new XElement("Color", prod.GetAs<string>("Color")),
          new XElement("ListPrice", prod.GetAs<decimal>("ListPrice", 0)),
          new XElement("Quantity", order.GetAs<decimal>("OrderQty", 0)),
          new XElement("UnitPrice", order.GetAs<decimal>("UnitPrice", 0)),
          new XElement("Total", order.GetAs<decimal>("LineTotal", 0))
      ));

      // Display Document
      Console.WriteLine(newDoc);

      return newDoc;
    }
    #endregion

    #region GetSalesWithDetails Method
    /// <summary>
    /// Write a LINQ query to only get those sales orders that have details
    /// </summary>
    public List<XElement> GetSalesWithDetails() {
      XElement elem = XElement.Load(FileNameHelper.SalesAndDetailsFile);
      List<XElement> list = new();

      list = (from order in elem.Elements("SalesOrderHeader")
          where order.Element("SalesOrderDetails") == null
          select order).ToList();


            // Display Elements
            foreach (XElement order in list) {
        Console.WriteLine(order);
        Console.WriteLine();
      }

      Console.WriteLine();
      Console.WriteLine($"Total Items: {list.Count}");

      return list;
    }
    #endregion

    #region GetSalesLineTotalGreaterThan Method
    /// <summary>
    /// Write a LINQ query to only get those orders that have a LineTotal > $5,000
    /// </summary>
    public List<XElement> GetSalesLineTotalGreaterThan() {
      XElement elem = XElement.Load(FileNameHelper.SalesAndDetailsFile);
      List<XElement> list = new();

      list = (from order in elem.Descendants("SalesOrderDetail")
          where order.GetAs<decimal>("LineTotal", 0) > 5000
          select order).ToList();


            // Display Elements
            foreach (XElement order in list) {
        Console.WriteLine(order);
        Console.WriteLine();
      }

      Console.WriteLine();
      Console.WriteLine($"Total Items: {list.Count}");

      return list;
    }
    #endregion
  }
}
