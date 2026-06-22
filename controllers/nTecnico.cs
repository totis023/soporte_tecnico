using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Reflection;
using soporte_tecnico.models;

namespace soporte_tecnico.controllers
{
    public class nTecnico
    {
        // Ruta del archivo que se cargó (útil para diagnosticar problemas)
        public string UltimoArchivoCargado { get; private set; } = string.Empty;
        public int UltimoConteoCargado { get; private set; }
        private List<Tecnico> tecnicos;
        private int proximoId;

        private readonly string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "tecnicos.json");

        public nTecnico()
        {
            tecnicos = new List<Tecnico>();
            proximoId = 1;
            CargarDesdeArchivo();
        }

        public List<Tecnico> ObtenerTodos()
        {
            return tecnicos;
        }

        public void Agregar(string nombre, string especialidad, string email)
        {
            Tecnico tecnico = new Tecnico(proximoId, nombre, especialidad, email);
            tecnicos.Add(tecnico);
            proximoId++;
            GuardarEnArchivo();
        }

        public void Modificar(int id, string nombre, string especialidad, string email)
        {
            Tecnico tecnico = tecnicos.Find(t => t.Id == id);

            if(tecnico != null)
            {
                tecnico.Nombre = nombre;
                tecnico.Especialidad = especialidad;
                tecnico.Email = email;
                GuardarEnArchivo();
            }
        }

        public void Eliminar(int id)
        {
            Tecnico tecnico = tecnicos.Find(t => t.Id == id);

            if(tecnico != null)
            {
                tecnicos.Remove(tecnico);
                GuardarEnArchivo();
            }
        }

        private void CargarDesdeArchivo()
        {
            //version simplificada y clara de carga desde JSON
            try
            {
                //buscar el directorio 'data' subiendo desde el directorio de ejecucion hasta la raiz.
                string? repoFile = null;
                var start = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                var p = start;
                for (int i = 0; i < 12 && p != null; i++)
                {
                    var candidateFile = Path.Combine(p.FullName, "data", "tecnicos.json");
                    if (File.Exists(candidateFile))
                    {
                        repoFile = candidateFile;
                        break;
                    }

                    var candidateDir = Path.Combine(p.FullName, "data");
                    if (Directory.Exists(candidateDir))
                    {
                        repoFile = Path.Combine(candidateDir, "tecnicos.json");
                        break;
                    }

                    p = p.Parent;
                }

                //si no se encontro, usar dataPath (carpeta junto al ejecutable)
                if (repoFile == null)
                {
                    repoFile = dataPath;
                }

                //asegurar que exista el directorio y el archivo; si no, crear archivo vacío
                var dirRepo = Path.GetDirectoryName(repoFile) ?? AppDomain.CurrentDomain.BaseDirectory;
                if (!Directory.Exists(dirRepo)) Directory.CreateDirectory(dirRepo);
                if (!File.Exists(repoFile)) File.WriteAllText(repoFile, "[]");

                //leer el contenido y deserializar
                string json = File.ReadAllText(repoFile);
                UltimoArchivoCargado = repoFile;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var lista = JsonSerializer.Deserialize<List<Tecnico>>(json, options) ?? new List<Tecnico>();

                tecnicos = lista;
                proximoId = tecnicos.Count > 0 ? tecnicos.Max(t => t.Id) + 1 : 1;
                UltimoConteoCargado = tecnicos.Count;
            }
            catch
            {
                //en caso de error, inicializar lista vacía
                tecnicos = new List<Tecnico>();
                proximoId = 1;
                UltimoArchivoCargado = string.Empty;
                UltimoConteoCargado = 0;
            }
        }

        private void GuardarEnArchivo()
        {
            try
            {
                string dir = Path.GetDirectoryName(dataPath) ?? AppDomain.CurrentDomain.BaseDirectory;
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(tecnicos, options);
                File.WriteAllText(dataPath, json);
            }
            catch
            {
                //ignorar errores de escritura para no romper la app
            }
        }
    }
}
