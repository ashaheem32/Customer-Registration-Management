using System.ComponentModel.DataAnnotations;

namespace CustomerRegApp.Models
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        // --- Step 1: Account Details ---
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Gmail is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Gmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", 
            ErrorMessage = "Password must be at least 8 characters, contain 1 uppercase, 1 number, and 1 special character.")]
        public string PasswordHash { get; set; } = string.Empty;

        // --- Step 2: Personal Information ---
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly DateOfBirth { get; set; }
        public string Gender { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // --- Step 3: Financial Information ---
        public decimal NetWorth { get; set; }
        public decimal MonthlyIncome { get; set; }
        public string Occupation { get; set; } = string.Empty;
        public string MaritalStatus { get; set; } = string.Empty;

        // --- Step 4: Documents ---
        public List<UserDocument> Documents { get; set; } = new();
    }

    public class UserDocument
    {
        [Key]
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string ContentType { get; set; } = string.Empty;
        public byte[] Content { get; set; } = Array.Empty<byte>();

        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;
    }
}
