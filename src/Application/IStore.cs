namespace Academic;
public interface IStore {
 User Register(Credentials c,string role="requester"); User? Login(Credentials c); User? GetUser(long id); List<User> Users(); void Role(long id,string role);
 List<Space> Spaces(); long SaveSpace(SpaceInput input,long? id=null); bool Available(Booking b); long Reserve(long user,Booking b); List<Reservation> History(long? user); void Change(long id,User actor,string status);
}
