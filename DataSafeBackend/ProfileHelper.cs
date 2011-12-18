using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections.Generic;
using System.Windows.Controls;
using DataSafeBackend.Profile;
using DataSafeBackend.Profile.Contact;

namespace DataSafeBackend
{
    public class ProfileHelper
    {
        #region Ausortieren
        ////Ruft den ausgewählten Kontakt anhand von einer Indexnummer ab.
        //public static ContactType GetSelctedContact(int indexNumber, ProfileType Profile)
        //{
        //    ContactType contact = Profile.contacs.ElementAt(indexNumber);
        //    return contact;
        //}

        //public static string EmailListEntryCreator(EmailType email)
        //{
        //    string entry = email.name + "   " + email.emailAdress;
        //    return entry;
        //}

        //public static string PhoneListEntryCreator(PhoneType phone)
        //{
        //    string entry = phone.name + "   " + phone.phoneNummber;
        //    return entry;
        //}

        //public static List<Expander> getContactDetailList(ContactType contact)
        //{
        //    List<Expander> contactDetailsList = new List<Expander>();
        //    List<string> OperationList = new List<string>();
        //    OperationList.Add("Firstname:   " + contact.vorname);
        //    OperationList.Add("Middelname:  " + contact.name);
        //    OperationList.Add("Street:      " + contact.straße);
        //    OperationList.Add("Housenumber: " + contact.hausnummer);
        //    OperationList.Add("Postscript:  " + contact.postleitzahl); 
        //    OperationList.Add("City:        " + contact.ort);
        //    Expander DetailExpander = getExpanderFromContactInformation(OperationList);
        //    DetailExpander.Header = "Details";
        //    contactDetailsList.Add(DetailExpander);
        //    OperationList.Clear();

        //    foreach (PhoneType entry in contact.phoneList)
        //    {
        //        string listEntry = entry.name + "   " + entry.phoneNummber;
        //        OperationList.Add(listEntry);
        //    }
        //    Expander PhoneExpander = getExpanderFromContactInformation(OperationList);
        //    PhoneExpander.Header = "Phone";
        //    contactDetailsList.Add(PhoneExpander);
        //    OperationList.Clear();


        //    foreach (EmailType entry in contact.emailList)
        //    {
        //        string listEntry = entry.name + "   " + entry.emailAdress;
        //        OperationList.Add(listEntry);
        //    }

        //    Expander EmailExpander = getExpanderFromContactInformation(OperationList);
        //    EmailExpander.Header = "Email";
        //    contactDetailsList.Add(EmailExpander);

        //    return contactDetailsList;
        //}

        //private static Expander getExpanderFromContactInformation(List<string> ContactInformation)
        //{
        //    Expander Expander = new Expander();
        //    ListBox ExpanderListbox = new ListBox();
        //    foreach (string entry in ContactInformation)
        //    {
        //        ExpanderListbox.Items.Add(entry);
        //    }
        //    Expander.Content = ExpanderListbox;
        //    return Expander;
        //}

        //public static bool LoadSelectedProfile(string profileName)
        //{
        //    return true;
        //}
        #endregion

        
    }   
}


