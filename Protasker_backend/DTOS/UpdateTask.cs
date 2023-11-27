
namespace Protasker_backend
{
    public class UpdateTaskDto
    {
        public int Id { get;set; }
        public int UserID { get;set; }
        public string ?Libelle { get;set; }
        public TaskModel.TaskModelStatus Status { get;set; }
    }
}