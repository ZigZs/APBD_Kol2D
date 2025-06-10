namespace APBD_KOL2C.DTO;

public class PostPlayerWithPlayerMatchDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDay { get; set; }
    public List<PostMatchDto> Matches { get; set; }
}

public class PostMatchDto
{
    public int MatchId { get; set; }
    public int MVPs { get; set; }
    public decimal Rating { get; set; }
}
