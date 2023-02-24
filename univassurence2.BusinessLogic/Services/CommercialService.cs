using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using univassurence2.dataAccess.models;

namespace univassurence2.BusinessLogic.Services
{
  public class CommercialService
  {

    public CommercialService()
    {

    }

    public List<Commercial> GetCommercials()
    {
      return DataBase.TCommercial;
    }

    public Commercial? GetCommercialsById(int id)
    {
      Commercial? commercial = (from com in DataBase.TCommercial where id == com.CommercialId select com).FirstOrDefault();
      return commercial;
    }

    public Commercial? CreateCommercial(Commercial commercial)
    {
      DataBase.TCommercial.Add(commercial);
      return commercial;
    }

    public void UpdateCommercial(Commercial commercial)
    {
      Console.WriteLine("Update");
    }

    public static string DeleteProduct(int id)
    {
      var index = DataBase.TProduct.FindIndex(pro => pro.ProductId == id);
      if (index > 0)
      {
        DataBase.TProduct.RemoveAt(index);
        return "Success";
      }
      else
      {
        return "Error";
      }
    }

  }
}