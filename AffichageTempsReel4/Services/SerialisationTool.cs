using Classes;
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
     

        public static string serialiser(Train infoTrain)
        {
            string json = JsonConvert.SerializeObject(infoTrain, Formatting.Indented);
            return json;
        }

        public static Train deserialiser(string json)
        {
            Train infoTrain = JsonConvert.DeserializeObject<Train>(json);
            return infoTrain;
        }
    }
}
