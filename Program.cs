using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MasterMech
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
            
            LoginForm lObjLoginForm = new LoginForm();
            do
            {
                lObjLoginForm.ShowDialog();

                if (lObjLoginForm.mnStatus != 0)
                {
                    lObjLoginForm.mbOKButtonClicked = false;
                    MasterMechLib.MasterMechUtil.sUserID = lObjLoginForm.msUserID;
                    MasterMechLib.MasterMechUtil.sUserType = lObjLoginForm.msUserType;
                    MasterMechLib.MasterMechUtil.sFY = lObjLoginForm.msFY;
                    MainForm lObjMainForm = new MainForm(MasterMechLib.MasterMechUtil.sUserID, MasterMechLib.MasterMechUtil.sUserType);
                    Application.Run(lObjMainForm);

                    //to Exit and stop when basic settings have changed
                    if (lObjMainForm.ExitApp)
                    {
                        lObjLoginForm.mnStatus = 0;
                    }

                }
            }
            while (lObjLoginForm.mnStatus != 0);
        }
    }
}
