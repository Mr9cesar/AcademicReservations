# Plan de ingeniería — AcademicReservations
## 1. Análisis
La gestión por correo y hojas de cálculo produce duplicados, conflictos y falta de visibilidad. La institución necesita centralizar espacios, usuarios y reservas con control de acceso e historial. Actores: solicitante (consulta y solicita), administrador (gestiona usuarios, espacios y decisiones). Alcance: API local para espacios, usuarios, disponibilidad y ciclo de reservas. Fuera de alcance: interfaz independiente, correo, integración institucional y despliegue productivo.
## 2. Solución
API REST con Swagger. Módulos: identidad, espacios y reservas. Primero identidad y espacios; después disponibilidad y solicitudes; finalmente decisiones, cancelación e historial. Los intervalos son semiabiertos [inicio, fin), en UTC. Una solicitud pendiente o aprobada bloquea el espacio; rechazo o cancelación lo libera. El historial conserva las solicitudes y su estado.
## 3. Arquitectura y tecnología
Arquitectura por capas inspirada en Clean Architecture: dominio (entidades), aplicación (casos de uso y contrato), infraestructura (SQLite), API (HTTP y autorización). Dependencias hacia los contratos de aplicación. Se elige .NET 8, C#, ASP.NET Core, Microsoft.Data.Sqlite, Swagger y xUnit.
| Decisión | Alternativa descartada | Justificación |
|---|---|---|
| SQLite | MySQL | Persistencia transaccional sin servidor adicional |
| API REST | Aplicación monolítica con interfaz gráfica | Separación del transporte y facilidad de verificación |
| Capas | Código íntegro en controladores | Facilita pruebas y separación de responsabilidades |
| Tokens aleatorios locales | JWT | Menor complejidad para prototipo; sesiones revocables al reiniciar |
La persistencia usa tablas relacionales, claves foráneas y transacciones de escritura inmediatas para evitar carreras. Las contraseñas se almacenan mediante hash con sal. No se almacenan tokens en disco. El prototipo no está destinado a producción.
## 4. Desarrollo
SDD incremental: plan y commit; especificaciones y revisión; implementación; pruebas; cambio posterior mediante nueva propuesta; verificación final. Identidad y espacios preceden reservas; reservas preceden decisiones. Cada etapa termina con revisión, criterios de aceptación comprobables y commit. No se implementan requisitos no revisados.
## 5. Calidad
Pruebas unitarias de reglas, integración SQLite y comprobación HTTP mediante Swagger. Trazabilidad mediante identificadores de requisitos y pruebas.
| Riesgo | Mitigación |
|---|---|
| Reservas simultáneas | Transacción inmediata y consulta de solapamiento |
| Acceso indebido | Validación de token y rol |
| Fechas ambiguas | UTC e intervalos semiabiertos |
| Pérdida de historial | No eliminar reservas; cambiar estado |
| Código IA incorrecto | Revisar diffs y ejecutar pruebas |
| Datos inválidos | Validaciones y restricciones SQL |
## 6. SDD e IA
Inicializar OpenSpec después del commit del plan. Convertir módulos en requisitos SHALL y escenarios Given/When/Then; revisar coherencia y tareas antes de programar. La IA propone especificaciones, código y pruebas; el estudiante decide alcance, arquitectura, reglas, revisión y aceptación. Validar OpenSpec, revisar código, ejecutar pruebas y comprobar HTTP. Todo cambio funcional requiere especificación previa y commit independiente.
