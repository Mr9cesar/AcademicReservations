## ADDED Requirements
### Requirement: R2 Espacios
El sistema SHALL permitir al administrador crear y editar espacios con nombre único y tipo laboratorio, auditorio o sala de cómputo; usuarios autenticados pueden listar espacios.

#### Scenario: Validación de Espacios
- **GIVEN** un solicitante autenticado
- **WHEN** intenta crear un espacio
- **THEN** se deniega; un administrador puede crearlo
