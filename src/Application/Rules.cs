namespace Academic;
public static class Rules {
 public static void Interval(DateTimeOffset start,DateTimeOffset end){if(start>=end) throw new RuleException("Inicio debe preceder al fin");}
 public static bool Overlap(DateTimeOffset a,DateTimeOffset b,DateTimeOffset c,DateTimeOffset d)=>a<d && c<b;
 public static void Transition(string old,string next){if(!((old=="pending" && (next=="approved"||next=="rejected"||next=="cancelled"))||(old=="approved"&&next=="cancelled")))throw new RuleException("Transición inválida");}
}
