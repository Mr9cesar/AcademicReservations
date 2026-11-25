## ADDED Requirements
### Requirement: R3 Reservas
El sistema SHALL permitir solicitar reservas con inicio anterior al fin, en UTC, consultar disponibilidad y evitar solapamientos de solicitudes pendientes o aprobadas mediante transacción; intervalos contiguos se permiten.

#### Scenario: Validación de Reservas
- **GIVEN** una reserva pendiente de 10 a 12
- **WHEN** se solicita el mismo espacio de 11 a 13
- **THEN** se rechaza; de 12 a 13 se permite
