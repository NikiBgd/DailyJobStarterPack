using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.Services.Clients;
using DailyJobStarterPack.DataBaseObjects;

namespace DataBaseCommunication.Helpers
{
    public class ClientsHelper
    {
        public static List<ClientProfile> ApplyClientsSearchCriteria(ClientsSearchCriteria criteria, List<ClientProfile> list)
        {
            if(!string.IsNullOrEmpty(criteria.Name))
            {
                var searchTerm = criteria.Name.ToLower();
                list = list.Where(x => x.Name.ToLower().Contains(searchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.Address))
            {
                var searchTerm = criteria.Address.ToLower();
                list = list.Where(x => x.Address.ToLower().Contains(searchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.Place))
            {
                var searchTerm = criteria.Place.ToLower();
                list = list.Where(x => x.Place.ToLower().Contains(searchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.Municipality))
            {
                var searchTerm = criteria.Municipality.ToLower();
                list = list.Where(x => x.Municipality.ToLower().Contains(searchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.PIB))
            {
                var searchTerm = criteria.PIB.ToLower();
                list = list.Where(x => x.PIB.ToLower().Contains(searchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.LegalID))
            {
                var searchTerm = criteria.LegalID.ToLower();
                list = list.Where(x => x.LegalID.ToLower().Contains(searchTerm)).ToList();
            }

            if (criteria.CreationDate != null && criteria.CreationDate != DateTime.MinValue)
            {
                switch (criteria.CreationDateCompariosonMode)
                {
                    case ">":
                        list = list.Where(x => x.CreationDate.Date > criteria.CreationDate.Date).ToList();
                        break;
                    case ">=":
                        list = list.Where(x => x.CreationDate.Date >= criteria.CreationDate.Date).ToList();
                        break;
                    case "<":
                        list = list.Where(x => x.CreationDate.Date < criteria.CreationDate.Date).ToList();
                        break;
                    case "<=":
                        list = list.Where(x => x.CreationDate.Date <= criteria.CreationDate.Date).ToList();
                        break;
                    case "=":
                        list = list.Where(x => x.CreationDate.Date == criteria.CreationDate.Date).ToList();
                        break;
                }
            }

            if (!string.IsNullOrEmpty(criteria.Activity))
            {
                var searchTerm = criteria.Activity.ToLower();
                list = list.Where(x => x.Activity.ToLower().Contains(searchTerm)).ToList();
            }

            if (!string.IsNullOrEmpty(criteria.ActivityCode))
            {
                var searchTerm = criteria.ActivityCode.ToLower();
                list = list.Where(x => x.ActivityCode.ToLower().Contains(searchTerm)).ToList();
            }

            return list;
        }

        internal static List<Change> GetAllChanges(ClientProfile newClient, ClientProfile oldClient)
        {
            var changes = new List<Change>();
            if(newClient.Name != oldClient.Name)
            {
                changes.Add(new Change
                {
                    FieldName = "Naziv",
                    NewValue = newClient.Name,
                    OldValue = oldClient.Name
                });
            }

            if (newClient.Address != oldClient.Address)
            {
                changes.Add(new Change
                {
                    FieldName = "Adresa",
                    NewValue = newClient.Address,
                    OldValue = oldClient.Address
                });
            }

            if (newClient.Place != oldClient.Place)
            {
                changes.Add(new Change
                {
                    FieldName = "Mesto",
                    NewValue = newClient.Place,
                    OldValue = oldClient.Place
                });
            }

            if (newClient.Municipality != oldClient.Municipality)
            {
                changes.Add(new Change
                {
                    FieldName = "Opstina",
                    NewValue = newClient.Municipality,
                    OldValue = oldClient.Municipality
                });
            }

            if (newClient.PIB != oldClient.PIB)
            {
                changes.Add(new Change
                {
                    FieldName = "PIB",
                    NewValue = newClient.PIB,
                    OldValue = oldClient.PIB
                });
            }

            if (newClient.LegalID != oldClient.LegalID)
            {
                changes.Add(new Change
                {
                    FieldName = "Maticni broj",
                    NewValue = newClient.LegalID,
                    OldValue = oldClient.LegalID
                });
            }

            if (newClient.CreationDate != oldClient.CreationDate)
            {
                changes.Add(new Change
                {
                    FieldName = "Datum osnivanja",
                    NewValue = newClient.CreationDate.ToString(),
                    OldValue = oldClient.CreationDate.ToString()
                });
            }

            if (newClient.Form != oldClient.Form)
            {
                changes.Add(new Change
                {
                    FieldName = "Oblik",
                    NewValue = newClient.Form,
                    OldValue = oldClient.Form
                });
            }

            if (newClient.FormSubType != oldClient.FormSubType)
            {
                changes.Add(new Change
                {
                    FieldName = "Podoblik",
                    NewValue = newClient.FormSubType,
                    OldValue = oldClient.FormSubType
                });
            }

            if (newClient.Activity != oldClient.Activity)
            {
                changes.Add(new Change
                {
                    FieldName = "Delatnost",
                    NewValue = newClient.Activity,
                    OldValue = oldClient.Activity
                });
            }

            if (newClient.ActivityCode != oldClient.ActivityCode)
            {
                changes.Add(new Change
                {
                    FieldName = "Sifra delatnosti",
                    NewValue = newClient.ActivityCode,
                    OldValue = oldClient.ActivityCode
                });
            }


            if (newClient.ResponsiblePerson != oldClient.ResponsiblePerson)
            {
                changes.Add(new Change
                {
                    FieldName = "Odgovorno lice",
                    NewValue = newClient.ResponsiblePerson,
                    OldValue = oldClient.ResponsiblePerson
                });
            }

            if (newClient.ResponsiblePersonBirthDate != oldClient.ResponsiblePersonBirthDate)
            {
                changes.Add(new Change
                {
                    FieldName = "Odgovorno lice - rodjendan",
                    NewValue = newClient.ResponsiblePersonBirthDate.ToString(),
                    OldValue = oldClient.ResponsiblePersonBirthDate.ToString()
                });
            }

            if(newClient.ResponsiblePersonMail != oldClient.ResponsiblePersonMail)
            {
                changes.Add(new Change
                {
                    FieldName = "Odgovorno lice - mail",
                    NewValue = newClient.ResponsiblePersonMail,
                    OldValue = oldClient.ResponsiblePersonMail
                });
            }

            if (newClient.AdditionalMails != oldClient.AdditionalMails)
            {
                changes.Add(new Change
                {
                    FieldName = "Odgovorno lice - dodatni mailovi",
                    NewValue = newClient.AdditionalMails,
                    OldValue = oldClient.AdditionalMails
                });
            }

            if (newClient.ResponsiblePersonPhone != oldClient.ResponsiblePersonPhone)
            {
                changes.Add(new Change
                {
                    FieldName = "Odgovorno lice - telefon",
                    NewValue = newClient.ResponsiblePersonPhone,
                    OldValue = oldClient.ResponsiblePersonPhone
                });
            }

            if (newClient.PDV != oldClient.PDV)
            {
                changes.Add(new Change
                {
                    FieldName = "PDV",
                    NewValue = newClient.PDV,
                    OldValue = oldClient.PDV
                });
            }

            if (newClient.BookKeepingType != oldClient.BookKeepingType)
            {
                changes.Add(new Change
                {
                    FieldName = "Tip kjigovodstva",
                    NewValue = newClient.BookKeepingType,
                    OldValue = oldClient.BookKeepingType
                });
            }

            if (newClient.Director != oldClient.Director)
            {
                changes.Add(new Change
                {
                    FieldName = "Direktor",
                    NewValue = newClient.Director,
                    OldValue = oldClient.Director
                });
            }

            if (newClient.EmployeesNumber != oldClient.EmployeesNumber)
            {
                changes.Add(new Change
                {
                    FieldName = "BrojZapolsenih",
                    NewValue = newClient.EmployeesNumber.ToString(),
                    OldValue = oldClient.EmployeesNumber.ToString()
                });
            }

            if (newClient.Account != oldClient.Account)
            {
                changes.Add(new Change
                {
                    FieldName = "Racuni",
                    NewValue = newClient.Account,
                    OldValue = oldClient.Account
                });
            }

            if (newClient.StartDate != oldClient.StartDate)
            {
                changes.Add(new Change
                {
                    FieldName = "Datum saradnje",
                    NewValue = newClient.StartDate.ToString(),
                    OldValue = oldClient.StartDate.ToString()
                });
            }

            if (newClient.MainUserId != oldClient.MainUserId)
            {
                changes.Add(new Change
                {
                    FieldName = "Knjigovodja",
                    NewValue =  newClient.MainUserId.ToString(),
                    OldValue = oldClient.MainUserId.ToString()
                });
            }

            if (newClient.SecondUserId != oldClient.SecondUserId)
            {
                changes.Add(new Change
                {
                    FieldName = "Obracunski radnik",
                    NewValue = newClient.SecondUserId.ToString(),
                    OldValue = oldClient.SecondUserId.ToString()
                });
            }

            if (newClient.Amount != oldClient.Amount)
            {
                changes.Add(new Change
                {
                    FieldName = "Iznos",
                    NewValue = newClient.Amount.ToString(),
                    OldValue = oldClient.Amount.ToString()
                });
            }

            if (newClient.AmountCode != oldClient.AmountCode)
            {
                changes.Add(new Change
                {
                    FieldName = "Valuta",
                    NewValue = newClient.AmountCode,
                    OldValue = oldClient.AmountCode
                });
            }

            if (newClient.Slava != oldClient.Slava)
            {
                changes.Add(new Change
                {
                    FieldName = "Slava",
                    NewValue = newClient.Slava,
                    OldValue = oldClient.Slava
                });
            }

            if (newClient.DeliveryMethod != oldClient.DeliveryMethod)
            {
                changes.Add(new Change
                {
                    FieldName = "Dostava",
                    NewValue = newClient.DeliveryMethod,
                    OldValue = oldClient.DeliveryMethod
                });
            }

            if (newClient.BirthDate != oldClient.BirthDate)
            {
                changes.Add(new Change
                {
                    FieldName = "Rodjendan",
                    NewValue = newClient.BirthDate.ToString(),
                    OldValue = oldClient.BirthDate.ToString()
                });
            }

            return changes;
        }
    }
}
