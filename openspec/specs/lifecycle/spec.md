# lifecycle Specification

## Purpose

TBD - created by archiving change initial-system. Update Purpose after archive.

## Requirements

### Requirement: R4 Ciclo de reservas
El sistema SHALL permitir al administrador aprobar o rechazar pendientes; el propietario o administrador puede cancelar pendientes o aprobadas; el historial conserva todos los estados y solo muestra reservas propias salvo administrador.

#### Scenario: Validación de Ciclo de reservas
- **GIVEN** una solicitud pendiente
- **WHEN** el administrador la rechaza
- **THEN** el intervalo queda disponible y el historial conserva el rechazo
