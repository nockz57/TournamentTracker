using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();

        public static void InitialiseConnections(bool database, bool textfiles)
        {
            if (database)
            {
                //TODO -- Set up the sql connector properly.
                SQLConnector sql = new SQLConnector();
                Connections.Add(sql);
            }

            if (textfiles)
            {
                //TODO -- Create the Text connection
                TextConnector text = new TextConnector();
                Connections.Add(text);
            }
        }

        public static string CnnString(string name)
        {
            return  ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}
