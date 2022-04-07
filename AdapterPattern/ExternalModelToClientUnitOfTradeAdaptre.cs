using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class ExternalModelToClientUnitOfTradeAdaptre : ClientUnitOfTrade
    {
        public JsonDocument document;

        public ExternalModelToClientUnitOfTradeAdaptre(JsonDocument doc)
        {
            document = doc;
        }
        //Если я правильно понимаю, то тут необходимо выполнить мапинг 
        //полей на модель ClientUnitOfTrade
    }
}
