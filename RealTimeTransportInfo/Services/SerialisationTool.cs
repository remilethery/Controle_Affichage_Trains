using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SerialisationTool
    {
     

        public static string serialiser(InfoTrain infoTrain)
        {
            string json = JsonConvert.SerializeObject(infoTrain, Formatting.Indented);
            return json;
        }

        public static InfoTrain deserialiser(string json)
        {
            InfoTrain infoTrain = JsonConvert.DeserializeObject<InfoTrain>(json);
            return infoTrain;
        }
    }
}
