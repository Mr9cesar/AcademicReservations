namespace Academic;
public record User(long Id,string Email,string Role);
public record Space(long Id,string Name,string Type);
public record Reservation(long Id,long UserId,long SpaceId,DateTimeOffset Start,DateTimeOffset End,string Status);
public record Credentials(string Email,string Password);
public record SpaceInput(string Name,string Type);
public record Booking(long SpaceId,DateTimeOffset Start,DateTimeOffset End);
public record RoleInput(string Role);
public record Decision(string Status);
public class RuleException(string message):Exception(message) { }
