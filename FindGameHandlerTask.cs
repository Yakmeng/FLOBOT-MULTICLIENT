using FloBot.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FloBot.MemoryClass;
using FloBot.Model;

namespace FloBot.Tasks
{
    class FindGameHandlerTask : ITask
    {

        private const String gameName = "Multiclient.exe";
        private const String gameNameMultiClient = "FlorensiaEN";
        private static String oldWindowName ="Florensia ver2.02.00";
        private static String oldProcessNumber = "";
        public bool doTask(mainForm main_form, Player player)
        {
            throw new NotImplementedException();
        }

        public bool doTask(mainForm main_form, MemoryRW mc, Player player)
        {
           
            Int32.TryParse(main_form.tbProcessID.Text, out int number);

            if (mc.Process_Handle(gameName, number, main_form.tbProcessName.Text, !(oldProcessNumber.Equals(main_form.tbProcessID.Text) && oldWindowName.Equals(main_form.tbProcessName.Text))))
            {
                main_form.lblGameFound.Text = "Multiclient found";
               
                oldProcessNumber = main_form.tbProcessID.Text;
                oldWindowName = main_form.tbProcessName.Text;
                return true;
            }
            main_form.lblGameFound.Text = "Multiclient not found";

            return false;
        }
    }
}
