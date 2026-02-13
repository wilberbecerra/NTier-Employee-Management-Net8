# 🏢 NTier Employee Management System

Sistema de Gestión de Empleados Corporativo desarrollado con **.NET 8**, implementando una **Arquitectura de N-Capas** para garantizar escalabilidad, mantenibilidad y separación de responsabilidades.

---

## 🚀 Funcionalidades Principales (CRUD Completo)

* **Listado Dinámico:** Visualización profesional de empleados con integración de departamentos y cargos.
* **Registro de Personal:** Formulario validado para la inserción de nuevos registros en SQL Server.
* **Edición en Tiempo Real:** Capacidad de actualizar información existente mediante persistencia de datos.
* **Borrado Lógico (Soft Delete):** Implementación de integridad de datos donde los registros se desactivan (`Estado = 0`) en lugar de eliminarse físicamente, permitiendo auditorías y reingresos.

## 🛠️ Stack Tecnológico

* **Backend:** C# .NET 8 (LTS)
* **Arquitectura:** 3 Capas (Acceso a Datos, Lógica de Negocio, Presentación) + Entidades Transversales.
* **Base de Datos:** SQL Server (ADO.NET / T-SQL).
* **API:** ASP.NET Core Web API para la exposición de servicios RESTful.
* **Frontend:** ASP.NET Core MVC con Razor Pages y Bootstrap 5.

## 🏗️ Estructura del Proyecto

* **WB.Entidades:** Modelos de dominio (POCOs).
* **WB.AccesoDatos:** Comunicación directa con SQL Server utilizando patrones de seguridad contra Inyección SQL.
* **WB.LogicaNegocio:** Capa intermedia para validaciones y reglas de negocio.
* **WB.MVC:** Interfaz de usuario web interactiva.
* **WB.API:** Endpoints para integración con otros sistemas.

---

## ⚙️ Configuración

1. Clonar el repositorio.
2. Ejecutar el script `WB_EXAMEN_FINAL.sql` en su instancia de SQL Server.
3. Actualizar la cadena de conexión en el archivo `appsettings.json`.
4. ¡Ejecutar y probar!
