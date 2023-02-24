using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nameProject.webApi.models
{
    public class InitDb
    {
        public static void Begin(){

            Database.TPCommercial.Add(new Commercial{
                CommercialId = 1,
                Nom = "Lou",
                Matricule = "n20",
            });
            Database.TPCommercial.Add(new Commercial{
                CommercialId = 2,
                Nom = "Michele",
                Matricule = "n20",
            });
        
            Database.TPerson.Add(new Person {
                    PersonID = 1,
                    TypePart = "cni",
                    NumberTypePart = "n02",
                    Name = "John",
                    FirstName = "Issac",
                    Phone = "074856712",
                    Sex = "M",
                    MaritalStatus = "Marié",
                    NumberChildren = 1,
                    Employer = "Spvie"
            });
            Database.TPerson.Add(new Person {
                    PersonID = 2,
                    TypePart = "cni",
                    NumberTypePart = "n03",
                    Name = "Mozart",
                    FirstName = "Kiang",
                    Phone = "074856712",
                    Sex = "M",
                    MaritalStatus = "Marié",
                    NumberChildren = 3,
                    Employer = "Spvie"
            });
            Database.TPerson.Add(new Person {
                    PersonID = 3,
                    TypePart = "Password",
                    NumberTypePart = "n04",
                    Name = "MBALI",
                    FirstName = "Aube",
                    Phone = "074856712",
                    Sex = "M",
                    MaritalStatus = "Celibataire",
                    NumberChildren = 0,
                    Employer = "Spvie"
            });

            Database.TProduct.Add(new ProductAssurence {
                ProductId = 1,
                ProductName = "Assurance vie",
                price = 1000,
                CampaignStartDate = "2023-01-20",
                CampaignEndDate = "2023-03-20",
            });
            Database.TProduct.Add(new ProductAssurence {
                ProductId = 2,
                ProductName = "Assurance décès",
                price = 2000,
                CampaignStartDate = "2023-03-02",
                CampaignEndDate = "2023-04-05",
            });
            Database.TProduct.Add(new ProductAssurence {
                ProductId = 3,
                ProductName = "Assurance mixte (vie et décès)",
                price = 5000,
                CampaignStartDate = "2023-03-02",
                CampaignEndDate = "2023-04-05",
            });
        
            Database.TSouscription.Add(new Souscription{
                SubscriptionID = 1,
                PersonID = 1,
                ProductID = 1,
                SubscriptionDate = new DateTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = 5
            });
            Database.TSouscription.Add(new Souscription{
                SubscriptionID = 1,
                PersonID = 2,
                ProductID = 1,
                SubscriptionDate = new DateTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = 2
            });
            Database.TSouscription.Add(new Souscription{
                SubscriptionID = 1,
                PersonID = 3,
                ProductID = 1,
                SubscriptionDate = new DateTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = 2
            });
            Database.TSouscription.Add(new Souscription{
                SubscriptionID = 1,
                PersonID = 2,
                ProductID = 2,
                SubscriptionDate = new DateTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = 1
            });
            Database.TSouscription.Add(new Souscription{
                SubscriptionID = 1,
                PersonID = 3,
                ProductID = 1,
                SubscriptionDate = new DateTime(),
                SubscriptionState = "2023-02-20",
                ComercialID = 1,
                SubscriptionTime = 3
            });
        }
    }
}