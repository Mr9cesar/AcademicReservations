# identity Specification

## Purpose

TBD - created by archiving change initial-system. Update Purpose after archive.

## Requirements

### Requirement: R1 Identidad
El sistema SHALL permitir registro con correo único, contraseña de al menos ocho caracteres y rol solicitante; autenticación con token; solo administrador puede listar usuarios o cambiar roles.

#### Scenario: Validación de Identidad
- **GIVEN** un correo repetido
- **WHEN** se intenta registrar nuevamente
- **THEN** se rechaza; un solicitante no puede administrar usuarios
