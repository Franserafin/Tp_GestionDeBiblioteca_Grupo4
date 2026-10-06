# TP_GestionDeBiblioteca_[Grupo4]

## Descripción breve del sistema
Este proyecto es una aplicación de escritorio diseñada para llevar la gestión eficiente de una biblioteca. El sistema permitirá administrar el catálogo de libros disponibles y clasificarlos adecuadamente mediante un sistema de categorías, facilitando así el control del inventario y el seguimiento de los movimientos (alquileres) de la biblioteca.

Las entidades principales del sistema serán:
*   **Libro:** 
*   **Categoría:** 

## Objetivos y funcionalidades previstas
El objetivo principal es desarrollar una aplicación utilizando una arquitectura en capas y Entity Framework Core para la persistencia de datos. 

Las funcionalidades principales (ABM) incluyen:
1. **Gestión de Libros:** Permitirá realizar el Alta, Baja (eliminación o desactivación) y Modificación de los libros del catálogo.
2. **Gestión de Categorías:** Permitirá realizar el Alta, Baja y Modificación de las distintas categorías literarias.

## Reportes
El sistema generará los siguientes 4 reportes básicos para el análisis de la biblioteca:
1. Cantidad de Libros Alquilados en total.
2. Cantidad de Categorías registradas en el sistema.
3. El Libro que más se alquiló.
4. La Categoría más solicitada por los usuarios.

## Integración de capas del sistema
Para guardar un registro en la base de datos (por ejemplo, dar de alta un nuevo Libro), la integración de las capas funcionará de la siguiente manera:

1. **Capa de Presentación (WinForms App):** El usuario completará los datos del nuevo libro en un formulario (interfaz gráfica) y presionará el botón "Guardar". La interfaz capturará estos datos y creará una instancia del modelo `Libro`.
2. **Capa de Lógica de Negocio / Repositorio (Biblioteca de Clases):** La interfaz enviará el objeto `Libro` a una clase gestora o repositorio dentro de la biblioteca de clases. Aquí se pueden realizar validaciones adicionales de negocio.
3. **Capa de Acceso a Datos (DbContext):** El repositorio tomará el objeto `Libro` y lo agregará al contexto de Entity Framework Core (`DbContext`). Finalmente, se ejecutará el método `SaveChanges()` para traducir esta operación a una consulta SQL (INSERT) y persistir el registro de forma permanente en la base de datos.
