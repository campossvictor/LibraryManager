using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Core;

public class Entity
{
    private int _id;

    [Required]
    public int Id
    {
        get
        {
            return _id;
        }
        set
        {
            if (value < 0)
                throw new ArgumentException("Id Inválido");
            _id = value;
        }
    }
    
}