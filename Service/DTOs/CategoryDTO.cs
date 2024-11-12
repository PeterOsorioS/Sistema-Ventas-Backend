using System.ComponentModel.DataAnnotations;

namespace Service.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool State {  get; set; }
    }
}
