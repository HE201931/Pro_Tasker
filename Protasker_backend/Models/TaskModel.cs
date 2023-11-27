
namespace Protasker_backend
{
    public class TaskModel 
    {
        
        /// <summary>
        /// Classe de base des tâches
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum TaskModelStatus 
        {
            [Description("En cours")]
            EN_COURS = 0x0,
            [Description("Bloquée")]
            BLOQUEE =  0x1,
            [Description("Finie")]
            TERMINE = 0x2
        }

        [Key]
        public int Id { get;set; }
        public int UserID { get;set; }
        public UserModel? UserModel {get; set;}
        public string ?Libelle { get;set; }
        public TaskModelStatus Status { get;set; }
    }
}