# Informe final - AcademicReservations

## 1. Resultados

Se desarrolló una API REST para gestionar reservas de espacios académicos utilizando C#, .NET 8, SQLite y una arquitectura por capas.

Requisitos implementados:

- R1: Registro, autenticación y administración de usuarios.
- R2: Administración de espacios académicos.
- R3: Disponibilidad, reservas y prevención de conflictos.
- R4: Aprobación, rechazo, cancelación e historial de reservas.

## 2. Gestión del cambio

Se incorporó un límite máximo de cuatro horas consecutivas por usuario en un mismo espacio.

El cambio fue especificado, validado, implementado y archivado mediante OpenSpec, manteniendo la trazabilidad entre requisitos, código y pruebas.

## 3. Evidencias y pruebas

- Compilación inicial: exitosa.
- Pruebas automatizadas iniciales: 6 aprobadas.
- Validación inicial de OpenSpec: exitosa.
- Validación del cambio max-four-hours: exitosa.
- Swagger: funcionamiento comprobado.
- Reserva de cinco horas: rechazada.
- Reserva de cuatro horas: aceptada.
- Reserva consecutiva que supera el límite: rechazada.
- Historial de reservas: funcionamiento comprobado.
- Suite final de 7 pruebas: ejecución exitosa mediante GitHub Actions.

## 4. Decisiones técnicas

- Arquitectura por capas: Domain, Application e Infrastructure.
- SQLite para persistencia de información.
- API REST documentada mediante Swagger.
- Transacciones para prevenir conflictos de reservas.
- Pruebas automatizadas mediante xUnit.
- Control de versiones mediante Git y GitHub.
- Integración continua mediante GitHub Actions.

## 5. Dificultades

Durante la ejecución local de las pruebas finales, Windows Smart App Control bloqueó la carga del ensamblado de pruebas.

Se solucionó la verificación mediante GitHub Actions en un entorno Linux, sin desactivar los mecanismos de seguridad del equipo.

## 6. Conclusión

La metodología Spec-Driven Development permitió establecer los requisitos antes de implementar el sistema y gestionar posteriormente un cambio funcional de manera organizada.

OpenSpec facilitó la trazabilidad de los requisitos, mientras que Git permitió conservar el historial de planificación, especificación, implementación y evolución del proyecto.

El uso de inteligencia artificial facilitó el desarrollo, acompañado de revisión humana, validaciones y pruebas automatizadas.
