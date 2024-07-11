using System.Text.RegularExpressions;

namespace PruebaAnalisisDeImagen.Models
{
    public class ImageData
    {

        string pattern= @"\b\d{2}/\d{2}/\d{4}\b";
        string proceso;
        string fecha;
        string total;
        string hora;

    }

}
