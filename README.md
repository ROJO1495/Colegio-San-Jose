Descripcion del Proyecto
Sistema web desarrollado en ASP.NET Core MVC para la gestion de expedientes academicos del Colegio San Jose. Permite administrar alumnos, materias y calificaciones de forma digital.

Caracteristicas Principales
 Gestion de Alumnos
  - Registro de nuevos estudiantes
  - Consulta y edicion de datos personales
  - Eliminacion de registros academicos
  - Validacion de informacion en formularios

 Administracion de Materias
  - Catalogo completo del pensum escolar
  - Configuracion de creditos y codigos
  - Mantenimiento de asignaturas

 Expedientes Academicos
  - Registro de calificaciones por alumno
  - Asignacion de notas finales
  - Observaciones del docente
  - Control de fechas de inscripcion

 Reportes y Estadisticas
 - Calculo de promedios generales
 - Graficas de rendimiento academico
 - Estado de aprobados y reprobados
 - Consultas flexibles y filtros

 Tecnologias Utilizadas
 - ASP.NET Core 8.0 MVC
 - Entity Framework Core (Ultima version)
 - SQL Server
 - Bootstrap 5
 - Chart.js
 - HTML5, CSS3, JavaScript

 Estructura de la Base de Datos
  El sistema utiliza 3 tablas principales:
    - Alumnos: Informacion personal de estudiantes
    - Materias: Catalogo de asignaturas
    - Expedientes: Notas y relaciones alumno-materia

 Instalacion y Configuracion
 - Clonar el repositorio
 - Configurar la cadena de conexion en appsettings.json
 - Ejecutar las migraciones de Entity Framework
 - Ejecutar el script de base de datos incluido

 Funcionalidades CRUD
 Implementa operaciones completas de Alta, Baja, Modificacion y Consulta para las tres entidades principales, siguiendo los patrones de diseño MVC.

Notas Importantes
- Sistema desarrollado como proyecto academico
- Requiere Visual Studio 2022 o superior
- Compatible con SQL Server Express o LocalDB
- Interface responsiva y amigable
