using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace univassurence2.dataAccess.models
{
  public class InitDb
  {
    public static void Begin()
    {

      DataBase.TCommercial.Add(new Commercial
      {
        CommercialId = 1,
        Name = "Lou",
        Matricule = "n20",
      });
      DataBase.TCommercial.Add(new Commercial
      {
        CommercialId = 2,
        Name = "Michele",
        Matricule = "n20",
      });

      DataBase.TPerson.Add(new Person
      {
        id = 1,
        TypePart = "cni",
        NumberTypePart = "n02",
        LastName = "John",
        FirstName = "Issac",
        Phone = "074856712",
        Sex = "M",
        MaritalStatus = "Marié",
        NumberChildren = 1,
        Employer = "Spvie"
      });
      DataBase.TPerson.Add(new Person
      {
        id = 2,
        TypePart = "cni",
        NumberTypePart = "n03",
        LastName = "Mozart",
        FirstName = "Kiang",
        Phone = "074856712",
        Sex = "M",
        MaritalStatus = "Marié",
        NumberChildren = 3,
        Employer = "Spvie"
      });
      DataBase.TPerson.Add(new Person
      {
        id = 3,
        TypePart = "Password",
        NumberTypePart = "n04",
        LastName = "MBALI",
        FirstName = "Aube",
        Phone = "074856712",
        Sex = "M",
        MaritalStatus = "Celibataire",
        NumberChildren = 0,
        Employer = "Spvie"
      });

      DataBase.TProduct.Add(new Product
      {
        ProductId = 1,
        ProductName = "Assurance vie",
        price = 1000,
        CampaignStartDate = "2023-01-20",
        CampaignEndDate = "2023-03-20",
      });
      DataBase.TProduct.Add(new Product
      {
        ProductId = 2,
        ProductName = "Assurance décès",
        price = 2000,
        CampaignStartDate = "2023-03-02",
        CampaignEndDate = "2023-04-05",
      });
      DataBase.TProduct.Add(new Product
      {
        ProductId = 3,
        ProductName = "Assurance mixte (vie et décès)",
        price = 5000,
        CampaignStartDate = "2023-03-02",
        CampaignEndDate = "2023-04-05",
      });

      DataBase.TSubscription.Add(new Subscription
      {
        SubscriptionID = 1,
        PersonID = 1,
        ProductID = 1,
        SubscriptionDate = new DateTime(2023 - 01 - 20),
        SubscriptionState = "2023-02-20",
        ComercialID = 1,
        SubscriptionTime = new DateTime(2023 - 01 - 20)
      });
      DataBase.TSubscription.Add(new Subscription
      {
        SubscriptionID = 1,
        PersonID = 2,
        ProductID = 1,
        SubscriptionDate = new DateTime(2023 - 01 - 20),
        SubscriptionState = "2023-02-20",
        ComercialID = 1,
        SubscriptionTime = new DateTime(2023 - 01 - 20)
      });
      DataBase.TSubscription.Add(new Subscription
      {
        SubscriptionID = 1,
        PersonID = 3,
        ProductID = 1,
        SubscriptionDate = new DateTime(2023 - 01 - 20),
        SubscriptionState = "2023-02-20",
        ComercialID = 1,
        SubscriptionTime = new DateTime(2023 - 01 - 20)
      });
      DataBase.TSubscription.Add(new Subscription
      {
        SubscriptionID = 1,
        PersonID = 2,
        ProductID = 2,
        SubscriptionDate = new DateTime(2023 - 01 - 20),
        SubscriptionState = "2023-02-20",
        ComercialID = 1,
        SubscriptionTime = new DateTime(2023 - 01 - 20)
      });
      DataBase.TSubscription.Add(new Subscription
      {
        SubscriptionID = 1,
        PersonID = 3,
        ProductID = 1,
        SubscriptionDate = new DateTime(2023 - 01 - 20),
        SubscriptionState = "2023-02-20",
        ComercialID = 1,
        SubscriptionTime = new DateTime(2023 - 01 - 20)
      });
    }
  }
}

