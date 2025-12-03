#  Biblioteca Nacional - Prueba Desarrollo .NET

## Descripción

Este proyecto es la solución para la Librería "NACIONAL". Implementa las operaciones **CRUD (Crear, Leer, Actualizar, Eliminar)** para los módulos de Libros y Editoriales, usando MVC Y un principio Solid .

**Tecnología Utilizada:**
- **Framework:** .NET 8 (ASP.NET Core MVC)
- **Base de Datos:** SQL Server (Se adjunta el Script en el correo de envio)
- **ORM:** Entity Framework Core
- **Frontend:** Bootstrap

## Arquitectura y Principios usados

Se implementó el patrón **Repository and Interface** para garantizar:
1.  **Separación de Responsabilidades (SoC):** El Controller se enfoca en el flujo web, y el Repository en el acceso a datos lo que nos permitiria evitar un riesgo frecuente y es el cambio de motor de base de datos
por cualquier eventualidad lo que nos llevaria a cambiar en cada controlador la forma para acceder a los datos pero con el uso de repositorios no ya que este maneja ese acceso.
2.  **Desacoplamiento:** Los Controllers dependen de **Interfaces** (`ILibroRepository`), lo que permite generar escalabilidad ya que permitiria realziar test unitarios con mocks con facilidad.
3.  Se uso la creacion de modelos de vista , esto para manejar un modelo de datos especifico para la vista de lo que requiere visualizar el usuario
   en nuestro caso al momento de cargar la lista de editoriales para los libros asi separamos en un modelo de vista esta lista y evitamos tener que hacerlo todo en el modelo de "Libro"
4.Se realiza algunos comentarios con el proposito de geenrar escalabilidad y mantenimeinto al codigo al momento de la revision
   5. MVC , manejo de conexion por medio de un appcontext, y separar la logica del negocio para mejorar la integracion contniua o mejoras que se queiran implementar con esta arquitectura.
   6. Tambien se incluyo valdiaciones de formulario(required) y validaciones de modelo lo cual nos permite identificar errores que peudan afectar los datos , se encapsulan y se indica al usuario que no es posible el cambio
   7. Se agrega un modal para la vista de libro con el proposito de manejar el campo "Sinopsis" de la mejor forma para la visualziacion del usuario.
##  Instalación y Ejecución

Para ejecutar el proyecto localmente:

### 1. Requisitos
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (o SQL LocalDB)

### 2. Configuración de la Base de Datos
- **Adjunto se encuentra el script SQL:** `ScriptBD.sql`
- Ejecute este script para crear la base de datos y las tablas (`libros`, `editoriales`, etc.).
- **Actualizar `appsettings.json`:** Modifique la cadena de conexión (`"DefaultConnection"`) para que apunte a su instancia de SQL Server.

### 3. Ejecutar la Aplicación

Abra una terminal en la carpeta raíz del proyecto:

# Restaurar todas las dependencias (paquetes NuGet)
dotnet restore

# Ejecutar la aplicación
dotnet run

# Nos indicara en la compilacion el localhost y el puerto donde se esta ejecutando la aplicación
