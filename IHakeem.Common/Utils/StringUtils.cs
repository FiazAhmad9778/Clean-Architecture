using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace iHakeem.SharedKernal.Utils
{
    public class StringUtils
    {
        public static string GenerateFourDigitRandomNo()
        {
            int _min = 1000;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max).ToString();
        }

        public static string ConvertObjectToJson(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
