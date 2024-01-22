namespace BlazorLeilart.Models.User;

public class User
{
    public int Id { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }
    public bool Admin { get; private set; }

    public User(int id, string email, string telefone, string passe, bool admin)
    {
        this.Id = id;
        this.Email = email;
        this.Phone = telefone;
        this.Password = passe;
        this.Admin = admin;
    }

    public User()
    {
        this.Id = 1;
        this.Email = "teste@teste.com";
        this.Phone = "999999999";
        this.Password = "null";
        this.Admin = false;
    }
}
