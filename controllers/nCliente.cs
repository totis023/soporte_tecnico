using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Text.Json;
using soporte_tecnico.models;

namespace soporte_tecnico.controllers
{
    public class nCliente
    {
        private List<Cliente> clientes;
        private int proximoId;

        private readonly string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "clientes.json");

        public string UltimoArchivoCargado { get; private set; } = string.Empty;
        public int UltimoConteoCargado { get; private set; }

        public nCliente()
        {
            clientes = new List<Cliente>();
            proximoId = 1;
            CargarDesdeArchivo();
        }

        public List<Cliente> ObtenerTodos()
        {
            return clientes;
        }

        public void Agregar(string nombre, string telefono, string email)
        {
            Cliente cliente = new Cliente(proximoId, nombre, telefono, email);
            clientes.Add(cliente);
            proximoId++;
            GuardarEnArchivo();
        }

        public void Modificar(int id, string nombre, string telefono, string email)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                cliente.Nombre = nombre;
                cliente.Telefono = telefono;
                cliente.Email = email;
                GuardarEnArchivo();
            }
        }

        public void Eliminar(int id)
        {
            Cliente cliente = clientes.Find(c => c.Id == id);

            if (cliente != null)
            {
                clientes.Remove(cliente);
                GuardarEnArchivo();
            }
        }

        private void CargarDesdeArchivo()
        {
            try
            {
                // Buscar el directorio 'data' subiendo desde el directorio de ejecucion hasta la raiz.
                string repoFile = null;
                var start = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                var p = start;
                string lastFound = null;
                for (int i = 0; i < 12 && p != null; i++)
                {
                    var candidateFile = Path.Combine(p.FullName, "data", "clientes.json");
                    if (File.Exists(candidateFile))
                    {
                        // no romper: preferir la carpeta 'data' más alta en el árbol (más cercana a la raíz del repo)
                        lastFound = candidateFile;
                    }

                    var candidateDir = Path.Combine(p.FullName, "data");
                    if (Directory.Exists(candidateDir))
                    {
                        // si existe la carpeta data pero no el archivo, considerar la ruta de archivo dentro de ella
                        var candidate = Path.Combine(candidateDir, "clientes.json");
                        lastFound = candidate;
                    }

                    p = p.Parent;
                }

                // si se encontro alguna 'data' en ancestros, usar la mas alta (lastFound). Si no, usar dataPath.
                if (!string.IsNullOrEmpty(lastFound)) repoFile = lastFound; else repoFile = dataPath;

                // asegurar que exista el directorio y el archivo; si no, crear archivo vacío
                var dirRepo = Path.GetDirectoryName(repoFile) ?? AppDomain.CurrentDomain.BaseDirectory;
                if (!Directory.Exists(dirRepo)) Directory.CreateDirectory(dirRepo);
                if (!File.Exists(repoFile)) File.WriteAllText(repoFile, "[]");

                // leer el contenido y deserializar
                string json = File.ReadAllText(repoFile);
                UltimoArchivoCargado = repoFile;

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var lista = JsonSerializer.Deserialize<List<Cliente>>(json, options) ?? new List<Cliente>();

                clientes = lista;
                proximoId = clientes.Count > 0 ? clientes.Max(c => c.Id) + 1 : 1;
                UltimoConteoCargado = clientes.Count;
            }
            catch
            {
                clientes = new List<Cliente>();
                proximoId = 1;
                UltimoArchivoCargado = string.Empty;
                UltimoConteoCargado = 0;
            }
        }

        private void GuardarEnArchivo()
        {
            try
            {
                var dir = Path.GetDirectoryName(dataPath) ?? AppDomain.CurrentDomain.BaseDirectory;
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = JsonSerializer.Serialize(clientes, options);
                File.WriteAllText(dataPath, json);
            }
            catch
            {
                // ignorar errores de escritura
            }
        }
    }
}
