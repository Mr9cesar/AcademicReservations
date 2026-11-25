# AcademicReservations
API REST de reservas académicas. Requiere .NET 8 SDK.

```powershell
$env:ACADEMIC_ADMIN_PASSWORD="Cambiar123!"
dotnet run --project src --urls http://localhost:5109
```
Abrir http://localhost:5109/swagger. Iniciar sesión en `/users/login` con `admin@local.test` y la contraseña configurada. Copiar token a Authorize. Crear espacio con tipo `laboratorio`, `auditorio` o `computo`. Registrar otro usuario, iniciar sesión y solicitar reserva con fechas ISO 8601 UTC. Estados: pending, approved, rejected, cancelled. SQLite se crea automáticamente.

Pruebas: `dotnet test tests`. Eliminar academic.db solo si se desea reiniciar datos de demostración. Tokens se pierden al reiniciar. Prototipo local, no producción.
