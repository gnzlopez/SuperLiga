using Recursiva.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web;

namespace Recursiva.Logic
{
    public class Process
    {
        public List<SocioModel> ProcessFile(HttpPostedFileBase file)
        {
            if (file == null)
            {
                throw new Exception("Debe cargar un archivo");
            }

            string extension = Path.GetExtension(file.FileName);

            if (extension != ".csv")
            {
                throw new Exception("La extension del archivo no es la correcta");
            }

            if (file.ContentLength > 0)
            {
                string path = HttpContext.Current.Server.MapPath("~\\Files\\");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                var filePath = path + Path.GetFileName(file.FileName);
                file.SaveAs(filePath);


                var socios = new List<SocioModel>();

                var csvFile = File.ReadAllText(filePath, Encoding.Default);
                string[] csvFileArray = csvFile.Split('\n');

                foreach (var row in csvFileArray)
                {
                    if (!string.IsNullOrEmpty(row))
                    {
                        var cells = row.Split(';');
                        var socio = new SocioModel
                        {
                            Name = cells[0],
                            Age = int.Parse(cells[1]),
                            Team = cells[2],
                            MaritalStatus = cells[3],
                            Schooling = cells[4]
                        };

                        socios.Add(socio);
                    }
                }

                return socios;
            }
            else
            {
                throw new Exception("El archivo esta vacio");
            }
        }
    }
}