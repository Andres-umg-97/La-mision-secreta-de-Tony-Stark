using System;
using System.IO;

class LaboratorioAvengers
{
    // Rutas de los archivos y carpetas
    static string rutaInventos = Path.Combine("LaboratorioAvengers", "inventos.txt");
    static string rutaBackup = Path.Combine("LaboratorioAvengers", "Backup", "inventos.txt");
    static string rutaArchivosClasificados = Path.Combine("LaboratorioAvengers", "ArchivosClasificados", "inventos.txt");
    static string rutaProyectosSecretos = Path.Combine("LaboratorioAvengers", "ProyectosSecretos");

    static void Main(string[] args)
    {
        // Crear la carpeta principal "LaboratorioAvengers" si no existe
        CrearCarpeta("LaboratorioAvengers");

        // Menú interactivo para el usuario
        while (true)
        {
            Console.WriteLine("\n--- Menú de Operaciones ---");
            Console.WriteLine("1. Crear archivo 'inventos.txt'");
            Console.WriteLine("2. Agregar un invento");
            Console.WriteLine("3. Leer archivo línea por línea");
            Console.WriteLine("4. Leer todo el contenido del archivo");
            Console.WriteLine("5. Copiar archivo a 'Backup'");
            Console.WriteLine("6. Mover archivo a 'ArchivosClasificados'");
            Console.WriteLine("7. Crear carpeta 'ProyectosSecretos'");
            Console.WriteLine("8. Listar archivos en 'LaboratorioAvengers'");
            Console.WriteLine("9. Eliminar archivo 'inventos.txt'");
            Console.WriteLine("10. Salir");
            Console.Write("Selecciona una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    CrearArchivo(); 
                    break;
                case "2":
                    Console.Write("Ingresa el nombre del invento: ");
                    string invento = Console.ReadLine();
                    AgregarInvento(invento); 
                    break;
                case "3":
                    LeerLineaPorLinea(); 
                    break;
                case "4":
                    LeerTodoElTexto(); 
                    break;
                case "5":
                    CopiarArchivo(rutaInventos, rutaBackup); 
                    break;
                case "6":
                    MoverArchivo(rutaInventos, rutaArchivosClasificados); 
                    break;
                case "7":
                    CrearCarpeta(rutaProyectosSecretos); 
                    break;
                case "8":
                    ListarArchivos("LaboratorioAvengers"); 
                    break;
                case "9":
                    EliminarArchivo(rutaInventos); 
                    break;
                case "10":
                    Console.WriteLine("¡Hasta luego, Tony!"); 
                    return;
                default:
                    Console.WriteLine("Opción no válida. Intenta de nuevo."); 
                    break;
            }
        }
    }

    // Función para crear el archivo "inventos.txt"
    static void CrearArchivo()
    {
        try
        {
            if (!File.Exists(rutaInventos)) 
            {
                File.Create(rutaInventos).Close(); 
                Console.WriteLine("Archivo 'inventos.txt' creado exitosamente.");
            }
            else
            {
                Console.WriteLine("El archivo 'inventos.txt' ya existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para agregar un invento al archivo
    static void AgregarInvento(string invento)
    {
        try
        {
            using (StreamWriter sw = File.AppendText(rutaInventos)) 
            {
                sw.WriteLine(invento); 
            }
            Console.WriteLine($"Invento '{invento}' agregado exitosamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para leer el archivo línea por línea
    static void LeerLineaPorLinea()
    {
        try
        {
            if (File.Exists(rutaInventos)) 
            {
                using (StreamReader sr = new StreamReader(rutaInventos)) 
                {
                    string linea;
                    while ((linea = sr.ReadLine()) != null) 
                    {
                        Console.WriteLine(linea); 
                    }
                }
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para leer todo el contenido del archivo
    static void LeerTodoElTexto()
    {
        try
        {
            if (File.Exists(rutaInventos)) 
            {
                string contenido = File.ReadAllText(rutaInventos); 
                Console.WriteLine(contenido); 
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para copiar un archivo
    static void CopiarArchivo(string origen, string destino)
    {
        try
        {
            if (File.Exists(origen)) 
            {
                string directorioDestino = Path.GetDirectoryName(destino); 
                if (!Directory.Exists(directorioDestino)) 
                {
                    Directory.CreateDirectory(directorioDestino); 
                }
                File.Copy(origen, destino, true); 
                Console.WriteLine($"Archivo copiado a '{destino}' exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para mover un archivo
    static void MoverArchivo(string origen, string destino)
    {
        try
        {
            if (File.Exists(origen)) 
            {
                string directorioDestino = Path.GetDirectoryName(destino); 
                if (!Directory.Exists(directorioDestino)) 
                {
                    Directory.CreateDirectory(directorioDestino); 
                }
                File.Move(origen, destino);
                Console.WriteLine($"Archivo movido a '{destino}' exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para crear una carpeta
    static void CrearCarpeta(string nombreCarpeta)
    {
        try
        {
            if (!Directory.Exists(nombreCarpeta)) 
            {
                Directory.CreateDirectory(nombreCarpeta); 
                Console.WriteLine($"Carpeta '{nombreCarpeta}' creada exitosamente.");
            }
            else
            {
                Console.WriteLine($"La carpeta '{nombreCarpeta}' ya existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para listar archivos en una carpeta
    static void ListarArchivos(string ruta)
    {
        try
        {
            if (Directory.Exists(ruta)) 
            {
                string[] archivos = Directory.GetFiles(ruta);
                if (archivos.Length > 0) 
                {
                    Console.WriteLine($"Archivos en '{ruta}':");
                    foreach (string archivo in archivos) 
                    {
                        Console.WriteLine(Path.GetFileName(archivo));
                    }
                }
                else
                {
                    Console.WriteLine($"No hay archivos en '{ruta}'.");
                }
            }
            else
            {
                Console.WriteLine($"La carpeta '{ruta}' no existe.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }

    // Función para eliminar un archivo
    static void EliminarArchivo(string ruta)
    {
        try
        {
            if (File.Exists(ruta)) 
            {
                File.Delete(ruta); 
                Console.WriteLine($"Archivo '{ruta}' eliminado exitosamente.");
            }
            else
            {
                Console.WriteLine("Error: El archivo 'inventos.txt' no existe. ¡Ultron debe haberlo borrado!");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}"); 
        }
    }
}
