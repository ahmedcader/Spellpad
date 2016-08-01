using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace AssemblyRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            OperatingSystem osInfo = Environment.OSVersion;
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Wow6432Node\Spellpad"))
            {
                if (osInfo.Platform == PlatformID.Win32NT)
                {
                    switch (osInfo.Version.Major)
                    {
                        case 5:
                            switch (osInfo.Version.Minor)
                            {
                                case 0:
                                case 1:
                                case 2:
                                    string o = key.GetValue("CommandLineArgument").ToString();
                                    Registry.ClassesRoot.CreateSubKey(@"*\shell\ASpellpad\Command").SetValue("", string.Format(@"{0} ""%1""", o));
                                    Registry.ClassesRoot.OpenSubKey(@"*\shell\ASpellpad", true).SetValue("", "Edit with Spellpad");

                                    break;
                            }
                            break;

                        case 6:
                            switch (osInfo.Version.Minor)
                            {
                                case 0:
                                case 1:
                                case 2:
                                    string o = key.GetValue("COMDLLPath").ToString();
                                    Assembly asm = Assembly.LoadFile(o.ToString());
                                    RegistrationServices regAsm = new RegistrationServices();
                                    bool bResult = regAsm.RegisterAssembly(asm, AssemblyRegistrationFlags.SetCodeBase);

                                    break;
                            }
                            break;
                    }
                }
            }
        }
    }
}

