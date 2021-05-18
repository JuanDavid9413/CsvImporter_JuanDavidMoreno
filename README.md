# CsvImporter_JuanDavidMoreno
This project is for ACNE COPPORATION

1. El proyecto esta creado con NetCore 3.1.
2. El proyecto esta creado con arquitectura a N Capas.
3. Contiene 7 capas.
	* BackEnd.PruebaCsvImporter.Business : Esta caparealiza toda la logica del proyecto.
	* BackEnd.PruebaCsvImporter.DB contiene los scripts para crear la tabla en la base de datos. Esto lo utilizo para tener un control de los scripts de la BD.
	* BackEnd.PruebaCsvImporter.Entities: contiene los modelos y interfaces de la aplicacion.
	* BackEnd.PruebaCsvImporter.Repository: contiene la logica de los procesos a la base de datos.
	* BackEnd.PruebaCsvImporter.Test: Contiene el archivo de prueba unitarias.
	* BackEnd.PruebaCsvImporter.Utilities: Contiene la clases, extenciones de clase transversales de toda la aplicacion.
	* PruebaCsvImporter: Proyecto de consola inicial donde se encuentra el configuracion y los logger.
4. Los nugets utilizados fueron:
	* Microsoft.Extensions.Hosting Version="5.0.0".
	* Serilog.Extensions.Hosting Version="4.1.2".
	* Serilog.Settings.Configuration Version="3.1.0".
	* Serilog.Sinks.Console Version="3.1.1".
	* Microsoft.EntityFrameworkCore Version="5.0.6".
	* Microsoft.EntityFrameworkCore.Relational Version="5.0.6".
    * Microsoft.EntityFrameworkCore.SqlServer Version="5.0.6".
    * Microsoft.Extensions.DependencyInjection Version="5.0.1".
	* Z.EntityFramework.Plus.EFCore Version="5.1.36".
	* Microsoft.Extensions.Configuration.Json Version="5.0.0".
    * Moq Version="4.16.1".
    * MSTest.TestAdapter Version="2.2.3".
    * MSTest.TestFramework Version="2.2.3".
    * Microsoft.NET.Test.Sdk Version="16.4.0".
	
5. El proyecto de demora en total 30 minutos contabilizados con una maquina con la siguientes especificaciones.
	* RAM: 12GB. (9,95 GB utilizable)
	* Procesador AMD 5. 2.10 GHz
   El proceso puede demorar dependiendo de la velosidad del internet y la RAM del PC.
6. No se logro optimizar mejor la aplicacion para que no consumiera tanta RAM.
7. Los proyectos quedaron creados con inyeccion de dependecias para poder garantizar la separacion y utilizacion de cada uno de los componentes independientemente.
8. Para el acceso a base de datos se utiliza Entity Framework con code First.
9 La cadena de conexion se encuentra en la clase ApplicationContext.