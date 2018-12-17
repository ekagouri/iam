using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;

public class adConnector
{
    public static DirectoryEntry Get_AD_Entry()
    {
        using (DirectoryEntry de = new DirectoryEntry())
        {            
            de.Path = ConfigurationManager.AppSettings["LDAP"];
            de.AuthenticationType = AuthenticationTypes.Secure;
            de.Username = @"global\USRL-AutoRABIT-ADMIN";
            de.Password = "Auto123!";
            return de;
        }
    }

    public static DirectoryEntry Get_MGR_Entry()
    {
        using (DirectoryEntry adm = new DirectoryEntry())
        {
            adm.Path = ConfigurationManager.AppSettings["LDAP"];
            adm.AuthenticationType = AuthenticationTypes.Secure;
            adm.Username = @"global\USRL-AutoRABIT-ADMIN";
            adm.Password = "Auto123!";
            return adm;
        }
    }

    public static DirectoryEntry Get_LDS_Entry()
    {
        using (DirectoryEntry adlds = new DirectoryEntry())
        {
            adlds.Path = ConfigurationManager.AppSettings["ADLDS"];
            adlds.AuthenticationType = AuthenticationTypes.Secure;
            adlds.Username = @"CN=GLBL-IDMBind,OU=Service Accounts,DC=corpprod,DC=baxter,DC=com";
            adlds.Password = "W@M1dM4BAX";
            return adlds;
        }
    }
    public adConnector()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}