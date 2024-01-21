namespace BlazorLeilart.Models.User;

public class User
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public string Telefone { get; private set; }
    public string Passe { get; private set; }
    public bool Admin { get; private set; }

    public User(int id, string email, string telefone, string passe, bool admin)
    {
        this.Id = id;
        this.Email = email;
        this.Telefone = telefone;
        this.Passe = passe;
        this.Admin = admin;
    }

    public User()
    {
        this.Id = 1;
        this.Email = "teste@teste.com";
        this.Telefone = "999999999";
        this.Passe = "null";
        this.Admin = false;
    }
}
