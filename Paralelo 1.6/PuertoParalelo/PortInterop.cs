using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace PuertoParalelo
{
    class PortInterop
    {
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void Output(int address, int value);
        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int Input(int adress);
    }
}
