using Microsoft.Win32;
using System;
using System.Linq;
using System.Reflection;

namespace SecretFiles.Crypt.X509
{
    public enum ReistryHKEY
    {
        HKEY_CURRENTUSER,
        HKEY_LOCALMASHINE
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class WinReesterAttribute : System.Attribute
    {
        public ReistryHKEY HKEY { get; }
        public string KeyRoot { get; }

        public WinReesterAttribute(ReistryHKEY hkey, string keyroot)
        {
            HKEY = hkey;
            KeyRoot = keyroot;
        }

        public RegistryKey RegistryHKEY {
            get
            {
                switch (HKEY)
                {
                    case ReistryHKEY.HKEY_CURRENTUSER:
                        return Registry.CurrentUser;
                    case ReistryHKEY.HKEY_LOCALMASHINE:
                        return Registry.LocalMachine;
                    default:
                        throw new Exception("Unknown data");
                }
            }
        }
    }
    [AttributeUsage(AttributeTargets.Property)]
    public class WinReestrFieldAttribute : Attribute
    {        
    }

    public static class WinReestr
    {
        public static void Save(object obj)
        {
            var ReestrAttr = obj.GetType().GetCustomAttribute<WinReesterAttribute>(true);
            if (ReestrAttr != null)
            {
                RegistryKey Key = ReestrAttr.RegistryHKEY.CreateSubKey(ReestrAttr.KeyRoot);
                if (Key != null)
                {
                    foreach (var regvalue in obj.GetType().GetProperties().Where(x => x.GetCustomAttribute<WinReestrFieldAttribute>() != null))
                    {
                        var val = regvalue.GetValue(obj);
                        if (val is Enum)
                        {
                            Key.SetValue(regvalue.Name, val.ToString());
                        }
                        else if (val is DateTime)
                        {
                            Key.SetValue(regvalue.Name, ((DateTime)val).ToString("dd.MM.yyyy"));
                        }
                        else
                        {
                            Key.SetValue(regvalue.Name, val);
                        }
                    }
                }
            }
        }

        public static void Load(object obj)
        {
            var ReestrAttr = obj.GetType().GetCustomAttribute<WinReesterAttribute>(true);
            if (ReestrAttr != null)
            {
                RegistryKey Key = ReestrAttr.RegistryHKEY.OpenSubKey(ReestrAttr.KeyRoot);
                if (Key != null)
                {
                    foreach (var regvalue in obj.GetType().GetProperties().Where(x => x.GetCustomAttribute<WinReestrFieldAttribute>() != null))
                    {
                        var val = Key.GetValue(regvalue.Name);
                        if (val != null)
                        {
                            if (regvalue.PropertyType == typeof(bool))
                            {
                                bool res;
                                if (bool.TryParse(val.ToString(), out res))
                                {
                                    regvalue.SetValue(obj, res);
                                }
                            }
                            else if (regvalue.PropertyType.IsEnum)
                            {
                                var res = Enum.Parse(regvalue.PropertyType, val.ToString());
                                regvalue.SetValue(obj, res);
                            }
                            else if (regvalue.PropertyType == typeof(DateTime))
                            {
                                try
                                {
                                    var res = DateTime.Parse((string)val);
                                    regvalue.SetValue(obj, res);
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else
                            {
                                regvalue.SetValue(obj, val);
                            }
                        }
                    }
                }
            }
        }
    }
}
