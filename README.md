# Clinidev - Sistema de Gestión Clínica

Trabajo Práctico Integrador de la materia Programación III - Tecnicatura Universitaria en Programación (TUP), UTN FRGP.

## Objetivo

Sistema de gestión para clínicas médicas que centraliza la administración de médicos, pacientes, turnos, horarios e informes. El proyecto busca resolver un problema real de cualquier centro de salud: unificar información que normalmente está dispersa entre planillas y procesos manuales.

## Tecnologías

- ASP.NET WebForms
- C#
- SQL Server
- CSS

## Arquitectura

El sistema está desarrollado con una arquitectura en tres capas:

- **Entidades**: clases que representan los objetos del dominio (Médico, Paciente, Turno, Usuario, etc.)
- **Datos**: acceso a la base de datos (conexiones, adaptadores, procedimientos almacenados)
- **Negocio**: lógica de validación y procesamiento
- **Vistas**: interfaz de usuario (ASP.NET WebForms)

## DER Clínica
![alt text](Der imagen-1.png)
![alt text](Der imagen-2.png)
![alt text](Der imagen-3.png)

## Funcionalidades principales

- Gestión de médicos (alta, baja lógica, modificación, listado)
- Gestión de pacientes (alta, baja lógica, modificación, listado)
- Gestión de horarios médicos
- Asignación y gestión de turnos
- Informes (ausentismo, demanda por especialidad, mapa de demanda, pacientes por fecha)
- Sistema de usuarios con roles (Administrador, Médico)

## Documentación

El documento completo del proyecto se encuentra en la carpeta [`/docs`](./docs).

## Equipo

- Leonardo Farid Tello Moscoso
- Thiago Pinza
- Matías Giménez
- Matías Romano
- Agustín Romano
- Brandon Avendaño

---

# Clinidev - Clinical Management System

Final integrative project for Programación III - University Technician in Programming (TUP), UTN FRGP.

## Objective

A clinical management system that centralizes the administration of doctors, patients, appointments, schedules, and reports. The project addresses a real problem faced by health centers: unifying information that is usually scattered across spreadsheets and manual processes.

## Technologies

- ASP.NET WebForms
- C#
- SQL Server
- CSS

## Architecture

The system follows a three-layer architecture:

- **Entidades (Entities)**: domain model classes (Doctor, Patient, Appointment, User, etc.)
- **Datos (Data)**: database access layer (connections, adapters, stored procedures)
- **Negocio (Business)**: validation and processing logic
- **Vistas (Views)**: user interface (ASP.NET WebForms)

## Main features

- Doctor management (create, logical delete, update, list)
- Patient management (create, logical delete, update, list)
- Doctor schedule management
- Appointment assignment and management
- Reports (absenteeism, demand by specialty, demand map, patients by date)
- Role-based user system (Admin, Doctor)

## Documentation

The full project documentation is available in the [`/docs`](./docs) folder.

## Database ER Diagram
![alt text](Der imagen-1.png)
![alt text](Der imagen-2.png)
![alt text](Der imagen-3.png)

## Team

- Leonardo Tello Moscoso
- Thiago Pinza
- Matías Giménez
- Matías Romano
- Brandon Avendaño
- Agustín Romano
