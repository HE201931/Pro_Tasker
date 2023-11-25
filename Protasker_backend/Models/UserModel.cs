
namespace Protasker_backend
{
    /// <summary>
    /// Classe de base des utilisateurs
    /// </summary>
    public class UserModel
    {
        [Key]
        public int Id { get;set; }
        
        public string? Nom { get;set; }
        public string? Prenom { get;set; }
        public string? Photo { get;set; }
        public List<TaskModel>? TaskModels { get;set; }
    }
}