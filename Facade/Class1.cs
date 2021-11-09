using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    public class Facade
    {
        protected InstallButton ibutton;
        protected SettingsButton sbutton;
        protected DeleteButton dbutton;

        public Facade(InstallButton ib, SettingsButton sb, DeleteButton db)
        {
            this.ibutton = ib;
            this.sbutton = sb;
            this.dbutton = db;
        }
        public string ShowOperation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this.ibutton.operation1();
            result += this.sbutton.operation1();
            result += this.dbutton.operation1();
            return result;
        }
        public string SetOperation(int n)
        {
            string result = "Facade orders subsystems to perform the action:\n";
            if (n == 1)
            {
                result += this.ibutton.operation2();
            }
            else if (n == 2)
            {
                result += this.sbutton.operation2();
            }
            else if (n == 3)
            {
                result += this.dbutton.operation2();
            }
            return result;
        }
    }
    public class InstallButton
    {
        public string operation1()
        {
            return "Button1: Install.\n";
        }

        public string operation2()
        {
            return "Button1: Installing in progress...\n";
        }
    }
    public class SettingsButton
    {
        public string operation1()
        {
            return "Button2: Settings...\n";
        }

        public string operation2()
        {
            return "Button2: Choose destination folder:\n";
        }
    }
    public class DeleteButton
    {
        public string operation1()
        {
            return "Button3: Delete.\n";
        }

        public string operation2()
        {
            return "Button3: Deleting in progress...\n";
        }
    }
    public class ClientF
    {
        public static void ShowButtons(Facade facade)
        {
            Console.Write(facade.ShowOperation());
        }
        public static void ChooseButtons(Facade facade, int n)
        {
            Console.Write(facade.SetOperation(n));
        }
    }
}
