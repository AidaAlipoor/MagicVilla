using Microsoft.AspNetCore.Mvc;
using static MagicVilla_Utility.StaticDetail;

namespace MagicVilla_Web.Models
{
    public class APIRequest
    {
        public APIType APItype { get; set; } = APIType.Get;
        public string APIurl { get; set; }
        public object Data { get; set; }
    }
}
