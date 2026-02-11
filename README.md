# 🏢 NTier Employee Management System

Sistema de Gestión de Empleados Corporativo desarrollado con **.NET 8** implementando una **Arquitectura de N-Capas**.

## 🚀 Tecnologías
* **Backend:** C# .NET 8 (LTS)
* **Base de Datos:** SQL Server
* **Arquitectura:** 3 Capas (Datos, Negocio, Presentación) + Entidades Transversales
* **Frontend:** ASP.NET Core MVC (Razor)
* **API:** ASP.NET Core Web API

## 📂 Estructura del Proyecto
* `WB.Entidades`: Modelos de dominio (POCOs).
* `WB.AccesoDatos`: Comunicación con SQL Server (ADO.NET / Dapper).
* `WB.LogicaNegocio`: Reglas de negocio y validaciones.
* `WB.MVC`: Interfaz de usuario Web.
* `WB.API`: Servicios RESTful.

