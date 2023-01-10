using System.Net;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using webAPI.Models;

namespace webAPI.Controllers
{
    [Route("[controller]")]
    public class Documento : Controller
    {
        private readonly ILogger<Documento> _logger;

        public Documento(ILogger<Documento> logger)
        {
            _logger = logger;
        }

        [HttpGet("imprimir")]
        public ActionResult Imprimir()
        {
            MemoryStream ms = new MemoryStream();
            iTextSharp.text.Document doc = new iTextSharp.text.Document();
            PdfWriter pw = PdfWriter.GetInstance(doc, ms);

            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font tituloFont = new iTextSharp.text.Font(bf, 9, iTextSharp.text.Font.NORMAL);
            Font privacidadFont = new iTextSharp.text.Font(bf, 7, iTextSharp.text.Font.NORMAL);


            doc.Open();
            Paragraph saltoDeLinea = new Paragraph(" ");
            doc.Add(new Paragraph("SERVICIO DE ADMINISTRACIÓN TRIBUTARIA DEL ESTADO DE GUANAJUATO", tituloFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("SUBDIRECCIÓN GENERAL DE INGRESOS", tituloFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("DIRECCIÓN DE SERVICIOS AL CONTRIBUYENTE", tituloFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(saltoDeLinea);
            doc.Add(new Paragraph("EVALUACIÓN DE SATISFACCIÓN DE LAS Y LOS USUARIOS DE LAS OFICINAS DE SERVICIOS AL CONTRIBUYENTE", tituloFont) { Alignment = Element.ALIGN_CENTER });
            doc.Add(new Paragraph("AVISO DE PRIVACIDAD", privacidadFont));
            doc.Add(saltoDeLinea);
            doc.Close();

            byte[] byteStream = ms.ToArray();
            ms = new MemoryStream();
            ms.Write(byteStream, 0, byteStream.Length);
            ms.Position = 0;

            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(ms.ToArray())
            };

            return Ok();
        }

        [HttpGet("print")]
        public IActionResult Prints(Boleto boleto)
        {
            return Ok(boleto);
        }
    }
}