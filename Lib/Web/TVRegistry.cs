using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace TruongViet.Lib.Web
{
    public class TVRegistry : LibBase
    {
        public static void RegSetValue(string subKeyName, string subKeyValue)
        {
            const string userRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE";
            const string subkey = "TRUONGVIET";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, "", RegistryValueKind.String);
            Registry.SetValue(keyName, subKeyName, subKeyValue);
        }

        public static string RegGetValue(string subKeyName)
        {
            const string userRoot = "HKEY_LOCAL_MACHINE\\SOFTWARE";
            const string subkey = "TRUONGVIET";
            const string keyName = userRoot + "\\" + subkey;

            string subKeyValue = (string)Registry.GetValue(keyName, subKeyName, "");
            return subKeyValue;
        }
    }
}
