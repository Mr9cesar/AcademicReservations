using Academic;
using Xunit;
public class StoreTests:IDisposable {
 readonly string path=Path.Combine(Path.GetTempPath(),Guid.NewGuid()+".db");readonly Store s;readonly User u,a;readonly long space;readonly DateTimeOffset start=new(2026,12,1,10,0,0,TimeSpan.Zero);
 public StoreTests(){s=new(path);u=s.Register(new("u@test.local","password1"));a=s.Register(new("a@test.local","password2"),"admin");space=s.SaveSpace(new("Lab","laboratorio"));}
 Booking B(int from,int to)=>new(space,start.AddHours(from),start.AddHours(to));
 [Fact] public void R1_Identity(){Assert.Equal(u,s.Login(new("u@test.local","password1")));Assert.Null(s.Login(new("u@test.local","wrong")));Assert.Throws<RuleException>(()=>s.Register(new("u@test.local","password1")));s.Role(u.Id,"admin");Assert.Equal("admin",s.GetUser(u.Id)!.Role);}
 [Fact] public void R2_Spaces(){Assert.Single(s.Spaces());s.SaveSpace(new("Lab 2","computo"),space);Assert.Equal("Lab 2",s.Spaces()[0].Name);Assert.Throws<RuleException>(()=>s.SaveSpace(new("Bad","bad")));}
 [Fact] public void R3_Overlap(){s.Reserve(u.Id,B(0,2));Assert.False(s.Available(B(1,3)));Assert.Throws<RuleException>(()=>s.Reserve(u.Id,B(1,3)));Assert.True(s.Available(B(2,3)));s.Reserve(u.Id,B(2,3));}
 [Fact] public void R3_Invalid(){Assert.Throws<RuleException>(()=>s.Reserve(u.Id,B(2,1)));}
 [Fact] public async Task R3_Concurrency(){var jobs=Enumerable.Range(0,2).Select(_=>Task.Run(()=>{try{s.Reserve(u.Id,B(0,2));return true;}catch(RuleException){return false;}}));Assert.Single((await Task.WhenAll(jobs)).Where(x=>x));}
 [Fact] public void R4_Lifecycle(){var id=s.Reserve(u.Id,B(0,2));Assert.Throws<UnauthorizedAccessException>(()=>s.Change(id,u,"approved"));s.Change(id,a,"approved");s.Change(id,u,"cancelled");Assert.True(s.Available(B(0,2)));Assert.Equal("cancelled",s.History(u.Id)[0].Status);var id2=s.Reserve(u.Id,B(0,2));s.Change(id2,a,"rejected");Assert.True(s.Available(B(0,2)));Assert.Empty(s.History(a.Id));}
 public void Dispose(){Microsoft.Data.Sqlite.SqliteConnection.ClearAllPools();File.Delete(path);}
}
