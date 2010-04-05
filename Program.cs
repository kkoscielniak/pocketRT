using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace pocketRT
{
    static class Program
    {
        [MTAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}