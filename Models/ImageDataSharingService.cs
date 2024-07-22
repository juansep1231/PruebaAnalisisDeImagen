using System;

namespace PruebaAnalisisDeImagen.Models
{
    public class ImageDataSharingService
    {
    public string Archivo { get; set; }
        public string Corte { get; set; }

        public void SetImageData(string archivo, string corte)
        {
            Archivo = archivo;
            Corte = "Corte "+corte;
        }

        public (string archivo, string corte) GetImageData()
        {
            return (Archivo, Corte);
        }
    }
}
