namespace DefaultNamespace;

public class User
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public int Telefone { get; private set; }
    public string Passe { get; private set; }
    public bool Admin { get; private set; }

    public User(int id, string email, int telefone, string passe, bool admin)
    {
        this.Id = id;
        this.Email = email;
        this.Telefone = telefone;
        this.Passe = passe;
        this.Admin = admin;
    }
}
